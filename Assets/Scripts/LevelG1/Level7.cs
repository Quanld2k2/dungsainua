using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Spine.Unity;
using Spine;
using System.Collections;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;


public class Level7 : MonoBehaviour
{
    public static Level7 ins;

    public Image bg1,bg2,carpet1,carpet2,bed1,bed2,curtain1,curtain2,chair,chair2,money1,money2,
        pic1,pic2,dad,girl2,desk,desk2,phone1,phone2,ticket,light1,light2,gun1,gun2,dog, ticket11,ticket12;
    public SkeletonGraphic a_girl1,a_dog1;

    public GameObject ve1;

    private void Awake()
    {
        Level7.ins = this;
    }

    private void Start()
    {
        startLevel();
    }

    public void startLevel()
    {
        bg1.gameObject.SetActive(true);
        bg2.gameObject.SetActive(false);
        carpet1.gameObject.SetActive(true);
        carpet2.gameObject.SetActive(false);
        bed1.gameObject.SetActive(true);
        bed2.gameObject.SetActive(false);
        curtain1.gameObject.SetActive(true);
        curtain2.gameObject.SetActive(false);
        chair.gameObject.SetActive(false);
        chair2.gameObject.SetActive(false);
        pic1.gameObject.SetActive(false);
        pic2.gameObject.SetActive(false);
        dad.gameObject.SetActive(true);
        girl2.gameObject.SetActive(false);
        desk.gameObject.SetActive(true);
        desk2.gameObject.SetActive(false);
        phone1.gameObject.SetActive(true);
        phone2.gameObject.SetActive(false);
        money1.gameObject.SetActive(true);
        money2.gameObject.SetActive(false);
        ticket.gameObject.SetActive(true);
        light1.gameObject.SetActive(true);
        light2.gameObject.SetActive(false);
        gun1.gameObject.SetActive(true);
        gun2.gameObject.SetActive(false);
        dog.gameObject.SetActive(false);
        a_girl1.gameObject.SetActive(true);
        a_dog1.gameObject.SetActive(true);

        a_girl1.AnimationState.SetAnimation(1, "animation", true);
        a_dog1.AnimationState.SetAnimation(1, "animation", true);

        frBg2.gameObject.SetActive(false);
        Bg_black2.gameObject.SetActive(false);
        gameover = 0;
        overLoa = false;
        ve1.SetActive(true);
        ticket11.gameObject.SetActive(false);
        ticket12.gameObject.SetActive(false);
        ticket11.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(228f, 185f, 0f);
        ticket12.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(240f, 170f, 0f);
        dad.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-475f, -92f, 0f);

        Invoke(nameof(PlaySound), 1f);
    }


    void PlaySound()
    {
        AudioManager.ins.play1shot(AudioManager.ins.level7[2]);
    }
    public void PauseAnimation()
    {
        a_girl1.timeScale = 0;
        a_dog1.timeScale = 0;
    }

    public void ResumeAnimation()
    {
        a_girl1.timeScale = 1;
        a_dog1.timeScale = 1;
    }
    public int gameover = 0;
    public bool overLoa = false;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy
    public void endGame()
    {

        Debug.Log("endgame"+gameover);
       

        if (gameover == 12)
        {
            AudioManager.ins.stop1shot();

            dad.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-97f, -157f, 0f);

            textCoroutine2 = StartCoroutine(ENDGAME());
            Debug.Log("gameover");
        }
        else if (gameover == 10)
        {
            if (overLoa == false)
            {
                AudioManager.ins.stop1shot();

                dad.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-97f, -157f, 0f);

                textCoroutine2 = StartCoroutine(ENDOVER());
            }
        }

    }
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
    