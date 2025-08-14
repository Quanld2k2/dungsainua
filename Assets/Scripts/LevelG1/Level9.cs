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

public class Level9 : MonoBehaviour
{
    public static Level9 ins;

    public Image bg, cabinet1, cabinet2, clock, door, door_open, candle1, bear, curtain1, curtain2, girl1, a1,
        girl2,lose,knock,miror,money1,money2,pt_boy,ring,thang,ghost1, ghost2, ghost3, ghost4, ghost5, ghost6, ghost7;
    public Image[] ghost;
    public SkeletonGraphic a_girl, a_nock, a_fire;

    private void Awake()
    {
        Level9.ins = this;
    }

    private void Start()
    {
        startLevel();
    }
    public void startLevel()
    {
        bg.gameObject.SetActive(true);
        cabinet1.gameObject.SetActive(true);
        cabinet2.gameObject.SetActive(false);
        clock.gameObject.SetActive(true);
        door.gameObject.SetActive(true);
        door_open.gameObject.SetActive(false);
        candle1.gameObject.SetActive(true);
        bear.gameObject.SetActive(false);
        curtain1.gameObject.SetActive(true);
        curtain2.gameObject.SetActive(false);
        girl1.gameObject.SetActive(false);
        girl2.gameObject.SetActive(false);
        lose.gameObject.SetActive(false);
        knock.gameObject.SetActive(false);
        miror.gameObject.SetActive(true);
        money1.gameObject.SetActive(true);
        money2.gameObject.SetActive(false);
        pt_boy.gameObject.SetActive(false);
        ring.gameObject.SetActive(false);
        thang.gameObject.SetActive(true);
        ghost1.gameObject.SetActive(false);
        ghost2.gameObject.SetActive(false);
        ghost3.gameObject.SetActive(false);
        ghost4.gameObject.SetActive(false);
        ghost5.gameObject.SetActive(false);
        ghost6.gameObject.SetActive(false);
        ghost7.gameObject.SetActive(false);
        a1.gameObject.SetActive(true);

        a_girl.gameObject.SetActive(true);
        a_nock.gameObject.SetActive(false);
        a_fire.gameObject.SetActive(false);

        a_nock.AnimationState.Complete += OnAnimationComplete1;
        a_girl.AnimationState.SetAnimation(1, "animation", true);
        aanim = 0;

        AudioManager.ins.playmusicgame(AudioManager.ins.level9[4]);
        frBg2.gameObject.SetActive(false);
        Bg_black2.gameObject.SetActive(false);
        ResumeAnimation();
        selects = false;
        seint = 0;
    }
    public bool selects = false;
    public int seint = 0;

    public void OnAnimationComplete1(TrackEntry trackEntry)
    {
        seint += 1;
        if (seint == 2)
        {
            selects = false;
            a_nock.gameObject.SetActive(false);
           Level9.ins.selec1(Level9.ins.ghost3.gameObject);
        }
        

    }

    public void PauseAnimation()
    {
        // GameManager.ins.Pause = true;
        a_girl.timeScale = 0;
        a_nock.timeScale = 0; a_fire.timeScale = 0;

    }

    public void ResumeAnimation()
    {
        // GameManager.ins.Pause = true;
        a_girl.timeScale = 1;
        a_nock.timeScale = 1; a_fire.timeScale = 1;

    }
    public int aanim = 0;
    public void selec2()
    {
        DG.Tweening.Sequence sequence = DOTween.Sequence();
        for (int i = 0; i < ghost.Length; i++)
        {
            if (i >= aanim)
            {
                RectTransform rect = ghost[i].rectTransform;
                Vector2 targetPosition = ghost[i - 1].rectTransform.anchoredPosition;
                sequence.Join(rect.DOAnchorPos(targetPosition, 0.5f)
                .SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                }));
            }
        }
    }
    public void selec1(GameObject akk)
    {
        // Ẩn sau khi bay lên + mờ
        GameObject ghostObj = akk;
        RectTransform rect = ghostObj.GetComponent<RectTransform>();
        CanvasGroup canvasGroup = ghostObj.GetComponent<CanvasGroup>();

        // Nếu object chưa có CanvasGroup thì thêm vào để điều khiển alpha
        if (canvasGroup == null)
            canvasGroup = ghostObj.AddComponent<CanvasGroup>();

        // Reset alpha để bắt đầu từ trạng thái rõ ràng
        canvasGroup.alpha = 1f;

        // Bắt đầu bay lên + mờ dần
        rect.DOAnchorPos(new Vector2(179f, 600f), 1f)
        .SetEase(Ease.OutQuad)
        .SetDelay(0.7f);
        canvasGroup.DOFade(0f, 1f).SetEase(Ease.InQuad).SetDelay(0.5f).OnComplete(() =>
        {
            ghostObj.SetActive(false); // Ẩn khi hoàn tất
            Level9.ins.selec2();
            Level9.ins.gameover += 1;
            Level9.ins.gameOver();
        });
    }

    public int gameover = 0;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy

    public void gameOver()
    {
        Debug.Log(gameover);

        if (gameover == 7)
        {
           // AudioManager.ins.Stop2();
            Debug.Log("gameover");
            textCoroutine2 = StartCoroutine(ENDGAME());
        }else if (gameover == 100)
        {
            //AudioManager.ins.Stop2();

            Debug.Log("gameover");
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
        yield return new WaitForSeconds(3f);
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
