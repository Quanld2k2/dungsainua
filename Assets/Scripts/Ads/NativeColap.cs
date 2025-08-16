using DG.Tweening;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Ump;
using GoogleMobileAds.Ump.Api;

public class NativeColap : MonoBehaviour
{
    NativeAd nativeAd;
    [Header("------------- nativeAd-------4-----")]
    public RawImage icon1;
    public RawImage icon2;
    public Text AdHeadline4;
    public Text AdCallToAction4;
    public GameObject Pop;

    public void Start()
    {
        Debug.Log("StartN1SpawnOnePrefab");
         GameManager.ins.N2ADS = false;
        GameManager.ins.navi2 = false;
        a = 0;
      //  RequestNativeAd3();
    }
    public int a = 0;
    IEnumerator YourFunction3()
    {
        a += 1;
        yield return new WaitForSeconds(2f);
        if (a <= 5)
        {
            RequestNativeAd3();

        }
        else
        {
            //  UiController.ins.N1DestroyPrefab();

        }


    }

    public void RequestNativeAd3()
    {
        Debug.Log("Navi_new1_Native ad loaded.");

        // AdLoaded3.SetActive(false);
        //   Pop.SetActive(false);

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
         GameManager.ins.navi2 = true;
        Debug.Log("Native ad loaded........oooooooooooooooooooooooooooooooooooooooo");
        if (nativeAd.GetIconTexture() != null)
        {
            Debug.Log("Icon texture loaded.");
            icon1.texture = nativeAd.GetIconTexture();
            icon2.texture = nativeAd.GetIconTexture();
        }
        else
        {
             GameManager.ins.navi2 = false;
            Debug.LogWarning("No icon texture available.");
        }

        if (nativeAd.GetHeadlineText() != null)
        {
            Debug.Log("Icon texture loaded.");
            AdHeadline4.text = nativeAd.GetHeadlineText();

        }
        else
        {//
          GameManager.ins.navi2 = false;
            Debug.LogWarning("No icon texture available.");
        }


        AdCallToAction4.text = nativeAd.GetCallToActionText();


        RegisterNativeGameObjects3();
        //  AdLoaded4.SetActive(true);
        Pop.SetActive(true);
        //  UiController.ins.N1HidePrefab();

         GameManager.ins.N2ADS = true;
        // Debug.Log("N1ADSN1ADSN1ADSN1ADSN1ADSN1ADSN1ADSN1ADS" + GameManager.ins.N1ADS);

        //  UiController.ins.ShowPrefab2();
        int adsRemoved = PlayerPrefs.GetInt("W2_removeads");
        // GameManager.ins.checkNativeManager = adsRemoved != 1;
        nativeAd.OnPaidEvent += HandleOnPaidEvent;
        //FirebaseAnalytics.LogEvent("Native_Done");

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
        //  string nativeId = "ca-app-pub-5904408074441373/2035366274";
        //  AppsFlyerInit.LogAdRevenue("Native", nativeId, revenue);
    }

    private void RegisterNativeGameObjects3()
    {
        if (!nativeAd.RegisterIconImageGameObject(icon1.gameObject))
            Debug.Log("Error registering icon");

        if (!nativeAd.RegisterHeadlineTextGameObject(AdHeadline4.gameObject))
            Debug.Log("Error registering headline");

        if (!nativeAd.RegisterCallToActionGameObject(AdCallToAction4.gameObject))
            Debug.Log("Error registering CTA");
    }

    public void ahahaha (){
        Pop.SetActive(false);

    }
}
