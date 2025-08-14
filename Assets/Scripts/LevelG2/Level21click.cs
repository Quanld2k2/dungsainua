using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class Level21click : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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

        if (this.gameObject.name == "bell")
        {
            GameManager.ins.Click1 += 1;
        //    GameManager.ins.Click2 = 0;
        //    GameManager.ins.Click3 = 0;
            if (GameManager.ins.Click1 == 3)
            {
                Level21.ins.chageString("lev21_7");

                Level21.ins.girl.gameObject.SetActive(true);
                GameManager.ins.hint1 = true;
                Level21.ins.chinsu.gameObject.SetActive(true);
                Level21.ins.chili.gameObject.SetActive(true);
                Level21.ins.chili3.gameObject.SetActive(true);
                Level21.ins.wine.gameObject.SetActive(true);
                Level21.ins.mutat.gameObject.SetActive(true);
                Level21.ins.garlic1.gameObject.SetActive(true);
                Level21.ins.otbot1.gameObject.SetActive(true);
                Level21.ins.bell.gameObject.SetActive(false);

                Level21.ins.ResetTimer();
                Level21.ins.timeS();

            }
        }
    }
}
