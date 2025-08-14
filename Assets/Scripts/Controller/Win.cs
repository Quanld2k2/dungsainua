using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Spine.Unity;
using Spine;
using System.Collections;
using System;

public class Win : MonoBehaviour
{
    public static Win ins;
    public GameObject  black;
    public SkeletonGraphic a_win1, a_win2;
    public Image  btCon, btHome,gold;
    public Text txt_content,txt_gold;


    private void Awake()
    {
        Win.ins = this;
    }

    private void Start()
    {
        a_win1.AnimationState.Complete += OnAnimationComplete1;

    }

    public void StartCounting()
    {
        float from = 0f;
        float to = 100f;
        float duration = 1f;
        txt_gold.gameObject.SetActive(true);

      


        DOTween.To(() => from, x => {
            from = x;
            txt_gold.text = $"{from:0}";
        }, to, duration).SetEase(Ease.OutQuad);
    }
    private void OnAnimationComplete1(TrackEntry trackEntry)
    {
        if (trackEntry.Animation != null)
        {
            gold.gameObject.SetActive(true);
            gold.transform.localScale = new Vector3(0.5f, 1f, 1f);
            gold.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack).OnComplete(() =>
            {
                txt_gold.gameObject.SetActive(true);
                StartCounting();

                btCon.gameObject.SetActive(true);
                btCon.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                btCon.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack);

                btHome.gameObject.SetActive(true);
                btHome.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                btHome.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack);
            });
            

            
            

        }
    }

    public Sprite[] ic;
    public Image targetImage; // Ảnh cần hiển thị
    public float duration = 1.5f; // Thời gian hiệu ứng
    public Image maskImage; // Ảnh overlay để che ảnh chính
   
    public void OpenWin(int id)
    {

        targetImage.sprite = ic[id];


        black.SetActive(true);
        btCon.gameObject.SetActive(false);
        btHome.gameObject.SetActive(false);
        txt_content.gameObject.SetActive(false);
        a_win1.gameObject.SetActive(false);
        a_win2.gameObject.SetActive(false);
        targetImage.gameObject.SetActive(false);
        gold.gameObject.SetActive(false);
        txt_gold.gameObject.SetActive(false);

        targetImage.transform.localScale = new Vector3(0f, 0f, 0f);

        a_win1.gameObject.SetActive(true);
        a_win1.transform.localScale = new Vector3(0f, 0f, 0f);
        a_win1.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            a_win2.gameObject.SetActive(true);
            a_win2.AnimationState.ClearTrack(1);
            a_win2.AnimationState.SetAnimation(1, "animation", true);
        });

        txt_content.gameObject.SetActive(true);
        txt_content.transform.localScale = new Vector3(0.5f, 1f, 1f);
        txt_content.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);

        a_win1.AnimationState.ClearTrack(1);
        a_win1.AnimationState.SetAnimation(1, "animation", false);

        targetImage.gameObject.SetActive(true);
        Color color = maskImage.color;  // Lấy màu hiện tại
        color.a = 1f;  // Đặt Alpha thành 1 (hiển thị rõ)
        maskImage.color = color;

        targetImage.transform.DOScale(1f, 0.6f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            

        });
       maskImage.rectTransform.localScale = new Vector3(1, 1, 1);
       maskImage.rectTransform.DOScaleY(0, 0.4f).SetEase(Ease.OutQuad);
      //  maskImage.DOFade(0, 1f).SetEase(Ease.OutQuad);



    }

}
