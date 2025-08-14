using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
public class Level5click : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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

        if (this.gameObject.name == "a_girl")
        {
            GameManager.ins.Click1 += 1;
            if (GameManager.ins.Click1 == 2)
            {
                //  Level4.ins.many.GetComponent<RectTransform>().anchoredPosition = new Vector3(376f, -267f, 0f);
                Level5.ins.a_perfume.gameObject.SetActive(true);
                Level5.ins.a_perfume.AnimationState.SetAnimation(1, "animation", true);
                Level5.ins.bot9 = true;

                Level5.ins.a_girl.gameObject.SetActive(false);

                Level5.ins.a_G2.gameObject.SetActive(true);
                Level5.ins.a_G2.AnimationState.SetAnimation(1, "anim2", false);
                GameManager.ins.hint7 = true;
                Level5.ins.chageString("lev5_5");


            }
        }
    }
}
