using System;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class IAPManager : MonoBehaviour
{
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
    [SerializeField] private Text bt_removeads;
    [SerializeField] private Text bt_benefit;
    [SerializeField] private Text bt_sale;
    [SerializeField] private Text bt_vip;

    // UI Controller
    public UiController ui;

    // Store Controller để tra thông tin sản phẩm khi cần
    private IStoreController storeController;

    // Được gọi khi khởi tạo IAP thành công (bạn gán hàm này ở OnInitialized)
    public void SetStoreController(IStoreController controller)
    {
        storeController = controller;
    }

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
        else if (product.definition.id == removeads) UpdateButtonPrice(bt_removeads, product);
        else if (product.definition.id == benefit) UpdateButtonPrice(bt_benefit, product);
        else if (product.definition.id == sale) UpdateButtonPrice(bt_sale, product);
        else if (product.definition.id == vip) UpdateButtonPrice(bt_vip, product);
    }

    // Gọi khi mua hàng thành công
    public void OnOrderConfirmed(ConfirmedOrder order)
    {
        
    }

    // Gọi khi mua hàng thất bại
    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason) 
    {
        Debug.LogError($"Mua hàng thất bại: {product.definition.id}, Lý do: {reason}");
    }

    // ==============================
    //      HELPER FUNCTIONS
    // ==============================

    private void AddHints(int quantity, int amountPerPack)
    {
        for (int i = 0; i < quantity; i++)
        {
            ui.addScore(amountPerPack);
        }
    }

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
