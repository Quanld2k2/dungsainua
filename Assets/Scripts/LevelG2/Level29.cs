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

public class Level29 : MonoBehaviour
{
    public static Level29 ins;
    public Image bg, kitchen, kitchen2, wal;
    public Image perfume, bowtie, lipstick, snake;
    public Image soap2, toilet, toilet2, bathtub;
    public Image curtain1, curtain2, soap, table;
    public Image underwear, eyeshadow, shortakirt, hairstraightener;
    public SkeletonGraphic anim_mother, anim_boy, anim_girl;

    private void Awake()
    {
        Level29.ins = this;
    }
    private void Start()
    {
        startLevel();
    }
    public void startLevel()
    {        
        bg.gameObject.SetActive(true);
        kitchen.gameObject.SetActive(true);
        kitchen2.gameObject.SetActive(false);
        wal.gameObject.SetActive(true);

        perfume.gameObject.SetActive(false);
        bowtie.gameObject.SetActive(true);
        lipstick.gameObject.SetActive(true);
        snake.gameObject.SetActive(false);

        soap2.gameObject.SetActive(true);
        toilet.gameObject.SetActive(true);
        toilet2.gameObject.SetActive(false);
        bathtub.gameObject.SetActive(true);

        curtain1.gameObject.SetActive(true);
        curtain2.gameObject.SetActive(false);
        soap.gameObject.SetActive(false);
        table.gameObject.SetActive(true);

        underwear.gameObject.SetActive(true);
        eyeshadow.gameObject.SetActive(true);
        shortakirt.gameObject.SetActive(true);
        hairstraightener.gameObject.SetActive(true);

        anim_mother.gameObject.SetActive(true);
        anim_boy.gameObject.SetActive(true);
        anim_girl.gameObject.SetActive(true);

        anim_mother.AnimationState.SetAnimation(1, "animation", true);
        anim_boy.AnimationState.SetAnimation(1, "animation", true);
        anim_girl.AnimationState.SetAnimation(1, "idle", true);

        anim_girl.AnimationState.Complete += OnAnimationComplete1;

        l21a2 = false;
        gameover = 0;

        frBg2.gameObject.SetActive(false);
        Bg_black2.gameObject.SetActive(false);

        timeS(); AudioManager.ins.playmusicgame(AudioManager.ins.muisgame);

    }
    public void OnAnimationComplete1(TrackEntry trackEntry)
    {
        if (l21a2 == false)
        {

        }
        anim_girl.gameObject.SetActive(true);
        anim_girl.AnimationState.SetAnimation(1, "idle", true);


    }

    public bool l21a = false, l21a2 = false;

    public void PauseAnimation()
    {
        // GameManager.ins.Pause = true;
            anim_mother.timeScale = 0;
            anim_boy.timeScale = 0;
            anim_girl.timeScale = 0;

        PauseTimer();
    }

    public void ResumeAnimation()
    {
        isPaused = false;
        // GameManager.ins.Pause = true;
        //   a_boy.timeScale = 1;
        anim_mother.timeScale = 1;
        anim_boy.timeScale = 1;
        anim_girl.timeScale = 1;
    }

    /// <summary>
    /// //////////////////////////////////////////
    /// </summary>
    public Slider timeSlider; // Thanh thời gian
    public float totalTime = 10f; // Thời gian chạy (10s)

    private float currentTime;
    private Coroutine timerCoroutine;
    private bool isPaused = false; //                   iến kiểm tra trạng thái dừng
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
    /// <summary>
    /// ////////////////////////////////////////////
    /// </summary>

    public int gameover = 0;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy
    public void endGame()
    {

        Debug.Log("endgame"+ gameover);
        if (gameover == 9)
        {
            PauseTimer();
            textCoroutine2 = StartCoroutine(ENDGAME());
            Debug.Log("gameover");
        }
        else if(gameover == 100)
        {
            PauseTimer();
           textCoroutine2 = StartCoroutine(ENDOVER());

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
