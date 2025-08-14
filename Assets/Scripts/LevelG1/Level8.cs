using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Spine.Unity;
using Spine;
using System.Collections;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;
public class Level8 : MonoBehaviour
{
    public static Level8 ins;

    public Image bg,lifebuoy,duck,shoe,fish,bag,chair,ballon,cocconut,bottle,girl2,tree,
        ballon2,duck2,fish2,lifebuoy2,shoe2,bottle2,bag2,tree2;

    public SkeletonGraphic a_zombie,a_girl1,a_girl2;

    private void Awake()
    {
        Level8.ins = this;
    }

    private void Start()
    {
        startLevel();
    }
    public void startLevel()
    {
        bg.gameObject.SetActive(true);
        lifebuoy.gameObject.SetActive(true);
        duck.gameObject.SetActive(true);
        shoe.gameObject.SetActive(true);
        fish.gameObject.SetActive(true);
        bag.gameObject.SetActive(true);
        chair.gameObject.SetActive(true);
        ballon.gameObject.SetActive(true);
        cocconut.gameObject.SetActive(true);
        bottle.gameObject.SetActive(true);
        girl2.gameObject.SetActive(true);
        tree.gameObject.SetActive(true);
        ballon2.gameObject.SetActive(false);
        duck2.gameObject.SetActive(false);
        fish2.gameObject.SetActive(false);
        lifebuoy2.gameObject.SetActive(false);
        shoe2.gameObject.SetActive(false);
        bottle2.gameObject.SetActive(false);
        bag2.gameObject.SetActive(false);
        tree2.gameObject.SetActive(false);

        a_zombie.gameObject.SetActive(true);
        a_girl1.gameObject.SetActive(true);
        a_girl2.gameObject.SetActive(false);

        a_zombie.AnimationState.SetAnimation(1, "animation", true);
        a_girl1.AnimationState.SetAnimation(1, "anim1", true);

        fish2.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, -180f, 0f);
        bottle2.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, -180f, 0f);
        ballon2.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, -180f, 0f);
        tree2.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, -180f, 0f);
        shoe2.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, -180f, 0f);
        duck2.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, -180f, 0f);
        bag2.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, -180f, 0f);
        lifebuoy2.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, -180f, 0f);

        //  duck2.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, -180f, 0f);

        a_girl2.AnimationState.Complete += OnAnimationComplete;
        aa1 = 0;
        frBg2.gameObject.SetActive(false);
        Bg_black2.gameObject.SetActive(false);

        AudioManager.ins.play1shot(AudioManager.ins.level8[3]);

        ResumeAnimation();
        timeS();

    }
    public int aa1 = 0;
    public void OnAnimationComplete(TrackEntry trackEntry)
    {
        aa1 += 1;
        gameover += 1;
        a_girl1.gameObject.SetActive(true);
        a_girl2.gameObject.SetActive(false);
        timeS();
        AudioManager.ins.play1shot(AudioManager.ins.level8[1]);

        endGame();
    }

    public void PauseAnimation()
    {
        PauseTimer();
       

      
        a_girl1.timeScale = 0; // Dừng Spine Animation
        a_girl2.timeScale = 0;
        a_zombie.timeScale = 0;
    }

    public void ResumeAnimation()
    {
        StartTimer();
        a_girl1.timeScale = 1; // Tiếp tục animation
        a_girl2.timeScale = 1;
        a_zombie.timeScale = 1;
    }
    public int gameover = 0;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy
    public void endGame()
    {

        Debug.Log("endgame" + gameover);
        if (gameover == 9)
        {
            textCoroutine2 = StartCoroutine(ENDGAME());
            Debug.Log("gameover");
        }

    }
    public IEnumerator ENDGAME()
    {
        yield return new WaitForSeconds(1f);
        PauseTimer();
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

    /// <summary>
    /// //////////////////////////////////////////
    /// </summary>
    public Slider timeSlider; // Thanh thời gian
    public float totalTime = 10f; // Thời gian chạy (10s)

    private float currentTime;
    private Coroutine timerCoroutine;
    private bool isPaused = false; // Biến kiểm tra trạng thái dừng
    public System.Action onTimeUp; // Sự kiện khi hết thời gian

    public void timeS()
    {
        isPaused = false;
        ResetTimer();
        onTimeUp += OnTimeEnd;
        StartTimer();
    }

    public void StartTimer()
    {

        if (timerCoroutine == null)
        {
            timerCoroutine = StartCoroutine(UpdateTimeBar());
        }
        else if (isPaused) // Nếu đang dừng, tiếp tục chạy
        {
            isPaused = false;
        }
    }

    public void PauseTimer()
    {
        isPaused = true;
    }

    public void ResetTimer()
    {
        if (timerCoroutine != null) StopCoroutine(timerCoroutine);
        currentTime = 0;
        timeSlider.maxValue = totalTime;
        timeSlider.value = 0;
        timerCoroutine = null;
    }

    IEnumerator UpdateTimeBar()
    {
        while (currentTime < totalTime)
        {
            if (!isPaused) // Chỉ chạy nếu không bị dừng
            {
                currentTime += Time.deltaTime;
                timeSlider.value = currentTime;
            }
            yield return null;
        }

        if (currentTime >= totalTime)
        {
            timeSlider.value = totalTime;
            onTimeUp?.Invoke(); // Gọi sự kiện khi hết thời gian
            Debug.Log("Time's up!");
        }
    }
    void OnTimeEnd()
    {
        Debug.Log("Thời gian đã hết! Game Over!");
        UiController.ins.OpenLose();
    }
}
