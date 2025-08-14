using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
public class Level24click : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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

        if (this.gameObject.name == "door")
        {
            GameManager.ins.Click1 += 1;
          //  GameManager.ins.Click2 = 0;
          //  GameManager.ins.Click3 = 0;
            

            if (GameManager.ins.Click1 == 2)
            {
                AudioManager.ins.play1shot(AudioManager.ins.level24[0]);

                Level24.ins.door.gameObject.SetActive(false);
                Level24.ins.door2.gameObject.SetActive(true);
                Level24.ins.baba.gameObject.SetActive(true);

            }
        }
        else if (this.gameObject.name == "windown")
        {
            GameManager.ins.Click2 += 1;
         //   GameManager.ins.Click1 = 0;
         //   GameManager.ins.Click3 = 0;
         //   GameManager.ins.Click4 = 0;
         //   GameManager.ins.Click5 = 0;
         //   GameManager.ins.Click6 = 0;
            if (GameManager.ins.Click2 == 2)
            {
                Level24.ins.windown.gameObject.SetActive(false);
                Level24.ins.windown1.gameObject.SetActive(true);
            }
        }
        else if (this.gameObject.name == "tv3")
        {
            GameManager.ins.Click3 += 1;
       //     GameManager.ins.Click2 = 0;
        //    GameManager.ins.Click1 = 0; 
        //    GameManager.ins.Click4 = 0;
         //   GameManager.ins.Click5 = 0;
          //  GameManager.ins.Click6 = 0;
            if (GameManager.ins.Click3 == 2)
            {
                Level24.ins.tv3.gameObject.SetActive(false);
                Level24.ins.tv1.gameObject.SetActive(true);
            }
        }
        else if (this.gameObject.name == "gra1")
        {
            GameManager.ins.Click4 += 1; 
        //    GameManager.ins.Click3 = 0;
        ////    GameManager.ins.Click2 = 0;
         //   GameManager.ins.Click1 = 0;
         //   GameManager.ins.Click5 = 0;
          //  GameManager.ins.Click6 = 0;
            if (GameManager.ins.Click4 == 2)
            {
                Level24.ins.gra1.gameObject.SetActive(false);
                Level24.ins.gra2.gameObject.SetActive(true);
            }
        }
        else if (this.gameObject.name == "fa1")
        {
            GameManager.ins.Click5 += 1; 
         //   GameManager.ins.Click3 = 0;
         //   GameManager.ins.Click2 = 0;
         //   GameManager.ins.Click1 = 0;
          //  GameManager.ins.Click4 = 0;
          //  GameManager.ins.Click6 = 0;
            if (GameManager.ins.Click5 == 2)
            {
                Level24.ins.fa1.gameObject.SetActive(false);
                Level24.ins.fa2.gameObject.SetActive(true);
            }
        }
    }
}
