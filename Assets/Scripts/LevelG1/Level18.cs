using Spine.Unity;
using Spine;
using System.Collections;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Level18 : MonoBehaviour
{
    public static Level18 ins;
    public GameObject bg, bin1, bin2, table, door1, door2, pic, door3, door4,
                   sofa, key, carpet, carpet1, longman,
                   pillow1, pillow2, pillow3, bear, knife, dieukhien, air1,
                   _1, _2, _3, _4, _5, _6, _7, _8, _9, _10;

    public SkeletonGraphic a_girl, a_bear, a_air;

    public SkeletonGraphic[] a_run;
    private void Awake()
    {
        Level18.ins = this;
    }
    private void Start()
    {
        startLevel();
    }
    public void startLevel()
    {
        bg.gameObject.SetActive(true);
        bin1.gameObject.SetActive(true);
        bin2.gameObject.SetActive(false);
        table.gameObject.SetActive(true);
        door1.gameObject.SetActive(true);
        door2.gameObject.SetActive(false);
        pic.gameObject.SetActive(true);
        door3.gameObject.SetActive(true);
        door4.gameObject.SetActive(false);
        sofa.gameObject.SetActive(true);
        key.gameObject.SetActive(false);
        carpet.gameObject.SetActive(true);
        carpet1.gameObject.SetActive(false);
        longman.gameObject.SetActive(true);
        pillow1.gameObject.SetActive(true);
        pillow2.gameObject.SetActive(true);
        pillow3.gameObject.SetActive(true);
        bear.gameObject.SetActive(true);
        knife.gameObject.SetActive(false);
        dieukhien.gameObject.SetActive(true);
        air1.gameObject.SetActive(true);

        _1.gameObject.SetActive(false);
        _2.gameObject.SetActive(true);
        _3.gameObject.SetActive(false);
        _4.gameObject.SetActive(true);
        _5.gameObject.SetActive(true);
        _6.gameObject.SetActive(true);
        _7.gameObject.SetActive(true);
        _8.gameObject.SetActive(false);
        _9.gameObject.SetActive(false);
        _10.gameObject.SetActive(false);

        a_girl.gameObject.SetActive(true);
        a_girl.AnimationState.SetAnimation(1, "animation", true);

        a_bear.gameObject.SetActive(false);
        a_air.gameObject.SetActive(false);

        frBg2.gameObject.SetActive(false);
        Bg_black2.gameObject.SetActive(false);

        for (int i = 0; i < a_run.Length; i ++)
        {
            a_run[i].gameObject.SetActive(false);

        }
        a_bear.AnimationState.Complete += OnAnimationComplete1;
        AudioManager.ins.playmusicgame(AudioManager.ins.muisgame);

    }
    public void PauseAnimation()
    {
        a_girl.timeScale = 0; // Dừng Spine Animation
        a_air.timeScale = 0;
        for (int i = 0; i < a_run.Length; i++)
        {
            a_run[i].timeScale = 0;
        }
    }

    public void ResumeAnimation()
    {
        a_girl.timeScale = 1;
        a_air.timeScale = 1;
        for(int i = 0; i < a_run.Length; i++)
        {
            a_run[i].timeScale = 1;
        }
    }
    public void OnAnimationComplete1(TrackEntry trackEntry)
    {
        a_bear.gameObject.SetActive(false);
        _9.gameObject.SetActive(true);

        //a_stone.gameObject.SetActive(false);

    }
    public int nubm = 0;

    public int gameover = 0;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy
    public void endGame()
    {
        Debug.Log("endgame"+ gameover);
        if (gameover == 10)
        {
            textCoroutine2 = StartCoroutine(ENDGAME());
            Debug.Log("gameover");
        }

    }
    public IEnumerator ENDGAME()
    {
        yield return new WaitForSeconds(1f);
        UiController.ins.WinGame();
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