using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
public class Level12click : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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

        if (this.gameObject.name == "a1")
        {
           // GameManager.ins.Click1 += 1;
           // GameManager.ins.Click2 = 0;
           // GameManager.ins.Click3 = 0;
            if (GameManager.ins.Click1 == 2)
            {
                
            }
        }
        else if (this.gameObject.name == "a2")
        {
            GameManager.ins.Click2 += 1;
          //  GameManager.ins.Click1 = 0;
          //  GameManager.ins.Click3 = 0;
            if (GameManager.ins.Click2 == 2)
            {

                Level12.ins.a2.gameObject.SetActive(false);
                Level12.ins.ax1.gameObject.SetActive(true);
                Level12.ins.window.gameObject.SetActive(true);
            }
        }
        else if (this.gameObject.name == "a3")
        {
            GameManager.ins.Click3 += 1;
         //   GameManager.ins.Click2 = 0;
          //  GameManager.ins.Click1 = 0;
            if (GameManager.ins.Click3 == 2)
            {
                Level12.ins.a3.gameObject.SetActive(false);
                Level12.ins.alo.gameObject.SetActive(true);
                Level12.ins.esi.gameObject.SetActive(true);
            }


        }
    }
}
