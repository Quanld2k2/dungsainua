using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Spine.Unity;
using Spine;
using System.Collections;
public class Lose : MonoBehaviour
{
    public static Lose ins;
    public GameObject  black;
    public SkeletonGraphic a_win1;
    public Image btCon, btHome;
    public Text txt_content;


    private void Awake()
    {
        Lose.ins = this;
    }

    private void Start()
    {
        a_win1.AnimationState.Complete += OnAnimationComplete1;

    }
    private void OnAnimationComplete1(TrackEntry trackEntry)
    {
        if (trackEntry.Animation != null)
        {

        }
    }
    public void OpenLose()
    {
        black.SetActive(true);
        btCon.gameObject.SetActive(false);
        btHome.gameObject.SetActive(false);
        txt_content.gameObject.SetActive(false);


        a_win1.gameObject.SetActive(true);
        a_win1.transform.localScale = new Vector3(0f, 0f, 0f);
        a_win1.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            // Delay 1 giây trước khi hiển thị các nút
            DOVirtual.DelayedCall(0.5f, () =>
            {
                btCon.gameObject.SetActive(true);
                btCon.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                btCon.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack);

                btHome.gameObject.SetActive(true);
                btHome.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                btHome.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack);
            });
        });

        txt_content.gameObject.SetActive(true);
        txt_content.transform.localScale = new Vector3(0.5f, 1f, 1f);
        txt_content.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);

        a_win1.AnimationState.ClearTrack(1);
        a_win1.AnimationState.SetAnimation(1, "animation", true);
    }
}
