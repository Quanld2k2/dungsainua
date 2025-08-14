using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Spine.Unity;
using Spine;
using System.Collections;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;

public class Level1 : MonoBehaviour
{
    public static Level1 ins;
    public Image floor1, floor2, wall1, wall2, table1, table2, grandfather1, grandfather2,
         window1, window2, carpet1, carpet2, dog1, dog2, candle1, candle2, spider1, spider2, girl2,
         broom1, broom3,n1,n2,n3,n4,n5,n6,n7,n8,n9,n11;
    public SkeletonGraphic anim_girl, anim_grama, anim_yoga;
    public Image[] tien;
    private void Awake()
    {
        Level1.ins = this;
    }
    private void Start()
    {
        startLevel();
    }

    public void startLevel()
    {
        floor1.gameObject.SetActive(true);
        floor2.gameObject.SetActive(false);
        wall1.gameObject.SetActive(true);
        wall2.gameObject.SetActive(false);
        table1.gameObject.SetActive(true);
        table2.gameObject.SetActive(false);
        grandfather1.gameObject.SetActive(true);
        grandfather2.gameObject.SetActive(false);
        window1.gameObject.SetActive(true);
        window2.gameObject.SetActive(false);
        carpet1.gameObject.SetActive(true);
        carpet2.gameObject.SetActive(false);
        dog1.gameObject.SetActive(true);
        dog2.gameObject.SetActive(false);
        candle1.gameObject.SetActive(true);
        candle2.gameObject.SetActive(false);
        spider1.gameObject.SetActive(true);
        spider2.gameObject.SetActive(false);
        broom1.gameObject.SetActive(true);
        broom3.gameObject.SetActive(false);
        anim_girl.gameObject.SetActive(true);
        anim_grama.gameObject.SetActive(true);
        anim_yoga.gameObject.SetActive(false);
        
        girl2.gameObject.SetActive(false);
        anim_grama.AnimationState.SetAnimation(1, "grandma", true);
        anim_girl.AnimationState.SetAnimation(1, "girl", true);

        gameover = 0;

        Bg_black2.gameObject.SetActive(false);
        frBg2.gameObject.SetActive(false);

        ResumeAnimation();

        for (int i = 0; i < tien.Length; i++)
        {
            tien[i].gameObject.SetActive(true);
        }
        n1.gameObject.SetActive(true);
        n2.gameObject.SetActive(true);
        n3.gameObject.SetActive(true);
        n4.gameObject.SetActive(true);
        n5.gameObject.SetActive(true);
        n6.gameObject.SetActive(true);
        n7.gameObject.SetActive(true);
        n8.gameObject.SetActive(true);
        n9.gameObject.SetActive(true);
        n11.gameObject.SetActive(true);

        AudioManager.ins.playmusicgame(AudioManager.ins.muisgame);

    }

    public void PauseAnimation()
    {
        // GameManager.ins.Pause = true;
        anim_grama.timeScale = 0; // Dừng Spine Animation
        anim_girl.timeScale = 0; // Dừng Spine Animation
        anim_yoga.timeScale = 0; // Dừng Spine Animation
    }

    public void ResumeAnimation()
    {
        //GameManager.ins.Pause = false;
        anim_grama.timeScale = 1; // Tiếp tục animation
        anim_girl.timeScale = 1; // Dừng Spine Animation
        anim_yoga.timeScale = 1; // Dừng Spine Animation
    }
    public int gameover = 0;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy

    public void gameOver()
    {
        if (gameover == 10)
        {
            Debug.Log("gameover");
            textCoroutine2 = StartCoroutine(ENDGAME());
        }
        else if(gameover == 207 || gameover == 108 )
        {
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
            Debug.Log("LocalizeStringEvent is not set.");
        }
    }
    public void OnChangeLanguage(int languageIndex)
    {
      //  Debug.Log(languageIndex);
        // Thay đổi ngôn ngữ (0: English, 1: Vietnamese, ...)
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[languageIndex];
    }
    private Coroutine textCoroutine; // Lưu trữ coroutine đang chạy

    public void chageString(string Ai)
    {
       // Bg_black2.gameObject.SetActive(true);
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
