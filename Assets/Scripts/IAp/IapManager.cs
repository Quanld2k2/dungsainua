using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

public class IapManager : MonoBehaviour, IStoreListener
{
    private static IStoreController storeController;
    private static IExtensionProvider storeExtensionProvider;

    // Product IDs (phải trùng với Google Play / App Store)
    public const string hint5 = "light_pack_5";
    public const string hint10 = "light_pack_10";
    public const string hint25 = "light_pack_25";
    public const string hint50 = "light_pack_50";
    public const string hint100 = "light_pack_100";
    public const string hint250 = "light_pack_250";
    public const string removeads = "remove_ads";
    public const string benefit = "benefit_ads";
    public const string sale = "sale_ads";
    public const string vip = "vip_pass";

    void Start()
    {
        if (storeController == null)
        {
            InitializePurchasing();
        }
    }

    public void InitializePurchasing()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        // Add consumables
        builder.AddProduct(hint5, ProductType.Consumable);
        builder.AddProduct(hint10, ProductType.Consumable);
        builder.AddProduct(hint25, ProductType.Consumable);
        builder.AddProduct(hint50, ProductType.Consumable);
        builder.AddProduct(hint100, ProductType.Consumable);
        builder.AddProduct(hint250, ProductType.Consumable);

        // Add non-consumables
        builder.AddProduct(removeads, ProductType.NonConsumable);
        builder.AddProduct(benefit, ProductType.NonConsumable);
        builder.AddProduct(sale, ProductType.NonConsumable);
        builder.AddProduct(vip, ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }

    // Mua sản phẩm
    public void BuyProduct(string productId)
    {
        if (storeController != null && storeController.products.WithID(productId) != null)
        {
            storeController.InitiatePurchase(productId);
        }
        else
        {
            Debug.LogError("BuyProduct FAIL. Not initialized or product not found: " + productId);
        }
    }

    // Gọi khi mua thành công
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        Debug.Log("Purchase Completed: " + args.purchasedProduct.definition.id);

        switch (args.purchasedProduct.definition.id)
        {
            case hint5:
                AddHints(5);
                break;
            case hint10:
                AddHints(10);
                break;
            case hint25:
                AddHints(25);
                break;
            case hint50:
                AddHints(50);
                break;
            case hint100:
                AddHints(100);
                break;
            case hint250:
                AddHints(250);
                break;
            case removeads:
                RemoveAds();
                break;
            case benefit:
                UnlockBenefit();
                break;
            case sale:
                UnlockSale();
                break;
            case vip:
                UnlockVIP();
                break;
        }

        return PurchaseProcessingResult.Complete;
    }

    // Gọi khi mua thất bại
    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.LogError($"Purchase failed: {product.definition.id}, Reason: {failureReason}");
    }

    // Callback khi IAP init xong
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        storeController = controller;
        storeExtensionProvider = extensions;
        Debug.Log("IAP Initialized successfully");
    }

    // Bản cũ (Unity giữ lại vì backward compatibility)
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.LogError($"IAP Initialize Failed (old callback): {error}");
    }

    // Bản mới (Unity IAP 5.x)
    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.LogError($"IAP Initialize Failed (new callback): {error} - {message}");
    }

    // Các hàm custom xử lý game
    private void AddHints(int amount)
    {
        Debug.Log("Add " + amount + " hints");
        // TODO: code tăng hint ở đây
    }

    private void RemoveAds()
    {
        Debug.Log("Remove Ads");
        // TODO: code tắt quảng cáo ở đây
    }

    private void UnlockBenefit()
    {
        Debug.Log("Unlock Benefit");
    }

    private void UnlockSale()
    {
        Debug.Log("Unlock Sale");
    }

    private void UnlockVIP()
    {
        Debug.Log("Unlock VIP");
    }
}
