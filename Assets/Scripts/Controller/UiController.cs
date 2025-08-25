using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Spine.Unity;
using Spine;
using System.Collections;
using System;
using Firebase;
using Firebase.Analytics;

public class UiController : MonoBehaviour
{
    public static UiController ins;
    [SerializeField]
    public GameObject HomeUI, setting, uiplay, unlock,hintpop,
        unlockAll, hint, win, timePop, lose, BgVNS, ShopPop, ShopVipPop, sale;
    public Image BG_XV, icon_V;
    // [SerializeField] public Image BG_XV;
    public SkeletonGraphic a_scene, loading, loading2;
    public Text txt_gold;
    int LevelGame = 30; //-----------------------------------//
    public Adsmob amob;


    private void Awake()
    {
        // PlayerPrefs.DeleteAll();
        timerAdsOpen = 0;
        UiController.ins = this;
    }
    private void Start()
    {
        startL();
    }
    public void auuuuu()
    {
        Debug.Log("doneauuuuuauuuuuauuuuu");
    }
    public void startL()
    {
        // PlayerPrefs.DeleteAll();
        BgVNS.gameObject.SetActive(true);
        loading.gameObject.SetActive(true);
        loading.AnimationState.SetAnimation(1, "animation", false);

        loading2.gameObject.SetActive(true);
        loading2.AnimationState.SetAnimation(1, "animation", true);
        a_scene.gameObject.SetActive(false);
        a_scene.AnimationState.Complete += OnAnimationCompleteScene;
        loading.AnimationState.Complete += OnAnimationCompleteLoading;
        HomeUI.gameObject.SetActive(true);

        setting.gameObject.SetActive(true);
        uiplay.gameObject.SetActive(true);
        unlock.gameObject.SetActive(true);
        unlockAll.gameObject.SetActive(true);
        hint.gameObject.SetActive(true);
        win.gameObject.SetActive(true);
        lose.gameObject.SetActive(true);
        timePop.gameObject.SetActive(true);
        ShopPop.gameObject.SetActive(false);
        ShopVipPop.gameObject.SetActive(true);
        sale.gameObject.SetActive(true);
        hintpop.gameObject.SetActive(true);

        BG_XV.gameObject.SetActive(true);
        icon_V.gameObject.SetActive(true);

        setting.GetComponent<RectTransform>().anchoredPosition = new Vector3(500f, 5000f, 0f);
        uiplay.GetComponent<RectTransform>().anchoredPosition = new Vector3(-4000f, 0f, 0f);
        unlock.GetComponent<RectTransform>().anchoredPosition = new Vector3(-4000f, 5000f, 0f);
        unlockAll.GetComponent<RectTransform>().anchoredPosition = new Vector3(-6000f, 5000f, 0f);
        hint.GetComponent<RectTransform>().anchoredPosition = new Vector3(5000f, 5000f, 0f);
        win.GetComponent<RectTransform>().anchoredPosition = new Vector3(2880f, 5000f, 0f);
        lose.GetComponent<RectTransform>().anchoredPosition = new Vector3(-1720f, 5000f, 0f);
        timePop.GetComponent<RectTransform>().anchoredPosition = new Vector3(7000f, 5000f, 0f);
        ShopPop.GetComponent<RectTransform>().anchoredPosition = new Vector3(-6000f, 0f, 0f);
        ShopVipPop.GetComponent<RectTransform>().anchoredPosition = new Vector3(-4000f, 0f, 0f);
        sale.GetComponent<RectTransform>().anchoredPosition = new Vector3(-8000f, 0f, 0f);
        hintpop.GetComponent<RectTransform>().anchoredPosition = new Vector3(-3000f, 3000f, 0f);

        Home.ins.StartHome();
        unlockLevel.ins.startUnlock();
        Setting.ins.OpenSetting();
        Win.ins.OpenWin(0);
        Lose.ins.OpenLose();
        Setting.ins.SLanguague_open();
        // StartCoroutine(StartLoop());
        //  txt_gold.text = "0";

        int Vip_game_second = PlayerPrefs.GetInt("Vip_game_second");

        if (Vip_game_second == 0) 
        {
            PlayerPrefs.SetInt("Vip_game_second", 1);
        }

        loadelevelactive = 0;
        lo2 = 0;
        addGold();

        if (newObject != null)
        {
            Destroy(newObject);
        }
        //  Level.ins.indexLevel2();

        //........iap
        if (PlayerPrefs.GetInt("Iap_Removeads", 0) == 0)
        {
            N1SpawnOnePrefab();
            N2SpawnOnePrefab();
            amob.LoadSplashAd();
            StartCoroutine(ShowAppOpenAds());
        }
    }
    public void langGA()
    {

    }
    IEnumerator StartLoop()
    {
        yield return new WaitForSeconds(3f);
        // startGame();
    }

    public void startGame()
    {
        Debug.Log("startGAME");


        unlockLevel.ins.CheckImageVisibility();
        //loading.gameObject.SetActive(true);

        BgVNS.gameObject.SetActive(false);
        HomeUI.gameObject.SetActive(true);

        setting.gameObject.SetActive(false);
        uiplay.gameObject.SetActive(false);
        unlock.gameObject.SetActive(false);
        unlockAll.gameObject.SetActive(false);
        hint.gameObject.SetActive(false);
        win.gameObject.SetActive(false);
        lose.gameObject.SetActive(false);
        timePop.gameObject.SetActive(false);
        ShopPop.gameObject.SetActive(false);
        ShopVipPop.gameObject.SetActive(false);
        sale.gameObject.SetActive(false);
        hintpop.gameObject.SetActive(false);

        BG_XV.gameObject.SetActive(false);
        icon_V.gameObject.SetActive(false);

        GameManager.ins.alang = false;

        int Vip_game_second = PlayerPrefs.GetInt("Vip_game_second");

        if (Vip_game_second != 0)
        {
            int aload = PlayerPrefs.GetInt("anoyme1");
            int aload2 = loadelevelactive + aload;
            if (PlayerPrefs.GetInt("Iap_Removeads", 0) == 0)
            {
                if (lo2 == 100)
                {
                    if (aload2 >= 4)
                    {
                        Home.ins.a_sale.gameObject.SetActive(true);

                        sale.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                        sale.gameObject.SetActive(true);
                        Sale.ins.sale_up_lev4true();
                    }
                }

                StartCoroutine(ShowNative());
                amob.LoadInterRetry();
                amob.LoadRewardHint();
                amob.LoadRewardTime();
                amob.LoadRewardUnlock();
             //   amob.LoadRewardDaily();

            }
            if (lo2 == 0)
            {
                lo2 = 100; 
                int vipIap = PlayerPrefs.GetInt("vipIap");

                if (vipIap == 0) 
                {
                    ShopVipPop.gameObject.SetActive(true);
                    ShopVip.ins.ShowPopupFromButton();
                }
           
            }
        }

        //........iap
    }
    IEnumerator ShowNative()
    {
        Debug.Log("ShowNativeShowNativeShowNativeShowNative ok");

        yield return new WaitForSeconds(2f);
        if (GameManager.ins.N1ADS == true && GameManager.ins.navi1 == true)
        {
            N1ShowPrefab();
            Debug.Log("N1ShowPrefab ok");

        }
        else
        {
            N1DestroyPrefab();
            N1SpawnOnePrefab();
            Debug.Log("N1ShowPrefab faild");

        }

        if (GameManager.ins.N2ADS == true && GameManager.ins.navi2 == true)
        {
            N2ShowPrefab();
            Debug.Log("N1ShowPrefab ok");

        }
        else
        {
            N2DestroyPrefab();
            N2SpawnOnePrefab();
            Debug.Log("N1ShowPrefab faild");

        }
    }
    int timerAdsOpen = 0;
    IEnumerator ShowAppOpenAds()
    {
        yield return new WaitForSeconds(1.5f);
        if (GameManager.ins.openAd12333 == true)
        {
            amob.ShowSplashAd();

            //Am.ShowSplashAd(startpp);
        }
        else
        {
            timerAdsOpen += 1;
            if (timerAdsOpen == 7)
            {
                // startGame(); 
            }
            else
            {
                amob.LoadSplashAd();
                StartCoroutine(ShowAppOpenAds());
            }
        }
    }
    public void addGold()
    {
        int coins2 = PlayerPrefs.GetInt("txt_gold");
        float from = 0f;
        float to = coins2;
        float duration = 1f;
        DOTween.To(() => from, x => {
            from = x;
            txt_gold.text = $"{from:0}";
        }, to, duration).SetEase(Ease.OutQuad);
    }

    private void OnAnimationCompleteLoading(TrackEntry trackEntry)
    {
        if (trackEntry.Animation != null)
        {
            AudioManager.ins.musicSource.mute = false;
           // AudioManager.ins.Click.mute = false;

            startGame();
        }
    }

    private void OnAnimationCompleteScene(TrackEntry trackEntry)
    {
        if (trackEntry.Animation != null)
        {
            if (trackEntry.Animation.Name == "Close")
            {
                Debug.Log("GameManager.ins.SHome-----" + GameManager.ins.SHome);
                Debug.Log("GameManager.ins.SPlay-----" + GameManager.ins.SPlay);
                Debug.Log("GameManager.ins.RSET-----" + GameManager.ins.RSET);

                if (GameManager.ins.SHome == true)
                {
                  //  amob.LoadInterRetry();

                    Debug.Log("Play-----Active");

                    AudioManager.ins.musicSource.mute = true;
                    // AudioManager.ins.Click.mute = true;
                    GameManager.ins.sod = true;
                    Destroy(newObject);
                    Debug.Log(newObject);
                    HomeUI.gameObject.SetActive(false);
                    lose.gameObject.SetActive(false);
                    
                    StartGamePlay();
                    a_scene.AnimationState.ClearTrack(1);
                   // a_scene.AnimationState.SetAnimation(1, "Open", false);
                    // GameManager.ins.SHome = false;
                }
                else if (GameManager.ins.SPlay == true)
                {
                    Debug.Log("Home-----Active");
                    AudioManager.ins.musicSource.mute = false;
                    //  AudioManager.ins.Click.mute = false;
                    GameManager.ins.sod = false;
                    AudioManager.ins.stop1shot();
                    AudioManager.ins.stop2shot();
                    AudioManager.ins.stop3shot();
                    AudioManager.ins.stopmusicgame();

                    addGold();
                    Destroy(newObject);
                    Debug.Log(newObject);
                    HomeUI.gameObject.SetActive(true);
                    N1DestroyPrefab();
                    N2DestroyPrefab();

                    N1SpawnOnePrefab();
                    N2SpawnOnePrefab();

                    startGame();
                    a_scene.AnimationState.ClearTrack(1);
                   // a_scene.AnimationState.SetAnimation(1, "Open", false);
                    GameManager.ins.SPlay = false;
                }
                else if (GameManager.ins.RSET == true)
                {
                  //  amob.LoadInterRetry();

                    Destroy(newObject);
                    StartGamePlay();
                    a_scene.AnimationState.ClearTrack(1);
                  //  a_scene.AnimationState.SetAnimation(1, "Open", false);
                    //GameManager.ins.RSET = false;
                }
                else
                {
                    if (GameManager.ins.alang == false)
                    {
                        uiplay.gameObject.SetActive(true);
                        uiplay.GetComponent<RectTransform>().anchoredPosition = new Vector3(-4000f, 0f, 0f);
                    }
                   

                    Setting.ins.SLanguague_close();
                    a_scene.AnimationState.ClearTrack(1);
                   // a_scene.AnimationState.SetAnimation(1, "Open", false);
                    if (GameManager.ins.alang == false)
                    {
                        uiplay.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                        uiplay.gameObject.SetActive(false);
                    }
                    

                }
            }
            else if (trackEntry.Animation.Name == "Open")
            {
                if (GameManager.ins.RSET == true || GameManager.ins.SHome == true)
                {
                    int aload = PlayerPrefs.GetInt("anoyme1");
                    int aload2 = loadelevelactive + aload;
                    if (PlayerPrefs.GetInt("Iap_Removeads", 0) == 0)
                    {
                        if (aload2 == 4)
                        {
                            sale.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                            sale.gameObject.SetActive(true);
                            Sale.ins.sale_up_lev4true();
                        }
                    }
                   
                    
                    Debug.Log("levelloading..   " + aload2);

                    GameManager.ins.SHome = false;
                    GameManager.ins.RSET = false;

                    time.ins.StartCountdown();

                   // if (PlayerPrefs.GetInt("Iap_Removeads", 0) == 0)
                    //{
                    //    StartCoroutine(StartInter());
                    //}
                }
                a_scene.gameObject.SetActive(false);
                
                if (PlayerPrefs.GetInt("Iap_Removeads", 0) == 0 && (GameManager.ins.SPlay == true))
                {
                   // amob.LoadBannerAd();
                }
                //  a_scene.AnimationState.ClearTrack(1);
                // a_scene.AnimationState.SetAnimation(1, "Open", false);
            }
        }
    }
    int loadelevelactive = 0, lo2 = 0;
    IEnumerator StartInter()
    {
        yield return new WaitForSeconds(1.5f);
     //   amob.ShowInterRetry();
    }
    public void StartGamePlay()
    {
        Debug.Log("📺 BStartGamePlayStartGamePlayStartGamePlay");
        Debug.Log(id_level);

        uiplay.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        uiplay.gameObject.SetActive(true);

        setting.gameObject.SetActive(false);
        unlock.gameObject.SetActive(false);
        hint.gameObject.SetActive(false);
        win.gameObject.SetActive(false);
        lose.gameObject.SetActive(false);
        timePop.gameObject.SetActive(false);
        hintpop.gameObject.SetActive(false);

        time.ins.ResetCountdown();
        time.ins.startHi();
        //  AudioManager.ins.stop1shot();

        if (id_level < LevelGame)
        {

        }
        else
        {
            id_level = 0;

        }
        time.ins.conTent(id_level);

        SpawnMoveAndDestroy(prefabToSpawn1[id_level]);
        GameManager.ins.alang = true;
        GameManager.ins.HintActive();

    }
    public ScrollRect scrollRect;

    public void ScrollToTop()
    {
        AudioManager.ins.playClickshot();

        Debug.Log("ScrollToTop");
        DOTween.To(() => scrollRect.verticalNormalizedPosition,
               x => scrollRect.verticalNormalizedPosition = x,
               1f, 1f); // scroll lên đầu trong 0.5 giây
    }

    public void ScrollToBottom()
    {
        AudioManager.ins.playClickshot();

        Debug.Log("ScrollToBottom");
        DOTween.To(() => scrollRect.verticalNormalizedPosition,
               x => scrollRect.verticalNormalizedPosition = x,
               0f, 1f); // scroll xuống cuối trong 0.5 giây
    }
   
        
    public void OpenSale()
    {
        AudioManager.ins.playClickshot();
        Home.ins.a_sale.transform.DOScale(1.1f, 0.1f).OnComplete(() =>
        {
            Home.ins.a_sale.transform.DOScale(1f, 0.1f).OnComplete(() =>
            {
                sale.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                sale.gameObject.SetActive(true);
                Sale.ins.Saleup();
            });
        });
    }
    public void CloseSale()
    {
        Sale.ins.bt2.DOKill();                  // hủy tween
        Sale.ins.bt2.transform.localScale = Vector3.one;  // trả về scale gốc
        sale.GetComponent<RectTransform>().anchoredPosition = new Vector3(-8000f, 0f, 0f);
        sale.gameObject.SetActive(false);
    }
    public void OpenShop()
    {
        AudioManager.ins.playClickshot();

        ShopPop.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        ShopPop.gameObject.SetActive(true);
        Shop.ins.OpenShop();
    }
    public void CloseShop()
    {
        ShopPop.GetComponent<RectTransform>().anchoredPosition = new Vector3(-6000f, 0f, 0f);
        ShopPop.gameObject.SetActive(false);
        addGold();
    }
    public void OpenHintpop()
    {
        AudioManager.ins.playClickshot();

        hintpop.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        hintpop.transform.localScale = new Vector3(0f, 0f, 0f);
        hintpop.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);
        hintpop.gameObject.SetActive(true);
        if (GameManager.ins.Home == true)
        {
            time.ins.PauseCountdown();
            PauseGame();
        }
        //  Shop.ins.OpenShop();
    }
    public void Closehintpop()
    {
        hintpop.GetComponent<RectTransform>().anchoredPosition = new Vector3(-3000f, 3000f, 0f);
        hintpop.gameObject.SetActive(false);
        if (GameManager.ins.Home == true)
        {
            ResumeGame();
            time.ins.ResumeCountdown();
        }
        //  addGold();
    }
    public void OpenShopVip()
    {
       AudioManager.ins.playClickshot();
       Home.ins.bt_Vip.transform.DOScale(1.1f, 0.1f).OnComplete(() =>
        {
            Home.ins.bt_Vip.transform.DOScale(1f, 0.1f).OnComplete(() =>
            {
                ShopVipPop.gameObject.SetActive(true);
                ShopVip.ins.ShowPopupFromButton();
            });
        });
       
    }
    public void CloseShopVip()
    {
        AudioManager.ins.playClickshot();
        ShopVip.ins.bt2.transform.DOScale(1.1f, 0.1f).OnComplete(() =>
        {
            ShopVip.ins.bt2.transform.DOScale(1f, 0.1f).OnComplete(() =>
            {
                ShopVip.ins.bt1.DOKill();                  // hủy tween
                ShopVip.ins.bt1.transform.localScale = Vector3.one;  // trả về scale gốc
                ShopVipPop.GetComponent<RectTransform>().anchoredPosition = new Vector3(-4000f, 0f, 0f);
                ShopVipPop.gameObject.SetActive(false);
            });
        });
        
    }
    public void Bt_Privacy()
    {
#if UNITY_ANDROID
        Application.OpenURL("https://vnstart.com/privacy-policy.html");
#elif UNITY_IPHONE
        Application.OpenURL("https://vnstart.com/privacy-policy.html");

#endif

    }
    public void Bt_Service()
    {
#if UNITY_ANDROID
        Application.OpenURL("https://vnstart.com/privacy-policy.html");
#elif UNITY_IPHONE
        Application.OpenURL("https://vnstart.com/privacy-policy.html");

#endif

    }
    public void OpenSetting()
    {
        AudioManager.ins.playClickshot();

        setting.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        setting.gameObject.SetActive(true);
        Setting.ins.OpenSetting();
        // GameManager.ins.Pause = true;
        Debug.Log("GameManager.ins.Home" + GameManager.ins.Home);
        if (GameManager.ins.Home == true)
        {
            time.ins.PauseCountdown();
            PauseGame();


        }
    }
    public void CloseSetting()
    {
        if (GameManager.ins.Home == true)
        {
            ResumeGame();
            time.ins.ResumeCountdown();
        }

        setting.GetComponent<RectTransform>().anchoredPosition = new Vector3(500f, 5000f, 0f);
        //Setting.ins.board.SetActive(false);
        setting.gameObject.SetActive(false);
    }
    public void CloseSettingLang()
    {
        int codeLanguage = PlayerPrefs.GetInt("GameLanguageID");
        if (codeLanguage == LocalSelector.ins.ids)
        {
            Setting.ins.SLanguague_close();
        }
        else
        {
            // amob.DestroyBannerAd();

            a_scene.gameObject.SetActive(true);
            a_scene.AnimationState.ClearTrack(1);
            a_scene.AnimationState.SetAnimation(1, "Close", false);
            AudioManager.ins.playClickshot2();
          //  N1HidePrefab();
          //  N2HidePrefab();
        }
    }
    public void addScore(int id)
    {
        int hiNum = PlayerPrefs.GetInt("hiGame");
        hiNum += id;
        PlayerPrefs.SetInt("hiGame", hiNum);
        time.ins.startHi();
        Shop.ins.addhiGame();
    }
    public void OpenHintReward()
    {
        AudioManager.ins.playClickshot();

        int hiNum = PlayerPrefs.GetInt("hiGame");

        if (hiNum > 0)
        {
            hiNum -= 1;
            PlayerPrefs.SetInt("hiGame", hiNum);

            if (hiNum <= 0)
            {
                hiNum = 0;
                time.ins.startHi();
            }
            else
            {
                time.ins.hiNumber.text = $"{hiNum}";
            }
            OpenHint();
        }
        else
        {

            OpenHintpop();

           
        }
        //  Adsmob.ins.ShowRewardedAd(OpenHint);
    }

    public void hintReward()
    {
         amob.ShowRewardedAd(RewardType.Hint, () => {
                OpenHint();
            });
            Debug.Log("ggads");
    }


    public void OpenHint()
    {
        Closehintpop();

        hint.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        hint.gameObject.SetActive(true);
        Hint.ins.allLevel(id_level);
        if (GameManager.ins.Home == true)
        {
            time.ins.PauseCountdown();
            PauseGame();
        }
    }
    public void CloseHint()
    {
        if (GameManager.ins.Home == true)
        {
            ResumeGame();
            time.ins.ResumeCountdown();
        }
        hint.GetComponent<RectTransform>().anchoredPosition = new Vector3(5000f, 5000f, 0f);
        hint.gameObject.SetActive(false);
    }

    public void OpenUnlockAll(int id)
    {
        AudioManager.ins.playClickshot();

        unlockAll.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        unlockAll.gameObject.SetActive(true);
        // unlockLev = id;

        Home.ins.OpenUnlockAllLevel();

    }
    public void PuTime()
    {
        amob.ShowRewardedAd(RewardType.Time, () => {
            time.ins.AddTime(120);
        });
        //  Adsmob.ins.ShowRewardedAd(numberAds);
    }

    public void UnlockAll()
    {
        amob.ShowRewardedAd(RewardType.Unlock, () => {
            numberAds();
        });
        //  Adsmob.ins.ShowRewardedAd(numberAds);
    }
    public void numberAds()
    {
        GameManager.ins.numberAds += 1;
        if (GameManager.ins.numberAds == 3)
        {
            ShowImage();
            Home.ins.unLockAll();
            CloseUnlockAll();
        }
        else
        {
            unlockLevel.ins.UnlockAll();
        }
    }
    private string keyTime = "ImageShowTime";
    public void ShowImage()
    {
        // Lưu thời gian hiện tại khi click
        DateTime now = DateTime.Now;
        PlayerPrefs.SetString(keyTime, now.ToString());
        PlayerPrefs.Save();

    }
    public void CloseUnlockAll()
    {
        Home.ins.CloseUnlockAllLevel();
        unlockAll.GetComponent<RectTransform>().anchoredPosition = new Vector3(-6000f, 5000f, 0f);
        unlockAll.gameObject.SetActive(true);
    }
    public void OpenUnlock(int id)
    {
        AudioManager.ins.playClickshot();

        unlock.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        unlock.gameObject.SetActive(true);
        unlockLev = id;
        Home.ins.OpenUnlockLevel();       
    }
    int unlockLev = 0;
    public void Unlock()
    {
        amob.ShowRewardedAd(RewardType.Unlock, () => {
            lockLev();
        });
        // Adsmob.ins.ShowRewardedAd(lockLev);
    }
    public void lockLev()
    {
        id_level = unlockLev;
        GameManager.ins.adslock = true;
        start_Game_Play();
        Home.ins.unLockLevel(unlockLev);
        CloseUnlock();

    }
    public void CloseUnlock()
    {
        Home.ins.CloseUnlockLevel();

        unlock.GetComponent<RectTransform>().anchoredPosition = new Vector3(-4000f, 5000f, 0f);
        unlock.gameObject.SetActive(false);
    }
    public void WinGame()
    {
        idf = id_level;
        AudioManager.ins.stop1shot();
        AudioManager.ins.stop2shot();
        AudioManager.ins.stop3shot();
        AudioManager.ins.stopmusicgame();

        firebaseLog(id_level);

        Home.ins.AddValue2(id_level);
        Home.ins.SaveData22();
        AudioManager.ins.play3shot(AudioManager.ins.lvcomplete);

        BG_XV.gameObject.SetActive(true);
        icon_V.gameObject.SetActive(true);
        icon_V.rectTransform.localScale = Vector3.zero;
        icon_V.rectTransform.DOScale(1f, 0.7f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            //StartCoroutine(StartInter());
          //  amob.ShowInterRetry();

            DOVirtual.DelayedCall(0.7f, () =>
            {
                OpenWin();
            });
        });

        WinGG();
    }
    public int idf = 0;
    bool GameEnd = false;
    public void WinGG()
    {
        id_level += 1;
        Debug.Log("id_level" + id_level);

        if (id_level < LevelGame)
        {
            int loadedScore = PlayerPrefs.GetInt("anoyme1");
            Debug.Log("loadedScore" + loadedScore);
            if (id_level < loadedScore)
            {

            }
            else
            {
                if (GameManager.ins.LockLv == true)
                {
                    Home.ins.AddValue(id_level);
                    Home.ins.SaveData();
                    loadelevelactive += 1;
                }
                else
                {
                    PlayerPrefs.SetInt("anoyme1", id_level);
                    PlayerPrefs.Save();
                }
            }
        }
        else
        {
            GameEnd = true;
        }



        int coins2 = PlayerPrefs.GetInt("txt_gold");
        int ai = coins2 + 100;
        PlayerPrefs.SetInt("txt_gold", ai);

    }


    public void OpenWin()
    {
        win.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        time.ins.PauseCountdown();
        win.gameObject.SetActive(true);
        Win.ins.OpenWin(idf);
        BG_XV.gameObject.SetActive(false);
        icon_V.gameObject.SetActive(false);

    }

    public void CloseWin()
    {
        AudioManager.ins.playClickshot();

        //  time.ins.ResumeCountdown();
        //   win.gameObject.SetActive(false);
        if (GameEnd == true)
        {
            closeSPlay();
        }
        else
        {
            start_Game_Play();
        }


    }
    public void OpenLose()
    {
        AudioManager.ins.stop1shot();
        AudioManager.ins.stop2shot();
        AudioManager.ins.stop3shot();
        AudioManager.ins.stopmusicgame();
        AudioManager.ins.play3shot(AudioManager.ins.lose);

        lose.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
      //  lose.transform.localScale = new Vector3(0f, 0f, 0f);
      //  lose.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);
        time.ins.PauseCountdown();
        lose.gameObject.SetActive(true);
        Lose.ins.OpenLose();
    }
    public void CloseLose()
    {
        time.ins.ResumeCountdown();
        lose.gameObject.SetActive(false);

    }
    public void closeSPlay()
    {
        AudioManager.ins.playClickshot();

        //amob.DestroyBannerAd();
//
        GameManager.ins.Pause = false;
        GameManager.ins.SPlay = true;
        GameManager.ins.Home = false;
        a_scene.gameObject.SetActive(true);
        a_scene.AnimationState.ClearTrack(1);
        a_scene.AnimationState.SetAnimation(1, "Close", false);
        AudioManager.ins.playClickshot2();
      //  N1HidePrefab();
      //  N2HidePrefab();


    }

    int id_level = 0;
    public void PlayLevel(int id)
    {
        AudioManager.ins.playClickshot();

        int loadedScore = PlayerPrefs.GetInt("anoyme1");
        //   Debug.Log("anoyme1=" + loadedScore);
        // 

        if (id <= loadedScore)
        {
            start_Game_Play();
            id_level = id;
        }
        else
        {
            Debug.Log(Home.ins.numbers.Contains(id));

            if (Home.ins.numbers.Contains(id))
            {
                start_Game_Play();
                id_level = id;
                GameManager.ins.LockLv = true;
            }
            else
            {
                OpenUnlock(id);
            }
        }
        Debug.Log(id_level);

    }

    public void PlayBT()
    {
        AudioManager.ins.playClickshot();

        int loadedScore = PlayerPrefs.GetInt("anoyme1");
        Debug.Log("loadedScore" + loadedScore);
        PlayLevel(loadedScore);
    }


    public void start_Game_Play()
    {
        //  amob.DestroyBannerAd();
       
        GameManager.ins.SHome = true;
        GameManager.ins.Home = true;
        a_scene.gameObject.SetActive(true);
        a_scene.AnimationState.ClearTrack(1);
        a_scene.AnimationState.SetAnimation(1, "Close", false);
        AudioManager.ins.playClickshot2();
       /// N1HidePrefab();
       // N2HidePrefab();
    }
    public void reSetGame()
    {
        AudioManager.ins.playClickshot();

      //  amob.DestroyBannerAd();

        GameManager.ins.RSET = true;
        a_scene.gameObject.SetActive(true);
        a_scene.AnimationState.ClearTrack(1);
        a_scene.AnimationState.SetAnimation(1, "Close", false);
        AudioManager.ins.playClickshot2();
       // N1HidePrefab();
       // N2HidePrefab();
    }
    public void rsG()
    {
        // SpawnMoveAndDestroy(prefabToSpawn1[id_level]);
        Debug.Log("rsG");
        if (id_level == 0)
        {
            Debug.Log("id_level");
            Level1.ins.startLevel();
        }
        else if (id_level == 1)
        {
            Debug.Log("id_level");
            Level2.ins.startLevel();
        }
        else if (id_level == 2)
        {
            Debug.Log("id_level");
            Level3.ins.startLevel();
        }
        else if (id_level == 3)
        {
            Debug.Log("id_level");
            Level4.ins.startLevel();
        }
        else if (id_level == 4)
        {
            Debug.Log("id_level");
            Level5.ins.startLevel();
        }
        else if (id_level == 5)
        {
            Debug.Log("id_level");
            Level2.ins.startLevel();
        }
    }
    public GameObject[] prefabToSpawn1;
    public Canvas parentCanvas;
    GameObject newObject;
    public void SpawnMoveAndDestroy(GameObject prefabToSpawn)
    {
         firebaseLog2(id_level);
        FirebaseAnalytics.LogEvent("Level");

        if (parentCanvas == null)
        {
            Debug.LogError("Parent canvas is not assigned.");
            return;
        }
        newObject = Instantiate(prefabToSpawn, parentCanvas.transform);
        newObject.transform.SetSiblingIndex(6);
        RectTransform rectTransform = newObject.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.anchoredPosition = new Vector3(0f, 0f, 0f);


            //  Destroy(newObject);

        }
        else
        {
            Debug.LogError("The prefab does not have a RectTransform component.");
        }
        SetStretch(newObject.GetComponent<RectTransform>());

    }
    public void SetStretch(RectTransform rect)
    {
        if (rect == null) return;

        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        rect.offsetMin = Vector2.zero;
        rect.offsetMax = Vector2.zero;
        rect.pivot = new Vector2(0.5f, 0.5f); // tuỳ bạn nếu cần pivot khác
        rect.localScale = Vector3.one;
    }
    //IAP
    public void IapVip()
    {
       // PlayerPrefs.SetInt("anoyme1", 20);
        //Home.ins.STHome();
       // LogOncePerDay();
    }
    void LogOncePerDay()
    {
        // Key lưu ngày đã log
        const string lastLogDateKey = "LastLogDate";

        // Ngày hiện tại dưới dạng string (yyyy-MM-dd)
        string todayDate = System.DateTime.Now.ToString("yyyy-MM-dd");

        // Kiểm tra PlayerPrefs
        string lastLoggedDate = PlayerPrefs.GetString(lastLogDateKey, "");

        if (lastLoggedDate != todayDate)
        {
            // Chưa log hôm nay -> log 100
            Debug.Log(100);
            int hiNum = PlayerPrefs.GetInt("hiGame");
            hiNum += 10;
            PlayerPrefs.SetInt("hiGame", hiNum);
            // Lưu ngày hôm nay để ngày mai mới log lại
            PlayerPrefs.SetString(lastLogDateKey, todayDate);
            PlayerPrefs.Save();
        }
        else
        {
            // Đã log rồi, không log nữa
            Debug.Log("Today already logged");
        }
    }
    /// <summary>
    /// --------------------IAP--------------
    /// </summary>
    public void IAP_BTVip()
    {
        Home.ins.a_lock.gameObject.SetActive(false);
        Home.ins.bt_Vip.gameObject.SetActive(false);

        ShopVipPop.gameObject.SetActive(false);
        Home.ins.unLockAll();

        IAP_BTRemoveAds();
        GameManager.ins.subs = true;
        PlayerPrefs.SetInt("vipIap", 1);
        PlayerPrefs.Save();
        LogOncePerDay();
    }
    public void IAP_BTBenefit()
    {
        // addGold();       
        int coins2 = PlayerPrefs.GetInt("txt_gold");
        coins2 += 3000;
        PlayerPrefs.SetInt("txt_gold", coins2);

        int hiNum = PlayerPrefs.GetInt("hiGame");
        hiNum += 30;
        PlayerPrefs.SetInt("hiGame", hiNum);

        PlayerPrefs.SetInt("benefitGame", 1);

        PlayerPrefs.Save();

        IAP_BTRemoveAds();
        Shop.ins.fr3.gameObject.SetActive(false);
    }
    public void IAP_BTSale()
    {
        int hiNum = PlayerPrefs.GetInt("hiGame");
        hiNum += 50;
        PlayerPrefs.SetInt("hiGame", hiNum);
        PlayerPrefs.Save();

        sale.gameObject.SetActive(false);

        IAP_BTRemoveAds();
    }
    public void IAP_BTHint(int id)
    {
        int hiNum = PlayerPrefs.GetInt("hiGame");
        hiNum += id;
        PlayerPrefs.SetInt("hiGame", hiNum);
        PlayerPrefs.Save();

    }
    public void IAP_BTRemoveAds()
    {
        Home.ins.a_sale.gameObject.SetActive(false);
        Shop.ins.btnoAds.gameObject.SetActive(false);

        PlayerPrefs.SetInt("Iap_Removeads", 1);
      //  amob.DestroyBannerAd();
    }
    public void IAP_ResetVip()
    {
        Home.ins.a_lock.gameObject.SetActive(true);
        Home.ins.bt_Vip.gameObject.SetActive(true);
        Home.ins.a_sale.gameObject.SetActive(true);

        PlayerPrefs.SetInt("anoyme1", 0);
        PlayerPrefs.SetInt("Iap_Removeads", 0);
        PlayerPrefs.SetInt("vipIap", 0);
        PlayerPrefs.SetInt("benefitGame", 0);

        PlayerPrefs.Save();

        Home.ins.STHome();
        //  amob.LoadBannerAd();

    }
    public void IAP_ResetVip2()
    {
        PlayerPrefs.SetInt("anoyme1", 0);
        PlayerPrefs.Save();
        Home.ins.STHome();
    }

    public void PauseGame()
    {
        if (id_level == 0)
        {
            Level1.ins.PauseAnimation();
        }
        else if (id_level == 1)
        {
            Level2.ins.PauseAnimation();
        }
        else if (id_level == 2)
        {
            Level3.ins.PauseAnimation();
        }
        else if (id_level == 3)
        {
            Level4.ins.PauseAnimation();
        }
        else if (id_level == 4)
        {
            Level5.ins.PauseAnimation();
        }
        else if (id_level == 5)
        {
            Level6.ins.PauseAnimation();
        }
        else if (id_level == 6)
        {
            Level7.ins.PauseAnimation();
        }
        else if (id_level == 7)
        {
            Level8.ins.PauseAnimation();
        }
        else if (id_level == 8)
        {
            Level9.ins.PauseAnimation();
        }
        else if (id_level == 9)
        {
            Level10.ins.PauseAnimation();
        }
        else if (id_level == 10)
        {
            Level11.ins.PauseAnimation();
        }
        else if (id_level == 11)
        {
            Level12.ins.PauseAnimation();
        }
        else if (id_level == 12)
        {
            Level13.ins.PauseAnimation();
        }
        else if (id_level == 13)
        {
            Level14.ins.PauseAnimation();
        }
        else if (id_level == 14)
        {
            Level15.ins.PauseAnimation();
        }
        else if (id_level == 15)
        {
            Level16.ins.PauseAnimation();
        }
        else if (id_level == 16)
        {
            Level17.ins.PauseAnimation();
        }
        else if (id_level == 17)
        {
            Level18.ins.PauseAnimation();
        }
        else if (id_level == 18)
        {
            Level19.ins.PauseAnimation();
        }
        else if (id_level == 19)
        {
            Level20.ins.PauseAnimation();
        }
        else if (id_level == 20)
        {
            Level21.ins.PauseAnimation();
        }
        else if (id_level == 21)
        {
            Level22.ins.PauseAnimation();
        }
        else if (id_level == 22)
        {
            Level23.ins.PauseAnimation();
        }
        else if (id_level == 23)
        {
            Level24.ins.PauseAnimation();
        }
        else if (id_level == 24)
        {
            Level25.ins.PauseAnimation();
        }
        else if (id_level == 25)
        {
            Level26.ins.PauseAnimation();
        }
        else if (id_level == 26)
        {
            Level27.ins.PauseAnimation();
        }
        else if (id_level == 27)
        {
            Level28.ins.PauseAnimation();
        }
        else if (id_level == 28)
        {
            Level29.ins.PauseAnimation();
        }
        else if (id_level == 29)
        {
            Level30.ins.PauseAnimation();
        }
    }
    public void ResumeGame()
    {
        if (id_level == 0)
        {
            Level1.ins.ResumeAnimation();
        }
        else if (id_level == 1)
        {
            Level2.ins.ResumeAnimation();
        }
        else if (id_level == 2)
        {
            Level3.ins.ResumeAnimation();
        }
        else if (id_level == 3)
        {
            Level4.ins.ResumeAnimation();
        }
        else if (id_level == 4)
        {
            Level5.ins.ResumeAnimation();
        }
        else if (id_level == 5)
        {
            Level6.ins.ResumeAnimation();
        }
        else if (id_level == 6)
        {
            Level7.ins.ResumeAnimation();
        }
        else if (id_level == 7)
        {
            Level8.ins.ResumeAnimation();
        }
        else if (id_level == 8)
        {
            Level9.ins.ResumeAnimation();
        }
        else if (id_level == 9)
        {
            Level10.ins.ResumeAnimation();
        }
        else if (id_level == 10)
        {
            Level11.ins.ResumeAnimation();
        }
        else if (id_level == 11)
        {
            Level12.ins.ResumeAnimation();
        }
        else if (id_level == 12)
        {
            Level13.ins.ResumeAnimation();
        }
        else if (id_level == 13)
        {
            Level14.ins.ResumeAnimation();
        }
        else if (id_level == 14)
        {
            Level15.ins.ResumeAnimation();
        }
        else if (id_level == 15)
        {
            Level16.ins.ResumeAnimation();
        }
        else if (id_level == 16)
        {
            Level17.ins.ResumeAnimation();
        }
        else if (id_level == 17)
        {
            Level18.ins.ResumeAnimation();
        }
        else if (id_level == 18)
        {
            Level19.ins.ResumeAnimation();
        }
        else if (id_level == 19)
        {
            Level20.ins.ResumeAnimation();
        }
        else if (id_level == 20)
        {
            Level21.ins.ResumeAnimation();
        }
        else if (id_level == 21)
        {
            Level22.ins.ResumeAnimation();
        }
        else if (id_level == 22)
        {
            Level23.ins.ResumeAnimation();
        }
        else if (id_level == 23)
        {
            Level24.ins.ResumeAnimation();
        }
        else if (id_level == 24)
        {
            Level25.ins.ResumeAnimation();
        }
        else if (id_level == 25)
        {
            Level26.ins.ResumeAnimation();
        }
        else if (id_level == 26)
        {
            Level27.ins.ResumeAnimation();
        }
        else if (id_level == 27)
        {
            Level28.ins.ResumeAnimation();
        }
        else if (id_level == 28)
        {
            Level29.ins.ResumeAnimation();
        }
        else if (id_level == 29)
        {
            Level30.ins.ResumeAnimation();
        }
    }

   

    [Header("Prefab cần sinh")]
    public GameObject N1prefab;

    private GameObject N1currentInstance; // tham chiếu đến prefab đã sinh ra
    [Header("Vị trí cha để đặt prefab")]
    public Transform N1parentContainer;
    // Tạo 1 prefab mới (và xóa cũ nếu có)
    public void N1SpawnOnePrefab()
    {
        int cremove = PlayerPrefs.GetInt("W2_removeads");
        if (cremove != 1)
        {
            // Xoá prefab cũ nếu đã có
            if (N1currentInstance != null)
            {
                Destroy(N1currentInstance);
            }

            // Sinh prefab mới
            N1currentInstance = Instantiate(N1prefab, N1parentContainer);
            N1currentInstance.name = "N1";
            N1currentInstance.transform.localScale = Vector3.one;
            N1currentInstance.GetComponent<RectTransform>().anchoredPosition = new Vector3(2000, 2000, 0);

            ///  ShowPrefab2();
            //N1HidePrefab();
        }

    }

    // Ẩn prefab (nếu đã tạo)
    public void N1HidePrefab()
    {
        int cremove = PlayerPrefs.GetInt("W2_removeads");
        if (cremove != 1)
        {
            if (N1currentInstance != null)
            {
                N1currentInstance.SetActive(false);
            }
        }

    }

    // Hiện lại prefab 
    public void N1ShowPrefab()
    {
        FirebaseAnalytics.LogEvent("Native_Start");

        int cremove = PlayerPrefs.GetInt("W2_removeads");
        if (cremove != 1)
        {
            Debug.Log("ShowPrefab2");
            if (N1currentInstance != null)
            {
             //   FirebaseAnalytics.LogEvent("Native_Done");

                N1currentInstance.SetActive(true);
                RectTransform rect = N1currentInstance.GetComponent<RectTransform>();
                rect.anchoredPosition = new Vector3(0, 50, 0);

                // Reset scale về nhỏ rồi scale lên mượt
                rect.localScale = Vector3.zero;
                rect.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack);
            }
        }
    }

    // Xóa hoàn toàn prefab
    public void N1DestroyPrefab()
    {
        if (N1currentInstance != null)
        {
            Debug.Log("Navi_new1_Destroy");

            Destroy(N1currentInstance);
            N1currentInstance = null;
        }
    }

    [Header("Prefab cần sinh")]
    public GameObject N2prefab;

    private GameObject N2currentInstance; // tham chiếu đến prefab đã sinh ra

    // Tạo 1 prefab mới (và xóa cũ nếu có)
    public void N2SpawnOnePrefab()
    {
        int cremove = PlayerPrefs.GetInt("W2_removeads");
        if (cremove != 1)
        {
            Debug.Log("N2SpawnOnePrefabN2SpawnOnePrefabN2SpawnOnePrefab");
            // Xoá prefab cũ nếu đã có
            if (N2currentInstance != null)
            {
                Destroy(N2currentInstance);
            }

            // Sinh prefab mới
            N2currentInstance = Instantiate(N2prefab, N1parentContainer);
            N2currentInstance.name = "N2";
            N2currentInstance.transform.localScale = Vector3.one;
            N2currentInstance.GetComponent<RectTransform>().anchoredPosition = new Vector3(2000, 2000, 0);

            ///  ShowPrefab2();
            //N2HidePrefab();
        }

    }

    // Ẩn prefab (nếu đã tạo)
    public void N2HidePrefab()
    {
        int cremove = PlayerPrefs.GetInt("W2_removeads");
        if (cremove != 1)
        {
            if (N2currentInstance != null)
            {
                N2currentInstance.SetActive(false);
            }
        }

    }

    // Hiện lại prefab
    public void N2ShowPrefab()
    {
        int cremove = PlayerPrefs.GetInt("W2_removeads");
        if (cremove != 1)
        {
            Debug.Log("ShowPrefab2");
            if (N2currentInstance != null)
            {
             //   FirebaseAnalytics.LogEvent("Native_backhome");

                N2currentInstance.SetActive(true);
                RectTransform rect = N2currentInstance.GetComponent<RectTransform>();
                rect.anchoredPosition = new Vector3(0, 350, 0);

                // Reset scale về nhỏ rồi scale lên mượt
                rect.localScale = Vector3.zero;
                rect.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack).SetDelay(2f);
            }
        }


    }

    // Xóa hoàn toàn prefab
    public void N2DestroyPrefab()
    {

        if (N2currentInstance != null)
        {
            Debug.Log("Navi_new2_Destroy");

            Destroy(N2currentInstance);
            N2currentInstance = null;
        }


    }



    void firebaseLog(int id)
    {
        //Firebase.Analytics.FirebaseAnalytics.LogEvent("level_complete", "level_number", id);
        string userName = System.Environment.UserName;
        Firebase.Analytics.FirebaseAnalytics.LogEvent(
        Firebase.Analytics.FirebaseAnalytics.EventLevelUp,
        new Firebase.Analytics.Parameter[] {
            new Firebase.Analytics.Parameter(
            Firebase.Analytics.FirebaseAnalytics.ParameterCharacter, userName),
            new Firebase.Analytics.Parameter(
            Firebase.Analytics.FirebaseAnalytics.ParameterLevel, id),
             });

        LogAllUsersProgress(id);
    }
    void LogAllUsersProgress(int level)
    {
        for (int i = 1; i <= 30; i++)
        {
            string userName = "User" + i;
            int currentLevel = level;  // Giả sử mỗi người dùng hoàn thành cấp độ ngẫu nhiên từ 1 đến 10
                                       // LogLevelProgress(userName, currentLevel);
            if (i == level)
            {
                Firebase.Analytics.FirebaseAnalytics.LogEvent("hoanthanhLev_" + i, "level_number", 1);

            }

        }
    }
    void firebaseLog2(int id)
    {
        Debug.Log("firebaseLog2firebaseLog2firebaseLog2");
        //Firebase.Analytics.FirebaseAnalytics.LogEvent("level_complete", "level_number", id);
        string userName = System.Environment.UserName;
        Firebase.Analytics.FirebaseAnalytics.LogEvent(
        Firebase.Analytics.FirebaseAnalytics.EventLevelUp,
        new Firebase.Analytics.Parameter[] {
            new Firebase.Analytics.Parameter(
            Firebase.Analytics.FirebaseAnalytics.ParameterCharacter, userName),
            new Firebase.Analytics.Parameter(
            Firebase.Analytics.FirebaseAnalytics.ParameterLevel, id),
             });

        LogAllUsersProgress2(id);
    }
    void LogAllUsersProgress2(int level)
    {
        for (int i = 1; i <= 30; i++)
        {
            string userName = "User" + i;
            int currentLevel = level;  // Giả sử mỗi người dùng hoàn thành cấp độ ngẫu nhiên từ 1 đến 10
                                       // LogLevelProgress(userName, currentLevel);
            if (i == level)
            {
                Firebase.Analytics.FirebaseAnalytics.LogEvent("Lev_" + i, "level_number", 1);

            }

        }
    }
}
