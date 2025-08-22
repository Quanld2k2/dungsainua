using DG.Tweening;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Ump;
using GoogleMobileAds.Ump.Api;
using Firebase;
using Firebase.Analytics;

public enum RewardType
{
    None,
    Hint,
    Time,
    Unlock,
    Daily
}
public enum InterstitialType
{
    None,
    Retry,
    After2Round
}
public class Adsmob : MonoBehaviour
{
    public string appId = "ca-app-pub-3940256099942544~3347511713";

#if UNITY_ANDROID
    // string bannerId = "ca-app-pub-3940256099942544/6300978111";
    // string interId = "ca-app-pub-3940256099942544/1033173712";
    // string rewardedId = "ca-app-pub-3940256099942544/5224354917";
    // string nativeId = "ca-app-pub-3940256099942544/2247696110";
    // string _adUnitId = "ca-app-pub-3940256099942544/6300978111";

#elif UNITY_IPHONE
   // string bannerId = "ca-app-pub-3940256099942544/2934735716";
   // string interId = "ca-app-pub-3940256099942544/4411468910";
   // string rewardedId = "ca-app-pub-3940256099942544/1712485313";
   // string nativeId = "ca-app-pub-3940256099942544/3986624511";

#endif
    public static Adsmob ins;
    private void Awake()
    {
        Adsmob.ins = this;
        int checkIntDate = PlayerPrefs.GetInt("quanDatewho");
        MobileAds.RaiseAdEventsOnUnityMainThread = true;

        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            Debug.Log("✅ AdMob SDK đã khởi tạo xong!");
            AppStateEventNotifier.AppStateChanged += OnAppStateChanged;
        });
    }
    
    private void Start()
    {
        
    }
    public void RequestConsentInfoUpdate()
    {
        ConsentRequestParameters requestParameters = new ConsentRequestParameters
        {
            TagForUnderAgeOfConsent = false
        };

        // Sử dụng callback duy nhất
        ConsentInformation.Update(requestParameters, (FormError error) =>
        {
            if (error != null)
            {
                Debug.Log("Consent info update failed: " + error.Message);
                return;
            }

            Debug.Log("Consent info updated");

            if (ConsentInformation.IsConsentFormAvailable())
            {
                LoadConsentForm();
            }
            else
            {
                MobileAds.RaiseAdEventsOnUnityMainThread = true;
                MobileAds.Initialize((InitializationStatus initStatus) =>
                {
                    Debug.Log("✅ AdMob SDK đã khởi tạo xong!");
                    AppStateEventNotifier.AppStateChanged += OnAppStateChanged;

                });
                Debug.Log("Consent form not available.");
            }
        });
    }
    void LoadConsentForm()
    {
        ConsentForm.Load((form, loadError) =>
        {
            if (loadError != null)
            {
                Debug.Log("Load consent form error: " + loadError.Message);
                return;
            }

            if (form != null)
            {
                form.Show((FormError formError) =>
                {
                    if (formError != null)
                    {
                        Debug.Log("Show consent form error: " + formError.Message);
                        return;
                    }

                    // ✅ SAU KHI FORM ĐÓNG LẠI, LẤY LẠI TRẠNG THÁI
                    GoogleMobileAds.Ump.Api.ConsentStatus status = ConsentInformation.ConsentStatus;
                    Debug.Log("Consent Status After Form: " + status.ToString());

                    if (status == GoogleMobileAds.Ump.Api.ConsentStatus.Obtained)
                    {
                        Debug.Log("✅ User gave consent - you can initialize ads SDK");

                        MobileAds.RaiseAdEventsOnUnityMainThread = true;

                        MobileAds.Initialize((InitializationStatus initStatus) =>
                        {
                            Debug.Log("✅ AdMob SDK đã khởi tạo xong");
                            AppStateEventNotifier.AppStateChanged += OnAppStateChanged;
                        });
                    }
                    else
                    {
                        Debug.Log("❌ User did not give consent - skip personalized ads");
                        // Có thể tắt quảng cáo cá nhân hóa ở đây nếu cần
                    }
                    // Lưu lại ngày hiển thị form
                    PlayerPrefs.SetInt("quanDatewho", 10080);
                    string todayDate = DateTime.Now.ToString("yyyy-MM-dd");
                    PlayerPrefs.SetString("LastCheckDateKey", todayDate);
                    PlayerPrefs.Save();
                });
            }
        });
    }

    private void OnDestroy()
    {
        AppStateEventNotifier.AppStateChanged -= OnAppStateChanged;
    }
    //NativeAd navi;
    BannerView bannerView;
    #region Banner
    private bool isBannerEventsAttached = false;

    public void LoadBannerAd()
    {
        // Kiểm tra nếu người dùng chưa mua gỡ quảng cáo
        bool isAdsRemoved = PlayerPrefs.GetInt("W2_removeads", 0) == 1;
        if (isAdsRemoved)
        {
            Debug.Log("Ads removed. Banner will not be shown.");
            return;
        }
        // Tạo banner nếu chưa có
        if (bannerView == null)
        {
            CreateBannerView();
        }
        // Gắn sự kiện 1 lần duy nhất
        if (!isBannerEventsAttached)
        {
            ListenToBannerEvents();
            isBannerEventsAttached = true;
        }
        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");
        bannerView.LoadAd(adRequest);
    }
   // NativeAd nativeAd;

    private void CreateBannerView()
    {
        DestroyBannerAd(); // Hủy banner cũ nếu có
        string bannerId = "ca-app-pub-5342144217301971/1506606405"; // Thay ID nếu cần
        bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Bottom);
    }

    private void ListenToBannerEvents()    
    {
        bannerView.OnBannerAdLoaded += () =>
        {
            Debug.Log("✅ Banner loaded: " + bannerView.GetResponseInfo());
        };

        bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.Log("❌ Banner load failed: " + error);
        };

        bannerView.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log($"💰 Banner paid: {adValue.Value} {adValue.CurrencyCode}");
        };

        bannerView.OnAdImpressionRecorded += () =>
        {
            Debug.Log("📈 Banner impression recorded.");
        };

        bannerView.OnAdClicked += () =>
        {
            Debug.Log("🖱️ Banner clicked.");
        };

        bannerView.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("📺 Banner fullscreen content opened.");
        };

        bannerView.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("❎ Banner fullscreen content closed.");
        };
    }

    public void DestroyBannerAd()
    {
        if (bannerView != null)
        {
            Debug.Log("🗑️ Destroying banner ad.");
            bannerView.Destroy();
            bannerView = null;
            isBannerEventsAttached = false;
        }
    }
    #endregion

    InterstitialAd interstitialAd;
    #region Interstitial
    private InterstitialAd interAd_Round2;
    private InterstitialAd interAd_Retry;
    private InterstitialType currentInterType = InterstitialType.None;

    // interload and show1
    public void LoadInterAfter2Round()
    {
        if (retryCoroutine_Round2 != null)
            StopCoroutine(retryCoroutine_Round2);

        retryCoroutine_Round2 = StartCoroutine(LoadInterAfter2RoundWithTimeout());
    }
    private IEnumerator LoadInterAfter2RoundWithTimeout()
    {
        float startTime = Time.time;
        bool adLoaded = false;

        while (Time.time - startTime < retryTimeoutSeconds && !adLoaded)
        {
            bool waiting = true;
            string interId = "ca-app-pub-5342144217301971/9193524733";

            InterstitialAd.Load(interId, new AdRequest(),
                (InterstitialAd ad, LoadAdError error) =>
                {
                    if (error == null && ad != null)
                    {
                        interAd_Round2 = ad;
                        //RegisterInterstitialEvents(ad);
                        RegisterInterstitialEvents(ad, interId, "interAd_Round2");

                        adLoaded = true;
                        Debug.Log("Interstitial (After2Round) loaded successfully.");
                        ShowInterAfter2Round();
                    }
                    else
                    {
                        Debug.LogWarning("Interstitial (After2Round) load failed: " + error);
                    }

                    waiting = false;
                });

            // Đợi callback hoặc tối đa 1 giây
            float waitStart = Time.time;
            while (waiting && Time.time - waitStart < 1f)
            {
                yield return null;
            }

            if (!adLoaded)
                yield return new WaitForSeconds(1f); // chờ rồi retry tiếp
        }

        if (!adLoaded)
        {
            Debug.Log("Failed to load Interstitial (After2Round) after timeout.");
        }

        retryCoroutine_Round2 = null;
    }
    private Coroutine retryCoroutine_Round2;
    private Coroutine retryCoroutine_Retry;
    private float retryTimeoutSeconds = 5f;
    // interload and show2
    public void LoadInterRetry()
    {
        if (retryCoroutine_Retry != null)
            StopCoroutine(retryCoroutine_Retry);

        retryCoroutine_Retry = StartCoroutine(LoadInterRetryWithTimeout());
    }
    private IEnumerator LoadInterRetryWithTimeout()
    {
        float startTime = Time.time;
        bool adLoaded = false;

        while (Time.time - startTime < retryTimeoutSeconds && !adLoaded)
        {
            bool waiting = true;

            string interId = "ca-app-pub-5342144217301971/9193524733";

            InterstitialAd.Load(interId, new AdRequest(),
                (InterstitialAd ad, LoadAdError error) =>
                {
                    if (error == null && ad != null)
                    {
                        interAd_Retry = ad;
                        RegisterInterstitialEvents(ad, interId, "interAd_Retry");
                        adLoaded = true;
                        Debug.Log("Interstitial (Retry) loaded successfully.");
                       // ShowInterRetry();
                    }
                    else
                    {
                        Debug.Log("Interstitial (Retry) load failed: " + error);
                    }

                    waiting = false;
                });

            // Đợi tối đa 1s trước khi retry (hoặc đến khi callback xong)
            float waitStart = Time.time;
            while (waiting && Time.time - waitStart < 1f)
            {
                yield return null;
            }

            if (!adLoaded)
                yield return new WaitForSeconds(1f); // đợi 1s rồi thử lại
        }

        if (!adLoaded)
        {
            Debug.Log("Failed to load Interstitial (Retry) after timeout.");
        }

        retryCoroutine_Retry = null;
    }
    // interload show2
    public void ShowInterAfter2Round()
    {

        if (interAd_Round2 != null && interAd_Round2.CanShowAd())
        {
            // FirebaseAnalytics.LogEvent("inter_game_after_1round");

            GameManager.ins.OP1 = true;
            currentInterType = InterstitialType.After2Round;
            interAd_Round2.Show();
        }
    }
    private bool isShowingInterRetry = false;

    public void ShowInterRetry()
    {
        if (interAd_Retry != null && interAd_Retry.CanShowAd() && !isShowingInterRetry)
        {          
            FirebaseAnalytics.LogEvent("ShowInterRetry");

            isShowingInterRetry = true;
            currentInterType = InterstitialType.Retry;
            interAd_Retry.Show();
        }
    }

    private void RegisterInterstitialEvents(InterstitialAd ad, string key, string placement)
    {
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log($"Interstitial ad paid {adValue.Value} {adValue.CurrencyCode}.");

            double _value = adValue.Value;
            // AppsFlyerInit.LogAdRevenue("Interstitial", key, _value);
        };

        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Interstitial ad recorded an impression.");
        };

        ad.OnAdClicked += () =>
        {
            Debug.Log("Interstitial ad was clicked.");
        };

        //ad.OnAdFullScreenContentOpened += () =>
      //  {
       //     Debug.Log("Interstitial ad full screen content opened.");
      //  };

        ad.OnAdFullScreenContentClosed += () =>
        {
            isShowingInterRetry = false;

            Debug.Log("Interstitial ad full screen content closed.");

            // Delay xử lý để tránh ANR
            StartCoroutine(HandleAdClosedWithDelay());
        };

        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.Log("Interstitial ad failed to open full screen content with error: " + error);
        };
    }
    private IEnumerator HandleAdClosedWithDelay()
    {
        yield return new WaitForSeconds(0.7f); // 0.5-1 giây tùy thiết bị
        OnInterstitialAdClosed();

        switch (currentInterType)
        {
            case InterstitialType.Retry:
                LoadInterRetry();
                break;
            case InterstitialType.After2Round:
               // LoadInterAfter2Round();
                break;
            default:
                Debug.LogWarning("Unknown interstitial type when closed.");
                break;
        }

        currentInterType = InterstitialType.None;
    }
    #endregion

    RewardedAd rewardedAd;
    #region Rewarded
    private RewardedAd reward_hint;
    private RewardedAd reward_time;
    private RewardedAd reward_unlock;
    private RewardedAd reward_daily;

    private RewardType currentRewardType = RewardType.None;

    public void LoadRewardHint()
    {
        var request = new AdRequest();
        string rewardedidhint = "ca-app-pub-5342144217301971/3941198056";

        RewardedAd.Load(rewardedidhint, request, (RewardedAd ad, LoadAdError error) =>
        {
            if (error == null && ad != null)
            {
                reward_hint = ad;
                //RewardedAdEvents(reward_hint);
                RewardedAdEvents(reward_hint, rewardedidhint, "reward_hint");
            }
        });
    }

    public void LoadRewardTime()
    {
        var request = new AdRequest();
        string rewardedidtime = "ca-app-pub-5342144217301971/3941198056";

        RewardedAd.Load(rewardedidtime, request, (RewardedAd ad, LoadAdError error) =>
        {
            if (error == null && ad != null)
            {
                reward_time = ad;
                // RewardedAdEvents(reward_time);
                RewardedAdEvents(reward_time, rewardedidtime, "reward_time");
            }
        });
    }

    public void LoadRewardUnlock()
    {
        var request = new AdRequest();
        string rewardedidtime = "ca-app-pub-5342144217301971/3941198056";

        RewardedAd.Load(rewardedidtime, request, (RewardedAd ad, LoadAdError error) =>
        {
            if (error == null && ad != null)
            {
                reward_unlock = ad;
                //RewardedAdEvents(reward_unlock);
                RewardedAdEvents(reward_unlock, rewardedidtime, "reward_unlock");
            }
        });
    }
    public void LoadRewardDaily()
    {
        var request = new AdRequest();
        string rewardedidtime = "ca-app-pub-5342144217301971/3941198056";

        RewardedAd.Load(rewardedidtime, request, (RewardedAd ad, LoadAdError error) =>
        {
            if (error == null && ad != null)
            {
                reward_daily = ad;
                //  RewardedAdEvents(reward_daily);
                RewardedAdEvents(reward_daily, rewardedidtime, "reward_daily");
            }
        });
    }




    public void ShowRewardedAd(RewardType type, Action onReward)
    {
        //GameManager.ins.pauseRW = true;
        GameManager.ins.OP2 = true;
        currentRewardType = type;

        RewardedAd adToShow = null;

        switch (type)
        {
            case RewardType.Hint:
                 FirebaseAnalytics.LogEvent("reward_hint");

                adToShow = reward_hint;
                break;
            case RewardType.Time:
                  FirebaseAnalytics.LogEvent("reward_time");

                adToShow = reward_time;
                break;
            case RewardType.Unlock:
                 FirebaseAnalytics.LogEvent("Reward_Daily");

                adToShow = reward_unlock;
                break;
            case RewardType.Daily:
                FirebaseAnalytics.LogEvent("resume_all");

                adToShow = reward_daily;
                break;
        }

        if (adToShow != null && adToShow.CanShowAd())
        {
            adToShow.Show((Reward reward) =>
            {
                onReward?.Invoke();
                LoadRewardAgain(type);
            });
        }
        else
        {
            SpawnMoveAndDestroy();
            LoadRewardAgain(type);
        }
    }

    public GameObject prefabToSpawn;
    public float moveDistance = 3f;
    public Canvas parentCanvas;
    public float moveSpeed = 1f;
    public void SpawnMoveAndDestroy()
    {
        if (parentCanvas == null)
        {
            Debug.Log("Parent canvas is not assigned.");
            return;
        }
        GameObject newObject = Instantiate(prefabToSpawn, parentCanvas.transform);
        RectTransform rectTransform = newObject.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.anchoredPosition = new Vector2(0, 0);
            Vector2 targetPosition = rectTransform.anchoredPosition + Vector2.up * moveDistance * 150;
            rectTransform.DOAnchorPos(targetPosition, 2f).SetEase(Ease.OutQuint)
                        .OnComplete(() =>
                        {
                            Destroy(newObject);
                        });
        }
        else
        {
            Debug.Log("The prefab does not have a RectTransform component.");
        }
    }
    void LoadRewardAgain(RewardType type)
    {
        switch (type)
        {
            case RewardType.Hint:
                LoadRewardHint();
                break;
            case RewardType.Time:
                LoadRewardTime();
                break;
            case RewardType.Unlock:
                LoadRewardUnlock();
                break;
        }
    }
    public void RewardedAdEvents(RewardedAd ad, string key, string placement)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log("Rewarded ad paid {0} {1}." +
                adValue.Value +
                adValue.CurrencyCode);

            double _value = adValue.Value;
            //  AppsFlyerInit.LogAdRevenue("Rewarded", key, _value);

        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Rewarded ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Rewarded ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Rewarded ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");
            OnInterstitialAdClosed();
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.Log("Rewarded ad failed to open full screen content " +
                           "with error : " + error);
        };
    }

    #endregion

    #region extra 
    private AppOpenAd splashOpenAd;
    private AppOpenAd resumeOpenAd;
    private enum AppOpenAdType { None, Splash, Resume }
    private AppOpenAdType currentAdType = AppOpenAdType.None;

    // ===== LOAD SPLASH AD =====
    public void LoadSplashAd()
    {
        if (splashOpenAd != null)
        {
            splashOpenAd.Destroy();
            splashOpenAd = null;
        }
        string adUnitId = "ca-app-pub-5342144217301971/1315034710";
        var adRequest = new AdRequest();

        AppOpenAd.Load(adUnitId, adRequest, (ad, error) =>
        {
            if (error != null || ad == null)
            {
                Debug.Log("Splash Ad failed to load: " + error);
                return;
            }
            splashOpenAd = ad;
            currentAdType = AppOpenAdType.Splash;
            //  RegisterEventHandlers(ad, AppOpenAdType.Splash);
            RegisterEventHandlers(ad, AppOpenAdType.Splash, adUnitId, "splashOpenAd");
            GameManager.ins.openAd12333 = true;
            Debug.Log("Splash Ad Loaded.");
        });
    }
    // ===== LOAD RESUME AD =====
    public void LoadResumeAd()
    {
        StartCoroutine(HandleAdClosedWithDelayOOP());

    }
    private IEnumerator HandleAdClosedWithDelayOOP()
    {
        yield return new WaitForSeconds(1.5f); // 0.5-1 giây tùy thiết bị
        if (resumeOpenAd != null)
        {
            resumeOpenAd.Destroy();
            resumeOpenAd = null;
        }
        string adUnitId = "ca-app-pub-5342144217301971/1315034710";
        var adRequest = new AdRequest();

        AppOpenAd.Load(adUnitId, adRequest, (ad, error) =>
        {
            if (error != null || ad == null)
            {
                Debug.Log("Resume Ad failed to load: " + error);
                return;
            }

            resumeOpenAd = ad;
            currentAdType = AppOpenAdType.Resume;
            //   RegisterEventHandlers(ad, AppOpenAdType.Resume);
            RegisterEventHandlers(ad, AppOpenAdType.Resume, adUnitId, "resumeOpenAd");

            //  GameManager.ins.openAd12333 = true;
            Debug.Log("Resume Ad Loaded.");
        });
    }

    // ===== REGISTER EVENT HANDLERS =====
    private void RegisterEventHandlers(AppOpenAd ad, AppOpenAdType adType, string key, string placement)
    {
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log($"App open ad paid {adValue.Value} {adValue.CurrencyCode}.");
            double _value = adValue.Value;
            // AppsFlyerInit.LogAdRevenue("AppOpenAd", key, _value);
        };

        ad.OnAdImpressionRecorded += () => { Debug.Log("App open ad recorded an impression."); };

        ad.OnAdClicked += () => { Debug.Log("App open ad was clicked."); };

        ad.OnAdFullScreenContentOpened += () => { Debug.Log("App open ad full screen content opened."); };

        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("App open ad full screen content closed.");

            // Reload appropriate ad
            if (adType == AppOpenAdType.Splash)
                LoadResumeAd();
            else if (adType == AppOpenAdType.Resume)
                LoadResumeAd();
            // Logic sau khi ads đóng
            if (GameManager.ins.OpAds1)
            {
                GameManager.ins.OpAds1 = false;
                // UiController.ins.startpp();
            }
        };

        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.Log("App open ad failed to show full screen: " + error);
            if (adType == AppOpenAdType.Splash)
                LoadSplashAd();
            else if (adType == AppOpenAdType.Resume)
                LoadResumeAd();
        };
    }

    // ===== INTERSTITIAL FLAG CONTROL =====
    private bool isInterstitialJustClosed = false;
    private float lastAdShownTime = 0f;
    private const float resumeAdCooldown = 45f; // giây

    // ✅ Gọi cái này sau khi Interstitial đóng
    public void OnInterstitialAdClosed()
    {
        StartCoroutine(OP2S());

        isInterstitialJustClosed = true;
        lastAdShownTime = Time.realtimeSinceStartup;

        Debug.Log("Interstitial ad just closed - cooldown started.");
    }
    IEnumerator OP2S()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Loading continue screen: ");
        GameManager.ins.OP1 = false;
        GameManager.ins.OP2 = false;
    }
    // ===== SHOW SPLASH AD =====
    public void ShowSplashAd()
    {
        if (splashOpenAd != null && splashOpenAd.CanShowAd())
        {
            // FirebaseAnalytics.LogEvent("open_splash");
            currentAdType = AppOpenAdType.Splash;
            splashOpenAd.Show();
            Debug.Log("Showing Splash Ad.");
        }
        else
        {
            Debug.Log("Splash ad not ready.");
        }
    }

    // ===== SHOW RESUME AD =====
    public void ShowResumeAd()
    {
        float timeSinceLastAd = Time.realtimeSinceStartup - lastAdShownTime;
        Debug.Log($"[ResumeAd] Time since last ad: {timeSinceLastAd}, Interstitial flag: {isInterstitialJustClosed}");

        if (isInterstitialJustClosed || timeSinceLastAd < resumeAdCooldown)
        {
            Debug.Log("Skip resume ad: cooldown or just shown interstitial.");
            isInterstitialJustClosed = false; // reset
            return;
        }

        if (resumeOpenAd != null && resumeOpenAd.CanShowAd())
        {
            //FirebaseAnalytics.LogEvent("resume_all");

            currentAdType = AppOpenAdType.Resume;
            resumeOpenAd.Show();
            Debug.Log("Showing Resume Ad.");
            lastAdShownTime = Time.realtimeSinceStartup;
        }
        else
        {
            Debug.Log("Resume ad not ready.");
        }
    }

    // ===== HANDLE APP STATE =====
    private bool isShowingAd = false;
    private void OnApplicationPause(bool pauseStatus)
    {
        if (!pauseStatus)
        {
            if (GameManager.ins.OP1 == false && GameManager.ins.OP2 == false)
            {
                Debug.Log("App resumed from background.");
                if (PlayerPrefs.GetInt("Iap_Removeads", 0) == 0)
                {
                    StartCoroutine(ShowResumeAdDelayed());
                }

            }
            else
            {
                Debug.Log("Nooo App resumed from background.");
            }
            // Không gọi ShowResumeAd ở đây để tránh trùng
        }

    }
    private IEnumerator ShowResumeAdDelayed()
    {
        yield return new WaitForSeconds(1.2f);
        ShowResumeAd();
    }

    private void OnAppStateChanged(AppState state)
    {
        Debug.Log("App State changed to : " + state);

        if (state == AppState.Foreground)
        {
            // ShowResumeAd();
        }
    }
    #endregion



}