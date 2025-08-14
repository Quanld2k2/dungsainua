using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Spine.Unity;
using Spine;
using System.Collections;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;
using RotateMode = DG.Tweening.RotateMode; // Xác định rõ `RotateMode` là của DOTween
using Sequence = DG.Tweening.Sequence; // Alias cho Sequence của DOTween

public class Level24 : MonoBehaviour
{
    public static Level24 ins;
    public Image bg, door, door2, baba, baba1, baba2,
                    windown1, windown,
                    gra1, gra2, gra3,
                    fa1, fa2, fa3,embe1,embe2,
                    tv, tv1, tv2,tv3,
                    table1, bed2, mom, bed1,mom1,bed3,
                    tree, tree2,
                    girl, girl2,
                    dog, dog2;
    public Image[] ab1;
    private void Awake()
    {
        Level24.ins = this;
    }
    private void Start()
    {
        startLevel();
    }
    public void startLevel()
    {
        bg.gameObject.SetActive(true);
        door.gameObject.SetActive(true);
        door2.gameObject.SetActive(false);
        baba.gameObject.SetActive(false);
        baba1.gameObject.SetActive(false);
        baba2.gameObject.SetActive(false);
        windown1.gameObject.SetActive(false);
        windown.gameObject.SetActive(true);
        gra1.gameObject.SetActive(true);
        gra2.gameObject.SetActive(false);
        gra3.gameObject.SetActive(false);
        fa1.gameObject.SetActive(true);
        fa2.gameObject.SetActive(false);
        fa3.gameObject.SetActive(false);
        tv.gameObject.SetActive(true);
        tv1.gameObject.SetActive(false);
        tv2.gameObject.SetActive(false);
        tv3.gameObject.SetActive(true);
        table1.gameObject.SetActive(true);
        bed2.gameObject.SetActive(true);
        mom.gameObject.SetActive(true);
        bed1.gameObject.SetActive(true);
        tree.gameObject.SetActive(true);
        tree2.gameObject.SetActive(false);
        girl.gameObject.SetActive(true);
        girl2.gameObject.SetActive(false);
        dog.gameObject.SetActive(true);
        dog2.gameObject.SetActive(false);
        embe1.gameObject.SetActive(false);
        embe2.gameObject.SetActive(false);
        mom1.gameObject.SetActive(true);
        bed3.gameObject.SetActive(true);

        for (int i = 0; i < ab1.Length; i++)
        {
            ab1[i].gameObject.SetActive(true);
        }
        frBg2.gameObject.SetActive(false);
        Bg_black2.gameObject.SetActive(false); AudioManager.ins.playmusicgame(AudioManager.ins.muisgame);

    }

    public bool l21a = false, l21a2 = false;

    public void PauseAnimation()
    {
        // GameManager.ins.Pause = true;
        //  a_boy.timeScale = 0;
        //  a_girl.timeScale = 0;
    }

    public void ResumeAnimation()
    {
        // GameManager.ins.Pause = true;
        //   a_boy.timeScale = 1;
        //   a_girl.timeScale = 1;
    }

    public void OnAnimationComplete3(TrackEntry trackEntry)
    {
        //    Level5.ins.a_perfume.gameObject.SetActive(false);


    }

    public int gameover = 0;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy
    public void endGame()
    {

        Debug.Log("endgame");
        if (gameover == 10)
        {
            textCoroutine2 = StartCoroutine(ENDGAME());
            Debug.Log("gameover");
        }
        else if(gameover == 100)
        {
            textCoroutine2 = StartCoroutine(ENDOVER());
            Debug.Log("gameover");
        }

    }
    public bool head = false;
    public IEnumerator ENDGAME()
    {
        yield return new WaitForSeconds(1f);
        UiController.ins.WinGame();
    }
    public IEnumerator ENDOVER()
    {
        yield return new WaitForSeconds(2f);
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
        yield return new WaitForSeconds(2f);
        frBg2.gameObject.SetActive(false);
        Bg_black2.gameObject.SetActive(false);
        textCoroutine = null; // Reset lại khi hoàn thành

    }
}
