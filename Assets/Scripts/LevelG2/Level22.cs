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

public class Level22 : MonoBehaviour
{
    public static Level22 ins;
    public Image bg, nurse, table, artboard6, dress, chair,
                   doctor1, doctor, hammer, chili, table2, nurse2,
                   p1, p1done, earphone, p2, p3done, p3,t1,card,
                   p4done, p4, p5done, p6, p7done, bn4;

    public SkeletonGraphic animbn2, animbn5, animbn6;

    public GameObject[] a1;
    private void Awake()
    {
        Level22.ins = this;
    }
    private void Start()
    {
        startLevel();
    }
    public void startLevel()
    {
        bg.gameObject.SetActive(true);
        nurse.gameObject.SetActive(true);
        table.gameObject.SetActive(true);
        artboard6.gameObject.SetActive(true);
        dress.gameObject.SetActive(true);
        chair.gameObject.SetActive(true);
        doctor1.gameObject.SetActive(true);
        doctor.gameObject.SetActive(false);
        hammer.gameObject.SetActive(true);
        chili.gameObject.SetActive(true);
        table2.gameObject.SetActive(false);
        t1.gameObject.SetActive(false);
        nurse2.gameObject.SetActive(false);
        card.gameObject.SetActive(false);

        p1.gameObject.SetActive(false);
        p1done.gameObject.SetActive(false);
        earphone.gameObject.SetActive(false);

        p2.gameObject.SetActive(false);
        animbn2.gameObject.SetActive(false);

        p3.gameObject.SetActive(false);
        p3done.gameObject.SetActive(false);

        p4.gameObject.SetActive(false);
        p4done.gameObject.SetActive(false);
        bn4.gameObject.SetActive(false);

        animbn5.gameObject.SetActive(false);
        p5done.gameObject.SetActive(false);

        animbn6.gameObject.SetActive(false);
        p6.gameObject.SetActive(false);

        p7done.gameObject.SetActive(false);

        frBg2.gameObject.SetActive(false);
        Bg_black2.gameObject.SetActive(false);

        l21a3 = false; l21a4 = false; l21a = false; l21a5 = false;
        animbn2.AnimationState.Complete += OnAnimationComplete1;
        animbn6.AnimationState.Complete += OnAnimationComplete2;
        AudioManager.ins.playmusicgame(AudioManager.ins.muisgame);


        for (int i = 0; i < a1.Length; i++)
        {
            a1[i].gameObject.SetActive(false);
            a1[i].gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(1000f, -200f, 0f);
        }
        
        number1 = 0; number2 = 0;
        canh1(number1);
    }
   
    public void OnAnimationComplete1(TrackEntry trackEntry)
    {
        number2 += 1;
        if (number2 == 6)
        {
            if (l21a == false)
            {
                l21a = true;
                ket1(number1);
            }
        }
    }
    public void OnAnimationComplete2(TrackEntry trackEntry)
    {
        if (l21a4 == false)
        {
            l21a4 = true;
            ket1(5);
        }
    }
    public bool l21a = false, l21a2 = false, l21a3 = false, l21a4 = false,l21a5 = false;
    public int number1 = 0, number2 = 0;
    public void canh1(int id)
    {
        number2 = id;
        if (id == 0)
        {
            p1.gameObject.SetActive(true);
            earphone.gameObject.SetActive(true);
        }
        else if (id == 1)
        {
            p2.gameObject.SetActive(true);
            animbn2.gameObject.SetActive(false);
        }
        else if (id == 2)
        {
            p3.gameObject.SetActive(true);
            p3done.gameObject.SetActive(false);
        }
        else if (id == 3)
        {
            Level22.ins.l21a5 = true;
            p4.gameObject.SetActive(true);
            p4done.gameObject.SetActive(false);
            bn4.gameObject.SetActive(false);
           

        }
        else if (id == 4)
        {
            animbn5.gameObject.SetActive(true);
            animbn5.AnimationState.SetAnimation(1, "animation", true);
            p5done.gameObject.SetActive(false);
            t1.gameObject.SetActive(true);
        }
        else if (id == 5)
        {
            l21a3 = true;
            animbn6.gameObject.SetActive(false);
            p6.gameObject.SetActive(true);
        }
        else if (id == 6)
        {
            doctor.gameObject.SetActive(true);

            p7done.gameObject.SetActive(false);
        }
        a1[id].gameObject.SetActive(true);
        a1[id].gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(300f, -200f, 0f), 0.6f).SetDelay(1f).OnComplete(() =>
        {
            if (id == 0)
            {
                Level22.ins.chageString("lev22_1");
            }
            else if (id == 1)
            {
                Level22.ins.chageString("lev22_3");
            }
            else if (id == 2)
            {
                Level22.ins.chageString("lev22_15");
            }
            else if (id == 3)
            {
                Level22.ins.chageString("lev22_6");
            }
            else if (id == 4)
            {
                Level22.ins.chageString("lev22_9");
            }
            else if (id == 5)
            {
                Level22.ins.chageString("lev22_11");
            }
            else if (id == 6)
            {
                Level22.ins.chageString("lev22_13");
            }

        });

        
    }
    public void ket1(int id)
    {
        AudioManager.ins.play2shot(AudioManager.ins.level22[2]);

        if (id == 0 || id == 1 || id == 2 || id == 4)
        {
            Level22.ins.chageString("lev22_2");
        }
        else if (id == 3)
        {
            Level22.ins.chageString("lev22_8");
            Level22.ins.doctor1.gameObject.SetActive(true);
            Level22.ins.bn4.gameObject.SetActive(false);
            p4done.gameObject.SetActive(true);
            p4.gameObject.SetActive(false);
        }
        else if (id == 5)
        {
            Level22.ins.l21a3 = false;
            Level22.ins.nurse.gameObject.SetActive(true);
            Level22.ins.nurse2.gameObject.SetActive(false);
        }
        a1[id].gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-1000f, -200f, 0f), 1f).SetDelay(2f).OnComplete(() =>
        {
            number1 += 1;
            a1[id].gameObject.SetActive(false);
            canh1(number1);
        });
    }


    public void PauseAnimation()
    {
        // GameManager.ins.Pause = true;
        //  a_boy.timeScale = 0;
        //  a_girl.timeScale = 0;
    }

    public void ResumeAnimation()
    {
        // GameManager.ins.Pause = true;
        //   a_boy.timeScale = 1;
        //   a_girl.timeScale = 1;
    }

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
        yield return new WaitForSeconds(2f);
        frBg2.gameObject.SetActive(false);
        Bg_black2.gameObject.SetActive(false);
        textCoroutine = null; // Reset lại khi hoàn thành

        if (number2 == 200)
        {
            number2 = 1000;
            Level22.ins.ket1(2);
        }
        else if (number2 == 300)
        {
            number2 = 1000;
            Level22.ins.ket1(3);
        }
        else if (number2 == 400)
        {
            number2 = 1000;
            textCoroutine2 = StartCoroutine(ENDOVER());
        }
        else if (number2 == 800)
        {
            number2 = 1000;
            animbn6.gameObject.SetActive(true);
            p6.gameObject.SetActive(false);
            animbn6.AnimationState.SetAnimation(1, "animation", false);
        }
        else if (number2 == 900)
        {
            number2 = 1000;
            textCoroutine2 = StartCoroutine(ENDGAME());

        }
    }
}
