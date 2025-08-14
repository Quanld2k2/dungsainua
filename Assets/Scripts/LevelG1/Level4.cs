using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Spine.Unity;
using Spine;
using System.Collections;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;

public class Level4 : MonoBehaviour
{
    public static Level4 ins;
    public Image basket, bin, blanket, boy, bucket, flute, garbage, poster, skateboard, snake, socks, ufo, umbrella;
    public SkeletonGraphic[] a1, a2;
    public SkeletonGraphic a_ghost, a_ghostboy, a_girl;

    private void Awake()
    {
        Level4.ins = this;
    }

    private void Start()
    {
        startLevel();
    }

    public void startLevel()
    {
        Debug.Log("lv4");

        basket.gameObject.SetActive(true);
        bin.gameObject.SetActive(true);
        blanket.gameObject.SetActive(true);
        boy.gameObject.SetActive(true);
        bucket.gameObject.SetActive(true);
        flute.gameObject.SetActive(true);
        garbage.gameObject.SetActive(false);
        poster.gameObject.SetActive(true);
        skateboard.gameObject.SetActive(true);
        snake.gameObject.SetActive(false);
        socks.gameObject.SetActive(false);
        ufo.gameObject.SetActive(true);
        umbrella.gameObject.SetActive(true);
        a_ghost.gameObject.SetActive(false);
        a_ghostboy.gameObject.SetActive(true);
        a_girl.gameObject.SetActive(true);
     //   c1.gameObject.SetActive(false);
        aanim = 0;
        a1333 = false;
        GameManager.ins.Click1 = 0;

       // c1.AnimationState.Complete += OnAnimationComplete1;
        a_girl.AnimationState.SetAnimation(1, "animation", true);
        a_ghostboy.AnimationState.SetAnimation(1, "animation", true);

        Bg_black2.gameObject.SetActive(false);
        frBg2.gameObject.SetActive(false);

        ResumeAnimation();
        AudioManager.ins.play1shot(AudioManager.ins.level4[1]);
        AudioManager.ins.playmusicgame(AudioManager.ins.level4[0]);

    }
    public bool a112 = false,a1333 = false;
    public void OnAnimationComplete1(TrackEntry trackEntry)
    {
        if (a112 == true)
        {
            //Level4.ins.c1.gameObject.SetActive(false);

        }

    }

    public int gameover = 0;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy
    public void endGame()
    {
        
        Debug.Log("endgame");
        if (gameover == 8)
        {
            textCoroutine2 = StartCoroutine(ENDGAME());
            Debug.Log("gameover");
        }

    }
    public IEnumerator ENDGAME()
    {
        yield return new WaitForSeconds(1f);
        UiController.ins.WinGame();
    }
    public void PauseAnimation()
    {
        // GameManager.ins.Pause = true;
        a_girl.timeScale = 0;
        a_ghostboy.timeScale = 0;
    }

    public void ResumeAnimation()
    {
        // GameManager.ins.Pause = true;
        a_girl.timeScale = 1;
        a_ghostboy.timeScale = 1;
    }

    public void selec()
    {
        for (int i = 0; i < a1.Length; i++)
        {
            a1[i].gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-645f, 160f);

        }
        //sequence.Append(rect.DOAnchorPos(new Vector2(-255 + (i * 50), 34), 0.5f)
        DG.Tweening.Sequence sequence = DOTween.Sequence(); // Sử dụng DOTween.Sequence
        float adjustedDelay = 0.1f;

        for (int i = 0; i < a1.Length; i++)
        {
            RectTransform rect = a1[i].rectTransform;
            Vector2 midPoint = new Vector2(202 - (i * 50), 76 - (i * 50));
            Vector2 targetPosition = a2[i].rectTransform.anchoredPosition;

            sequence.Join(rect.DOAnchorPos(midPoint, 0.2f / 2)
            .SetEase(Ease.OutQuad)
            .SetDelay(i * adjustedDelay)
            .OnComplete(() =>
            {
                rect.DOAnchorPos(targetPosition, 0.5f);
                //.SetEase(Ease.InQuad);
            }));
        }
    }
    public int aanim = 0;
    public void selec2()
    {
        for (int i = 0; i < a2.Length; i++)
        {
            Level4.ins.a2[i].AnimationState.SetAnimation(1, "animation", false);
        }

        DG.Tweening.Sequence sequence = DOTween.Sequence();
        for (int i = 0; i < a1.Length; i++)
        {

            // Vector2 midPoint = new Vector2(202 - (i * 50), 76 - (i * 50));
            if (i >= aanim)
            {
                RectTransform rect = a2[i].rectTransform;
                Vector2 targetPosition = a2[i - 1].rectTransform.anchoredPosition;
                sequence.Join(rect.DOAnchorPos(targetPosition, 0.5f)
                .SetEase(Ease.OutQuad)
                // .SetDelay(i * adjustedDelay)
                .OnComplete(() =>
                {
                   
                    if (i == (a1.Length - 1))
                    {
                        for (int i = 0; i < a2.Length; i++)
                        {
                            // Level4.ins.a2[i].AnimationState.SetAnimation(1, "animation", false);

                        }
                    }
                }));

                if (i == (a1.Length - 1))
                {
                    a_girl.gameObject.GetComponent<RectTransform>().DOAnchorPos(a2[i].rectTransform.anchoredPosition, 0.4f).OnComplete(() =>
                    {

                        ///a_girl.AnimationState.SetAnimation(1, "animation", false);
                    });
                }
            }
        }
    }
    public GameObject prefabToSpawn1, prefabToSpawn2, prefabToSpawn3, prefabToSpawn4, prefabToSpawn5, prefabToSpawn6, prefabToSpawn7, prefabToSpawn8;
    public GameObject parentCanvas;
    public void SpawnMoveAndDestroy(GameObject prefabToSpawn)
    {
        if (parentCanvas == null)
        {
            Debug.LogError("Parent canvas is not assigned.");
            return;
        }
        GameObject newObject = Instantiate(prefabToSpawn, parentCanvas.transform);
        RectTransform rectTransform = newObject.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            AudioManager.ins.play1shot(AudioManager.ins.level4[5]);

            rectTransform.anchoredPosition = new Vector3(197f, 129f, 0f);
            rectTransform.DOAnchorPos(new Vector3(674f, 8f, 0f), 1f)
                        .SetEase(Ease.Linear)
                        .SetDelay(0.5f)
                        .OnComplete(() =>
                        {
                            gameover += 1;
                            endGame();
                            Level4.ins.selec2();
                            Destroy(newObject);
                        });
        }
        else
        {
            Debug.LogError("The prefab does not have a RectTransform component.");
        }
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
