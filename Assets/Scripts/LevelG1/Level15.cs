using Spine.Unity;
using Spine;
using System.Collections;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Level15 : MonoBehaviour
{
    public static Level15 ins;
    public Image bg, girl1, girl2, bowl, fridge1, fridge2, wd_1, wd_2, soco1, cabbage1, carot1, chicken1, water, cream1, cucumber1, drag, egg1, fish1, hair,
        img, mushroom1, mushroom2, mushroom3, melon1, pot1, pot2, noodeles,b1,b2,
        cabbage2, soco2, melon2, mushroom4, carot2, cream2, fish2, chicken2, egg2, cucumber2;
    public SkeletonGraphic a_girl1, a_girl2;
    private void Awake()
    {
        Level15.ins = this;
    }
    private void Start()
    {
        startLevel();
    }
    public void startLevel()
    {
        bg.gameObject.SetActive(true);
        girl1.gameObject.SetActive(true);
        girl2.gameObject.SetActive(false);
        bowl.gameObject.SetActive(true);
        fridge1.gameObject.SetActive(true);
        fridge2.gameObject.SetActive(false);
        wd_1.gameObject.SetActive(true);
        wd_2.gameObject.SetActive(false);
        soco1.gameObject.SetActive(true );
        cabbage1.gameObject.SetActive(true);
        carot1.gameObject.SetActive(false);
        chicken1.gameObject.SetActive(false);
        water.gameObject.SetActive(false);
        cream1.gameObject.SetActive(false);
        cucumber1.gameObject.SetActive(false);
        drag.gameObject.SetActive(true);
        egg1.gameObject.SetActive(true);
        fish1.gameObject.SetActive(true);
        hair.gameObject.SetActive(false);
        img.gameObject.SetActive(true);
        mushroom1.gameObject.SetActive(true);
        mushroom2.gameObject.SetActive(true);
        mushroom3.gameObject.SetActive(true);
        melon1.gameObject.SetActive(true);
        pot1.gameObject.SetActive(true);
        pot2.gameObject.SetActive(true);
        noodeles.gameObject.SetActive(false);
        cabbage2.gameObject.SetActive(false);
        soco2.gameObject.SetActive(false);
        melon2.gameObject.SetActive(false);
        mushroom4.gameObject.SetActive(false);
        carot2.gameObject.SetActive(false);
        cream2.gameObject.SetActive(false);
        fish2.gameObject.SetActive(false);
        chicken2.gameObject.SetActive(false);
        egg2.gameObject.SetActive(false);
        cucumber2.gameObject.SetActive(false);

        b1.gameObject.SetActive(true);
        b2.gameObject.SetActive(false);

        a_girl1.gameObject.SetActive(false);
        a_girl2.gameObject.SetActive(false);

        acheck = false;
        a_girl1.AnimationState.Complete += OnAnimationComplete;
        a_girl2.AnimationState.Complete += OnAnimationComplete2;
        frBg2.gameObject.SetActive(false);
        Bg_black2.gameObject.SetActive(false);
        l15aab = 0;
        AudioManager.ins.playmusicgame(AudioManager.ins.muisgame);

    }
    public void PauseAnimation()
    {
    }

    public void ResumeAnimation()
    {
    }
    public void OnAnimationComplete(TrackEntry trackEntry)
    {
        a_girl1.gameObject.SetActive(false);
    }
    public void OnAnimationComplete2(TrackEntry trackEntry)
    {
        a_girl2.gameObject.SetActive(false);
    }
    public int l15aab = 0;

    public bool acheck = false;
    public int gameover = 0;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy

    public void gameOver()
    {
        if (acheck == false)
        {
            a_girl1.gameObject.SetActive(true);

            Level15.ins.a_girl1.AnimationState.SetAnimation(1, "animation", false);

        }else
        {
            a_girl2.gameObject.SetActive(true);

            Level15.ins.a_girl2.AnimationState.SetAnimation(1, "animation", false);

        }
        gameover += 1;
        if (gameover == 11)
        {
            textCoroutine2 = StartCoroutine(ENDGAME());

        }

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
        yield return new WaitForSeconds(2.5f);
        frBg2.gameObject.SetActive(false);
        Bg_black2.gameObject.SetActive(false);
        textCoroutine = null; // Reset lại khi hoàn thành
    }
}