using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
public class Level10click : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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
        Debug.Log(GameManager.ins.Click1);

        if (this.gameObject.name == "water_tap")
        {
            GameManager.ins.Click1 += 1;
            if (GameManager.ins.Click1 == 5)
            {
                AudioManager.ins.play1shot(AudioManager.ins.level10[8]);
                GameManager.ins.Click1 = 1001;

                Level10.ins.a_water.gameObject.SetActive(true);
               // Level10.ins.water_tap.gameObject.SetActive(false);
                Level10.ins.a_water.AnimationState.SetAnimation(1, "animation", false);
                GameManager.ins.hint2 = true;



            }
        }
    }
}
