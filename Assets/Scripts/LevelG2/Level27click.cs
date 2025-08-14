using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
public class Level27click : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        AudioManager.ins.play3shot(AudioManager.ins.level11[0]);

        Debug.Log("click");
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name);

        if (this.gameObject.name == "tablet1")
        {
            GameManager.ins.Click1 += 1;
        //    GameManager.ins.Click2 = 0;
            if (GameManager.ins.Click1 == 2)
            {
                Level27.ins.tablet.gameObject.SetActive(true);
                Level27.ins.tablet1.gameObject.SetActive(false);
            }
        }
        else if (this.gameObject.name == "lid2" || this.gameObject.name == "lid1")
        {
            GameManager.ins.Click2 += 1;
        //    GameManager.ins.Click1 = 0;
            if (GameManager.ins.Click2 == 2)
            {
                AudioManager.ins.play1shot(AudioManager.ins.level27[0]);

                GameManager.ins.hint6 = true;

                Level27.ins.l21a1 = true;
                Level27.ins.lid1.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-270f, -60f, 0f), 0.5f)
                    .OnComplete(() =>
                    {
                       

                        Level27.ins.z1_1.gameObject.SetActive(true);

                    });
                Level27.ins.lid2.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(270f, -60f, 0f), 0.5f)
                    .OnComplete(() =>
                    {
                       // Level27.ins.l21a1 = true;

                        Level27.ins.z2_2.gameObject.SetActive(true);
                        Level27.ins.StartCoroutine(Level27.ins.v2_1s());

                    });
            }

        }
    }
}
