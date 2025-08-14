using Spine.Unity;
using Spine;
using System.Collections;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Level12 : MonoBehaviour
{
    public static Level12 ins;
    public Image bg, window, girl1, ax1, bom1, bough, esi, alo, guitar, flag, hand,
        handzombie, knife, pestle, rope, snake, stick, lose,a1 ,a2, a3;
    public SkeletonGraphic a_boom, a_zom1,a_zom2,a_zom3, a_zom4, a_girl,a_agirl;
    public Image[] done;
    public Sprite ax2, bough2, esi2, ola2, flag2, hand2, knife2, pestle2, rope2, snake2, stick2, guitar2, boom2;
    public int number = 0;
    private void Awake()
    {
        Level12.ins = this;
    }
    private void Start()
    {
        startLevel();
    }
    public void startLevel()
    {
        bg.gameObject.SetActive(true);
        window.gameObject.SetActive(false);
        girl1.gameObject.SetActive(false);
        ax1.gameObject.SetActive(false);
        bom1.gameObject.SetActive(true);
        bough.gameObject.SetActive(false);
        esi.gameObject.SetActive(false);
        alo.gameObject.SetActive(false);
        guitar.gameObject.SetActive(true);
        flag.gameObject.SetActive(true);
        hand.gameObject.SetActive(true);
        handzombie.gameObject.SetActive(true);
        knife.gameObject.SetActive(true);
        pestle.gameObject.SetActive(true);
        snake.gameObject.SetActive(true);
        stick.gameObject.SetActive(true);
        lose.gameObject.SetActive(false);

        a_boom.gameObject.SetActive(false);
        a_zom1.gameObject.SetActive(true);
        a_zom2.gameObject.SetActive(true);
        a_zom3.gameObject.SetActive(true);
        a_zom4.gameObject.SetActive(true);
        a_girl.gameObject.SetActive(false);
        a_agirl.gameObject.SetActive(true);

        a1.gameObject.SetActive(true);
        a2.gameObject.SetActive(true);
        a3.gameObject.SetActive(true);

        for (int i = 0; i < done.Length; i++)
        {
            done[i].gameObject.SetActive(false);

        }

        GameManager.ins.Click1 = 0;
        GameManager.ins.Click2 = 0;
        GameManager.ins.Click3 = 0;

        a_zom1.AnimationState.SetAnimation(1, "animation", true);
        a_zom2.AnimationState.SetAnimation(1, "animation", true);
        a_zom3.AnimationState.SetAnimation(1, "animation", true);
        a_zom4.AnimationState.SetAnimation(1, "animation", true);
        number = 0;
        a_agirl.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(26f,-264f,0f);
        a_boom.AnimationState.Complete += OnAnimationComplete;

         AudioManager.ins.playmusicgame(AudioManager.ins.level12[0]);
        axc = false; iin = 0;
    }
    public void PauseAnimation()
    {
        a_zom1.timeScale = 0; // Dừng Spine Animation
        a_zom2.timeScale = 0;
        a_zom3.timeScale = 0;
        a_zom4.timeScale = 0;
    }

    public void ResumeAnimation()
    {
        a_zom1.timeScale = 1;
        a_zom2.timeScale = 1;
        a_zom3.timeScale = 1;
        a_zom4.timeScale = 1;
    }
    public bool axc = false;
    public int iin = 0;

    public void OnAnimationComplete(TrackEntry trackEntry)
    {
        lose.gameObject.SetActive(true);
        gameOver();
    }
    public void moveA()
    {
        //girl1.gameObject.SetActive(true);
        a_agirl.AnimationState.SetAnimation(1, "animation", false);
       
        if (number == 0)
        {
            a_agirl.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(33f, -235f, 0f), 0.8f).OnComplete(() =>
            {
                Debug.Log("1");
            });
        }
        else if(number == 1)
        {
            a_agirl.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(44f, -175f, 0f), 0.8f).OnComplete(() =>
            {
                Debug.Log("2");

            });
        }
        else if (number == 2)
        {
            a_agirl.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(57f, -116f, 0f), 0.8f).OnComplete(() =>
            {
                Debug.Log("3");

            });
        }
        else if (number == 3)
        {
            a_agirl.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(70f, -60f, 0f), 0.8f).OnComplete(() =>
            {
                Debug.Log("4");

            });
        }
        else if (number == 4)
        {
            a_agirl.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(83f, -0f, 0f), 0.8f).OnComplete(() =>
            {
                Debug.Log("5");

            });
        }
        else if (number == 5)
        {
            a_agirl.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(96f, 65f, 0f), 0.8f).OnComplete(() =>
            {
                Debug.Log("6");

            });
        }
        else if (number == 6)
        {
            a_agirl.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(109f, 126f, 0f), 0.8f).OnComplete(() =>
            {
                Debug.Log("7");

            });
        }
       
        else if (number == 7)
        {
            a_agirl.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(120f, 181f, 0f), 0.8f).OnComplete(() =>
            {
                Debug.Log("8");

            });
        }
        else if (number == 8)
        {
            a_agirl.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(133f, 248f, 0f), 0.8f).OnComplete(() =>
            {
                Debug.Log("9");

            });
        }
        else if (number == 9)
        {
            a_agirl.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(147f, 308f, 0f), 0.8f).OnComplete(() =>
            {
                Debug.Log("10");

            });
        }
        else if (number == 10)
        {
            a_agirl.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(161f, 373f, 0f), 0.8f).OnComplete(() =>
            {
                Debug.Log("11");

            });
        }
        else if (number == 11)
        {
            a_agirl.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(170f, 431f, 0f), 0.8f).OnComplete(() =>
            {
             
            });
        }
        else if (number == 12)
        {
         
        }
        if (GameManager.ins.Click1 == 123)
        {
            Level12.ins.a_boom.gameObject.GetComponent<RectTransform>().anchoredPosition =
                Level12.ins.done[Level12.ins.number].gameObject.GetComponent<RectTransform>().anchoredPosition;
            Level12.ins.a_boom.gameObject.SetActive(true);
            Level12.ins.a_boom.AnimationState.SetAnimation(1, "animation", false);
            AudioManager.ins.play1shot(AudioManager.ins.boom);

            return;
        }else if (GameManager.ins.Click1 == 225)
        {
          //  Level12.ins.a_boom.gameObject.GetComponent<RectTransform>().anchoredPosition =
             //   Level12.ins.done[Level12.ins.number].gameObject.GetComponent<RectTransform>().anchoredPosition;

            lose.gameObject.SetActive(true);
            gameOver();
        }
        else
        {
            if (number == 11 )
            {
                Debug.Log("12");
                a_agirl.gameObject.SetActive(false);
                a_girl.gameObject.SetActive(true);
                a_girl.AnimationState.SetAnimation(1, "animation", true);
                textCoroutine2 = StartCoroutine(ENDGAME());
            }
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
}