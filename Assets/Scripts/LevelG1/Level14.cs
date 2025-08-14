using Spine.Unity;
using Spine;
using System.Collections;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Level14 : MonoBehaviour
{
    public static Level14 ins;
    public HorizontalLayoutGroup horizontalLayoutGroup;
    public ContentSizeFitter contentSizeFitter;

    public Image bg, bg2, wat1, wat2, door1, door2, hole1, hole2, pipe1, pipe2, table, wood, humane1, shark,shark2,w1,w2,w3,w4,b1;
    public SkeletonGraphic a_waterpipe, a_rain, a_water2, a_water3, a_pump, a_h2o;

    private void Awake()
    {
        Level14.ins = this;
    }
    private void Start()
    {
        bg.gameObject.SetActive(true);
        bg2.gameObject.SetActive(true);
        wat1.gameObject.SetActive(true);
        wat2.gameObject.SetActive(true);
        door1.gameObject.SetActive(true);
        door2.gameObject.SetActive(false);
        hole1.gameObject.SetActive(true);
        hole2.gameObject.SetActive(false);
        pipe1.gameObject.SetActive(true);
        pipe2.gameObject.SetActive(false);
        table.gameObject.SetActive(true);
        wood.gameObject.SetActive(false);
        humane1.gameObject.SetActive(true);
        shark.gameObject.SetActive(true);
        shark2.gameObject.SetActive(false);
        w1.gameObject.SetActive(true);
        w2.gameObject.SetActive(true);
        w3.gameObject.SetActive(true);
        w4.gameObject.SetActive(true);
        b1.gameObject.SetActive(false);

        a_waterpipe.gameObject.SetActive(false);
        a_rain.gameObject.SetActive(true);
        a_water2.gameObject.SetActive(true);
        a_water3.gameObject.SetActive(true);
        a_pump.gameObject.SetActive(false);
        a_h2o.gameObject.SetActive(true);

        a_rain.AnimationState.SetAnimation(1, "animation", true);
        a_water3.AnimationState.SetAnimation(1, "animation", true);
        a_water2.AnimationState.SetAnimation(1, "animation", true);
        a_h2o.AnimationState.SetAnimation(1, "animation", true);

        a_waterpipe.AnimationState.Complete += OnAnimationComplete;
        a_pump.AnimationState.Complete += OnAnimationComplete2;
        checkid = 0;
        q1 = false; q2 = false; q3 = false; q4 = false;
        AudioManager.ins.playmusicgame(AudioManager.ins.level14[4]);

    }

    public void PauseAnimation()
    {
        a_rain.timeScale = 0; // Dừng Spine Animation
        a_water3.timeScale = 0;
        a_water2.timeScale = 0;
        a_h2o.timeScale = 0;
    }

    public void ResumeAnimation()
    {
        a_rain.timeScale = 1;
        a_water3.timeScale = 1;
        a_water2.timeScale = 1;
        a_h2o.timeScale = 1;
    }
    public bool q1 = false, q2 = false, q3 = false, q4 = false;
    public void OnAnimationComplete(TrackEntry trackEntry)
    {
        pipe2.gameObject.SetActive(true);
    }
    public void OnAnimationComplete2(TrackEntry trackEntry)
    {
        a_pump.gameObject.SetActive(false);
        a_water2.gameObject.SetActive(false);

    }
    public void ToggleLayout(bool isOn)
    {
        if (horizontalLayoutGroup != null)
            horizontalLayoutGroup.enabled = isOn;

        if (contentSizeFitter != null)
            contentSizeFitter.enabled = isOn;
    }

    public int checkid = 0;
    public int gameover = 0;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy

    public void gameOver()
    {
        if (gameover == 8 )
        {
            gameOver2();
        }

        StartCoroutine(ACC());
    }
    public void gameOver2()
    {

         textCoroutine2 = StartCoroutine(ENDGAME());
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
    public IEnumerator ACC()
    {
        yield return new WaitForSeconds(1f);
        Level14.ins.horizontalLayoutGroup.enabled = false;
        Level14.ins.contentSizeFitter.enabled = false;
    }
}
