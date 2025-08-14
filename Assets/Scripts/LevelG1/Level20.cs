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

public class Level20 : MonoBehaviour
{
    public static Level20 ins;
    public GameObject bg, furniture, girl, bouquet, cabinet, cabinet2,
                       broom, broccoli, orchids, door, wc, hanger, towel, towel1,
                       money, boy, img, spider, cottoc, needle, spider2, broom1,
                       cottoc2, money2, img2, broom2, rose2, broccoli2, towel2,img1;
    private void Awake()
    {
        Level20.ins = this;
    }
    private void Start()
    {
        startLevel();
    }
    public void startLevel()
    {
        bg.gameObject.SetActive(true);
        furniture.gameObject.SetActive(true);
        girl.gameObject.SetActive(true);
        bouquet.gameObject.SetActive(true);
        cabinet.gameObject.SetActive(true);
        cabinet2.gameObject.SetActive(false);
        broom.gameObject.SetActive(true);
        broccoli.gameObject.SetActive(true);
        orchids.gameObject.SetActive(true);
        door.gameObject.SetActive(true);
        wc.gameObject.SetActive(false);
        hanger.gameObject.SetActive(false);
        towel.gameObject.SetActive(false);
        money.gameObject.SetActive(false);
        boy.gameObject.SetActive(false);
        img.gameObject.SetActive(true);
        img1.gameObject.SetActive(true);
        spider.gameObject.SetActive(true);
        cottoc.gameObject.SetActive(false);
        needle.gameObject.SetActive(false);
        broom1.gameObject.SetActive(false);
        towel1.gameObject.SetActive(false);

        spider2.gameObject.SetActive(false);
        cottoc2.gameObject.SetActive(false);
        money2.gameObject.SetActive(false);
        img2.gameObject.SetActive(false);
        broom2.gameObject.SetActive(false);
        rose2.gameObject.SetActive(false);
        broccoli2.gameObject.SetActive(false);
        towel2.gameObject.SetActive(false);

        AudioManager.ins.playmusicgame(AudioManager.ins.muisgame);

    }

    public bool l21a = false, l21a2 = false;

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
        if (gameover == 8)
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
}
