using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Spine.Unity;
using Spine;
using System.Collections;
using System;

public class Sale : MonoBehaviour
{
    public static Sale ins;
    public Image black,vip,bt1,bt2;
    public Text txt1,txt2;

    private void Awake()
    {
        Sale.ins = this;
    }
    private void Start()
    {
        
    }
    public void Saleup()
    {
        black.gameObject.SetActive(true);
        vip.gameObject.SetActive(true);
        bt1.gameObject.SetActive(false);
        bt2.gameObject.SetActive(false);
       // moneyText.gameObject.SetActive(false);

        vip.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        vip.transform.DOScale(1f, 0.4f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            bt1.gameObject.SetActive(true);
            bt1.transform.localScale = new Vector3(0.5f, 1f, 1f);
            bt1.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack);

            bt2.gameObject.SetActive(true);
            bt2.transform.localScale = new Vector3(0.5f, 1f, 1f);
            bt2.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack).OnComplete(() =>
            {
                // StartCounting();

                bt2.transform.DOScale(1.1f, 0.7f)
                              .SetLoops(-1, LoopType.Yoyo) // loop vô hạn, kiểu đi tới rồi quay về
                              .SetEase(Ease.InOutSine);
            });
        });
    }

    public void sale_up_lev4true()
    {
        black.gameObject.SetActive(true);
        vip.gameObject.SetActive(false);
        // Đặt alpha về 0 trước (trong suốt)
        Color c = black.color;
        c.a = 0;
        black.color = c;
        // Fade lên alpha = 1 trong 0.5s
        black.DOFade(0.8f, 0.5f).OnComplete(() =>
        {
            vip.gameObject.SetActive(true);
            bt1.gameObject.SetActive(false);
            bt2.gameObject.SetActive(false);
            vip.transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
            vip.transform.DOScale(1f, 0.4f).SetEase(Ease.OutBack).OnComplete(() =>
            {
                bt1.gameObject.SetActive(true);
                bt1.transform.localScale = new Vector3(0.5f, 1f, 1f);
                bt1.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack);

                bt2.gameObject.SetActive(true);
                bt2.transform.localScale = new Vector3(0.5f, 1f, 1f);
                bt2.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack).OnComplete(() =>
                {
                    // StartCounting();
                    bt2.transform.DOScale(1.1f, 0.7f)
                             .SetLoops(-1, LoopType.Yoyo) // loop vô hạn, kiểu đi tới rồi quay về
                             .SetEase(Ease.InOutSine);
                });
            });
        });
    }

    public Text moneyText;

    public void StartCounting()
    {
        float from = 0f;
        float to = 2.99f;
        float duration = 1.5f;
        moneyText.gameObject.SetActive(true);

        DOTween.To(() => from, x => {
            from = x;
            moneyText.text = $"{from:0.00}$";
        }, to, duration).SetEase(Ease.OutQuad);
    }
}
