using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
public class Level4click : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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

        if (this.gameObject.name == "bin")
        {
            GameManager.ins.Click1 += 1;
            if (GameManager.ins.Click1 == 2)
            {
                Level4.ins.garbage.gameObject.SetActive(true);
                Level4.ins.bin.gameObject.SetActive(false);
                GameManager.ins.hint4 = true;

            }
        }
        else if (this.gameObject.name == "boy")
        {
            if (Level4.ins.a1333 == false)
            {
                Level4.ins.a1333 = true;
                Level4.ins.socks.gameObject.SetActive(true);

            }


        }
    }
}
