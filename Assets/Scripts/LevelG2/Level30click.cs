using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
public class Level30click : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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

        if (this.gameObject.name == "cabinet1")
        {
            GameManager.ins.Click1 += 1;
         //   GameManager.ins.Click2 = 0;
       //     GameManager.ins.Click3 = 0;
            if (GameManager.ins.Click1 == 2)
            {
                Level30.ins.cabinet1.gameObject.SetActive(false);
                Level30.ins.cabinetO1.gameObject.SetActive(true);

                Level30.ins.tool1.gameObject.SetActive(true);
                Level30.ins.tool2.gameObject.SetActive(true);

            }
        }
        else if (this.gameObject.name == "cabinet2")
        {
            GameManager.ins.Click2 += 1;
        //    GameManager.ins.Click1 = 0;
         //   GameManager.ins.Click3 = 0;
            if (GameManager.ins.Click2 == 2)
            {

                Level30.ins.cabinet2.gameObject.SetActive(false);
                Level30.ins.cabinetO2.gameObject.SetActive(true);

                Level30.ins.tool3.gameObject.SetActive(true);
                Level30.ins.tool10.gameObject.SetActive(true);
            }


        }
        else if (this.gameObject.name == "fridge")
        {
            GameManager.ins.Click3 += 1;
         //   GameManager.ins.Click2 = 0;
          ///  GameManager.ins.Click1 = 0;
            if (GameManager.ins.Click3 == 2)
            {
                Level30.ins.fridge.gameObject.SetActive(false);
                Level30.ins.fridge1.gameObject.SetActive(true);
            }


        }
    }
}
