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
using DG.Tweening;


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
    private IStoreController storeController2;

    public ConsumableItem hint5;
    public ConsumableItem hint10;
    public ConsumableItem hint25;

    public ConsumableItem hint50;
    public ConsumableItem hint100;
    public ConsumableItem hint250;

    public NonConsumableItem removeAds;

    public NonConsumableItem benefitAds;
    public NonConsumableItem saleAds;

    public SubscriptionItem vipPass;


    // public SubscriptionItem sItem;
    // public GameObject AdsPurchasedWindow;
    // public Shop shop;

    // public Data data;
    // public Payload payload;
    // public PayloadData payloadData;

    public Text hint5txt;
    public Text hint10txt;
    public Text hint25txt;

    public Text hint50txt;
    public Text hint100txt;
    public Text hint250txt;

    public Text removeAdstxt;

    public Text benefitAdstxt; 
    public Text saleAdstxt;

    public Text vipPasstxt;

    public Image hint5btn;
    public Image hint10btn;
    public Image hint25btn;

    public Image hint50btn;
    public Image hint100btn;
    public Image hint250btn;

    public Image removeAdsbtn;

    public Image benefitAdsbtn;
    public Image saleAdsbtn;

    public Image vipPassbtn;



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
    /// <summary>
    /// Hàm check user có sub chưa
    /// </summary>


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
        Debug.Log("ConnumableBtn"+ this.name);

        // audioManager.PlaySFX("click");
        if (storeController == null)
        {
            Debug.LogError("⚠️ StoreController chưa init xong, không thể mua: " + val);
            return;
        }

        if (val == hint5.Id)
        {
            AudioManager.ins.playClickshot();
            hint5btn.transform.DOScale(1.1f, 0.1f).OnComplete(() =>
            {
                hint5btn.transform.DOScale(1f, 0.1f).OnComplete(() =>
                {
                    storeController.PurchaseProduct(hint5.Id);
                });
            });
        }
        else if (val == hint10.Id)
        {
            AudioManager.ins.playClickshot();
            hint10btn.transform.DOScale(1.1f, 0.1f).OnComplete(() =>
            {
                hint10btn.transform.DOScale(1f, 0.1f).OnComplete(() =>
                {
                    storeController.PurchaseProduct(hint10.Id);
                });
            });
        }

        else if (val == hint25.Id)
        {
            AudioManager.ins.playClickshot();
            hint25btn.transform.DOScale(1.1f, 0.1f).OnComplete(() =>
            {
                hint25btn.transform.DOScale(1f, 0.1f).OnComplete(() =>
                {
                    storeController.PurchaseProduct(hint25.Id);
                });
            });
        }
        
        else if (val == hint50.Id)
        {
            AudioManager.ins.playClickshot();
            hint50btn.transform.DOScale(1.1f, 0.1f).OnComplete(() =>
            {
                hint50btn.transform.DOScale(1f, 0.1f).OnComplete(() =>
                {
                    storeController.PurchaseProduct(hint50.Id);
                });
            });
        }
       
        else if (val == hint100.Id)
        {
            AudioManager.ins.playClickshot();
            hint100btn.transform.DOScale(1.1f, 0.1f).OnComplete(() =>
            {
                hint100btn.transform.DOScale(1f, 0.1f).OnComplete(() =>
                {
                    storeController.PurchaseProduct(hint100.Id);
                });
            });
        }
        
        else if (val == hint250.Id)
        {
            AudioManager.ins.playClickshot();
            hint250btn.transform.DOScale(1.1f, 0.1f).OnComplete(() =>
            {
                hint250btn.transform.DOScale(1f, 0.1f).OnComplete(() =>
                {
                    storeController.PurchaseProduct(hint250.Id);
                });
            });
        }
        

       // else if (val == vipPass.Id) storeController.PurchaseProduct(vipPass.Id);

    }
    public void SubscriptBtn()
    {
        AudioManager.ins.playClickshot();
        vipPassbtn.transform.DOScale(1.1f, 0.1f).OnComplete(() =>
        {
            vipPassbtn.transform.DOScale(1f, 0.1f).OnComplete(() =>
            {
                Debug.Log("SubscriptBtn");
                storeController.PurchaseProduct(vipPass.Id);
            });
        });
    }
    public void NonConnumableBtn(string val)
    {
        Debug.Log("NonConnumableBtn");

        if (val == removeAds.Id)
        {
            AudioManager.ins.playClickshot();
            removeAdsbtn.transform.DOScale(1.1f, 0.1f).OnComplete(() =>
            {
                removeAdsbtn.transform.DOScale(1f, 0.1f).OnComplete(() =>
                {
                    storeController.PurchaseProduct(removeAds.Id);
                });
            });
        }

           
        else if (val == benefitAds.Id)
        {
            AudioManager.ins.playClickshot();
            benefitAdsbtn.transform.DOScale(1.1f, 0.1f).OnComplete(() =>
            {
                benefitAdsbtn.transform.DOScale(1f, 0.1f).OnComplete(() =>
                {
                    storeController.PurchaseProduct(benefitAds.Id);
                });
            });
        }
           
        else if (val == saleAds.Id)
        {
            AudioManager.ins.playClickshot();
            saleAdsbtn.transform.DOScale(1.1f, 0.1f).OnComplete(() =>
            {
                saleAdsbtn.transform.DOScale(1f, 0.1f).OnComplete(() =>
                {
                    storeController.PurchaseProduct(saleAds.Id);
                });
            });
        }
            

    }

    public void RemoveAds()
    {
        Debug.Log("remove ads");
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
        Debug.Log("InitializeIAP......." + storeController);

        storeController.OnPurchaseConfirmed += OnPurchaseConfirmed;
        storeController.OnPurchasePending += OnPurchasePending;
        storeController.OnStoreDisconnected += OnStoreDisconnected;
        storeController.OnPurchaseFailed += OnPurchaseFailed;
        storeController.OnPurchaseDeferred += OnPurchaseDeferred;

        await storeController.Connect();

        storeController.OnProductsFetched += OnProductsFetched;
        storeController.OnProductsFetchFailed += OnProductsFetchFailed;
        storeController.OnPurchasesFetched += OnPurchasesFetched;
        storeController.OnPurchasesFetchFailed += OnPurchasesFetchFailed;

       
        var initialProductsToFetch = new List<ProductDefinition>
            {
                new(removeAds.Id, ProductType.NonConsumable),
                new(benefitAds.Id, ProductType.NonConsumable),
                new(saleAds.Id, ProductType.NonConsumable),

                new(hint5.Id, ProductType.Consumable),
                new(hint10.Id, ProductType.Consumable),
                new(hint25.Id, ProductType.Consumable),

                new(hint50.Id, ProductType.Consumable),
                new(hint100.Id, ProductType.Consumable),
                new(hint250.Id, ProductType.Consumable),

                new(vipPass.Id, ProductType.Subscription),


            };

        storeController.FetchProducts(initialProductsToFetch);


    }

    void OnPurchasePending(PendingOrder pendingOrder)
    {
        Debug.Log("OnPurchasePending_____________________");
        Debug.Log("OnPurchasePendin"+ pendingOrder.Info.PurchasedProductInfo.Count);

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
        float timeout = 1f; // tối đa 5 giây chờ
        float elapsed = 0f;

        while (pendingOrder.Info.PurchasedProductInfo.Count == 0 && elapsed < timeout)
        {
            yield return null;
            elapsed += Time.deltaTime;
        }

        storeController.ConfirmPurchase(pendingOrder);
    }
    public UiController ui;
    public GooglePurchaseData gg2;
    
    void OnPurchaseConfirmed(Order order)
    {
        Debug.Log("OnPurchaseConfirmed_____________________");
        int quantity = order.Info.PurchasedProductInfo.Count;
        int quantity2 = gg2.quantity;
        foreach (var purchasedProduct in order.Info.PurchasedProductInfo)
        {

            string productId = purchasedProduct.productId;

            // string productId = order.Info.PurchasedProductInfo[0].productId;
            Debug.Log(productId);
            Debug.Log(quantity);
            Debug.Log(quantity2);

            if (productId == removeAds.Id)
            {
                //  saveDataJson.SaveData("RemoveAds", true);
                ui.IAP_BTRemoveAds();
            }
            else if (productId == benefitAds.Id)
            {
                ui.IAP_BTBenefit();                             
            }
            else if (productId == saleAds.Id)
            {
                ui.IAP_BTSale();                
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
            else if (productId == hint50.Id)
            {
                for (int i = 0; i < quantity; i++)
                {
                    ui.addScore(50);
                }
            }
            else if (productId == hint100.Id)
            {
                for (int i = 0; i < quantity; i++)
                {
                    ui.addScore(100);
                }
            }
            else if (productId == hint250.Id)
            {
                for (int i = 0; i < quantity; i++)
                {
                    ui.addScore(250);
                }
            }
            else if (productId == vipPass.Id)
            {  
                 ui.IAP_BTVip();
            }
            else
            {
               
            }

            Product product = storeController.GetProductById(productId);

            if (product != null)
            {
                Debug.Log($"Purchased {productId} - Type: {product.definition.type}");

                if (product.definition.type == ProductType.Consumable)
                {
                    Debug.Log("👉 Đây là Consumable");
                }
                else if (product.definition.type == ProductType.NonConsumable)
                {
                    Debug.Log("👉 Đây là Non-Consumable");
                }
                else if (product.definition.type == ProductType.Subscription)
                {
                    Debug.Log("👉 Đây là Subscription");
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
        Debug.Log("FailedOrder: " + failedOrder);
    }
    void OnPurchaseDeferred(DeferredOrder deferredOrder)
    {
        Debug.Log("DeferredOrder: " + deferredOrder);
    }


    void OnProductsFetched(List<Product> products)
    {
        Debug.Log("OnProductsFetched=================================");

        foreach (var product in products)
        {
           /// Debug.Log($"ID: {product.definition.id}");
          //  Debug.Log($"Localized Price: {product.metadata.localizedPriceString}");
          //  Debug.Log($"Currency: {product.metadata.isoCurrencyCode}");
          //  Debug.Log($"Raw Price: {product.metadata.localizedPrice}");

            string priceText = product.metadata.localizedPriceString;

            if (product.definition.id == hint5.Id)
            {
                UpdateButtonPrice(hint5txt, product);
            }
            else if (product.definition.id == hint10.Id)
            {
                UpdateButtonPrice(hint10txt, product);
            }
            else if (product.definition.id == hint25.Id)
            {
                UpdateButtonPrice(hint25txt, product);
            }
            else if (product.definition.id == hint50.Id)
            {
                UpdateButtonPrice(hint50txt, product);
            }
            else if (product.definition.id == hint100.Id)
            {
                UpdateButtonPrice(hint100txt, product);
            }
            else if (product.definition.id == hint250.Id)
            {
                UpdateButtonPrice(hint250txt, product);
            }
            else if (product.definition.id == removeAds.Id)
            {
                UpdateButtonPrice(removeAdstxt, product);
            }
            else if (product.definition.id == benefitAds.Id)
            {
                UpdateButtonPrice(benefitAdstxt, product);
            }
            else if (product.definition.id == saleAds.Id)
            {
                UpdateButtonPrice(saleAdstxt, product);
            }
            else if (product.definition.id == vipPass.Id)
            {
                UpdateButtonPrice(vipPasstxt, product);
            }
            // ... add thêm else if cho các gói khác
        }


        storeController.FetchPurchases();
    }
    private void UpdateButtonPrice(Text button, Product product)
    {
        //Debug.Log(product.metadata.isoCurrencyCode);
        button.text = product.metadata.localizedPrice + "" + product.metadata.isoCurrencyCode;
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

        bool isRemoveAds2 = false;
        foreach (var order in orders.ConfirmedOrders)
        {
            foreach (var product in order.Info.PurchasedProductInfo)
            {
                if (product.productId == vipPass.Id)
                {
                    isRemoveAds2 = true;
                }
            }
            if (isRemoveAds2) break;
        }
        // if(isSubscription) ActivateElitePass();
        // else DeActivateElitePass();

        Debug.Log("Người dùng có remove: " + isRemoveAds);

        int hiNum = PlayerPrefs.GetInt("Iap_Removeads");
        if (isRemoveAds == true || hiNum != 0)
        {
            ui.IAP_BTRemoveAds();

        }
        Debug.Log("Người dùng có sub: " + isRemoveAds2);

        if (isRemoveAds2 == true)
        {
            
            ui.IAP_BTVip();
        }
        else
        {
            ui.IAP_ResetVip2();
        }


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