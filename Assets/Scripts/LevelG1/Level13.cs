using Spine.Unity;
using Spine;
using System.Collections;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Level13 : MonoBehaviour
{
    public static Level13 ins;
    public Image bg, boat, boat1, ladder, bag, caxau1,cu1,brusk, stick1, rod, rod1,elip1,elip2,god, god1, sli1, fish1, app1, app2,
        app3, bo1, bo2,bone1,apple1, water1, water2,reshovel1,ad1,ad2,b1,b2, w2;
    public SkeletonGraphic a_girl,a_boy,a_shovel,a_water;
    public Image[] done;
    public Sprite caxau2, stick2, bag2,cu2,god2,sli2,bone2,boat2,rod2,fish2,apple2,resovel2;
    public int number = 0;
    private void Awake()
    {
        Level13.ins = this;
    }
    private void Start()
    {
        startLevel();
    }
    public void startLevel()
    {
        bg.gameObject.SetActive(true);
        boat.gameObject.SetActive(true);
        boat1.gameObject.SetActive(true);
        ladder.gameObject.SetActive(true);
        bag.gameObject.SetActive(true);
        caxau1.gameObject.SetActive(true);
        cu1.gameObject.SetActive(true);
        brusk.gameObject.SetActive(true);
        stick1.gameObject.SetActive(true);
        rod.gameObject.SetActive(true);
        rod1.gameObject.SetActive(false);
        elip1.gameObject.SetActive(true);
        elip2.gameObject.SetActive(true);
        god.gameObject.SetActive(false);
        god1.gameObject.SetActive(false);
        sli1.gameObject.SetActive(false);
        fish1.gameObject.SetActive(false);
        app1.gameObject.SetActive(false);
        app2.gameObject.SetActive(false);
        app3.gameObject.SetActive(false);
        bo1.gameObject.SetActive(true);
        bo2.gameObject.SetActive(false);
        bone1.gameObject.SetActive(false);
        apple1.gameObject.SetActive(true);
        water1.gameObject.SetActive(false);
        water2.gameObject.SetActive(true);
        reshovel1.gameObject.SetActive(true);

        b1.gameObject.SetActive(true);
        //   b2.gameObject.SetActive(false);
      //  w2.gameObject.SetActive(true);

        ad1.gameObject.SetActive(false);
        ad2.gameObject.SetActive(false);

        a_girl.gameObject.SetActive(true);
        a_boy.gameObject.SetActive(true);
        a_shovel.gameObject.SetActive(false);
        a_water.gameObject.SetActive(false);


        for (int i = 0; i < done.Length; i++)
        {
            done[i].gameObject.SetActive(false);

        }

        GameManager.ins.Click1 = 0;
        GameManager.ins.Click2 = 0;
        GameManager.ins.Click3 = 0;

        a_boy.AnimationState.SetAnimation(1, "animation", true);
    //    a_girl.AnimationState.SetAnimation(1, "animation", true);

        number = 0;
        a_girl.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-360f, -320f, 0f);
        a_girl.AnimationState.Complete += OnAnimationComplete;
        a_shovel.AnimationState.Complete += OnAnimationComplete2;
        a_water.AnimationState.Complete += OnAnimationComplete3;
        AudioManager.ins.play1shot(AudioManager.ins.level13[1]);
        frBg2.gameObject.SetActive(false);
        Bg_black2.gameObject.SetActive(false);
        add1 = 0; add2 = 0; checkaa = false;
        AudioManager.ins.playmusicgame(AudioManager.ins.muisgame);

    }
    public void PauseAnimation()
    {
        a_boy.timeScale = 0; // Dừng Spine Animation
    }

    public void ResumeAnimation()
    {
        a_boy.timeScale = 1;
    }
    public int add1 = 0; 
    public int add2 = 0;
    public bool checkaa = false;

    public void OnAnimationComplete(TrackEntry trackEntry)
    {

    }
    public void OnAnimationComplete2(TrackEntry trackEntry)
    {
        Level13.ins.bo1.gameObject.SetActive(false);
        Level13.ins.bo2.gameObject.SetActive(true);
        Level13.ins.bone1.gameObject.SetActive(true);
        a_shovel.gameObject.SetActive(false);
        reshovel1.gameObject.SetActive(true);
    }
    public void OnAnimationComplete3(TrackEntry trackEntry)
    {
        Level13.ins.app1.gameObject.SetActive(true);
        Level13.ins.app2.gameObject.SetActive(true);
        Level13.ins.app3.gameObject.SetActive(true);
        Level13.ins.b1.gameObject.SetActive(false);
        a_water.gameObject.SetActive(false);
    }
    public void moveA()
    {
        a_girl.AnimationState.SetAnimation(1, "animation", false);

        //girl1.gameObject.SetActive(true);
        if (number == 0)
        {
            a_girl.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-283f, -293f, 0f), 0.8f).OnComplete(() =>
            {

            });
        }
        else if (number == 1)
        {
            a_girl.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-260f, -212f, 0f), 0.8f).OnComplete(() =>
            {

            });
        }
        else if (number == 2)
        {
            a_girl.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-218f, -140f, 0f), 0.8f).OnComplete(() =>
            {

            });
        }
        else if (number == 3)
        {
            a_girl.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-180f, -60f, 0f), 0.8f).OnComplete(() =>
            {

            });
        }
        else if (number == 4)
        {
            a_girl.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-136f, 11f, 0f), 0.8f).OnComplete(() =>
            {

            });
        }
        else if (number == 5)
        {
            a_girl.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-97f, 76f, 0f), 0.8f).OnComplete(() =>
            {

            });
        }
        else if (number == 6)
        {
            a_girl.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-44f, 138f, 0f), 0.8f).OnComplete(() =>
            {

            });
        }

        else if (number == 7)
        {
            a_girl.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(15f, 207f, 0f), 0.8f).OnComplete(() =>
            {

            });
        }
        else if (number == 8)
        {
            a_girl.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(33f, 270f, 0f), 0.8f).OnComplete(() =>
            {

            });
        }
        else if (number == 9)
        {
            a_girl.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(68f, 348f, 0f), 0.8f).OnComplete(() =>
            {
                a_girl.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(170f, 387f, 0f), 0.8f).OnComplete(() =>
                {
                    a_girl.gameObject.SetActive(false);
                    a_girl.gameObject.SetActive(true);
                    a_girl.AnimationState.SetAnimation(1, "animation2", true);
                    textCoroutine2 = StartCoroutine(ENDGAME());
                    a_boy.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(1000f, 401f, 0f), 0.8f).SetDelay(0.5f).OnComplete(() =>
                    {

                    });
                });
            });
        }
        else if (number == 10)
        {
            
        }
      //  else if (number == 11)
       // {
          //  a_girl.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(317f, 327f, 0f), 0.8f).OnComplete(() =>
         //   {

         //   });
      //  }
        else if (number == 120)
        {
          //  
        }

        if (GameManager.ins.Click1 == 123)
        {
   
        }
        else if (GameManager.ins.Click1 == 225)
        {
            gameOver();
        }
    }
    public int gameover = 0;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy

    public void gameOver()
    {

        textCoroutine2 = StartCoroutine(ENDOVER());

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