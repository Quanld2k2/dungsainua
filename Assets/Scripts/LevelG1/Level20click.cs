using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
public class Level20click : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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

        if (this.gameObject.name == "broom")
        {
            GameManager.ins.Click1 += 1;
         //   GameManager.ins.Click2 = 0;
         //   GameManager.ins.Click3 = 0;
            if (GameManager.ins.Click1 == 2)
            {
                Level20.ins.broom.gameObject.SetActive(false); 
                Level20.ins.broom1.gameObject.SetActive(true);

                
            }
        }
        else if (this.gameObject.name == "cabinet")
        {
            GameManager.ins.Click2 += 1;
         //   GameManager.ins.Click1 = 0;
         //   GameManager.ins.Click3 = 0;
            if (GameManager.ins.Click2 == 2)
            {
                AudioManager.ins.play1shot(AudioManager.ins.level20[0]);


                Level20.ins.cabinet.gameObject.SetActive(false);
                Level20.ins.needle.gameObject.SetActive(true);
                Level20.ins.cottoc.gameObject.SetActive(true);
                Level20.ins.cabinet2.gameObject.SetActive(true);
            }


        }
        else if (this.gameObject.name == "door")
        {
            GameManager.ins.Click3 += 1;
          //  GameManager.ins.Click2 = 0;
         //   GameManager.ins.Click1 = 0;
            if (GameManager.ins.Click3 == 2)
            {
                AudioManager.ins.play1shot(AudioManager.ins.level20[2]);

                Level20.ins.door.gameObject.SetActive(false);
                Level20.ins.wc.gameObject.SetActive(true);
                Level20.ins.hanger.gameObject.SetActive(true);
                Level20.ins.towel.gameObject.SetActive(true);
                Level20.ins.money.gameObject.SetActive(true);
                Level20.ins.boy.gameObject.SetActive(true);
            }


        }
    }
}
