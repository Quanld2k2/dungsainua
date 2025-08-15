using System;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;
using UnityEngine.Purchasing.Extension;

public class IAPManager : MonoBehaviour, IDetailedStoreListener
{
    private IStoreController controller;
    private IExtensionProvider extensions;

    void Start()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct("light_pack_50", ProductType.Consumable);
        builder.AddProduct("light_pack_5", ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        this.controller = controller;
        this.extensions = extensions;

        Debug.Log("IAP Initialized");
        foreach (var product in controller.products.all)
        {
            Debug.Log($"Fetched: {product.definition.id} - {product.metadata.localizedPrice}");
        }
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.LogError("IAP Initialize Failed: " + error);
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.LogError($"IAP Initialize Failed: {error} - {message}");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        Debug.Log("Purchase Completed: " + args.purchasedProduct.definition.id);
        return PurchaseProcessingResult.Complete;
    }
    // ==== Product IDs ====
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

    // ==== UI Price Buttons ====
    [SerializeField] private Text Bt5;
    [SerializeField] private Text Bt10;
    [SerializeField] private Text Bt25;
    [SerializeField] private Text Bt50;
    [SerializeField] private Text Bt100;
    [SerializeField] private Text Bt250;

    [Header("------------- IAP Buttons -------------")]
   // [SerializeField] private Text bt_removeads;
   // [SerializeField] private Text bt_benefit;
   // [SerializeField] private Text bt_sale;
   // [SerializeField] private Text bt_vip;

    // UI Controller
    public UiController ui;

    // ==============================
    //      NEW UNITY IAP EVENTS
    // ==============================

    // Gọi khi fetch sản phẩm thành công
    public void OnProductFetched(Product product)
    {
        Debug.Log($"Fetched: {product.definition.id} - {product.metadata.localizedPriceString}");

        if (product.definition.id == hint5) UpdateButtonPrice(Bt5, product);
        else if (product.definition.id == hint10) UpdateButtonPrice(Bt10, product);
        else if (product.definition.id == hint25) UpdateButtonPrice(Bt25, product);
        else if (product.definition.id == hint50) UpdateButtonPrice(Bt50, product);
        else if (product.definition.id == hint100) UpdateButtonPrice(Bt100, product);
        else if (product.definition.id == hint250) UpdateButtonPrice(Bt250, product);
       // else if (product.definition.id == removeads) UpdateButtonPrice(bt_removeads, product);
       // else if (product.definition.id == benefit) UpdateButtonPrice(bt_benefit, product);
       // else if (product.definition.id == sale) UpdateButtonPrice(bt_sale, product);
       // else if (product.definition.id == vip) UpdateButtonPrice(bt_vip, product);
    }

    // Gọi khi mua hàng thành công
    public void OnOrderConfirmed( ConfirmedOrder order)
    {
        Debug.LogWarning("OnOrderConfirmed");
        string productId = order.Info.PurchasedProductInfo[0].productId;
        int quantity = order.Info.PurchasedProductInfo.Count;

        Debug.Log(productId);
        if (productId == hint5)
        {
            for (int i = 0; i < quantity; i++)
            {
                ui.addScore(5);
              //  AppsFlyerInit.TrackAdRevenue(0.99f);
                Debug.Log("hint10");
            }
        }
        else if (productId == hint10)
        {
            for (int i = 0; i < quantity; i++)
            {
                ui.addScore(10);
                //  AppsFlyerInit.TrackAdRevenue(0.99f);
                Debug.Log("hint10");
            }
        }
        else if (productId == hint25)
        {
            for (int i = 0; i < quantity; i++)
            {
                ui.addScore(25);
                //  AppsFlyerInit.TrackAdRevenue(0.99f);
                Debug.Log("hint10");
            }
        }
        else if (productId == hint50)
        {
            for (int i = 0; i < quantity; i++)
            {
                ui.addScore(50);
                //  AppsFlyerInit.TrackAdRevenue(0.99f);
                Debug.Log("hint10");
            }
        }
        else if (productId == hint100)
        {
            for (int i = 0; i < quantity; i++)
            {
                ui.addScore(100);
                //  AppsFlyerInit.TrackAdRevenue(0.99f);
                Debug.Log("hint10");
            }
        }
        else if (productId == hint250)
        {
            for (int i = 0; i < quantity; i++)
            {
                ui.addScore(250);
                //  AppsFlyerInit.TrackAdRevenue(0.99f);
                Debug.Log("hint10");
            }
        }
        else
        {
            Debug.LogWarning($"Không xác định được sản phẩm: {productId}");
        }
    }
    // Gọi khi mua hàng thất bại
    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log($"Purchase failed: {product.definition.id}, Reason: {reason}");
    }
    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
    {
        Debug.LogError($"Purchase failed: {product.definition.id}, Reason: {failureDescription}");
    }

    // Gọi khi đơn hàng đang chờ xử lý
    public void OnOrderPending(PendingOrder oderp)
    {
        Debug.LogWarning($"Đơn hàng đang chờ xử lý: {oderp}");
    }
    public void OnOrderDeferrent(DeferredOrder oderp)
    {
        Debug.Log($"OnOrderDeferrent: {oderp}, Lý do: ");
    }
    //Gọi khi fetch sản phẩm thất bại
    public void OnProductFetchFailed(ProductDefinition fd, string ax)
    {
        Debug.Log($"OnProductFetchFailed: {fd}, Lý do: ");
    }
    public void OnPurchaseFetched(Order oder)
    {
        Debug.Log($"OnPurchaseFetched: {oder}, Lý do: ");
    }

    // ==============================
    //      HELPER FUNCTIONS
    // ==============================


    private void UpdateButtonPrice(Text button, Product product)
    {
        if (button != null && product != null)
        {
            button.text = product.metadata.localizedPriceString;
        }
    }

    private int GetPurchaseQuantity(ConfirmedOrder order, Product product)
    {
        // Nếu server gửi thông tin số lượng, bạn parse từ receipt
        // Ở đây mặc định trả về 1
        return 1;
    }
}
