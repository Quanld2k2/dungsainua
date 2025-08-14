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

public class Level21 : MonoBehaviour
{
    public static Level21 ins;
    // Anim (SkeletonGraphic)
    public SkeletonGraphic a_boy, a_smoke;

    // Các GameObject bình thường
    public Image bg, girl, table, hotpot, blender,boy1, boy2,
                       chinsu, chili, garlic1, glass1, bell, chili3,
                       otbot1, wine, mutat, blender2, glass2, otbot2, chinsu2, chili2, mutat2, garlic2;

    private void Awake()
    {
        Level21.ins = this;
    }
    private void Start()
    {
        startLevel();
    }
    public void startLevel()
    {
        // Bật tất cả GameObject
        bg.gameObject.SetActive(true);
        girl.gameObject.SetActive(false);
        table.gameObject.SetActive(true);
        hotpot.gameObject.SetActive(true);
        blender.gameObject.SetActive(true);
        chinsu.gameObject.SetActive(false);
        chili.gameObject.SetActive(false);
        garlic1.gameObject.SetActive(false);
        glass1.gameObject.SetActive(true);
        bell.gameObject.SetActive(true);
        otbot1.gameObject.SetActive(false);
        wine.gameObject.SetActive(false);
        mutat.gameObject.SetActive(false);
        chili3.gameObject.SetActive(false);

        boy1.gameObject.SetActive(false);
        boy2.gameObject.SetActive(false);

        otbot2.gameObject.SetActive(false);
        chinsu2.gameObject.SetActive(false);
        chili2.gameObject.SetActive(false);
        mutat2.gameObject.SetActive(false);
        garlic2.gameObject.SetActive(false);
        blender2.gameObject.SetActive(false);
        glass2.gameObject.SetActive(false);

        frBg2.gameObject.SetActive(false);
        Bg_black2.gameObject.SetActive(false);

        // Bật SkeletonGraphic (nếu dùng Spine)
        a_boy.gameObject.SetActive(true);
        a_smoke.gameObject.SetActive(true);

        a_boy.AnimationState.SetAnimation(1, "animation", true);
        a_smoke.AnimationState.SetAnimation(1, "animation", true);

        l21a = false; l21a2 = false;
        gameover = 0;
        AudioManager.ins.playmusicgame(AudioManager.ins.muisgame);

        timeS();
    }

    public bool l21a = false, l21a2 = false;

    public void PauseAnimation()
    {
        a_boy.timeScale = 0;
        a_smoke.timeScale = 0;
        // GameManager.ins.Pause = true;
        //  a_boy.timeScale = 0;
        //  a_girl.timeScale = 0;
        PauseTimer();
    }

    public void ResumeAnimation()
    {
        a_boy.timeScale = 1;
        a_smoke.timeScale = 1;
        isPaused = false;
        // GameManager.ins.Pause = true;
     //   a_boy.timeScale = 1;
     //   a_girl.timeScale = 1;
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
    public IEnumerator edededed()
    {
        yield return new WaitForSeconds(2f);
        if (Level21.ins.l21a2 == true)
        {
            Level21.ins.l21a2 = false;
            Level21.ins.boy1.gameObject.SetActive(false);
            Level21.ins.a_boy.gameObject.SetActive(true);
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
    /// <summary>
    /// ////////////////////////////////////////////
    /// </summary>


    public bool bot1, bot2, bot3, bot4, bot5, bot6, bot7, bot8, bot9 = false;
    
    public void OnAnimationComplete3(TrackEntry trackEntry)
    {
        //    Level5.ins.a_perfume.gameObject.SetActive(false);


    }

    public int gameover = 0;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy
    public void endGame()
    {

        Debug.Log("endgame");
        if (gameover == 7)
        {
            Level21.ins.chageString("lev21_10");

            PauseTimer();
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
