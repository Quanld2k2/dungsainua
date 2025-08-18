using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
// using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using UnityEngine.UI;

// [System.Serializable]
// public class ExchangeRateResponse
// {
//     public Rates rates;
// }

// [System.Serializable]
// public class Rates
// {
//     public float AED, AFN, ALL, AMD, ANG, AOA, ARS, AUD, AWG, AZN, BAM, BBD, BDT, BGN, BHD, BIF, 
//         BMD, BND, BOB, BRL, BSD, BTN, BWP, BYN, BZD, CAD, CDF, CHF, CLP, CNY, COP, CRC, CUP, CVE, 
//         CZK, DJF, DKK, DOP, DZD, EGP, ERN, ETB, EUR, FJD, FKP, FOK, GBP, GEL, GGP, GHS, GIP, GMD, 
//         GNF, GTQ, GYD, HKD, HNL, HRK, HTG, HUF, IDR, ILS, IMP, INR, IQD, IRR, ISK, JEP, JMD, JOD, 
//         JPY, KES, KGS, KHR, KID, KMF, KRW, KWD, KYD, KZT, LAK, LBP, LKR, LRD, LSL, LYD, MAD, MDL, 
//         MGA, MKD, MMK, MNT, MOP, MRU, MUR, MVR, MWK, MXN, MYR, MZN, NAD, NGN, NIO, NOK, NPR, NZD, 
//         OMR, PAB, PEN, PGK, PHP, PKR, PLN, PYG, QAR, RON, RSD, RUB, RWF, SAR, SBD, SCR, SDG, SEK, 
//         SGD, SHP, SLL, SOS, SRD, SSP, STN, SYP, SZL, THB, TJS, TMT, TND, TOP, TRY, TTD, TVD, TWD, 
//         TZS, UAH, UGX, USD, UYU, UZS, VES, VND, VUV, WST, XAF, XCD, XOF, XPF, YER, ZAR, ZMW, ZWL;

// }


[Serializable]
public class ConsumableItem
{
    // public string Name;
    public string Id;
    // public string description;
    // public float price;
}

[Serializable]
public class NonConsumableItem
{
    // public string Name;
    public string Id;
    // public string description;
    // public float price;
}

[Serializable]
public class SubscriptionItem
{
    // public string Name;
    public string Id;
    // public string description;
    // public float price;
    // public int timeDuration; // in Day
}


public class iap : MonoBehaviour
{
   // public AudioManager audioManager;

   // public SaveDataJson saveDataJson;

    StoreController storeController;
    public ConsumableItem starterBundle;

    public ConsumableItem hint5;
    public ConsumableItem hint10;
    public ConsumableItem hint25;


    public ConsumableItem islandBundle;
    public ConsumableItem cityBundle;
    public ConsumableItem saleClassic;
    public ConsumableItem mushroomBundle;
    public NonConsumableItem removeAds;
    // public SubscriptionItem sItem;
    // public GameObject AdsPurchasedWindow;
    // public Shop shop;

    // public Data data;
    // public Payload payload;
    // public PayloadData payloadData;

    public Text starterBundleTxt;
    public Text islandBundleTxt;
    public Text cityBundleTxt;
    public Text saleClassicTxt;
    public Text mushroomBundleTxt;

    // private bool allowToShowShopBanner = true;

  //  public GameObject BtrRemoveAdsInShop;
  //  public GameObject BtrRemoveAdsInSetting;
  //  public Shop shop;
   // public AdsManager adsManager;

  //  public GameObject RemoveAdsBtn;
  //  public GameObject SaleBtn;
  //  public GameObject SaleDialog;
    // public RemoveAds removeAds;
    // private string exchangeRateApiUrl = "https://api.exchangerate-api.com/v4/latest/USD";

    void Start()
    {
     
        InitializeIAP();
    }

    private void OnDestroy()
    {
        storeController.OnPurchasePending -= OnPurchasePending;
        storeController.OnStoreDisconnected -= OnStoreDisconnected;
        storeController.OnProductsFetched -= OnProductsFetched;
        storeController.OnProductsFetchFailed -= OnProductsFetchFailed;
        storeController.OnPurchasesFetched -= OnPurchasesFetched;
        storeController.OnPurchasesFetchFailed -= OnPurchasesFetchFailed;
        storeController.OnPurchaseConfirmed -= OnPurchaseConfirmed;
        storeController.OnPurchaseDeferred -= OnPurchaseDeferred;
        storeController.OnPurchaseFailed -= OnPurchaseFailed;
    }

    public void ConnumableBtn(string val)
    {
        // audioManager.PlaySFX("click");
        if (storeController == null)
        {
            Debug.LogError("⚠️ StoreController chưa init xong, không thể mua: " + val);
            return;
        }
        if (val == starterBundle.Id) storeController.PurchaseProduct(starterBundle.Id);

        else if (val == hint5.Id) storeController.PurchaseProduct(hint5.Id);
        else if (val == hint25.Id) storeController.PurchaseProduct(hint25.Id);
        else if (val == hint10.Id) storeController.PurchaseProduct(hint10.Id);

        else if (val == islandBundle.Id) storeController.PurchaseProduct(islandBundle.Id);
        else if (val == cityBundle.Id) storeController.PurchaseProduct(cityBundle.Id);
        else if (val == saleClassic.Id) storeController.PurchaseProduct(saleClassic.Id);
        else if (val == mushroomBundle.Id) storeController.PurchaseProduct(mushroomBundle.Id);
    }

    public void NonConnumableBtn()
    {
        storeController.PurchaseProduct(removeAds.Id);
    }

    public void RemoveAds()
    {
        DisplayAds(false);
    }

    void ShowAds()
    {
        DisplayAds(true);
    }

    void DisplayAds(bool x)
    {
        if (!x)
        {
            // StartCoroutine(CloseShopBanner(0));

            // AdLoadedNewArea.transform.parent.gameObject.SetActive(false);
            // AdLoadedSetting.transform.parent.gameObject.SetActive(false);
            // AdLoadedSmallShop.transform.parent.gameObject.SetActive(false);
           // adsManager.DestroyBannerAd();
           // if ((bool)saveDataJson.GetData("RemoveAds"))
           // {
             //   RemoveAdsBtn.SetActive(false);
             //   SaleBtn.SetActive(false);
              //  SaleDialog.SetActive(false);
                // BtrRemoveAdsInSetting.GetComponent<Image>().color = new Color(0.372f, 0.372f, 0.372f);
                // BtrRemoveAdsInSetting.transform.GetChild(0).GetComponent<Text>().color = new Color(0.568f, 0.568f, 0.568f);
                // BtrRemoveAdsInShop.GetComponent<Image>().color = new Color(0.372f, 0.372f, 0.372f);
                // BtrRemoveAdsInShop.transform.GetChild(0).GetComponent<Text>().color = new Color(0.568f, 0.568f, 0.568f);
                // BtrRemoveAdsInSetting.GetComponent<Button>().interactable = false;
                // BtrRemoveAdsInShop.GetComponent<Button>().interactable = false;
           // }

            // if(removeAds.gameObject.activeSelf) removeAds.Exit();
        }
        else
        {
          //  saveDataJson.SaveData("RemoveAds", false);
        }
    }


    async void InitializeIAP()
    {
        Debug.Log("InitializeIAP.......");
        storeController = UnityIAPServices.StoreController();
        storeController.OnPurchaseConfirmed += OnPurchaseConfirmed;
        storeController.OnPurchasePending += OnPurchasePending;
        storeController.OnStoreDisconnected += OnStoreDisconnected;
        storeController.OnPurchaseFailed += OnPurchaseFailed;
        storeController.OnPurchaseDeferred += OnPurchaseDeferred;
        

        storeController.OnProductsFetched += OnProductsFetched;
        storeController.OnProductsFetchFailed += OnProductsFetchFailed;
        storeController.OnPurchasesFetched += OnPurchasesFetched;
        storeController.OnPurchasesFetchFailed += OnPurchasesFetchFailed;
        await storeController.Connect();
        var initialProductsToFetch = new List<ProductDefinition>
        {
            new(starterBundle.Id, ProductType.Consumable),

            new(hint10.Id, ProductType.Consumable),
            new(hint25.Id, ProductType.Consumable),
            new(hint5.Id, ProductType.Consumable),



            new(islandBundle.Id, ProductType.Consumable),
            new(cityBundle.Id, ProductType.Consumable),
            new(saleClassic.Id, ProductType.Consumable),
            new(mushroomBundle.Id, ProductType.Consumable),
            new(removeAds.Id, ProductType.NonConsumable),
        };

        storeController.FetchProducts(initialProductsToFetch);
        Debug.Log("InitializeIAP---------"+storeController);
    }

    void OnPurchasePending(PendingOrder pendingOrder)
    {
        Debug.Log("OnPurchasePending_____________________");
        if (pendingOrder.Info.PurchasedProductInfo.Count > 0)
        {
            storeController.ConfirmPurchase(pendingOrder);
        }
        else
        {
            StartCoroutine(ConfirmWhenReady(pendingOrder));
        }
    }

    IEnumerator ConfirmWhenReady(PendingOrder pendingOrder)
    {
        float timeout = 5f; // tối đa 5 giây chờ
        float elapsed = 0f;

        while (pendingOrder.Info.PurchasedProductInfo.Count == 0 && elapsed < timeout)
        {
            yield return null;
            elapsed += Time.deltaTime;
        }

        storeController.ConfirmPurchase(pendingOrder);
    }
    public UiController ui;

    void OnPurchaseConfirmed(Order order)
    {
        Debug.Log("OnPurchaseConfirmed_____________________");
        int quantity = order.Info.PurchasedProductInfo.Count;

        foreach (var purchasedProduct in order.Info.PurchasedProductInfo)
        {

            string productId = purchasedProduct.productId;
            // string productId = order.Info.PurchasedProductInfo[0].productId;
            Debug.Log(productId);
            Debug.Log(removeAds.Id);

            if (productId == removeAds.Id)
            {
              //  saveDataJson.SaveData("RemoveAds", true);
                RemoveAds();
            }
            else if (productId == hint5.Id)
            {
                for (int i = 0; i < quantity; i++)
                {
                    ui.addScore(5);
                }
            }
            else if (productId == hint10.Id)
            {
                for (int i = 0; i < quantity; i++)
                {
                    ui.addScore(10);
                }
            }
            else if (productId == hint25.Id)
            {
                for (int i = 0; i < quantity; i++)
                {
                    ui.addScore(25);
                }
            }
            else
            {
                try
                {
                    var unifiedReceipt = JsonUtility.FromJson<UnifiedReceipt>(order.Info.Receipt);

                    // Parse lớp thứ 2 (Payload)
                    var googleWrapper = JsonUtility.FromJson<GooglePayloadWrapper>(unifiedReceipt.Payload);

                    // Parse lớp thứ 3 (json)
                    var purchaseData = JsonUtility.FromJson<GooglePurchaseData>(googleWrapper.json);

                    Debug.Log($"Product: {purchaseData.productId}, Quantity: {purchaseData.quantity}");

                   // shop.AddPackage(productId, purchaseData.quantity);
                    if (productId == "sale_classic")
                    {
                      //  saveDataJson.SaveData("RemoveAds", true);
                        RemoveAds();
                    }
                }
                catch
                {
                   // shop.AddPackage(productId, 1);
                    if (productId == "sale_classic")
                    {
                      // saveDataJson.SaveData("RemoveAds", true);
                        RemoveAds();
                    }
                }
            }
        }
    }

    [Serializable]
    public class UnifiedReceipt
    {
        public string Store;
        public string TransactionID;
        public string Payload;
    }

    [Serializable]
    public class GooglePayloadWrapper
    {
        public string json;
        public string signature;
    }

    [Serializable]
    public class GooglePurchaseData
    {
        public string orderId;
        public string packageName;
        public string productId;
        public long purchaseTime;
        public int purchaseState;
        public int quantity; // Đây là cái bạn cần
    }

    void OnPurchaseFailed(FailedOrder failedOrder)
    {
        Debug.LogError("FailedOrder: " + failedOrder);
    }
    void OnPurchaseDeferred(DeferredOrder deferredOrder)
    {
        Debug.Log("DeferredOrder: " + deferredOrder);
    }


    void OnProductsFetched(List<Product> products)
    {
        storeController.FetchPurchases();
    }

    void OnProductsFetchFailed(ProductFetchFailed fail)
    {
        Debug.LogError($"Products fetch failed: {fail.FailureReason} - {fail.FailedFetchProducts}");
    }

    void OnPurchasesFetched(Orders orders)
    {
        Debug.Log("OnPurchasesFetched: " + orders);
        // Debug.Log(storeController.GetProductById(sItem.Id));

        bool isRemoveAds = false;

        foreach (var order in orders.ConfirmedOrders)
        {
            foreach (var product in order.Info.PurchasedProductInfo)
            {
                if (product.productId == removeAds.Id)
                {
                    isRemoveAds = true;
                }
            }
            if (isRemoveAds) break;
        }

        // if(isSubscription) ActivateElitePass();
        // else DeActivateElitePass();

        //if (isRemoveAds || (bool)saveDataJson.GetData("RemoveAds"))
       // {
       //     RemoveAds();
      //  }
       // else
       // {
       //     ShowAds();
       // }
    }

    void OnPurchasesFetchFailed(PurchasesFetchFailureDescription PurchasesFetchFailureDescription)
    {
        // DeActivateElitePass();
        Debug.LogError("OnPurchasesFetchFailed: " + PurchasesFetchFailureDescription);
    }

    void OnStoreDisconnected(StoreConnectionFailureDescription storeConnectionFailureDescription)
    {
        Debug.LogError("OnStoreDisconnected: " + storeConnectionFailureDescription);
    }
}