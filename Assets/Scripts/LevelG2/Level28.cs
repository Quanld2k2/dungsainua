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


public class Level28 : MonoBehaviour
{
    public static Level28 ins;

    // Anim
    public SkeletonGraphic a_duck;

    // GameObject
    public Image bg, rocket, bag, moutain, rope, hook, cloud1, cloud2, ballon, plane,
        nest,egg1, egg2, cloud3,thunder ;
    public Image[] q1,q2;

    private void Awake()
    {
        ins = this;
    }
    private void Start()
    {
        bg.gameObject.SetActive(true);
        rocket.gameObject.SetActive(true);
        bag.gameObject.SetActive(true);
        moutain.gameObject.SetActive(true);
        rope.gameObject.SetActive(true);
        hook.gameObject.SetActive(true);
        cloud1.gameObject.SetActive(true);
        cloud2.gameObject.SetActive(true);
        ballon.gameObject.SetActive(true);
        plane.gameObject.SetActive(true);
        nest.gameObject.SetActive(true);
        egg1.gameObject.SetActive(true);
        egg2.gameObject.SetActive(true);
        cloud3.gameObject.SetActive(false);
        thunder.gameObject.SetActive(false);

        intCK = 0; intEGG = 0;
        bolck = false;
        frBg2.gameObject.SetActive(false);
        Bg_black2.gameObject.SetActive(false);
        move(); AudioManager.ins.playmusicgame(AudioManager.ins.muisgame);
    
    }
    public void PauseAnimation()
    {
        // GameManager.ins.Pause = true;
        //  a_boy.timeScale = 0;
        //  a_girl.timeScale = 0;
      //  PauseTimer();
    }

    public void ResumeAnimation()
    {
      //  isPaused = false;
        // GameManager.ins.Pause = true;
        //   a_boy.timeScale = 1;
        //   a_girl.timeScale = 1;
    }
    public int intCK = 0, intEGG = 0;
    public bool bolck = false;
    public void move()
    {

        for (int i = 0; i < q1.Length; i++)
        {
            var graphics = q1[i].GetComponentsInChildren<UnityEngine.UI.Graphic>(true);

            q1[i].gameObject.SetActive(false);
            q1[i].gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-800f, -200f);

            q2[i].gameObject.SetActive(false);

            foreach (var graphic in graphics)
            {
                graphic.raycastTarget = false;
            }
            if (i == intCK)
                {
                    q1[i].gameObject.SetActive(true);
                    q2[i].gameObject.SetActive(true);

                // q1[i].gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(150f, -200f);
                q1[i].gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(150f, -200f), 1f).OnComplete(() =>
                    {
                    });

                    foreach (var graphic in graphics)
                    {
                        graphic.raycastTarget = true;
                    }
                }
                else if (i == (intCK + 1))
                {
                    q1[i].gameObject.SetActive(true);

                    // q1[i].gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-130f, -200f);
                    q1[i].gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-130f, -200f), 1f).SetDelay(0.2f).OnComplete(() =>
                    {
                    });
                }
                else if (i == (intCK + 2))
                {
                    q1[i].gameObject.SetActive(true);
                    //  q1[i].gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-400f, -200f);
                    q1[i].gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-400f, -200f), 1f).SetDelay(0.4f).OnComplete(() =>
                    {
                    });
                }
            
        }
    }
    public void move2()
    {
        Debug.Log("move2" + intCK);
        DG.Tweening.Sequence sequence = DOTween.Sequence();
        int dem = 0;
        for (int i = 0; i < q1.Length; i++)
        {
            if (i >= intCK)
            {
                dem += 1;
                if (dem == 1)
                {
                    if (bolck == true)
                    {
                        var graphics = q1[i].GetComponentsInChildren<UnityEngine.UI.Graphic>(true);
                        foreach (var graphic in graphics)
                        {
                            graphic.raycastTarget = false;
                        }
                    }
                    else
                    {
                        var graphics = q1[i].GetComponentsInChildren<UnityEngine.UI.Graphic>(true);
                        foreach (var graphic in graphics)
                        {
                            graphic.raycastTarget = true;
                        }
                    }
                    q2[i].gameObject.SetActive(true);
                }
                if (dem <= 3)
                {
                    q1[i].gameObject.SetActive(true);
                    RectTransform rect = q1[i].rectTransform;
                    Vector2 targetPosition = q1[i - 1].rectTransform.anchoredPosition;
                    sequence.Join(rect.DOAnchorPos(targetPosition, 0.5f)
                    .SetEase(Ease.OutQuad)
                    .OnComplete(() =>
                    {

                    }));
                }
                else
                {
                    q1[i].gameObject.SetActive(false);
                }
                
            }

        }
    }
    public GameObject prefabToSpawn1, prefabToSpawn2, prefabToSpawn3, prefabToSpawn4, prefabToSpawn5, prefabToSpawn6, prefabToSpawn7, prefabToSpawn8, prefabToSpawn9;
    public GameObject parentCanvas;
    public void SpawnAndPlaySpineAnimOnly(GameObject prefabToSpawn, string animName)
    {
        if (parentCanvas == null)
        {
            Debug.LogError("Parent canvas is not assigned.");
            return;
        }

        GameObject newObject = Instantiate(prefabToSpawn, parentCanvas.transform);
        RectTransform rectTransform = newObject.GetComponent<RectTransform>();
        Spine.Unity.SkeletonGraphic skeletonGraphic = newObject.GetComponent<Spine.Unity.SkeletonGraphic>();

        if (rectTransform != null)
        {
            rectTransform.anchoredPosition = new Vector3(180f, -110f, 0f);

            if (skeletonGraphic != null)
            {
                // ✅ Play anim tuỳ tên
                skeletonGraphic.AnimationState.SetAnimation(0, animName, false);

                // ✅ Lấy duration
                var anim = skeletonGraphic.Skeleton.Data.FindAnimation(animName);
                if (anim != null)
                {
                    StartCoroutine(DestroyAfterAnim(newObject, anim.Duration));
                }
                else
                {
                    Debug.LogWarning("Animation " + animName + " not found!");
                    Destroy(newObject);
                }
            }
            else
            {
                Debug.LogWarning("Prefab has no SkeletonGraphic.");
                Destroy(newObject);
            }
        }
        else
        {
            Debug.LogError("The prefab does not have a RectTransform component.");
        }
    }
    private IEnumerator DestroyAfterAnim(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        gameover += 1;
        endGame();
        move2();
        Destroy(obj);
    }
    public int gameover = 0;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy
    public void endGame()
    {
        Debug.Log("endgame" + gameover);
        if (gameover == 10)
        {

            textCoroutine2 = StartCoroutine(ENDGAME());
            Debug.Log("gameover");
        }

    }
    public IEnumerator ENDGAME()
    {
        yield return new WaitForSeconds(0.5f);
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
