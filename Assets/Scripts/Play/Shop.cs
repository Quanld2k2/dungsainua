using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Spine.Unity;
using Spine;
using System.Collections;
using System;

public class Shop : MonoBehaviour
{
    public static Shop ins;
    public GameObject black,bg, a1, a2;
    public SkeletonGraphic a3, a4;
    public Image btCan, btnoAds, fr3, bt1, b1, b2, b3, b4, b5, b6;
    public RectTransform popup;
    public Text txthint;
    private void Awake()
    {
        Shop.ins = this;
    }

    private void Start()
    {

    }
    public void addhiGame()
    {
        int coins2 = PlayerPrefs.GetInt("hiGame");
        float from = 0f;
        float to = coins2;
        float duration = 1f;
        DOTween.To(() => from, x => {
            from = x;
            txthint.text = $"{from:0}";
        }, to, duration).SetEase(Ease.OutQuad);
    }

    public void OpenShop()
    {
        

        btCan.gameObject.SetActive(false);
        btnoAds.gameObject.SetActive(false);
        a3.gameObject.SetActive(false);
        fr3.gameObject.SetActive(false);
        bt1.gameObject.SetActive(false);

        b1.gameObject.SetActive(false);
        b2.gameObject.SetActive(false);
        b3.gameObject.SetActive(false);
        b4.gameObject.SetActive(false);
        b5.gameObject.SetActive(false);
        b6.gameObject.SetActive(false);

        bt1.GetComponent<RectTransform>().anchoredPosition = new Vector3(-1100f, -328f, 0f);
        btnoAds.GetComponent<RectTransform>().anchoredPosition = new Vector3(1100f, 793f, 0f);
                   
        a3.transform.localScale = new Vector3(0f, 0f, 0f);
        fr3.transform.localScale = new Vector3(0f, 0f, 0f);
        popup.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1f);

        popup.DOScale(Vector3.one, 0.5f).OnComplete(() =>
        {
            
            if (PlayerPrefs.GetInt("Iap_Removeads", 0) == 0)
            {
                btnoAds.gameObject.SetActive(true);
                btnoAds.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(102f, 793f, 0f), 0.4f);
            }
            else
            {
                btnoAds.gameObject.SetActive(false);
            }

            b1.gameObject.SetActive(true);
            b1.transform.localScale = new Vector3(0f, 0f, 0f);
            b1.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);
            //b1.transform.DOScale(1f, 1.2f).SetEase(Ease.OutBack);

            b2.gameObject.SetActive(true);
            b2.transform.localScale = new Vector3(0f, 0f, 0f);
            b2.transform.DOScale(1f, 0.4f).SetEase(Ease.OutBack);

            b3.gameObject.SetActive(true);
            b3.transform.localScale = new Vector3(0f, 0f, 0f);
            b3.transform.DOScale(1f, 0.6f).SetEase(Ease.OutBack);

            b4.gameObject.SetActive(true);
            b4.transform.localScale = new Vector3(0f, 0f, 0f);
            b4.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);

            b5.gameObject.SetActive(true);
            b5.transform.localScale = new Vector3(0f, 0f, 0f);
            b5.transform.DOScale(1f, 0.4f).SetEase(Ease.OutBack);

            b6.gameObject.SetActive(true);
            b6.transform.localScale = new Vector3(0f, 0f, 0f);
            addhiGame();
            b6.transform.DOScale(1f, 0.6f).SetEase(Ease.OutBack).OnComplete(() =>
            {
                bt1.gameObject.SetActive(true);
                a3.gameObject.SetActive(true);

                bt1.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-207f, -328f, 0f), 0.4f);
                a3.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack).OnComplete(() =>
                {
                    

                    if (PlayerPrefs.GetInt("benefitGame", 0) == 0)
                    {
                        fr3.gameObject.SetActive(true);
                        fr3.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack).OnComplete(() =>{});
                    }
                    else
                    {
                        fr3.gameObject.SetActive(false);
                    }

                    btCan.gameObject.SetActive(true);
                    btCan.transform.localScale = new Vector3(0f, 0f, 0f);
                    btCan.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);
                });
            });
        });
    }
    public void bt_HintAndReward()
    {
        int hiNum = PlayerPrefs.GetInt("hiGame");

        int coins2 = PlayerPrefs.GetInt("txt_gold");
        if (coins2 >= 100)
        {
            hiNum += 1;
            coins2 -= 100;
            PlayerPrefs.SetInt("hiGame", hiNum);
            PlayerPrefs.SetInt("txt_gold", coins2);
            Debug.Log("doen");
        }
        else
        {
            Debug.Log("faild");

        }

        txthint.text = "" + hiNum;
    }
}
