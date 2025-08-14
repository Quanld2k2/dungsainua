using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
public class Level17click : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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

        if (this.gameObject.name == "door1")
        {
            GameManager.ins.Click1 += 1;
            if (GameManager.ins.Click1 == 2)
            {
                AudioManager.ins.play1shot(AudioManager.ins.level17[2]);

                Level17.ins.door2.gameObject.SetActive(true);
                Level17.ins.toilet2.gameObject.SetActive(true);
                Level17.ins.toilet1.gameObject.SetActive(true);
                Level17.ins.door1.gameObject.SetActive(false);
                Level17.ins.t1.gameObject.SetActive(true);

                Level17.ins.toilet_suction.gameObject.SetActive(true);
            }
        }
        else if (this.gameObject.name == "air2")
        {
            GameManager.ins.Click2 += 1;
            if (GameManager.ins.Click2 == 2)
            {
                Level17.ins.air1.gameObject.SetActive(true);
                Level17.ins.air_m.gameObject.SetActive(true);
                Level17.ins.air2.gameObject.SetActive(false);

            }
        }
        else if (this.gameObject.name == "piture")
        {
            GameManager.ins.hint12 = true;
            Level17.ins.crack2.gameObject.SetActive(true);
            Level17.ins.piture.gameObject.SetActive(false);
        }
        else if (this.gameObject.name == "wall1")
        {
            Level17.ins.wall_m.gameObject.SetActive(true);
            Level17.ins.wall1.gameObject.SetActive(false);

        }
        else if (this.gameObject.name == "a1")
        {
            GameManager.ins.hint8 = true;

            Level17.ins.cabinet2.gameObject.SetActive(true);
            Level17.ins.cabinet1.gameObject.SetActive(false);
            Level17.ins.clothe1.gameObject.SetActive(true);
            Level17.ins.drag.gameObject.SetActive(true);
            Level17.ins.cabinet_m.gameObject.SetActive(true);

        }
        else if (this.gameObject.name == "a2")
        {
            Level17.ins.cabinet3.gameObject.SetActive(true);
            Level17.ins.hammer.gameObject.SetActive(true);
            Level17.ins.a2.gameObject.SetActive(false);

        }
        else if (this.gameObject.name == "a3")
        {
            Level17.ins.cabinet3.gameObject.SetActive(true);
            Level17.ins.hammer.gameObject.SetActive(true);
            Level17.ins.a3.gameObject.SetActive(false);

        }
        else if (this.gameObject.name == "carpet1")
        {
            Level17.ins.box1.gameObject.SetActive(true);
            Level17.ins.box_m.gameObject.SetActive(true);
            Level17.ins.carpet1.gameObject.SetActive(false);
        }
        else if (this.gameObject.name == "clothe1")
        {
            Level17.ins.clothe1.gameObject.SetActive(false);
            Level17.ins.clothe2.gameObject.SetActive(true);
        }
        else if (this.gameObject.name == "boy2")
        {
            Level17.ins.boy2.gameObject.SetActive(false);

            Level17.ins.boy_m.gameObject.SetActive(true);
            Level17.ins.key.gameObject.SetActive(true);
        }
        else if (this.gameObject.name == "flower")
        {
            if (Level17.ins.ac1 == false)
            {
                Level17.ins.ac1 = true;
                Level17.ins.money1.gameObject.SetActive(true);
            }
        }
        else if (this.gameObject.name == "t1")
        {
            Level17.ins.toilet2.gameObject.SetActive(false);
            Level17.ins.toilet_m.gameObject.SetActive(true);
            Level17.ins.t1.gameObject.SetActive(false);

        }
        else if (this.gameObject.name == "wall_m")
        {
            Level17.ins.AddMoney(5000000); this.gameObject.SetActive(false); GameManager.ins.hint4 = true;

        }
        else if (this.gameObject.name == "air_m")
        {
            Level17.ins.AddMoney(500000); this.gameObject.SetActive(false); GameManager.ins.hint11 = true;
        }
        else if (this.gameObject.name == "cabinet_m")
        {
            Level17.ins.AddMoney(400000); this.gameObject.SetActive(false); GameManager.ins.hint9 = true;

        }
        else if (this.gameObject.name == "safe_m")
        {
            Level17.ins.AddMoney(600000); this.gameObject.SetActive(false); GameManager.ins.hint3 = true;

        }
        else if (this.gameObject.name == "crack_m")
        {
            Level17.ins.AddMoney(800000); this.gameObject.SetActive(false); GameManager.ins.hint13 = true;
        }
        else if (this.gameObject.name == "box_m")
        {
            Level17.ins.AddMoney(1100000); this.gameObject.SetActive(false); GameManager.ins.hint5 = true;

        }
        else if (this.gameObject.name == "tear_m")
        {
            Level17.ins.aatd += 1;
            if (Level17.ins.aatd == 2)
            {
                GameManager.ins.hint10 = true;
            }
            Level17.ins.AddMoney(400000); this.gameObject.SetActive(false);
        }
        else if (this.gameObject.name == "tear2_m")
        {
            Level17.ins.aatd += 1;
            if (Level17.ins.aatd == 2)
            {
                GameManager.ins.hint10 = true;
            }
           

            Level17.ins.AddMoney(300000); this.gameObject.SetActive(false);

        }
        else if (this.gameObject.name == "boy_m")
        {
            GameManager.ins.hint2 = true;

            Level17.ins.AddMoney(200000);
            this.gameObject.SetActive(false);
        }
        else if (this.gameObject.name == "money1")
        {
            GameManager.ins.hint1 = true;

            Level17.ins.AddMoney(100000); this.gameObject.SetActive(false);
        }
        else if (this.gameObject.name == "money2")
        {
            Level17.ins.AddMoney(100000); this.gameObject.SetActive(false); GameManager.ins.hint6 = true;

        }
        else if (this.gameObject.name == "toilet_m")
        {
            Level17.ins.AddMoney(500000); this.gameObject.SetActive(false); GameManager.ins.hint7 = true;

        }

    }
}
