using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class Level13click : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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

        if (this.gameObject.name == "brush")
        {
            GameManager.ins.Click1 += 1;
          //  GameManager.ins.Click2 = 0;
          //  GameManager.ins.Click3 = 0;
            if (GameManager.ins.Click1 == 2)
            {
                AudioManager.ins.play1shot(AudioManager.ins.level9[0]);

                Level9.ins.cabinet1.gameObject.SetActive(false);
                Level9.ins.cabinet2.gameObject.SetActive(true);
                Level9.ins.bear.gameObject.SetActive(true);


            }
        }
        else if (this.gameObject.name == "b1")
        {
         //   Level13.ins.app1.gameObject.SetActive(true);
         //   Level13.ins.app2.gameObject.SetActive(true);
        //    Level13.ins.app3.gameObject.SetActive(true);
          //  Level13.ins.b1.gameObject.SetActive(false);
//
        }
    }
}
