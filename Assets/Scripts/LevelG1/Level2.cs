using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Spine.Unity;
using Spine;
using System.Collections;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;

public class Level2 : MonoBehaviour
{
    public static Level2 ins;
    public Image wall2,wall1,bed,bell,bone,dog,knife,key1,key2,lamp,axe,phone,boy2,bride,d1,d2,d3,d4,d5,money1,money2, money3;
    public SkeletonGraphic door1,door2,door3,door4,door5,boyend,girl;
    public GameObject many;
    public Image n2,n3,n4,n5;
    private void Awake()
    {
        Level2.ins = this;
    }
    private void Start()
    {
        startLevel();
     
    }

    public void startLevel()
    {
        wall2.gameObject.SetActive(true);
        wall1.gameObject.SetActive(true);
        bed.gameObject.SetActive(true);
        bell.gameObject.SetActive(true);
        bone.gameObject.SetActive(false);
        dog.gameObject.SetActive(true);
        knife.gameObject.SetActive(true);
        key1.gameObject.SetActive(true);
        key2.gameObject.SetActive(false);
        lamp.gameObject.SetActive(true);
        axe.gameObject.SetActive(false);
        phone.gameObject.SetActive(true);
        boy2.gameObject.SetActive(false);
        bride.gameObject.SetActive(false);

        door1.gameObject.SetActive(false);
        door2.gameObject.SetActive(false);
        door3.gameObject.SetActive(false);
        door4.gameObject.SetActive(false);
        door5.gameObject.SetActive(false);
        boyend.gameObject.SetActive(false);
        many.SetActive(false);

        d1.gameObject.SetActive(true);
        d2.gameObject.SetActive(true);
        d3.gameObject.SetActive(true);
        d4.gameObject.SetActive(true);
        d5.gameObject.SetActive(true);

        n2.gameObject.SetActive(false);
        n3.gameObject.SetActive(false);
        n4.gameObject.SetActive(false);
        n5.gameObject.SetActive(false);

        boyend.GetComponent<RectTransform>().anchoredPosition = new Vector3(424f, -317f, 0f);

        boyend.gameObject.SetActive(true);
        girl.gameObject.SetActive(true);
        boyend.AnimationState.SetAnimation(1, "animation", true);
        girl.AnimationState.SetAnimation(1, "animation", true);

        boyend.AnimationState.Complete += OnAnimationComplete1;
        girl.AnimationState.Complete += OnAnimationComplete2;
        door1.AnimationState.Complete += OnAnimationComplete3;
        door2.AnimationState.Complete += OnAnimationComplete4;
        door3.AnimationState.Complete += OnAnimationComplete5;
        door4.AnimationState.Complete += OnAnimationComplete6;
        door5.AnimationState.Complete += OnAnimationComplete7;

        ResumeAnimation();

        Bg_black2.gameObject.SetActive(false);
        frBg2.gameObject.SetActive(false);

        GameManager.ins.Click1 = 0;
        GameManager.ins.Click2 = 0;

        Level2.ins.chageString("lev2_1");
        l3v = false;
        AudioManager.ins.playmusicgame(AudioManager.ins.muisgame);

    }
    public bool l3v = false;
    public void OnAnimationComplete1(TrackEntry trackEntry)
    {

    }
    public void OnAnimationComplete2(TrackEntry trackEntry)
    {

    }
    public void OnAnimationComplete3(TrackEntry trackEntry)
    {
        door1.gameObject.SetActive(false);
        n2.gameObject.SetActive(true);

    }
    public void OnAnimationComplete4(TrackEntry trackEntry)
    {
        door2.gameObject.SetActive(false);
        n3.gameObject.SetActive(true);
        AudioManager.ins.play1shot(AudioManager.ins.level2[6]);

    }
    public void OnAnimationComplete5(TrackEntry trackEntry)
    {
        door3.gameObject.SetActive(false);
        n4.gameObject.SetActive(true);

        bride.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-1200f, -314f, 0f), 0.4f).OnComplete(() =>
        {
            
        });
    }
    public void OnAnimationComplete6(TrackEntry trackEntry)
    {
        door4.gameObject.SetActive(false);
        n5.gameObject.SetActive(true);

    }
    public void OnAnimationComplete7(TrackEntry trackEntry)
    {
        door5.gameObject.SetActive(false);
      //  boyend.GetComponent<RectTransform>().anchoredPosition = new Vector3(-73f, 325f, 0f);
        boyend.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-73f, 325f, 0f), 0.4f).OnComplete(() =>
        {

        });
        Level2.ins.gameEnd();
    }

    private Coroutine textCoroutine2;
    public void gameOver()
    {
        textCoroutine2 = StartCoroutine(ENDOVER());
    }
    public void gameEnd()
    {
      
        textCoroutine2 = StartCoroutine(ENDGAME());
    }
    public IEnumerator ENDGAME()
    {
        yield return new WaitForSeconds(3f);
        UiController.ins.WinGame();
    }
    public IEnumerator ENDOVER()
    {
        yield return new WaitForSeconds(3f);
        UiController.ins.OpenLose();
    }
    public void PauseAnimation()
    {
        // GameManager.ins.Pause = true;
        boyend.timeScale = 0; // Dừng Spine Animation
        girl.timeScale = 0; // Dừng Spine Animation

    }

    public void ResumeAnimation()
    {
        //GameManager.ins.Pause = false;
        boyend.timeScale = 1; // Tiếp tục animation
        girl.timeScale = 1; // Dừng Spine Animation

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
