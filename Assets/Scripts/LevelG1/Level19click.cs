using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class Level19click : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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

        if (this.gameObject.name == "cua1")
        {
            GameManager.ins.Click1 += 1;
         //   GameManager.ins.Click2 = 0;
         //   GameManager.ins.Click3 = 0;
            //  if (GameManager.ins.Click1 == 2)
            //  {
            GameManager.ins.hint2 = true;

            Level19.ins.cua1.gameObject.SetActive(false);
                Level19.ins.cua2.gameObject.SetActive(true);
                Level19.ins.choi2.gameObject.SetActive(true);
                Level19.ins.paper3.gameObject.SetActive(true);


            // }
        }
        else if (this.gameObject.name == "q2")
        {
            Level19.ins.q2.gameObject.SetActive(false);
            Level19.ins.tu3.gameObject.SetActive(true);
        }
        else if (this.gameObject.name == "q3")
        {
            Level19.ins.q3.gameObject.SetActive(false);
            Level19.ins.tu2.gameObject.SetActive(true);
            Level19.ins.thuocxit.gameObject.SetActive(true);
        }
    }
}
