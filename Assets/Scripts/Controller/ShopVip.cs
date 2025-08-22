using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Spine.Unity;
using Spine;
using System.Collections;

public class ShopVip : MonoBehaviour
{
    public static ShopVip ins;
    public GameObject a1, a2, a3;
    public Text txt1,txt2,txt3,txt4, txt6, txt5;
    public Image icon,ic1,ic2,ic3,bt1,bt2,bg;

    public RectTransform popup;         // Popup sẽ mở

    private void Awake()
    {
        ShopVip.ins = this;
    }

    public void ShowPopupFromButton()
    {
        popup.gameObject.SetActive(true);
      

        txt1.gameObject.SetActive(false);
        txt2.gameObject.SetActive(false);
        txt3.gameObject.SetActive(false);
        txt4.gameObject.SetActive(false);
        ic1.gameObject.SetActive(false);
        ic2.gameObject.SetActive(false);
        ic3.gameObject.SetActive(false);
        bt1.gameObject.SetActive(false);
        bt2.gameObject.SetActive(false);
        txt5.gameObject.SetActive(false);
        txt6.gameObject.SetActive(false);

        //popup.localScale = Vector3.zero;
        txt1.transform.localScale = new Vector3(0f, 0f, 0f);
        txt2.GetComponent<RectTransform>().anchoredPosition = new Vector3(1100f, 0f, 0f);
        txt3.GetComponent<RectTransform>().anchoredPosition = new Vector3(1100f, 0f, 0f);
        txt4.GetComponent<RectTransform>().anchoredPosition = new Vector3(1100f, 0f, 0f);
        ic1.transform.localScale = new Vector3(0f, 0f, 0f);
        ic2.transform.localScale = new Vector3(0f, 0f, 0f);
        ic3.transform.localScale = new Vector3(0f, 0f, 0f);
        bt1.transform.localScale = new Vector3(0f, 0f, 0f);
        bt2.transform.localScale = new Vector3(0f, 0f, 0f);
        txt5.transform.localScale = new Vector3(0f, 0f, 0f);
        txt6.transform.localScale = new Vector3(0f, 0f, 0f);

        popup.gameObject.GetComponent<RectTransform>().localScale = Vector3.zero;
        popup.gameObject.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        icon.gameObject.SetActive(true);

        // Scale từ 0 → 1
        popup.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            txt1.gameObject.SetActive(true);

            txt1.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack).OnComplete(() =>
            {
                txt2.gameObject.SetActive(true);
                ic1.gameObject.SetActive(true);
                txt2.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(60f, 0f, 0f), 0.2f);
                ic1.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack).OnComplete(() =>
                {
                    txt3.gameObject.SetActive(true);
                    ic2.gameObject.SetActive(true);
                    txt3.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(60f, 0f, 0f), 0.2f);
                    ic2.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack).OnComplete(() =>
                    {
                        txt4.gameObject.SetActive(true);
                        ic3.gameObject.SetActive(true);
                        txt4.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(60f, 0f, 0f), 0.2f);
                        ic3.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack).OnComplete(() =>
                        {
                            bt1.gameObject.SetActive(true);
                            bt2.gameObject.SetActive(true);
                            txt5.gameObject.SetActive(true);
                            txt6.gameObject.SetActive(true);
                            bt1.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack).OnComplete(() =>
                            {
                                bt1.transform.DOScale(1.1f, 0.7f)
                               .SetLoops(-1, LoopType.Yoyo) // loop vô hạn, kiểu đi tới rồi quay về
                               .SetEase(Ease.InOutSine);
                            });
                            bt2.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack);
                            txt5.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack);
                            txt6.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack);

                            // Scale to lên 1.1 rồi thu nhỏ về 1.0, lặp vô hạn
                              // chuyển động mượt
                        });
                    });
                });
                
               
            });
           
        });
    }


}
