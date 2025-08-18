using System;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour, IStoreListener
{
    public static IAPManager Instance { get; private set; }

    // ==== PRODUCT ID (thay bằng id bạn tạo trên Google Play) ====
    public const string PRODUCT_COINS_100 = "light_pack_5";   // Consumable
    public const string PRODUCT_REMOVE_ADS = "com.yourgame.remove_ads";  // Non-consumable
    public const string PRODUCT_SUB_MONTHLY = "com.yourgame.sub_monthly"; // Subscription

    private static IStoreController storeController;
    private static IExtensionProvider extensionProvider;

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        InitializeIAP();
    }

    // ===== INIT IAP =====
    private void InitializeIAP()
    {
        if (IsInitialized()) return;

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance(AppStore.GooglePlay));

        builder.AddProduct(PRODUCT_COINS_100, ProductType.Consumable);
        builder.AddProduct(PRODUCT_REMOVE_ADS, ProductType.NonConsumable);
        builder.AddProduct(PRODUCT_SUB_MONTHLY, ProductType.Subscription);

        UnityPurchasing.Initialize(this, builder);
    }

    private bool IsInitialized() => storeController != null && extensionProvider != null;

    // ===== PUBLIC MUA HÀNG =====
    public void BuyCoins100() => BuyProduct(PRODUCT_COINS_100);
    public void BuyRemoveAds() => BuyProduct(PRODUCT_REMOVE_ADS);
    public void BuySubMonthly() => BuyProduct(PRODUCT_SUB_MONTHLY);

    private void BuyProduct(string productId)
    {
        if (!IsInitialized()) { Debug.LogError("IAP not initialized"); return; }

        Product product = storeController.products.WithID(productId);
        if (product != null && product.availableToPurchase)
        {
            Debug.Log("Buying product: " + productId);
            storeController.InitiatePurchase(product);
        }
        else
        {
            Debug.LogError("Product not available: " + productId);
        }
    }

    // ===== IStoreListener =====
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        storeController = controller;
        extensionProvider = extensions;
        Debug.Log("IAP initialized (Android).");
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.LogError("IAP init failed: " + error);
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.LogError($"IAP init failed: {error} - {message}");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        string id = args.purchasedProduct.definition.id;
        Debug.Log("Purchase success: " + id);

        switch (id)
        {
            case PRODUCT_COINS_100:
                // +100 coins
                PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 100);
                PlayerPrefs.Save();
                break;

            case PRODUCT_REMOVE_ADS:
                PlayerPrefs.SetInt("remove_ads", 1);
                PlayerPrefs.Save();
                break;

            case PRODUCT_SUB_MONTHLY:
                PlayerPrefs.SetInt("sub_monthly_active", 1);
                PlayerPrefs.Save();
                break;
        }

        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.LogError($"Purchase failed: {product?.definition?.id} - {failureReason}");
    }
}
