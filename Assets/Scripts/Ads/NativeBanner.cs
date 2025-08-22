using DG.Tweening;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Ump;
using GoogleMobileAds.Ump.Api;

public class NativeBanner : MonoBehaviour
{
    NativeAd nativeAd;
    [Header("------------- nativeAd-------4-----")]
    public RawImage icon2;
    public Text AdHeadline4;
    public Text AdDescription4;
    public Text AdCallToAction4;
    public GameObject Pop;

    public void Start()
    {
        Debug.Log("StartN1SpawnOnePrefab");
        GameManager.ins.N1ADS = false;
        GameManager.ins.navi1 = false;
       RequestNativeAd3();
    }

    IEnumerator YourFunction3()
    {
        yield return new WaitForSeconds(2f);
        RequestNativeAd3();

    }

    public void RequestNativeAd3()
    {
        Debug.Log("Navi_new3_Native ad loaded.");

        // AdLoaded3.SetActive(false);
        //  Pop.SetActive(false);

        string nativeId = "ca-app-pub-5342144217301971/6710847536";
        AdLoader adLoader = new AdLoader.Builder(nativeId)
            .ForNativeAd()
            .Build();

        adLoader.OnNativeAdLoaded += HandleNativeAdLoaded3;
        adLoader.OnAdFailedToLoad += HandleAdFailedToLoad3;

        var adRequest = new AdRequest();
        adLoader.LoadAd(adRequest);
    }

    private void HandleAdFailedToLoad3(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("Native ad failed to load: " + args.LoadAdError.GetMessage());
        StartCoroutine(YourFunction3());
    }

    private void HandleNativeAdLoaded3(object sender, NativeAdEventArgs args)
    {
        nativeAd = args.nativeAd;
        GameManager.ins.navi1 = true;
        Debug.Log("Native ad loaded........111111111111111");
        if (nativeAd.GetIconTexture() != null)
        {
            Debug.Log("Icon texture loaded.");


                if (icon2 != null)
                    icon2.texture = nativeAd.GetIconTexture();
            

        }
        else
        {
            GameManager.ins.navi1 = false;
            Debug.LogWarning("No icon texture available.");
        }

        if (nativeAd.GetHeadlineText() != null)
        {
            Debug.Log("Icon GetHeadlineText loaded.");
            AdHeadline4.text = nativeAd.GetHeadlineText();

        }
        else
        {
           /// GameManager.ins.navi8 = false;
            Debug.LogWarning("No icon texture available.");
        }
        if (nativeAd.GetBodyText() != null)
        {
            AdDescription4.text = nativeAd.GetBodyText();
            Debug.Log("GetBodyText.");

        }
        else
        {
            AdDescription4.text = ""; // <-- mặc định của bạn
            Debug.LogWarning("BodyText null hoặc không hợp lệ, dùng fallback text.");
          ///  GameManager.ins.navi8 = false;
        }

        AdCallToAction4.text = nativeAd.GetCallToActionText();


        RegisterNativeGameObjects3();
        //  AdLoaded4.SetActive(true);
        Pop.SetActive(true);
      //  UiController.ins.N3HidePrefab();

        GameManager.ins.N1ADS = true;
      //  Debug.Log("N3ADS@" + GameManager.ins.N3ADS);

        //  UiController.ins.ShowPrefab2();
        int adsRemoved = PlayerPrefs.GetInt("W2_removeads");
      ///  GameManager.ins.checkNativeManager = adsRemoved != 1;
        nativeAd.OnPaidEvent += HandleOnPaidEvent;
        //FirebaseAnalytics.LogEvent("Native_Start");

    }
    void HandleOnPaidEvent(object sender, AdValueEventArgs args)
    {
        Debug.Log("HandleOnPaidEvent triggered!");

        // Lấy giá trị doanh thu micros
        long micros = args.AdValue.Value; // ví dụ: 10_000 = $0.01
        double revenue = micros / 1_000_000.0; // convert sang USD

        string currencyCode = args.AdValue.CurrencyCode; // thường là "USD"
                                                         // GoogleMobileAds.Api.PrecisionType precision = args.AdValue.Precision;
        Debug.Log($"[AdMob Native] Revenue: {revenue} {currencyCode}");

        // In ra log để kiểm tra
        //  Debug.Log($"[AdMob Native] Revenue: {revenue} {currencyCode}, Precision: {precision}");

        // Gửi về server, Firebase, hoặc AppsFlyer
        // Ví dụ: key là ad unit id hoặc placement name
        //  string key = "Native_Ad_Unit";
        string nativeId = "ca-app-pub-5904408074441373/8839613624";
      //  AppsFlyerInit.LogAdRevenue("Native", nativeId, revenue);
    }
    private void RegisterNativeGameObjects3()
    {
        if (!nativeAd.RegisterIconImageGameObject(icon2.gameObject))
            Debug.Log("Error registering icon");

        if (!nativeAd.RegisterHeadlineTextGameObject(AdHeadline4.gameObject))
            Debug.Log("Error registering headline");

        if (!nativeAd.RegisterBodyTextGameObject(AdDescription4.gameObject))
            Debug.Log("Error registering description");

        if (!nativeAd.RegisterCallToActionGameObject(AdCallToAction4.gameObject))
            Debug.Log("Error registering CTA");
    }

    public void agg()
    {
        // UiController.ins.ShowPrefab();

        // Pop.SetActive(false);
        // UiController.ins.ShowPrefab();
    }
}
