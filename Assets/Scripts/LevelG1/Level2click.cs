using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
public class Level2click : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        AudioManager.ins.play3shot(AudioManager.ins.level11[0]);

    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (this.gameObject.name == "boyend")
        {
            GameManager.ins.Click1 += 1;
            if (GameManager.ins.Click1 == 2)
            {
                Level2.ins.many.GetComponent<RectTransform>().anchoredPosition = new Vector3(376f, -267f, 0f);
                Level2.ins.many.SetActive(true);
                Level2.ins.many.GetComponent<RectTransform>().DOAnchorPos(new Vector3(225f, -568f, 0f), 0.4f).OnComplete(() =>
                {
                  //  GameManager.ins.Click1 = 0;
                });
                Level2.ins.chageString("lev2_3");
                GameManager.ins.hint2 = true;

            }


        }
        else if (this.gameObject.name == "lamp")
        {
            GameManager.ins.Click2 += 1;
            if (GameManager.ins.Click2 == 2)
            {
                Level2.ins.key2.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(173f, 401f, 0f);
                Level2.ins.key2.gameObject.SetActive(true);
                Level2.ins.key2.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(173f, 237f, 0f), 0.4f).OnComplete(() =>
                {
                   // GameManager.ins.Click2 = 0;
                });
                GameManager.ins.hint5 = true;

            }
        }
        else if (this.gameObject.name == "bell")
        {
            AudioManager.ins.play2shot(AudioManager.ins.level2[1]);

            Level2.ins.boy2.gameObject.SetActive(true);
            Level2.ins.chageString("lev2_2");
            Level2.ins.gameOver();
        }
        else if (this.gameObject.name == "knife")
        {
           // Level2.ins.boy2.gameObject.SetActive(true);
            Level2.ins.chageString("lev2_4");

        }
        else if (this.gameObject.name == "dog")
        {
            AudioManager.ins.play2shot(AudioManager.ins.level2[3]);

            // Level2.ins.boy2.gameObject.SetActive(true);
            Level2.ins.chageString("lev2_6");

        }

    }
}
