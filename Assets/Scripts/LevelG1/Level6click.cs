using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
public class Level6click : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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

        if (this.gameObject.name == "windown2")
        {
            GameManager.ins.Click1 += 1;
            GameManager.ins.Click2 = 0;
            GameManager.ins.Click3 = 0;
            if (GameManager.ins.Click1 == 2)
            {
                Level6.ins.windown1.gameObject.SetActive(true);
                Level6.ins.windown2.gameObject.SetActive(false);
                Level6.ins.a3.gameObject.SetActive(true);

            }
        }
        else if (this.gameObject.name == "door")
        {
            GameManager.ins.Click2 += 1;
            GameManager.ins.Click1 = 0;
            GameManager.ins.Click3 = 0;
            if (GameManager.ins.Click2 == 2)
            {
                Level6.ins.toilet.gameObject.SetActive(true);

                Level6.ins.a4.gameObject.SetActive(true);
                Level6.ins.wc.gameObject.SetActive(true);
                Level6.ins.door.gameObject.SetActive(false);
            }


        }
        else if (this.gameObject.name == "cabinet")
        {
            GameManager.ins.Click3 += 1;
            GameManager.ins.Click2 = 0;
            GameManager.ins.Click1 = 0;
            if (GameManager.ins.Click3 == 2)
            {
                Level6.ins.a1.gameObject.SetActive(true);
                Level6.ins.cabinet.gameObject.SetActive(false);
            }


        }
    }
}
