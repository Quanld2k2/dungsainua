using Spine.Unity;
using Spine;
using System.Collections;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Level17 : MonoBehaviour
{
    public static Level17 ins;
    public Image bg, door2, toilet1, toilet_water, toilet2, toilet_m, door1, air1, air_m, air2, wall_m, wall1, cabinet2,
        cabinet3, clothe1, clothe2, hammer, cabinet1, safe2, safe_m, safe3, crack1, crack_m, crack2, piture, box1, box_m, carpet1, sofa1,
        tear1, tear_m, tear2, tear2_m, boy, boy2, key, boy_m, girl1, flower, cabinet_m, drag, a2, a3, money1, money2, toilet_suction, t1;
    public SkeletonGraphic a_win, a_toilet_water, a_toilet_suc, a_hammer, a_girl;
    private void Awake()
    {
        Level17.ins = this;
    }
    private void Start()
    {
        startLevel();
    }
    public void startLevel()
    {
        bg.gameObject.SetActive(true);

        door2.gameObject.SetActive(false);
        toilet1.gameObject.SetActive(false);
        toilet_water.gameObject.SetActive(false);
        toilet2.gameObject.SetActive(false);
        toilet_m.gameObject.SetActive(false);
        toilet_suction.gameObject.SetActive(false);
        door1.gameObject.SetActive(true);

        air1.gameObject.SetActive(false);
        air_m.gameObject.SetActive(false);
        air2.gameObject.SetActive(true);
        wall_m.gameObject.SetActive(true);
        wall1.gameObject.SetActive(true);
        cabinet2.gameObject.SetActive(false);

        cabinet_m.gameObject.SetActive(false);
        drag.gameObject.SetActive(false);

        cabinet3.gameObject.SetActive(false);
        clothe1.gameObject.SetActive(false);
        clothe2.gameObject.SetActive(false);
        hammer.gameObject.SetActive(false);
        cabinet1.gameObject.SetActive(true);

        safe2.gameObject.SetActive(false);
        safe_m.gameObject.SetActive(false);
        safe3.gameObject.SetActive(true);

        crack1.gameObject.SetActive(false);
        crack_m.gameObject.SetActive(false);
        crack2.gameObject.SetActive(false);
        piture.gameObject.SetActive(true);
        box1.gameObject.SetActive(false);
        box_m.gameObject.SetActive(false);
        carpet1.gameObject.SetActive(true);

        sofa1.gameObject.SetActive(true);
        tear1.gameObject.SetActive(false);
        tear_m.gameObject.SetActive(false);
        tear2_m.gameObject.SetActive(false);
        boy.gameObject.SetActive(true);
        tear2.gameObject.SetActive(false);

        key.gameObject.SetActive(false);
        boy2.gameObject.SetActive(true);
        boy_m.gameObject.SetActive(false);
        girl1.gameObject.SetActive(false);
        flower.gameObject.SetActive(true);
        money1.gameObject.SetActive(false);
        money2.gameObject.SetActive(false);
        t1.gameObject.SetActive(false);

        frBg2.gameObject.SetActive(false);
        Bg_black2.gameObject.SetActive(false);

        a_win.gameObject.SetActive(false);
        a_toilet_water.gameObject.SetActive(false);
        a_toilet_suc.gameObject.SetActive(false);
        a_hammer.gameObject.SetActive(false);
        a_girl.gameObject.SetActive(true);

        a_girl.AnimationState.SetAnimation(1, "animation", true);
        a_hammer.AnimationState.Complete += OnAnimationComplete;
        a_toilet_suc.AnimationState.Complete += OnAnimationComplete2;
        ResetMoney();

        ac1 = false;
        ST = false;
        Level17.ins.chageString("lev17_1");
        aatd = 0; AudioManager.ins.playmusicgame(AudioManager.ins.muisgame);

    }
    public void PauseAnimation()
    {
        a_girl.timeScale = 0; // Dừng Spine Animation
        a_toilet_suc.timeScale = 0;
    }

    public void ResumeAnimation()
    {
        a_girl.timeScale = 1;
        a_toilet_suc.timeScale = 1;
    }
    public int aatd = 0;
    public bool ST = false;
    public bool ac1 = false;
    public void OnAnimationComplete(TrackEntry trackEntry)
    {
        Level17.ins.a_hammer.gameObject.SetActive(false);
        crack2.gameObject.SetActive(false);
        crack1.gameObject.SetActive(true);
        crack_m.gameObject.SetActive(true);
    }
    public void OnAnimationComplete2(TrackEntry trackEntry)
    {   
        a_toilet_suc.gameObject.SetActive(false);
        a_toilet_water.gameObject.SetActive(true);
        a_toilet_water.AnimationState.SetAnimation(1, "animation", true);
        money2.gameObject.SetActive(true);

    }
    public Text moneyText;
    public int maxMoney = 10000000;
    public float duration = 0.5f;

    private int currentMoney = 0;
    private Coroutine animCoroutine;

    public delegate void OnFullMoneyDelegate();
    public event OnFullMoneyDelegate OnFullMoney; // Sự kiện khi đủ tiền

    public void AddMoney(int amount)
    {
        Level17.ins.chageString("lev17_3");

        int newMoney = currentMoney + amount;

        if (animCoroutine != null)
            StopCoroutine(animCoroutine);

        animCoroutine = StartCoroutine(AnimateMoney(currentMoney, newMoney));
        currentMoney = newMoney;
    }

    IEnumerator AnimateMoney(int from, int to)
    {
        float elapsed = 0f;

       while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            int value = Mathf.RoundToInt(Mathf.Lerp(from, to, t));
            moneyText.text = $"Tiền: {value:N0}/{maxMoney:N0}";
            yield return null;
       }

        moneyText.text = $"Tiền: {to:N0}/{maxMoney:N0}";

       CheckIfFull();
    }

    public void CheckIfFull()
    {
        if (currentMoney >= maxMoney)
        {
            Debug.Log("Đã đủ tiền!");
            textCoroutine2 = StartCoroutine(ENDGAME());
         //   OnFullMoney?.Invoke(); // Gọi sự kiện nếu có ai đăng ký
        }
    }

    // Nếu cần reset:
    public void ResetMoney()
    {
        currentMoney = 0;
        moneyText.text = $"Tiền: {currentMoney:N0}/{maxMoney:N0}";
    }


    public bool acheck = false;
    public int gameover = 0;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy

    public void gameOver()
    {

    }
    public void overGG()
    {
        textCoroutine2 = StartCoroutine(ENDOVER());

    }
    public IEnumerator ENDGAME()
    {
        yield return new WaitForSeconds(1f);
        UiController.ins.WinGame();
    }
    public IEnumerator ENDOVER()
    {
        yield return new WaitForSeconds(1f);
        UiController.ins.OpenLose();
    }
    // doi ngon ngu
    public Image frBg2, Bg_black2;
    public Text text2;
    public LocalizeStringEvent localizeStringEvent2;

    public void ChangeDialogue(string key)
    {
        if (localizeStringEvent2 != null)
        {
            localizeStringEvent2.StringReference.TableEntryReference = key;
            localizeStringEvent2.RefreshString();
        }
        else
        {
            Debug.LogError("LocalizeStringEvent is not set.");
        }
    }
    public void OnChangeLanguage(int languageIndex)
    {
        Debug.Log(languageIndex);
        // Thay đổi ngôn ngữ (0: English, 1: Vietnamese, ...)
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[languageIndex];
    }
    private Coroutine textCoroutine; // Lưu trữ coroutine đang chạy

    public void chageString(string Ai)
    {
        Bg_black2.gameObject.SetActive(true);
        frBg2.gameObject.SetActive(true);
        ChangeDialogue(Ai);
        if (textCoroutine != null)
        {
            StopCoroutine(textCoroutine);
        }
        textCoroutine = StartCoroutine(ShowTextName2());
    }

    public IEnumerator ShowTextName2()
    {
        yield return new WaitForSeconds(2f);
        frBg2.gameObject.SetActive(false);
        Bg_black2.gameObject.SetActive(false);
        textCoroutine = null; // Reset lại khi hoàn thành
        if (ST == false)
        {
            Level17.ins.chageString("lev17_2");
            ST = true;
        }


    }
}
