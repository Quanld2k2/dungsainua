using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class Level9click : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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

        if (this.gameObject.name == "cabinet")
        {
            GameManager.ins.Click1 += 1;
            GameManager.ins.Click2 = 0;
            GameManager.ins.Click3 = 0;
            if (GameManager.ins.Click1 == 2)
            {
                AudioManager.ins.play1shot(AudioManager.ins.level9[0]);

                Level9.ins.cabinet1.gameObject.SetActive(false);
                Level9.ins.cabinet2.gameObject.SetActive(true);
                Level9.ins.bear.gameObject.SetActive(true);


            }
        }
        else if (this.gameObject.name == "door")
        {
            GameManager.ins.Click2 += 1;
            GameManager.ins.Click1 = 0;
            GameManager.ins.Click3 = 0;
            if (GameManager.ins.Click2 == 2)
            {
                AudioManager.ins.play1shot(AudioManager.ins.level9[2]);

                Level9.ins.door.gameObject.SetActive(false);
                Level9.ins.door_open.gameObject.SetActive(true);
                Level9.ins.knock.gameObject.SetActive(true);
                Level9.ins.pt_boy.gameObject.SetActive(true);

            }


        }
        else if (this.gameObject.name == "curtain1")
        {
            AudioManager.ins.play1shot(AudioManager.ins.level9[1]);
            GameManager.ins.hint2 = true;

            Level9.ins.curtain1.gameObject.SetActive(false);
                Level9.ins.curtain2.gameObject.SetActive(true);
        }
        else if (this.gameObject.name == "a1")
        {
            GameManager.ins.Click3 += 1;
            GameManager.ins.Click2 = 0;
            GameManager.ins.Click1 = 0;
            if (GameManager.ins.Click3 == 2)
            {
                Level9.ins.ring.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-120f, 100f);

                Level9.ins.ring.gameObject.SetActive(true);
                Level9.ins.ring.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-86f, -184f), 1f)
                .SetEase(Ease.OutQuad);
                Level9.ins.a1.gameObject.SetActive(false);

            }


        }
    }
}
