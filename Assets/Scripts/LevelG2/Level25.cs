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


public class Level25 : MonoBehaviour
{
    public static Level25 ins;

    // Anim
    public SkeletonGraphic a_window, a_curtain, a_girl, a_cat2;

    // GameObject
    public Image bg, pic, blanket, bed, blanket2, cut,bread1, bread2,
                       wardrobe, wardrobe2, carpet, bed2, cat,cat1,cat2,
                       towel1, knife, tree, wool, wool1, table, wool2,windown,
                       bread, book, box1, quanao;
    private void Awake()
    {
        ins = this;
    }
    private void Start()
    {
        bg.gameObject.SetActive(true);
        pic.gameObject.SetActive(true);
        blanket.gameObject.SetActive(true);
        bed.gameObject.SetActive(true);
        blanket2.gameObject.SetActive(true);
        cut.gameObject.SetActive(true);
        wardrobe.gameObject.SetActive(true);
        wardrobe2.gameObject.SetActive(false);
        carpet.gameObject.SetActive(true);
        bed2.gameObject.SetActive(true);
        cat.gameObject.SetActive(true);
        towel1.gameObject.SetActive(true);
        knife.gameObject.SetActive(true);
        tree.gameObject.SetActive(true);
        wool.gameObject.SetActive(true);
        wool1.gameObject.SetActive(true);
        table.gameObject.SetActive(true);
        bread.gameObject.SetActive(true);
        book.gameObject.SetActive(true);
        box1.gameObject.SetActive(true);
        quanao.gameObject.SetActive(false);
        bread1.gameObject.SetActive(false);
        bread2.gameObject.SetActive(false);
        wool2.gameObject.SetActive(false);
        cat1.gameObject.SetActive(false);
        cat2.gameObject.SetActive(false);

        a_window.gameObject.SetActive(true);
        a_curtain.gameObject.SetActive(true);
        a_girl.gameObject.SetActive(true);
        a_cat2.gameObject.SetActive(false);

        a_window.AnimationState.SetAnimation(1, "animation", true);
        a_curtain.AnimationState.SetAnimation(1, "animation", true);
        a_girl.AnimationState.SetAnimation(1, "animation", true);

        a_cat2.AnimationState.Complete += OnAnimationComplete1;

        frBg2.gameObject.SetActive(false);
        Bg_black2.gameObject.SetActive(false);

        upstr();
        iab = 0; iab2 = 0; gameover = 0; AudioManager.ins.playmusicgame(AudioManager.ins.muisgame);

    }
    public void PauseAnimation()
    {
        a_window.timeScale = 0; // Dừng Spine Animation
        a_curtain.timeScale = 0;
        a_girl.timeScale = 0;
    }

    public void ResumeAnimation()
    {
        a_window.timeScale = 1; // Tiếp tục animation
        a_curtain.timeScale = 1;
        a_girl.timeScale = 1;
    }
    public void OnAnimationComplete1(TrackEntry trackEntry)
    {
        Level25.ins.a_cat2.gameObject.SetActive(false);

        Level25.ins.cat1.gameObject.SetActive(true);
          Level25.ins.cat2.gameObject.SetActive(true);

    }
    public int iab = 0, iab2 = 0;
    public Image[] zilen;
    public Sprite q1_curtain, q2_quanao,q7_box, q10_bread1, q11_bread2,q12_wool, q13_towel,q14_cat,
        q8_blanket22,q9_carpet,q3_tree, q4_sach, q5_pic, q6_blanket2;

    public void upstr()
    {
        for (int i = 0; i < zilen.Length; i++)
        {
            zilen[i].sprite = null;
            zilen[i].gameObject.SetActive(false);
        }
    }
    public int gameover = 0;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy
    public void endGame()
    {

        Debug.Log("endgame" + gameover);
        if (gameover == 15)
        {
            textCoroutine2 = StartCoroutine(ENDGAME());
            Debug.Log("gameover");
        }
        else
        {
            //  if (head == false)
            //  {
            //      PauseTimer();
            ///      textCoroutine2 = StartCoroutine(ENDOVER());
            //  }
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
