using Spine.Unity;
using Spine;
using System.Collections;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Level16 : MonoBehaviour
{
    public static Level16 ins;
    public Image bg, shoe, stick, bucket, cat, dumbell, wheel1, wheel2, wheel3, wheel4, waterbottle,
        watermelon, app1, app2, app3, app1_2, app2_2, app3_2, app1_3, app2_3, app3_3, a2, a3;
    public SkeletonGraphic a_boy, a_bucket, a_bucket2, a_cat, a_dumbell, a_pumkin,
        a_shoe, a_stick, a_watermelon, a_waterbottle1, a_waterbottle2, a_wheel;
    private void Awake()
    {
        Level16.ins = this;
    }
    private void Start()
    {
        startLevel();
    }
    public void startLevel()
    {
        bg.gameObject.SetActive(true);
        shoe.gameObject.SetActive(true);
        stick.gameObject.SetActive(true);
        bucket.gameObject.SetActive(true);
        cat.gameObject.SetActive(true);
        dumbell.gameObject.SetActive(true);
        wheel1.gameObject.SetActive(true);
        wheel2.gameObject.SetActive(true);
        wheel3.gameObject.SetActive(false);
        wheel4.gameObject.SetActive(false);

        waterbottle.gameObject.SetActive(true);
        watermelon.gameObject.SetActive(true);
        app1.gameObject.SetActive(true);
        app2.gameObject.SetActive(true);
        app3.gameObject.SetActive(true);

        app1_2.gameObject.SetActive(false);
        app2_2.gameObject.SetActive(false);
        app3_2.gameObject.SetActive(false);

        app1_3.gameObject.SetActive(false);
        app2_3.gameObject.SetActive(false);
        app3_3.gameObject.SetActive(false);
        a2.gameObject.SetActive(false);
        a3.gameObject.SetActive(false);

        a_boy.gameObject.SetActive(true);
        a_bucket.gameObject.SetActive(false);
        a_bucket2.gameObject.SetActive(false);
        a_cat.gameObject.SetActive(false);
        a_dumbell.gameObject.SetActive(false);
        a_pumkin.gameObject.SetActive(false);
        a_shoe.gameObject.SetActive(false);
        a_stick.gameObject.SetActive(false);
        a_watermelon.gameObject.SetActive(false);
        a_waterbottle1.gameObject.SetActive(false);
        a_waterbottle2.gameObject.SetActive(false);

        a_wheel.gameObject.SetActive(false);

        estry = false; estry2 = false;
        a_cat.AnimationState.SetAnimation(1, "animation", true);
        entry1 = a_boy.AnimationState.SetAnimation(1, "animation", true);
        a_waterbottle2.AnimationState.Complete += OnAnimationComplete;
        frBg2.gameObject.SetActive(false);
        Bg_black2.gameObject.SetActive(false); AudioManager.ins.playmusicgame(AudioManager.ins.muisgame);

    }
    public void PauseAnimation()
    {
        a_boy.timeScale = 0; // Dừng Spine Animation
        a_bucket.timeScale = 0;
        a_bucket2.timeScale = 0;
        a_dumbell.timeScale = 0;
        a_pumkin.timeScale = 0;
        a_shoe.timeScale = 0;
        a_stick.timeScale = 0;
        a_watermelon.timeScale = 0;
        a_waterbottle1.timeScale = 0;
        a_waterbottle2.timeScale = 0;
        a_wheel.timeScale = 0;

    }

    public void ResumeAnimation()
    {
        a_boy.timeScale = 1; // Dừng Spine Animation
        a_bucket.timeScale = 1;
        a_bucket2.timeScale = 1;
        a_dumbell.timeScale = 1;
        a_pumkin.timeScale = 1;
        a_shoe.timeScale = 1;
        a_stick.timeScale = 1;
        a_watermelon.timeScale = 1;
        a_waterbottle1.timeScale = 1;
        a_waterbottle2.timeScale = 1;
        a_wheel.timeScale = 1;
        entrysss();
    }
    public Spine.TrackEntry entry1, entry2, entry3, entry4, entry5, entry6, entry7, entry8;
    public bool estry = false, estry2 = false;
    public void OnAnimationComplete(TrackEntry trackEntry)
    {
        Level16.ins.a_waterbottle1.gameObject.SetActive(false);
        Level16.ins.a_waterbottle2.gameObject.SetActive(false);
        Level16.ins.a_bucket2.gameObject.SetActive(true);

        Level16.ins.entry8 = Level16.ins.a_bucket2.AnimationState.SetAnimation(1, "animation", true);
        Level16.ins.entrysss();
    }
    public void entrysss()
    {
        if (Level16.ins.estry == false)
        {
            if (entry1 != null)
            {
                if (entry2 != null) entry2.TrackTime = entry1.TrackTime;
                if (entry3 != null) entry3.TrackTime = entry1.TrackTime;
                if (entry4 != null) entry4.TrackTime = entry1.TrackTime;
                if (entry5 != null) entry5.TrackTime = entry1.TrackTime;
                if (entry6 != null) entry6.TrackTime = entry1.TrackTime;
                if (entry7 != null) entry7.TrackTime = entry1.TrackTime;
                if (entry8 != null) entry8.TrackTime = entry1.TrackTime;

            }
        }
        else
        {
            if (entry3 != null)
            {
                if (entry2 != null) entry2.TrackTime = entry3.TrackTime;
                if (entry4 != null) entry4.TrackTime = entry3.TrackTime;
                if (entry5 != null) entry5.TrackTime = entry3.TrackTime;
                if (entry6 != null) entry6.TrackTime = entry3.TrackTime;
                if (entry7 != null) entry7.TrackTime = entry3.TrackTime;
                if (entry8 != null) entry8.TrackTime = entry3.TrackTime;

            }
        }

    }
    public int gameover = 0;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy

    public void gameOver()
    {
        if (gameover == 7)
        {
            Level16.ins.chageString("lev16_3");

            textCoroutine2 = StartCoroutine(ENDGAME());

        }

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

        // Nếu đã có Coroutine cũ đang chạy, dừng nó ngay lập tức
        if (textCoroutine != null)
        {
            StopCoroutine(textCoroutine);
        }

        // Bắt đầu Coroutine mới và lưu lại
        textCoroutine = StartCoroutine(ShowTextName2());
    }

    public IEnumerator ShowTextName2()
    {
        yield return new WaitForSeconds(2.5f);
        frBg2.gameObject.SetActive(false);
        Bg_black2.gameObject.SetActive(false);
        textCoroutine = null; // Reset lại khi hoàn thành

    }
}
