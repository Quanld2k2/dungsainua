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

public class Level23 : MonoBehaviour
{

    public static Level23 ins;

    // Anim (SkeletonGraphic)
    public SkeletonGraphic a_box1, a_box2, a_door, a_hammer,
                           a_zombie1, a_girl, a_end, a_zombie2;

    public Image bg, rope, sofa, poster, maykhoan,sofa2,hammer, windown,shape3,floor,z1,z2,
                       bangdinh, table1, table2;

    private void Awake()
    {
        ins = this;
    }

    private void Start()
    {
        startGame23();
    }

    public void startGame23()
    {
        bg.gameObject.SetActive(true);
        rope.gameObject.SetActive(true);
        sofa.gameObject.SetActive(true);
        poster.gameObject.SetActive(true);
        maykhoan.gameObject.SetActive(true);
        bangdinh.gameObject.SetActive(true);
        table1.gameObject.SetActive(true);
        table2.gameObject.SetActive(false);
        sofa2.gameObject.SetActive(false);
        hammer.gameObject.SetActive(true);
        windown.gameObject.SetActive(false);
        shape3.gameObject.SetActive(true);
        floor.gameObject.SetActive(false);

        z1.gameObject.SetActive(true);
        z2.gameObject.SetActive(true);


        a_box1.gameObject.SetActive(true);
        a_box2.gameObject.SetActive(false);
        a_door.gameObject.SetActive(true);
        a_hammer.gameObject.SetActive(false);
        a_zombie1.gameObject.SetActive(true);
        a_girl.gameObject.SetActive(true);
        a_end.gameObject.SetActive(false);
        a_zombie2.gameObject.SetActive(true);

        a_girl.AnimationState.SetAnimation(1, "animation", true);
        a_zombie1.AnimationState.SetAnimation(1, "animation", true);
        a_zombie2.AnimationState.SetAnimation(1, "animation", true);
        a_door.AnimationState.SetAnimation(1, "animation", true);

        a_hammer.AnimationState.Complete += OnAnimationComplete1;
        a_end.AnimationState.Complete += OnAnimationComplete2;
        a_zombie2.AnimationState.Complete += OnAnimationComplete3;

        wwin = false;
        gameover = 0;

        frBg2.gameObject.SetActive(false);
        Bg_black2.gameObject.SetActive(false); 
        AudioManager.ins.playmusicgame(AudioManager.ins.muisgame);
        AudioManager.ins.play1shot(AudioManager.ins.level8[3]);

    }
    public void PauseAnimation()
    {
        a_zombie1.timeScale = 0; // Dừng Spine Animation
        a_zombie2.timeScale = 0;
        a_girl.timeScale = 0;
        a_box1.timeScale = 0;
        a_door.timeScale = 0;
    }

    public void ResumeAnimation()
    {
        a_zombie1.timeScale = 1;
        a_zombie2.timeScale = 1;
        a_girl.timeScale = 1; // Tiếp tục animation
        a_box1.timeScale = 1;
        a_door.timeScale = 1;
    }
    public void OnAnimationComplete1(TrackEntry trackEntry)
    {
        Debug.Log("Kéo đã kết thúc");

        table1.gameObject.SetActive(false);
        table2.gameObject.SetActive(true);
        a_hammer.gameObject.SetActive(false);
        hammer.gameObject.SetActive(true);

    }
    public void OnAnimationComplete2(TrackEntry trackEntry)
    {
        if (wwin == false)
        {
            wwin = true;
            textCoroutine2 = StartCoroutine(ENDGAME());
        }

    }
    public void OnAnimationComplete3(TrackEntry trackEntry)
    {
        hammer.gameObject.SetActive(true);


    }
    public bool wwin = false;
    public int gameover = 0;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy
    public void endGame()
    {

        if (gameover == 5)
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
