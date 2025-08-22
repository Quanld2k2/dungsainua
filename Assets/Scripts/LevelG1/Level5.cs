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

public class Level5 : MonoBehaviour
{
    public static Level5 ins;
    public Image bag1,bag2, bag3, ballon1,ballon2,ballon3,bin,bottle1,bottle2,bottle3, bottle4,
        durian1,durian2, durian3, fan,hat1,hat2,hat3,headphone,knife,nilon1,nilon2,nilon3,perfume,snow1,snow2, snow3;
    public SkeletonGraphic a_perfume,a_girl,a_fan,a_dog,a_boy,a_bottle,a_G2;

    private void Awake()
    {
        Level5.ins = this;
    }
    private void Start()
    {
       startLevel();
    }
    public void startLevel()
    {
        bag1.gameObject.SetActive(true);
        bag2.gameObject.SetActive(false);
        bag3.gameObject.SetActive(false);
        ballon1.gameObject.SetActive(true);
        ballon2.gameObject.SetActive(false);
        ballon3.gameObject.SetActive(false);
        bin.gameObject.SetActive(true);
        bottle1.gameObject.SetActive(true);
        bottle2.gameObject.SetActive(false);
        bottle3.gameObject.SetActive(false);
        bottle4.gameObject.SetActive(false);
        durian1.gameObject.SetActive(true);
        durian2.gameObject.SetActive(false);
        durian3.gameObject.SetActive(false);

        fan.gameObject.SetActive(true);
        hat1.gameObject.SetActive(true);
        hat2.gameObject.SetActive(false);
        hat3.gameObject.SetActive(false);
        headphone.gameObject.SetActive(true);
        knife.gameObject.SetActive(true);
        nilon1.gameObject.SetActive(true);
        nilon2.gameObject.SetActive(false);
        nilon3.gameObject.SetActive(false);

        perfume.gameObject.SetActive(false);
        snow1.gameObject.SetActive(true);
        snow2.gameObject.SetActive(false);
        snow3.gameObject.SetActive(false);

        a_perfume.gameObject.SetActive(false);
        a_girl.gameObject.SetActive(true);
        a_fan.gameObject.SetActive(false);
        a_dog.gameObject.SetActive(false);
        a_boy.gameObject.SetActive(true);
        a_bottle.gameObject.SetActive(false);
        a_G2.gameObject.SetActive(false);
        a_boy.AnimationState.SetAnimation(1, "Anim1", true);
        a_girl.AnimationState.SetAnimation(1, "anim1", true);
        bot1 = false; bot2 = false; bot3 = false; bot4 = false; bot5 = false; bot6 = false; bot7 = false; bot8 = false; bot9 = false;

        a_bottle.AnimationState.Complete += OnAnimationComplete1;
        a_G2.AnimationState.Complete += OnAnimationComplete2;
        a_perfume.AnimationState.Complete += OnAnimationComplete3;

        Bg_black2.gameObject.SetActive(false);
        frBg2.gameObject.SetActive(false);
        GameManager.ins.Click1 = 0;
        head = false;
        timeS();
        Level5.ins.chageString("lev5_9");
        AudioManager.ins.playmusicgame(AudioManager.ins.muisgame);

    }

    public void PauseAnimation()
    {
        // GameManager.ins.Pause = true;
        a_boy.timeScale = 0;
        a_girl.timeScale = 0;
        PauseTimer();
    }

    public void ResumeAnimation()
    {
        isPaused = false;
        // GameManager.ins.Pause = true;
        a_boy.timeScale = 1;
        a_girl.timeScale = 1; 
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
    /// <summary>
    /// ////////////////////////////////////////////
    /// </summary>


    public bool bot1,bot2,bot3, bot4, bot5, bot6, bot7, bot8, bot9 = false;
    public void OnAnimationComplete1(TrackEntry trackEntry)
    {
        a_bottle.gameObject.SetActive(false);
        bottle2.gameObject.SetActive(true);
        AudioManager.ins.stop1shot();

    }
    public void OnAnimationComplete3(TrackEntry trackEntry)
    {
        //    Level5.ins.a_perfume.gameObject.SetActive(false);


    }

    public void PauseSequence()
    {
    }

    // Tiếp tục sequence
    public void PlaySequence()
    {
    }
    public void OnAnimationComplete2(TrackEntry trackEntry)
    {
     //   Debug.Log("OnAnimationComplete2OnAnimationComplete2OnAnimationComplete2OnAnimationComplete2");
        if (bot1 == true)
        {
            bot1 = false;
            Level5.ins.a_girl.gameObject.SetActive(true);

            Level5.ins.a_G2.gameObject.SetActive(false);

            Level5.ins.a_girl.AnimationState.SetAnimation(1, "anim1", true);
            Level5.ins.bottle4.gameObject.SetActive(false);
            Level5.ins.bottle3.gameObject.SetActive(true);

            Sequence bottleSequence = DOTween.Sequence();

            bottleSequence.Append(bottle3.GetComponent<RectTransform>().DORotate(new Vector3(0f, 0f, 360f), 1.3f, DG.Tweening.RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Restart));

            bottleSequence.Join(bottle3.GetComponent<RectTransform>()
                .DOAnchorPos(new Vector3(200f, 519f, 0f), 2f)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.Linear));

            timeS();
        }
        else if (bot2 == true)
        {
            bot2 = false; Level5.ins.a_girl.gameObject.SetActive(true);

            Level5.ins.a_G2.gameObject.SetActive(false);
            Level5.ins.a_girl.AnimationState.SetAnimation(1, "anim1", true);
            Level5.ins.hat3.gameObject.SetActive(false);
            Level5.ins.hat2.gameObject.SetActive(true); 
            timeS();

          //  hat2.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-243f, 514f, 0f), 0.4f);
            hat2.GetComponent<RectTransform>().anchoredPosition = new Vector3(-243f, 514f, 0f);
            hat2.GetComponent<RectTransform>().DORotate(new Vector3(0f, 0f, 360f), 1.3f, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Restart); // Xoay vô hạn trên trục Z
            hat2.GetComponent<RectTransform>()
                        .DOAnchorPos(new Vector3(200f, 519f, 0f),2f)
                        .SetLoops(-1, LoopType.Yoyo) // Lặp vô hạn theo kiểu Yoyo (qua lại)
                        .SetEase(Ease.Linear); // Giữ tốc độ di chuyển mượt
            
        }
        else if (bot3 == true)
        {
            bot3 = false; Level5.ins.a_girl.gameObject.SetActive(true);

            Level5.ins.a_G2.gameObject.SetActive(false);
            Level5.ins.a_girl.AnimationState.SetAnimation(1, "anim1", true);
            Level5.ins.nilon2.gameObject.SetActive(false);
            Level5.ins.nilon3.gameObject.SetActive(true);

            nilon3.GetComponent<RectTransform>().anchoredPosition = new Vector3(-243f, 514f, 0f);
            nilon3.GetComponent<RectTransform>().DORotate(new Vector3(0f, 0f, 360f), 1.3f, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Restart); // Xoay vô hạn trên trục Z
            nilon3.GetComponent<RectTransform>()
                        .DOAnchorPos(new Vector3(200f, 519f, 0f), 2f)
                        .SetLoops(-1, LoopType.Yoyo) // Lặp vô hạn theo kiểu Yoyo (qua lại)
                        .SetEase(Ease.Linear); // Giữ tốc độ di chuyển mượt

            timeS();
        }
        else if (bot4 == true)
        {
            bot4 = false; Level5.ins.a_girl.gameObject.SetActive(true);

            Level5.ins.a_G2.gameObject.SetActive(false);
            Level5.ins.a_girl.AnimationState.SetAnimation(1, "anim1", true);
            Level5.ins.bag3.gameObject.SetActive(false);
            Level5.ins.bag2.gameObject.SetActive(true);

            bag2.GetComponent<RectTransform>().anchoredPosition = new Vector3(-243f, 514f, 0f);
            bag2.GetComponent<RectTransform>().DORotate(new Vector3(0f, 0f, 360f), 1.3f, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Restart); // Xoay vô hạn trên trục Z
            bag2.GetComponent<RectTransform>()
                        .DOAnchorPos(new Vector3(200f, 519f, 0f), 2f)
                        .SetLoops(-1, LoopType.Yoyo) // Lặp vô hạn theo kiểu Yoyo (qua lại)
                        .SetEase(Ease.Linear); // Giữ tốc độ di chuyển mượt
            timeS();
        }
        else if (bot5 == true)
        {
            bot5 = false; Level5.ins.a_girl.gameObject.SetActive(true);

            Level5.ins.a_G2.gameObject.SetActive(false);
            Level5.ins.a_girl.AnimationState.SetAnimation(1, "anim1", true);
            a_fan.gameObject.SetActive(false); timeS();
        }
        else if (bot6 == true)
        {
            bot6 = false; Level5.ins.a_girl.gameObject.SetActive(true);

            Level5.ins.a_G2.gameObject.SetActive(false);
            Level5.ins.a_girl.AnimationState.SetAnimation(1, "anim1", true);
            durian3.gameObject.SetActive(false); timeS();
        }
        else if (bot7 == true)
        {
            bot7 = false; Level5.ins.a_girl.gameObject.SetActive(true);

            Level5.ins.a_G2.gameObject.SetActive(false);
            Level5.ins.a_girl.AnimationState.SetAnimation(1, "anim1", true);
            snow3.gameObject.SetActive(false);
            snow2.gameObject.SetActive(true);

            


            timeS();

        }
        else if (bot8 == true)
        {
            bot8 = false; Level5.ins.a_girl.gameObject.SetActive(true);

            Level5.ins.a_G2.gameObject.SetActive(false);
            Level5.ins.a_girl.AnimationState.SetAnimation(1, "anim1", true);
            ballon2.gameObject.SetActive(false);
            ballon3.gameObject.SetActive(true);

            ballon3.GetComponent<RectTransform>().anchoredPosition = new Vector3(-243f, 514f, 0f);
            ballon3.GetComponent<RectTransform>().DORotate(new Vector3(0f, 0f, 360f), 1.3f, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Restart); // Xoay vô hạn trên trục Z
            ballon3.GetComponent<RectTransform>()
                        .DOAnchorPos(new Vector3(200f, 519f, 0f), 2f)
                        .SetLoops(-1, LoopType.Yoyo) // Lặp vô hạn theo kiểu Yoyo (qua lại)
                        .SetEase(Ease.Linear); // Giữ tốc độ di chuyển mượt

            timeS();

        }

        else if (bot9 == true)
        {
            bot9 = false;
            
            Level5.ins.a_girl.gameObject.SetActive(true);

            Level5.ins.a_G2.gameObject.SetActive(false);
            Level5.ins.a_girl.AnimationState.SetAnimation(1, "anim1", true);
            a_perfume.gameObject.SetActive(false); timeS();
            // ballon3.gameObject.SetActive(true);

        }
        gameover += 1;
        endGame();

    }

    public int gameover = 0;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy
    public void endGame()
    {

        Debug.Log("endgame");
        if (gameover == 9)
        {
            PauseTimer();
            textCoroutine2 = StartCoroutine(ENDGAME());
            Debug.Log("gameover");
        }else  
        {
            if (head == false)
            {
                PauseTimer();
                textCoroutine2 = StartCoroutine(ENDOVER());
            }
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
