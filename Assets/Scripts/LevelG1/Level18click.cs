using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
public class Level18click : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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

        if (this.gameObject.name == "d2" || this.gameObject.name == "d4" || this.gameObject.name == "d5" || this.gameObject.name == "d9"
            || this.gameObject.name == "d1" || this.gameObject.name == "d3" || this.gameObject.name == "d6" || this.gameObject.name == "d7")
        {
            if (this.gameObject.name == "d5" || this.gameObject.name == "d3")
            {
                this.transform.eulerAngles = Vector3.zero;
            }
            Level18.ins.gameover += 1;
            Level18.ins.endGame();

            this.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(250f, -460f, 0f), 0.4f).OnComplete(() =>
            {
                this.gameObject.SetActive(false);

                Level18.ins.a_run[Level18.ins.nubm].gameObject.SetActive(true);
                Level18.ins.a_run[Level18.ins.nubm].AnimationState.SetAnimation(1, "animation", true);
                Level18.ins.nubm += 1; 
            });
            if (this.gameObject.name == "d1" )
            {
                Level18.ins.chageString("lev18_3");
                GameManager.ins.hint8 = true;

            }
            else if (this.gameObject.name == "d2")
            {
                GameManager.ins.hint1 = true;

                Level18.ins.chageString("lev18_1");
            }
            else if (this.gameObject.name == "d3")
            {
                Level18.ins.chageString("lev18_8");
            }
            else if (this.gameObject.name == "d4")
            {
                Level18.ins.chageString("lev18_5");
            }
            else if (this.gameObject.name == "d5")
            {
                GameManager.ins.hint5 = true;

                Level18.ins.chageString("lev18_7");
            }
            else if (this.gameObject.name == "d6")
            {
                GameManager.ins.hint4 = true;

                Level18.ins.chageString("lev18_4");
            }
            else if (this.gameObject.name == "d7")
            {
                GameManager.ins.hint3 = true;

                Level18.ins.chageString("lev18_6");
            }
            else if (this.gameObject.name == "d8")
            {
            }
            else if (this.gameObject.name == "d9")
            {
                GameManager.ins.hint9 = true;

            }
            else if (this.gameObject.name == "d10")
            {
                GameManager.ins.hint2 = true;
                Level18.ins.chageString("lev18_2");
            }
        }
        else if (this.gameObject.name == "bin1")
        {
            Level18.ins.gameover += 1;
            Level18.ins.endGame();

            GameManager.ins.hint2 = true;
            Level18.ins.chageString("lev18_2");
            Level18.ins.bin1.gameObject.SetActive(false);
            Level18.ins.bin2.gameObject.SetActive(true);

            Level18.ins._10.gameObject.SetActive(true);

            Level18.ins._10.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(250f, -460f, 0f), 0.5f).SetDelay(0.5f).OnComplete(() =>
            {
                Level18.ins._10.gameObject.SetActive(false);

                Level18.ins.a_run[Level18.ins.nubm].gameObject.SetActive(true);
                Level18.ins.a_run[Level18.ins.nubm].AnimationState.SetAnimation(1, "animation", true);
                Level18.ins.nubm += 1; ;

            });
        }
        else if (this.gameObject.name == "door1")
        {
           

        }
        else if (this.gameObject.name == "door3")
        {
            Level18.ins.door3.gameObject.SetActive(false);
            Level18.ins._1.gameObject.SetActive(true);
            Level18.ins.knife.gameObject.SetActive(true);
            Level18.ins.door4.gameObject.SetActive(true);

        }
        else if (this.gameObject.name == "carpet")
        {
            Level18.ins.carpet.gameObject.SetActive(false);
            Level18.ins.key.gameObject.SetActive(true);
            Level18.ins.carpet1.gameObject.SetActive(true);

        }
        else if (this.gameObject.name == "longman")
        {
            Level18.ins.longman.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-380f, 230f, 0f), 0.5f).OnComplete(() =>
            {
               

            });

        }
        else if (this.gameObject.name == "pilow2")
        {
            Level18.ins.pillow2.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-100f, 390f, 0f), 0.5f).OnComplete(() =>
            {


            });

        }
    }
}
