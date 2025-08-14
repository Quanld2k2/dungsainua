using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Spine.Unity;
using Spine;
using System.Collections;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;
public class Level10 : MonoBehaviour
{
    public static Level10 ins;
    public Image bg, bin, bottle, hole, pool1, pool2, scissors, frog1, girl, shovel, money, table, food,
        water_tap, poster, sunscreen, tree, garbage1, garbage2, garbage3, char1, dog1, dog2, boy2, boy3, x, x2, apple1, apple2;
    public SkeletonGraphic a_boy, a_pic, a_shole1, a_shole2, a_water;
    private void Awake()
    {
        Level10.ins = this;
    }
    private void Start()
    {
        bg.gameObject.SetActive(true);
        bin.gameObject.SetActive(true);
        bottle.gameObject.SetActive(true);
        hole.gameObject.SetActive(false);
        pool1.gameObject.SetActive(true);
        pool2.gameObject.SetActive(false);
        scissors.gameObject.SetActive(true);
        frog1.gameObject.SetActive(true);
        girl.gameObject.SetActive(false);
        shovel.gameObject.SetActive(true);
        money.gameObject.SetActive(false);
        table.gameObject.SetActive(true);
        food.gameObject.SetActive(false);
        water_tap.gameObject.SetActive(true);
        poster.gameObject.SetActive(true);
        sunscreen.gameObject.SetActive(true);
        tree.gameObject.SetActive(true);
        garbage1.gameObject.SetActive(true);
        garbage2.gameObject.SetActive(true);
        garbage3.gameObject.SetActive(true);
        char1.gameObject.SetActive(true);
        dog1.gameObject.SetActive(true);
        dog2.gameObject.SetActive(false);
        boy2.gameObject.SetActive(false);
        boy3.gameObject.SetActive(false);
        x.gameObject.SetActive(true);
        x2.gameObject.SetActive(true);
        apple1.gameObject.SetActive(true);
        apple2.gameObject.SetActive(true);
        a_boy.gameObject.SetActive(true);
        a_pic.gameObject.SetActive(false);
        a_shole1.gameObject.SetActive(false);
        a_shole2.gameObject.SetActive(false);
        a_water.gameObject.SetActive(false);

        a_boy.AnimationState.Complete += OnAnimationComplete;
        a_boy.AnimationState.SetAnimation(1, "animation", true);
        a_shole1.AnimationState.Complete += OnAnimationComplete1;
        a_shole2.AnimationState.Complete += OnAnimationComplete2;
        a_pic.AnimationState.Complete += OnAnimationComplete3;
        a_water.AnimationState.Complete += OnAnimationComplete4;

        AudioManager.ins.playmusicgame(AudioManager.ins.level10[0]);

        frBg2.gameObject.SetActive(false);
        Bg_black2.gameObject.SetActive(false);
        dem = 0;
    }
    public void PauseAnimation()
    {
        a_boy.timeScale = 0; // Dừng Spine Animation
    }

    public void ResumeAnimation()
    {
        a_boy.timeScale = 1;
    }
    public void OnAnimationComplete(TrackEntry trackEntry)
    {
        string animName = trackEntry.Animation.Name;
      // Debug.Log(animName);
        if (animName == "animation2")
        {
            a_boy.gameObject.SetActive(false);
            boy2.gameObject.SetActive(true);
            //
        }
    }
   
    public void OnAnimationComplete1(TrackEntry trackEntry)
    {
        a_shole1.gameObject.SetActive(false);
        shovel.gameObject.SetActive(true);
        a_pic.gameObject.SetActive(true);
        a_pic.AnimationState.SetAnimation(1, "animation", false);
        x2.gameObject.SetActive(false);

    }
    public void OnAnimationComplete2(TrackEntry trackEntry)
    {
        a_shole2.gameObject.SetActive(false);
        shovel.gameObject.SetActive(true);
        x.gameObject.SetActive(false);
        hole.gameObject.SetActive(true);
        money.gameObject.SetActive(true);
    }
    public void OnAnimationComplete3(TrackEntry trackEntry)
    {
        // a_shole2.gameObject.SetActive(false);
        // shovel.gameObject.SetActive(true);


    }public int aak = 0;
    public void OnAnimationComplete4(TrackEntry trackEntry)
    {
        aak += 1;
        if (aak <= 3)
        {
            Level10.ins.a_water.AnimationState.SetAnimation(1, "animation", false);

        }
        else
        {
            Level10.ins.gameover += 1;
            Level10.ins.gameOver();
            pool1.gameObject.SetActive(false);
            pool2.gameObject.SetActive(true);
            water_tap.gameObject.SetActive(false);
            a_water.gameObject.SetActive(false);

        }

    }
    public int gameover = 0;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy
    public int dem = 0;
    public void gameOver()
    {
        Debug.Log(gameover);

        if (gameover == 11)
        {
            Debug.Log("gameover");
            textCoroutine2 = StartCoroutine(ENDGAME());
        }
        else if (gameover >= 100)
        {
            AudioManager.ins.play2shot(AudioManager.ins.level10[7]);

          //  AudioManager.ins.stop1shot();

            Debug.Log("gameover");
            textCoroutine2 = StartCoroutine(ENDOVER());
        }
    }
    public IEnumerator ENDGAME()
    {
        yield return new WaitForSeconds(1f);
        UiController.ins.WinGame();
    }
    public IEnumerator ENDOVER()
    {
        yield return new WaitForSeconds(3f);
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
