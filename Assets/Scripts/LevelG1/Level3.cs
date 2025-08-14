using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Spine.Unity;
using Spine;
using System.Collections;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;

public class Level3 : MonoBehaviour
{
    public static Level3 ins;
    public Image road,stone1, stone2, beater,bowl1,bowl2,bucket1,bucket2, bucket3, dogfood,hole1,hole2,hole3,
        sign,watertap1,watertap2,fence,bush,cement,sign1,sign2,n2,n4;
    public SkeletonGraphic a_oto,a_dog,a_stone,a_hole,a_girl,a_watertap,a_dogun;
    
    private void Awake()
    {
        Level3.ins = this;
    }
    private void Start()
    {
        startLevel();
    }
    public void startLevel()
    {
        Debug.Log("lv3");
        road.gameObject.SetActive(true);
        stone1.gameObject.SetActive(true);
        stone2.gameObject.SetActive(true);
        beater.gameObject.SetActive(true);
        bowl1.gameObject.SetActive(true);
        bowl2.gameObject.SetActive(false);
        bucket1.gameObject.SetActive(true);
        bucket2.gameObject.SetActive(false);
        bucket3.gameObject.SetActive(false);
        dogfood.gameObject.SetActive(true);
        hole1.gameObject.SetActive(true);
        hole2.gameObject.SetActive(false);
        hole3.gameObject.SetActive(false);
        sign.gameObject.SetActive(true);
        watertap1.gameObject.SetActive(false);
        watertap2.gameObject.SetActive(true);
        fence.gameObject.SetActive(true);
        bush.gameObject.SetActive(true);
        cement.gameObject.SetActive(true);
        sign1.gameObject.SetActive(true);
        sign2.gameObject.SetActive(false);
        n2.gameObject.SetActive(false);
        n4.gameObject.SetActive(true);

        a_oto.gameObject.SetActive(true);
        a_dog.gameObject.SetActive(true);
        a_stone.gameObject.SetActive(true);
        a_hole.gameObject.SetActive(false);
        a_girl.gameObject.SetActive(true);
        a_watertap.gameObject.SetActive(false);
        a_dogun.gameObject.SetActive(false);


        a_oto.AnimationState.SetAnimation(1, "animation", true);
        a_dog.AnimationState.SetAnimation(1, "animation", true);
        a_stone.AnimationState.SetAnimation(1, "anim1", true);
        a_girl.AnimationState.SetAnimation(1, "animation", true);

        Bg_black2.gameObject.SetActive(false);
        frBg2.gameObject.SetActive(false);

        a_stone.AnimationState.Complete += OnAnimationComplete1;
        a_dogun.AnimationState.Complete += OnAnimationComplete2;
        a_watertap.AnimationState.Complete += OnAnimationComplete3;
        a_hole.AnimationState.Complete += OnAnimationComplete4;
        gameover = 0;
        num1 = 0;
        num2 = 0;
        Level3.ins.chageString("lev3_2");
        ResumeAnimation();
        AudioManager.ins.play1shot(AudioManager.ins.level3[1]);
        stoneC = false;
    }
    public bool stoneC = false;
    public void OnAnimationComplete1(TrackEntry trackEntry)
    {
        //a_stone.gameObject.SetActive(false);

    }
    public void OnAnimationComplete4(TrackEntry trackEntry)
    {
        //a_stone.gameObject.SetActive(false);
        Level3.ins.hole3.gameObject.SetActive(false);
        Level3.ins.a_hole.gameObject.SetActive(false);
    }
    public void OnAnimationComplete3(TrackEntry trackEntry)
    {
      
        if (num2 == 1)
        {
            bucket3.gameObject.SetActive(false);
            bucket2.gameObject.SetActive(true);
            Level3.ins.a_watertap.AnimationState.SetAnimation(1, "animation", false);
            Level3.ins.n2.gameObject.SetActive(false);
            AudioManager.ins.stop1shot();

        }
        else
        {

        }
        num2 += 1;
    }

    int num1 = 0,num2 = 0;
    public void OnAnimationComplete2(TrackEntry trackEntry)
    {
        num1 += 1;
        if (num1 == 3)
        {
            Level3.ins.a_dogun.gameObject.SetActive(false);
            bowl1.gameObject.SetActive(true);
            bowl2.gameObject.SetActive(false);
            watertap1.gameObject.SetActive(true);

        }

    }
    public int gameover = 0;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy
    public void endGame()
    {
        Debug.Log("endgame");
        if (gameover == 3 )
        {
            fence.gameObject.SetActive(false);
            textCoroutine2 = StartCoroutine(ENDGAME());
            Debug.Log("gameover");
        }
        else if (gameover == 100)
        {
            textCoroutine2 = StartCoroutine(ENDOVER());
            Debug.Log("gameover");
        }

    }
    public IEnumerator ENDOVER()
    {
        yield return new WaitForSeconds(1f);
        UiController.ins.OpenLose();
    }
    public IEnumerator ENDGAME()
    {
        yield return new WaitForSeconds(1f);
        UiController.ins.WinGame();
    }
    public void PauseAnimation()
    {
        // GameManager.ins.Pause = true;
        a_oto.timeScale = 0;
        a_dog.timeScale = 0;
        a_stone.timeScale = 0;
        a_girl.timeScale = 0;
    }

    public void ResumeAnimation()
    {
        // GameManager.ins.Pause = true;
        a_oto.timeScale = 1;
        a_dog.timeScale = 1;
        a_stone.timeScale = 1;
        a_girl.timeScale = 1;
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
