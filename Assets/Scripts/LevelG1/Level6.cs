using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Spine.Unity;
using Spine;
using System.Collections;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;

public class Level6 : MonoBehaviour
{
    public static Level6 ins;

    public Image bg,book,cabinet1,cabinet,bed,carpet,desk,wc,door,money,spiderwed,table,towel,windown1,windown2,
        laptop,dog3,dog4,dog6,dog7,a1,book2,a2,a3,a4,a5, toilet;
    public SkeletonGraphic a_dog1,a_dog2,a_dog5,a_dog8,a_dog9,a_girl,a_phone;
    public GameObject dg;
    private void Awake()
    {
        Level6.ins = this;
    }

    private void Start()
    {
        startLevel();
    }
    public void startLevel()
    {
        bg.gameObject.SetActive(true);
        book.gameObject.SetActive(true);
        book2.gameObject.SetActive(false);
        cabinet1.gameObject.SetActive(true);
        cabinet.gameObject.SetActive(true);
        carpet.gameObject.SetActive(true);
        desk.gameObject.SetActive(true);
        bed.gameObject.SetActive(true);
        wc.gameObject.SetActive(false);
        door.gameObject.SetActive(true);
        money.gameObject.SetActive(true);
        spiderwed.gameObject.SetActive(true);
        table.gameObject.SetActive(true);
        towel.gameObject.SetActive(true);
        toilet.gameObject.SetActive(false);

        windown1.gameObject.SetActive(false);
        windown2.gameObject.SetActive(true);
        laptop.gameObject.SetActive(true);
        dog3.gameObject.SetActive(false);
        dog4.gameObject.SetActive(false);
        dog6.gameObject.SetActive(false);
        dog7.gameObject.SetActive(false);
        dg.SetActive(true);
        a1.gameObject.SetActive(false);
        a2.gameObject.SetActive(false);
        a3.gameObject.SetActive(false);
        a4.gameObject.SetActive(false);
        a5.gameObject.SetActive(true);

        a_dog1.gameObject.SetActive(false);
        a_dog2.gameObject.SetActive(false);
        a_dog5.gameObject.SetActive(false);
        a_dog8.gameObject.SetActive(false);
        a_dog9.gameObject.SetActive(false);
        a_girl.gameObject.SetActive(true);
        a_phone.gameObject.SetActive(true);

        a_girl.AnimationState.SetAnimation(1, "animation", true);
        a_phone.AnimationState.SetAnimation(1, "animation", true);
        GameManager.ins.Click1 = 0;              
        GameManager.ins.Click2 = 0;
        GameManager.ins.Click3 = 0;

        Bg_black2.gameObject.SetActive(false);
        frBg2.gameObject.SetActive(false);
        ResumeAnimation();
        AudioManager.ins.playmusicgame(AudioManager.ins.muisgame);

    }
    public void PauseAnimation()
    {
        a_girl.timeScale = 0; // Dừng Spine Animation
        a_phone.timeScale = 0; 
        a_dog1.timeScale = 0;
        a_dog2.timeScale = 0;
        a_dog5.timeScale = 0;
        a_dog8.timeScale = 0;
        a_dog9.timeScale = 0;
    }

    public void ResumeAnimation()
    {
        a_girl.timeScale = 1; // Tiếp tục animation
        a_phone.timeScale = 1;
        a_dog1.timeScale = 1;
        a_dog2.timeScale = 1;
        a_dog5.timeScale = 1;
        a_dog8.timeScale = 1;
        a_dog9.timeScale = 1;
    }

    public int gameover = 0;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy

    public void gameOver()
    {
        Debug.Log(gameover);

        if (gameover == 9)
        {
            Debug.Log("gameover");
            textCoroutine2 = StartCoroutine(ENDGAME());
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
