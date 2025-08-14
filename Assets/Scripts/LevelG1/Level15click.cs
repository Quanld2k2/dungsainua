using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class Level15click : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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

        if (this.gameObject.name == "fridge1")
        {
            Level15.ins.fridge1.gameObject.SetActive(false);
            Level15.ins.fridge2.gameObject.SetActive(true);
            Level15.ins.chicken1.gameObject.SetActive(true);
            Level15.ins.water.gameObject.SetActive(true);
            Level15.ins.cream1.gameObject.SetActive(true);

        }
        else if (this.gameObject.name == "wd_1")
        {
            Level15.ins.wd_1.gameObject.SetActive(false);
            Level15.ins.wd_2.gameObject.SetActive(true);
            Level15.ins.cucumber1.gameObject.SetActive(true);
        }

    }
}
