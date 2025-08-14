using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
public class Level22click : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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

        if (this.gameObject.name == "earphone")
        {
            GameManager.ins.Click1 += 1;
            // GameManager.ins.Click2 = 0;
            // GameManager.ins.Click3 = 0;
            if (GameManager.ins.Click1 == 2)
            {
                GameManager.ins.hint1 = true;

                Level22.ins.p1.gameObject.SetActive(false);
                Level22.ins.earphone.gameObject.SetActive(false);
                Level22.ins.p1done.gameObject.SetActive(true);
                Level22.ins.ket1(0);
            }
        }
        else if (this.gameObject.name == "nurse")
        {
            if (Level22.ins.l21a3 == true)
            {
                AudioManager.ins.play1shot(AudioManager.ins.level22[3]);

                GameManager.ins.Click2 += 1;
           //     GameManager.ins.Click1 = 0;
            //    GameManager.ins.Click3 = 0;
                if (GameManager.ins.Click2 == 2)
                {
                    GameManager.ins.hint6 = true;

                    Level22.ins.number2 = 800;
                    Level22.ins.nurse.gameObject.SetActive(false);
                    Level22.ins.nurse2.gameObject.SetActive(true);
                    Level22.ins.chageString("lev22_12");


                }
            }
            
        }
        else if (this.gameObject.name == "doctor")
        {
            GameManager.ins.Click3 += 1;
         //   GameManager.ins.Click2 = 0;
        //    GameManager.ins.Click1 = 0;
            if (GameManager.ins.Click3 == 2)
            {
                GameManager.ins.hint7 = true;

                Level22.ins.card.gameObject.SetActive(true);

            }


        }
        else if (this.gameObject.name == "card")
        {
            Level22.ins.number2 = 900;

            Level22.ins.p7done.gameObject.SetActive(true);
            Level22.ins.doctor1.gameObject.SetActive(false);
            Level22.ins.card.gameObject.SetActive(false);
            Level22.ins.chageString("lev22_14");

        }
    }
}
