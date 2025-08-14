using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class Level25click : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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

        if (this.gameObject.name == "wardrobe")
        {
            AudioManager.ins.play1shot(AudioManager.ins.level25[1]);

            GameManager.ins.Click1 += 1;
        //    GameManager.ins.Click2 = 0;
        //    GameManager.ins.Click3 = 0;
            if (GameManager.ins.Click1 == 3)
            {
                Level25.ins.wardrobe.gameObject.SetActive(false);
                Level25.ins.wardrobe2.gameObject.SetActive(true);
                Level25.ins.quanao.gameObject.SetActive(true);


            }
        }
        else if (this.gameObject.name == "a_windown")
        {
            AudioManager.ins.play1shot(AudioManager.ins.level25[1]);

            GameManager.ins.Click2 += 1;
         //   GameManager.ins.Click1 = 0;
         //   GameManager.ins.Click3 = 0;
            if (GameManager.ins.Click2 == 3)
            {
                GameManager.ins.hint16 = true;

                Level25.ins.a_window.gameObject.SetActive(false);
                Level25.ins.windown.gameObject.SetActive(true);
                Level25.ins.gameover += 1;
                Level25.ins.endGame();

            }
        }
    }
}
