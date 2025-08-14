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


public class Level26 : MonoBehaviour
{
    public static Level26 ins;

    // Anim
    public SkeletonGraphic a_duck, a_fish, a_girl, a_hoe, a_hoe2, a_girl2, 
        a_girl3, a_girl4, a_girl5, a_girl6, a_girl7, a_girl8, a_girl9;

    // GameObject
    public Image bg, cloud, lifebuoy, boat, saw, rope, tree, stick, shape, sweetpotato, fish;
    private void Awake()
    {
        ins = this;
    }
    private void Start()
    {
        bg.gameObject.SetActive(true);
        cloud.gameObject.SetActive(true);
        lifebuoy.gameObject.SetActive(true);
        boat.gameObject.SetActive(true);
        saw.gameObject.SetActive(true);
        rope.gameObject.SetActive(true);
        tree.gameObject.SetActive(true);
        stick.gameObject.SetActive(false);
        shape.gameObject.SetActive(true);
        sweetpotato.gameObject.SetActive(false);
        fish.gameObject.SetActive(false);

        a_duck.gameObject.SetActive(true);
        a_fish.gameObject.SetActive(true);
        a_girl.gameObject.SetActive(true);
        a_hoe.gameObject.SetActive(true);
        a_hoe2.gameObject.SetActive(false);

        a_girl2.gameObject.SetActive(false);
        a_girl3.gameObject.SetActive(false);
        a_girl4.gameObject.SetActive(false);
        a_girl5.gameObject.SetActive(false);
        a_girl6.gameObject.SetActive(false);
        a_girl7.gameObject.SetActive(false);
        a_girl8.gameObject.SetActive(false);
        a_girl9.gameObject.SetActive(false);

        a_duck.AnimationState.SetAnimation(1, "animation", true);
        a_fish.AnimationState.SetAnimation(1, "animation", true);
        a_girl.AnimationState.SetAnimation(1, "Anim1", true);
        a_hoe.AnimationState.SetAnimation(1, "animation", true);

        a_hoe2.AnimationState.Complete += OnAnimationComplete1;
        a_girl2.AnimationState.Complete += OnAnimationComplete2;
        a_girl3.AnimationState.Complete += OnAnimationComplete2;
        a_girl4.AnimationState.Complete += OnAnimationComplete2;
        a_girl5.AnimationState.Complete += OnAnimationComplete2;
        a_girl6.AnimationState.Complete += OnAnimationComplete2;
        a_girl7.AnimationState.Complete += OnAnimationComplete2;
        a_girl8.AnimationState.Complete += OnAnimationComplete2;
        frBg2.gameObject.SetActive(false); AudioManager.ins.playmusicgame(AudioManager.ins.muisgame);

        Bg_black2.gameObject.SetActive(false);
        //   a_girl9.AnimationState.Complete += OnAnimationComplete2;
        c1 = false; c2 = false; c3 = false; c4 = false; c5 = false; c6 = false; c7 = false; c8 = false; c9 = false;
    }
    public bool c1 = false, c2 = false, c3 = false, c4 = false, c5 = false, c6 = false, c7 = false, c8 = false, c9 = false;
    public void PauseAnimation()
    {
        a_duck.timeScale = 0;
        a_fish.timeScale = 0;
        a_girl.timeScale = 0;
        a_hoe.timeScale = 0;

        // GameManager.ins.Pause = true;
        //  a_boy.timeScale = 0;
        //  a_girl.timeScale = 0;
        //  PauseTimer();
    }

    public void ResumeAnimation()
    {
        a_duck.timeScale = 1;
        a_fish.timeScale = 1;
        a_girl.timeScale = 1; a_hoe.timeScale = 1;

        //  isPaused = false;
        // GameManager.ins.Pause = true;
        //   a_boy.timeScale = 1;
        //   a_girl.timeScale = 1;
    }
    public void OnAnimationComplete1(TrackEntry trackEntry)
    {
        shape.gameObject.SetActive(false);

        a_hoe2.gameObject.SetActive(false);
       // shape.gameObject.SetActive(true);
        sweetpotato.gameObject.SetActive(true);
    }
    public void OnAnimationComplete2(TrackEntry trackEntry)
    {
        a_girl.gameObject.SetActive(true);
         if (trackEntry.Animation.Name == "Anim2")
        {
            if (c1 == false)
            {
                c1 = true;
                a_girl2.gameObject.SetActive(false);
                Level26.ins.gameover += 1;
                Level26.ins.endGame();
            }
            
        }
        else if(trackEntry.Animation.Name == "Anim3")
        {
            if (c2 == false)
            {
                c2 = true;
                a_girl3.gameObject.SetActive(false);
                Level26.ins.gameover += 1;
                Level26.ins.endGame();
            }
           

        }
        else if (trackEntry.Animation.Name == "Anim4")
        {
            if (c3 == false)
            {
                c3 = true;
                a_girl4.gameObject.SetActive(false);
                Level26.ins.gameover += 1;
                Level26.ins.endGame();
            }
           
        }
        else if (trackEntry.Animation.Name == "Anim5")
        {
            if (c4 == false)
            {
                c4 = true;
                a_girl5.gameObject.SetActive(false);
                Level26.ins.gameover += 1;
                Level26.ins.endGame();
            }
            
        }
        else if (trackEntry.Animation.Name == "Anim6")
        {
            if (c5 == false)
            {
                c5 = true;
                a_girl6.gameObject.SetActive(false);
                Level26.ins.gameover += 1;
                Level26.ins.endGame();
            }
            
        }
        else if (trackEntry.Animation.Name == "Anim7")
        {
            if (c6 == false)
            {
                c6 = true;
                a_girl7.gameObject.SetActive(false);
                Level26.ins.gameover += 1;
                Level26.ins.endGame();
            }
            
        }
        else if (trackEntry.Animation.Name == "Anim8")
        {
            if (c7 == false)
            {
                c7 = true;
                a_girl8.gameObject.SetActive(false);
                Level26.ins.gameover += 1;
                Level26.ins.endGame();
            }
            
        }
        else if (trackEntry.Animation.Name == "Anim9")
        {
            a_girl9.gameObject.SetActive(false);

        }



    }
    public int gameover = 0;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy
    public void endGame()
    {
        Debug.Log("endgame" + gameover);
        if (gameover == 7)
        {
            Level26.ins.a_girl.gameObject.SetActive(false);

            Level26.ins.a_girl9.gameObject.SetActive(true);
            Level26.ins.a_girl9.AnimationState.SetAnimation(1, "Anim9", false);

            textCoroutine2 = StartCoroutine(ENDGAME());
            Debug.Log("gameover");
        }
        else
        {
            AudioManager.ins.play1shot(AudioManager.ins.level26[4]);

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
