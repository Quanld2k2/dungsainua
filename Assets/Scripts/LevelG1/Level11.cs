using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Spine.Unity;
using Spine;
using System.Collections;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;
public class Level11 : MonoBehaviour
{
    public static Level11 ins;
    public Image bg_done, wire1, wire2, dress1, hair1, dress2, hair2, hair3, dress3, face1, face2,body, clothers1, dumbbell1, phai, trai, 
        clothers2, dumbell2, clothers3, dumbell3, cabinet1, cabinet2, cat1,towel1, wool1, wool2, wool3, towel2, cat2, cat3, towel3, broom2,blanket2, broom3, blanket3,
        broom1, boyt3, girlt3, blanket1, bart22, towelt22, bart23, towelt23, bart21, towelt21, girl_lose, girl_win ;
    public SkeletonGraphic a_girl,a_fire;
    public GameObject g12;
    public bool l11 = false, l12 = false, l13 = false, l14 = false, l15 = false;

    private void Awake()
    {
        Level11.ins = this;
    }
    private void Start()
    {
        g12.gameObject.SetActive(true);

        girl_lose.gameObject.SetActive(false);
        girl_win.gameObject.SetActive(false);

        wire2.gameObject.SetActive(false);
        wire1.gameObject.SetActive(true);

        dress1.gameObject.SetActive(true);
        hair1.gameObject.SetActive(true);
        dress2.gameObject.SetActive(false);
        hair2.gameObject.SetActive(false);
        hair3.gameObject.SetActive(false);
        dress3.gameObject.SetActive(false);
        face1.gameObject.SetActive(true);
        face2.gameObject.SetActive(false);

        cabinet1.gameObject.SetActive(false);
        cabinet2.gameObject.SetActive(true);
        cat1.gameObject.SetActive(true);
        towel1.gameObject.SetActive(true);
        wool1.gameObject.SetActive(true);
        wool2.gameObject.SetActive(false); 
        wool3.gameObject.SetActive(false);
        towel2.gameObject.SetActive(false);
        cat2.gameObject.SetActive(false);
        cat3.gameObject.SetActive(false);
        towel3.gameObject.SetActive(false);


        body.gameObject.SetActive(true);
        clothers1.gameObject.SetActive(true);
        dumbbell1.gameObject.SetActive(true);
        phai.gameObject.SetActive(true);
        trai.gameObject.SetActive(true);
        clothers2.gameObject.SetActive(false);
        dumbell2.gameObject.SetActive(false);
        clothers3.gameObject.SetActive(false);
        dumbell3.gameObject.SetActive(false);

        broom2.gameObject.SetActive(false);
        blanket2.gameObject.SetActive(false);
        broom3.gameObject.SetActive(false);
        blanket3.gameObject.SetActive(false);
        broom1.gameObject.SetActive(true);
        boyt3.gameObject.SetActive(true);
        girlt3.gameObject.SetActive(true);
        blanket1.gameObject.SetActive(true);

        bart22.gameObject.SetActive(false);
        towelt22.gameObject.SetActive(false);
        bart23.gameObject.SetActive(false);
        towelt23.gameObject.SetActive(false);
        bart21.gameObject.SetActive(true);
        towelt21.gameObject.SetActive(true);

        bg_done.gameObject.SetActive(true);

        a_girl.gameObject.SetActive(true);
        a_fire.gameObject.SetActive(true);

        a_girl.AnimationState.SetAnimation(1, "animation", true);
        a_fire.AnimationState.SetAnimation(1, "animation", true);


        g12.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, -83f, 0f);
        a_girl.GetComponent<RectTransform>().anchoredPosition = new Vector3(-263f, 17f, 0f);
        l11 = false; l12 = false; l13 = false; l14 = false; l15 = false;
        AudioManager.ins.playmusicgame(AudioManager.ins.level11[1]);

        frBg2.gameObject.SetActive(false);
        Bg_black2.gameObject.SetActive(false);

        t1 = false; t2 = false; t3 = false; t4 = false; t5 = false; t6 = false; t7 = false;
    }
    public bool t1 = false, t2 = false, t3 = false, t4 = false, t5 = false, t6 = false, t7 = false;
    public void PauseAnimation()
    {
        a_girl.timeScale = 0; // Dừng Spine Animation
        a_fire.timeScale = 0;

    }

    public void ResumeAnimation()
    {
        a_girl.timeScale = 1;
        a_fire.timeScale = 1;

    }
    public void OnAnimationComplete(TrackEntry trackEntry)
    {

    }
    public void OnAnimationComplete1(TrackEntry trackEntry)
    {


    }
    public void OnAnimationComplete2(TrackEntry trackEntry)
    {

    }
    public bool acheck = false;
    public int gameover = 0;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy

    public void gameOver()
    {
        textCoroutine2 = StartCoroutine(ENDGAME());
    }
    public void overGG()
    {
        textCoroutine2 = StartCoroutine(ENDOVER());

    }
    public IEnumerator ENDGAME()
    {
        Level11.ins.chageString("lev11_12");

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
