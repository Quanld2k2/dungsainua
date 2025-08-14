using Spine.Unity;
using Spine;
using System.Collections;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Level19 : MonoBehaviour
{
    public static Level19 ins;
    public Image bg, cua2, choi2, cua1, tu, tu3, tu4, nem,
                    maygiat1, maygiat2, tranh, poster1, nguoi,
                    thuocxit, spiderweb1, spiderweb2, quanao1,
                    poster, book, choi, balo, ban, goi, goi3,
                    chan, chan2, quanao, paper1, paper2, paper3,
                    bin1, bin2, tu2, balo2, book2, gian1, gian2, gian3, gian4;
    public Image q1, q2, q3, q4, q5;
    public SkeletonGraphic a_choi1, a_choi2, a_launha, a_maygiat;

    public SkeletonGraphic[] a_run;
    private void Awake()
    {
        Level19.ins = this;
    }
    private void Start()
    {
        startLevel();
    }
    public void startLevel()
    {
        bg.gameObject.SetActive(true);
        cua2.gameObject.SetActive(true);
        choi2.gameObject.SetActive(true);
        cua1.gameObject.SetActive(true);
        tu.gameObject.SetActive(true);
        tu3.gameObject.SetActive(false);
        tu4.gameObject.SetActive(false);
        nem.gameObject.SetActive(true);
        maygiat1.gameObject.SetActive(true);
        maygiat2.gameObject.SetActive(false);
        tranh.gameObject.SetActive(true);
        poster1.gameObject.SetActive(false);
        nguoi.gameObject.SetActive(true);
        thuocxit.gameObject.SetActive(false);
        spiderweb1.gameObject.SetActive(true);
        spiderweb2.gameObject.SetActive(true);
        quanao1.gameObject.SetActive(false);
        poster.gameObject.SetActive(true);
        book.gameObject.SetActive(true);
        choi.gameObject.SetActive(true);
        balo.gameObject.SetActive(true);
        ban.gameObject.SetActive(true);
        goi.gameObject.SetActive(false);
        goi3.gameObject.SetActive(true);
        chan.gameObject.SetActive(false);
        chan2.gameObject.SetActive(true);
        quanao.gameObject.SetActive(true);
        paper1.gameObject.SetActive(true);
        paper2.gameObject.SetActive(true);
        paper3.gameObject.SetActive(false);
        balo2.gameObject.SetActive(false);
        book2.gameObject.SetActive(false);

        gian1.gameObject.SetActive(true);
        gian2.gameObject.SetActive(true);
        gian3.gameObject.SetActive(true);
        gian4.gameObject.SetActive(true);

        bin1.gameObject.SetActive(true);
        bin2.gameObject.SetActive(false);
        tu2.gameObject.SetActive(false);

        q1.gameObject.SetActive(true);
        q2.gameObject.SetActive(true);
        q3.gameObject.SetActive(true);
        q4.gameObject.SetActive(true);
        q5.gameObject.SetActive(true);

        chem1 = false; chem2 = false; chem3 = false; chem4 = false;
        nubm = 0;
        nubm2 = 0;
        a_choi1.gameObject.SetActive(false);
        a_choi2.gameObject.SetActive(false);
        a_launha.gameObject.SetActive(false);
        a_maygiat.gameObject.SetActive(false);

        a_choi1.AnimationState.Complete += OnAnimationComplete1;
        a_choi2.AnimationState.Complete += OnAnimationComplete2;
        a_launha.AnimationState.Complete += OnAnimationComplete3;
        a_maygiat.AnimationState.Complete += OnAnimationComplete4;
        AudioManager.ins.playmusicgame(AudioManager.ins.muisgame);

    }
    public void PauseAnimation()
    {
     
    }

    public void ResumeAnimation()
    {
        
    }
    public void OnAnimationComplete1(TrackEntry trackEntry)
    {
        Debug.Log("OnAnimationComplete1");
        spiderweb2.gameObject.SetActive(false);
        a_choi2.gameObject.SetActive(false);
        if (nubm == 1)
        {
            choi.gameObject.SetActive(true);
        }
    }
    public void OnAnimationComplete2(TrackEntry trackEntry)
    {
        Debug.Log("OnAnimationComplete2");

        spiderweb1.gameObject.SetActive(false);
        a_choi1.gameObject.SetActive(false);
        if (nubm == 1)
        {
            choi.gameObject.SetActive(true);
        }
    }
    public void OnAnimationComplete3(TrackEntry trackEntry)
    {
        a_launha.gameObject.SetActive(false);
        ban.gameObject.SetActive(false);

    }
    public void OnAnimationComplete4(TrackEntry trackEntry)
    {
        maygiat1.gameObject.SetActive(true);
        a_maygiat.gameObject.SetActive(false);
        if (chem1 == true)
        {
            quanao1.gameObject.SetActive(true);
            Debug.Log("quanao1");
            chem1 = false;

        }
        else if (chem2 == true)
        {
            chan.gameObject.SetActive(true);
            Debug.Log("chan");
            chem2 = false;

        }
        else if (chem3 == true)
        {
            goi.gameObject.SetActive(true);
            Debug.Log("goi");
            chem3 = false;

        }


    }

    public int nubm = 0, nubm2 = 0;
    public bool chem1 = false, chem2 = false, chem3 = false, chem4 = false;
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