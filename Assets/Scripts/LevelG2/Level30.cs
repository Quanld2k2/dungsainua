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

public class Level30 : MonoBehaviour
{
    public static Level30 ins;

    public Image bg, table, binhnuoc;
    public Image cabinet, cabinet1, cabinet2, cabinetO1, cabinetO2, fridge, fridge1;

    public Image tool1, tool2, tool3, tool4, tool5, tool6, tool7;
    public Image tool8, tool9, tool10, tool11, tool12, tool13, tool13_1;
    public Image tool14, tool14_1;

    public Image diaa1, diaa2, sh2, s1, boyboy;
    public SkeletonGraphic anim_boy, anim_girl;
    public Image[] t, sh;
    private void Awake()
    {
        Level30.ins = this;
    }
    private void Start()
    {
        startLevel();
    }
    public void startLevel()
    {
        bg.gameObject.SetActive(true);
        table.gameObject.SetActive(true);
        binhnuoc.gameObject.SetActive(false);

        cabinet.gameObject.SetActive(true);
        cabinet1.gameObject.SetActive(true);
        cabinet2.gameObject.SetActive(true);
        cabinetO1.gameObject.SetActive(false);
        cabinetO2.gameObject.SetActive(false);
        fridge.gameObject.SetActive(true);
        fridge1.gameObject.SetActive(false);

        tool1.gameObject.SetActive(false);
        tool2.gameObject.SetActive(false);
        tool3.gameObject.SetActive(false);
        tool4.gameObject.SetActive(true);
        tool5.gameObject.SetActive(true);
        tool6.gameObject.SetActive(true);
        tool7.gameObject.SetActive(true);
        tool8.gameObject.SetActive(true);
        tool9.gameObject.SetActive(true);
        tool10.gameObject.SetActive(false);
        tool11.gameObject.SetActive(true);
        tool12.gameObject.SetActive(true);
        tool13.gameObject.SetActive(true);
        tool13_1.gameObject.SetActive(false);
        tool14.gameObject.SetActive(true);
        tool14_1.gameObject.SetActive(false);

        diaa1.gameObject.SetActive(true);
        diaa2.gameObject.SetActive(true);
        sh2.gameObject.SetActive(false);
        s1.gameObject.SetActive(false);
        boyboy.gameObject.SetActive(false);

        anim_boy.gameObject.SetActive(true);
        anim_girl.gameObject.SetActive(true);
        //  anim_tool.gameObject.SetActive(false);

        anim_boy.AnimationState.SetAnimation(1, "animation", true);
        anim_girl.AnimationState.SetAnimation(1, "animation", true);


        l21a = false;
        num = 1;
        for (int i = 0; i < t.Length; i++)
        {
           
            if (i == (t.Length - num))
            {
                Debug.Log(t.Length - num);
                t[i].gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(60f, -500f, 0f);  
            }
            else
            {
                t[i].gameObject.SetActive(true);

            }
        }
        for (int i = 0; i < sh.Length; i++)
        {
            sh[i].gameObject.SetActive(false);
        }
        AudioManager.ins.playmusicgame(AudioManager.ins.muisgame);


        frBg2.gameObject.SetActive(false);
        Bg_black2.gameObject.SetActive(false);
    }
    public int num = 0;
    public void move2()
    {
        if (gameover < 14)
        {
            int ab = num - 2;
            sh[ab].gameObject.SetActive(true);

            int a = t.Length - num;
            Debug.Log(a);
            t[a].gameObject.SetActive(true);
            t[a].gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(60f, -500f, 0f), 0.5f)
            .OnComplete(() =>
            {
                Debug.Log("tool12");
            });
        }
        
        
       
    }
    public bool l21a = false, l21a2 = false;

    public void PauseAnimation()
    {
        // GameManager.ins.Pause = true;
        anim_boy.timeScale = 0;
        anim_girl.timeScale = 0;
    }

    public void ResumeAnimation()
    {
        // GameManager.ins.Pause = true;
        anim_boy.timeScale = 1;
        anim_girl.timeScale = 1;
    }

    public void OnAnimationComplete3(TrackEntry trackEntry)
    {
        //    Level5.ins.a_perfume.gameObject.SetActive(false);


    }
    public GameObject prefabToSpawn1, prefabToSpawn2, prefabToSpawn3, prefabToSpawn4, prefabToSpawn5, prefabToSpawn6,
        prefabToSpawn7, prefabToSpawn8, prefabToSpawn9, prefabToSpawn10, prefabToSpawn11, prefabToSpawn12, prefabToSpawn13, prefabToSpawn14;
    public GameObject parentCanvas;
    public void SpawnAndPlaySpineAnimOnly(GameObject prefabToSpawn, string animName)
    {
        if (parentCanvas == null)
        {
            Debug.LogError("Parent canvas is not assigned.");
            return;
        }
        boyboy.gameObject.SetActive(true);
        anim_boy.gameObject.SetActive(false);

        GameObject newObject = Instantiate(prefabToSpawn, parentCanvas.transform);
        RectTransform rectTransform = newObject.GetComponent<RectTransform>();
        Spine.Unity.SkeletonGraphic skeletonGraphic = newObject.GetComponent<Spine.Unity.SkeletonGraphic>();

        if (rectTransform != null)
        {
            rectTransform.anchoredPosition = new Vector3(70f, -480f, 0f);

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
        AudioManager.ins.play1shot(AudioManager.ins.level30[0]);

        yield return new WaitForSeconds(delay);
        boyboy.gameObject.SetActive(false);
        anim_boy.gameObject.SetActive(true);

        anim_boy.AnimationState.SetAnimation(1, "animation", true);
        gameover += 1;
        endGame();
        move2();
        Destroy(obj);
    }
    public int gameover = 0;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy
    public void endGame()
    {

        Debug.Log("endgame");
        if (gameover == 14)
        {
            textCoroutine2 = StartCoroutine(ENDGAME());
            Debug.Log("gameover");
        }
        else if (gameover == 100)
        {
            textCoroutine2 = StartCoroutine(ENDOVER());
            Debug.Log("gameover");
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
        yield return new WaitForSeconds(2f);
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
        yield return new WaitForSeconds(2f);
        frBg2.gameObject.SetActive(false);
        Bg_black2.gameObject.SetActive(false);
        textCoroutine = null; // Reset lại khi hoàn thành

    }
}
