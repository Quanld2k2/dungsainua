using System;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using UnityEngine.UI;

public class PurchareIAP : MonoBehaviour, IDetailedStoreListener
{
    private IStoreController controller;
    private IExtensionProvider extensions;

    // ==== Product IDs (trùng với Google Play Console) ====
    private string hint5 = "light_pack_5";
    private string hint10 = "light_pack_10";
    private string hint25 = "light_pack_25";
    private string hint50 = "light_pack_50";
    private string hint100 = "light_pack_100";
    private string hint250 = "light_pack_250";

    private string removeads = "remove_ads";
    private string benefit = "benefit_ads";
    private string sale = "sale_ads";
    private string vip = "vip_pass";

    // ==== UI Price Labels ====
    [SerializeField] private Text Bt5;
    [SerializeField] private Text Bt10;
    [SerializeField] private Text Bt25;
    [SerializeField] private Text Bt50;
    [SerializeField] private Text Bt100;
    [SerializeField] private Text Bt250;

    [Header("UI Controller")]
    public UiController ui;

    void Start()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        // Đăng ký sản phẩm
        builder.AddProduct(hint5, ProductType.Consumable);
        builder.AddProduct(hint10, ProductType.Consumable);
        builder.AddProduct(hint25, ProductType.Consumable);
        builder.AddProduct(hint50, ProductType.Consumable);
        builder.AddProduct(hint100, ProductType.Consumable);
        builder.AddProduct(hint250, ProductType.Consumable);

        builder.AddProduct(removeads, ProductType.NonConsumable);
        builder.AddProduct(benefit, ProductType.NonConsumable);
        builder.AddProduct(sale, ProductType.NonConsumable);
        builder.AddProduct(vip, ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }

    // ==========================================================
    //   Unity IAP 5.x Callbacks
    // ==========================================================

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        this.controller = controller;
        this.extensions = extensions;

        Debug.Log("✅ IAP Initialized");

        foreach (var product in controller.products.all)
        {
            if (product.availableToPurchase)
            {
                Debug.Log($"Fetched: {product.definition.id} - {product.metadata.localizedPriceString}");
                OnProductFetched(product); // cập nhật UI giá
            }
        }
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.LogError("❌ IAP Initialize Failed: " + error);
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.LogError($"❌ IAP Initialize Failed: {error} - {message}");
    }

    // Xử lý mua thành công
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        // Debug.Log("✅ Purchase Completed: " + args.purchasedProduct.definition.id);
        // HandlePurchase(args.purchasedProduct.definition.id, 1);
        //  return PurchaseProcessingResult.Complete;
        Debug.Log("ProcessPurchase được gọi, nhưng sẽ bỏ qua vì dùng OnOrderConfirmed");
        return PurchaseProcessingResult.Complete;
    }

    // Unity IAP 5.x: Gọi khi order xác nhận
    public void OnOrderConfirmed(ConfirmedOrder order)
    {
        int quantity = order.Info.PurchasedProductInfo.Count;

        Debug.Log("✅ OnOrderConfirmed");
        foreach (var info in order.Info.PurchasedProductInfo)
        {
            HandlePurchase(info.productId, quantity);
        }
    }

    // Unity IAP 5.x: Gọi khi order pending
    public void OnOrderPending(PendingOrder order)
    {
        Debug.LogWarning($"⚠️ Đơn hàng đang chờ xử lý: {order}");
    }

    // Unity IAP 5.x: Deferred
    public void OnOrderDeferred(DeferredOrder order)
    {
        Debug.Log($"⏳ OnOrderDeferred: {order}");
    }

    // Khi product fetch thành công
    public void OnProductFetched(Product product)
    {
        if (product == null) return;

        if (product.definition.id == hint5) UpdateButtonPrice(Bt5, product);
        else if (product.definition.id == hint10) UpdateButtonPrice(Bt10, product);
        else if (product.definition.id == hint25) UpdateButtonPrice(Bt25, product);
        else if (product.definition.id == hint50) UpdateButtonPrice(Bt50, product);
        else if (product.definition.id == hint100) UpdateButtonPrice(Bt100, product);
        else if (product.definition.id == hint250) UpdateButtonPrice(Bt250, product);
    }

    public void OnProductFetchFailed(ProductDefinition product, string reason)
    {
        Debug.LogError($"❌ OnProductFetchFailed: {product.id}, lý do: {reason}");
    }

    public void OnPurchaseFetched(Order order)
    {
        Debug.Log("📦 OnPurchaseFetched: " + order);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.LogError($"❌ Purchase failed: {product.definition.id}, Reason: {reason}");
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
    {
        Debug.LogError($"❌ Purchase failed: {product.definition.id}, Reason: {failureDescription}");
    }

    // ==========================================================
    //   Helpers
    // ==========================================================

    private void UpdateButtonPrice(Text button, Product product)
    {
        if (button != null && product != null)
            button.text = product.metadata.localizedPriceString;
    }

    private void HandlePurchase(string productId, int quantity)
    {
        int addScore = 0;

        if (productId == hint5) addScore = 5;
        else if (productId == hint10) addScore = 10;
        else if (productId == hint25) addScore = 25;
        else if (productId == hint50) addScore = 50;
        else if (productId == hint100) addScore = 100;
        else if (productId == hint250) addScore = 250;

        if (addScore > 0)
        {
            for (int i = 0; i < quantity; i++)
            {
                ui.addScore(addScore);
            }
            Debug.Log($"🎉 Add {addScore * quantity} score từ {productId}");
        }
        else if (productId == removeads)
        {
            Debug.Log("🚫 Remove Ads purchased");
        }
        else if (productId == vip)
        {
            Debug.Log("⭐ VIP Pass purchased");
        }
    }

    // Gọi từ UI button
    public void BuyProduct(string productId)
    {
        if (controller == null) { Debug.LogError("❌ IAP chưa sẵn sàng"); return; }

        var product = controller.products.WithID(productId);
        if (product != null && product.availableToPurchase)
        {
            controller.InitiatePurchase(product);
        }
        else
        {
            Debug.LogError("❌ Product không khả dụng: " + productId);
        }
    }

    public void BuyLightPack5()
    {
        Debug.Log("Mua light_pack_5 được gọi!");
        // chỗ này gọi sang IAPManager thực hiện mua:
        BuyProduct("light_pack_5");   // Gọi trực tiếp BuyProduct trong class này
    }
}
