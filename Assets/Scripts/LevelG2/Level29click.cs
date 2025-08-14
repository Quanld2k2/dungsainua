using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
public class Level29click : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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

        if (this.gameObject.name == "curtain1")
        {
            GameManager.ins.Click1 += 1;
         //   GameManager.ins.Click2 = 0;
        //    GameManager.ins.Click3 = 0;
            if (GameManager.ins.Click1 == 2)
            {
                Level29.ins.curtain1.gameObject.SetActive(false);
                Level29.ins.curtain2.gameObject.SetActive(true); 
                Level29.ins.soap.gameObject.SetActive(true);

            }
        }
        else if (this.gameObject.name == "kitchen")
        {
            GameManager.ins.Click2 += 1;
        //    GameManager.ins.Click1 = 0;
         //   GameManager.ins.Click3 = 0;
            if (GameManager.ins.Click2 == 2)
            {
                Level29.ins.kitchen.gameObject.SetActive(false);
                Level29.ins.kitchen2.gameObject.SetActive(true);
                Level29.ins.perfume.gameObject.SetActive(true);

            }

        }
        else if (this.gameObject.name == "toilet")
        {
            GameManager.ins.Click3 += 1;
         //   GameManager.ins.Click1 = 0;
         //   GameManager.ins.Click2 = 0;
            if (GameManager.ins.Click3 == 2)
            {
                Level29.ins.toilet.gameObject.SetActive(false);
                Level29.ins.toilet2.gameObject.SetActive(true);
                Level29.ins.snake.gameObject.SetActive(true);

            }

        }

    }
}
