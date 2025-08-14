using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
public class Level7click : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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
            GameManager.ins.Click2 = 0;
            GameManager.ins.Click3 = 0;
            if (GameManager.ins.Click1 == 2)
            {
                AudioManager.ins.play1shot(AudioManager.ins.level7[1]);
                GameManager.ins.hint7 = true;
                Level7.ins.chageString("lev7_2");

                Level7.ins.curtain2.gameObject.SetActive(true);
                Level7.ins.curtain1.gameObject.SetActive(false);
                Level7.ins.pic1.gameObject.SetActive(true);
                Level7.ins.chair.gameObject.SetActive(true);

            }
        }
      
    }
}
