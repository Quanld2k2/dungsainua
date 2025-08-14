using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level13move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 initialPosition;
    private int initialSiblingIndex;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        initialSiblingIndex = rectTransform.GetSiblingIndex();
        // if (this.gameObject.GetComponent<Image>().raycastTarget == true)
        //{
        //this.gameObject.GetComponent<Image>().raycastTarget = false;
        Debug.Log(rectTransform.position);

        initialPosition = rectTransform.anchoredPosition;
        Vector3 worldPoint;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out worldPoint))
        {
            rectTransform.position = worldPoint;
        }
        rectTransform.SetAsLastSibling(); // Đưa phần tử UI lên phía trên cùng
                                          //}
        AudioManager.ins.play3shot(AudioManager.ins.level11[0]);

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 worldPoint;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out worldPoint))
        {
            rectTransform.position = worldPoint;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Xử lý logic khi kết thúc kéo, nếu cần
        //Debug.Log("Kéo đã kết thúc");
        rectTransform.SetSiblingIndex(initialSiblingIndex);

        // Kiểm tra va chạm trong quá trình kéo
        if (!CheckCollisionWithOtherUI())
        {
            // Nếu không có va chạm hợp lệ, di chuyển về vị trí ban đầu
            rectTransform.DOAnchorPos(initialPosition, 0.3f).OnComplete(() =>
            {
                Debug.Log("Kéo đã kết thúc");
                this.gameObject.GetComponent<Image>().raycastTarget = true;
            });
        }


    }

    private bool CheckCollisionWithOtherUI()
    {
        bool collided = false;
        // Danh sách tất cả các UI Image khác cần kiểm tra va chạm
        UICollisionDetector[] otherUIDetectors = FindObjectsOfType<UICollisionDetector>();

        foreach (UICollisionDetector other in otherUIDetectors)
        {
            if (other.gameObject != this.gameObject)
            {
                if (IsOverlapping(other.GetRectTransform()))
                {
                    Debug.Log($"{name} đang va chạm với {other.name}");
                    collided = true;
                    // string[] validNames = { "a1", "a2", "a3", "a4", "a5", "a6", "a7", "a8" };
                    //  Debug.Log(validNames.Contains(name));
                    if ((other.name == "a_girl") && name == "caxau1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level13[0]);

                        GameManager.ins.hint1 = true;

                        Level13.ins.done[Level13.ins.number].gameObject.GetComponent<Image>().sprite = Level13.ins.caxau2;
                        Level13.ins.done[Level13.ins.number].gameObject.GetComponent<Image>().SetNativeSize();
                        Level13.ins.done[Level13.ins.number].gameObject.SetActive(true);
                        Level13.ins.moveA();
                        Level13.ins.number += 1;
                        Level13.ins.chageString("lev13_1");

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "bag")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level13[0]);

                        GameManager.ins.hint6 = true;

                        Level13.ins.done[Level13.ins.number].gameObject.GetComponent<Image>().sprite = Level13.ins.bag2;
                        Level13.ins.done[Level13.ins.number].gameObject.GetComponent<Image>().SetNativeSize();
                        Level13.ins.done[Level13.ins.number].gameObject.SetActive(true);
                        Level13.ins.moveA();
                        Level13.ins.number += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "boat1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level13[0]);

                        GameManager.ins.hint8 = true;
                        Level13.ins.chageString("lev13_4");

                        Level13.ins.done[Level13.ins.number].gameObject.GetComponent<Image>().sprite = Level13.ins.boat2;
                        Level13.ins.done[Level13.ins.number].gameObject.GetComponent<Image>().SetNativeSize();
                        Level13.ins.done[Level13.ins.number].gameObject.SetActive(true);
                        Level13.ins.moveA();
                        Level13.ins.number += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "cu1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level13[0]);

                        GameManager.ins.Click1 += 225;
                        Level13.ins.done[Level13.ins.number].gameObject.GetComponent<Image>().sprite = Level13.ins.cu2;
                        Level13.ins.done[Level13.ins.number].gameObject.GetComponent<Image>().SetNativeSize();
                        Level13.ins.done[Level13.ins.number].gameObject.SetActive(true);
                        Level13.ins.moveA();
                       // Level13.ins.number += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "Ellipse1") && name == "cu1")
                    {
                        GameManager.ins.hint3 = true;

                        Level13.ins.god.gameObject.SetActive(true);
                        Level13.ins.god1.gameObject.SetActive(true);
                        Level13.ins.sli1.gameObject.SetActive(true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "bo1") && name == "shovel1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.dao_dat);

                        GameManager.ins.hint7 = true;
                        Level13.ins.checkaa = true;
                        Level13.ins.a_shovel.gameObject.SetActive(true);
                        Level13.ins.a_shovel.AnimationState.SetAnimation(1, "animation", false);


                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "stick1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level13[0]);

                        GameManager.ins.hint2 = true;
                        Level13.ins.chageString("lev13_3");

                        Level13.ins.done[Level13.ins.number].gameObject.GetComponent<Image>().sprite = Level13.ins.stick2          ;
                        Level13.ins.done[Level13.ins.number].gameObject.GetComponent<Image>().SetNativeSize();
                        Level13.ins.done[Level13.ins.number].gameObject.SetActive(true);
                        Level13.ins.moveA();
                        Level13.ins.number += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "bone1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level13[0]);

                        GameManager.ins.hint11 = true;

                        Level13.ins.done[Level13.ins.number].gameObject.GetComponent<Image>().sprite = Level13.ins.bone2;
                        Level13.ins.done[Level13.ins.number].gameObject.GetComponent<Image>().SetNativeSize();
                        Level13.ins.done[Level13.ins.number].gameObject.SetActive(true);
                        Level13.ins.moveA();
                        Level13.ins.number += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "shovel1")
                    {
                        if (Level13.ins.checkaa == false)
                        {
                            GameManager.ins.Click1 += 225;
                        }

                        GameManager.ins.hint13 = true;

                        Level13.ins.done[Level13.ins.number].gameObject.GetComponent<Image>().sprite = Level13.ins.resovel2;
                        Level13.ins.done[Level13.ins.number].gameObject.GetComponent<Image>().SetNativeSize();
                        Level13.ins.done[Level13.ins.number].gameObject.SetActive(true);
                        Level13.ins.moveA();
                        Level13.ins.number += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    
                    else if ((other.name == "a_girl") && name == "god1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level13[0]);

                        Level13.ins.done[Level13.ins.number].gameObject.GetComponent<Image>().sprite = Level13.ins.god2;
                        Level13.ins.done[Level13.ins.number].gameObject.GetComponent<Image>().SetNativeSize();
                        Level13.ins.done[Level13.ins.number].gameObject.SetActive(true);
                        Level13.ins.moveA();
                        Level13.ins.number += 1;
                        Level13.ins.add2 += 1;
                        if (Level13.ins.add2 == 2)
                        {
                            GameManager.ins.hint10 = true;

                        }

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "sli1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level13[0]);

                        Level13.ins.done[Level13.ins.number].gameObject.GetComponent<Image>().sprite = Level13.ins.sli2;
                        Level13.ins.done[Level13.ins.number].gameObject.GetComponent<Image>().SetNativeSize();
                        Level13.ins.done[Level13.ins.number].gameObject.SetActive(true);
                        Level13.ins.moveA();
                        Level13.ins.number += 1;
                        Level13.ins.add2 += 1;
                        if (Level13.ins.add2 == 2)
                        {
                            GameManager.ins.hint10 = true;

                        }
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "apple1")
                    {
                        if (Level13.ins.add1 == 2)
                        {
                            AudioManager.ins.play1shot(AudioManager.ins.level13[0]);

                            GameManager.ins.hint5 = true;
                            Level13.ins.chageString("lev13_2");

                            Level13.ins.done[Level13.ins.number].gameObject.GetComponent<Image>().sprite = Level13.ins.apple2;
                            Level13.ins.done[Level13.ins.number].gameObject.GetComponent<Image>().SetNativeSize();
                            Level13.ins.done[Level13.ins.number].gameObject.SetActive(true);
                            Level13.ins.moveA();
                            Level13.ins.number += 1;

                            this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                            this.gameObject.SetActive(false);
                            return collided;
                        }
                        else
                        {
                            collided = false;
                            return collided;

                        }
                    }
                    else if ((other.name == "Ellipse2") && name == "rod1")
                    {
                        GameManager.ins.hint9 = true;
                        Debug.Log(GameManager.ins.hint9);
                        Level13.ins.rod1.gameObject.SetActive(false);
                        Level13.ins.fish1.gameObject.SetActive(true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "w2") && name == "water1")
                    {

                        Level13.ins.water1.gameObject.SetActive(false);
                        Level13.ins.water2.gameObject.SetActive(true);
                        Level13.ins.w2.gameObject.SetActive(false);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "b1") && name == "water2")
                    {
                        Level13.ins.a_water.gameObject.SetActive(true);
                        Level13.ins.a_water.AnimationState.SetAnimation(1, "animation", false);
                        GameManager.ins.hint4 = true;


                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "fish1")
                    {
                        GameManager.ins.hint12 = true;
                        AudioManager.ins.play1shot(AudioManager.ins.level13[0]);

                        Level13.ins.done[Level13.ins.number].gameObject.GetComponent<Image>().sprite = Level13.ins.fish2;
                        Level13.ins.done[Level13.ins.number].gameObject.GetComponent<Image>().SetNativeSize();
                        Level13.ins.done[Level13.ins.number].gameObject.SetActive(true);
                        Level13.ins.moveA();
                        Level13.ins.number += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "rodd") && (name == "appdd1" || name == "appdd2" || name == "appdd3"))
                    {
                        Level13.ins.rod.gameObject.SetActive(false);
                        Level13.ins.rod1.gameObject.SetActive(true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "apple1") && (name == "appdd1" || name == "appdd2" || name == "appdd3"))
                    {
                        if (Level13.ins.add1 == 0)
                        {
                            Level13.ins.ad1.gameObject.SetActive(true);
                            Level13.ins.add1 += 1;
                        }
                        else if(Level13.ins.add1 == 1)
                        {
                            Level13.ins.ad2.gameObject.SetActive(true);
                            Level13.ins.add1 += 1;
                        }

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else
                    {
                        Debug.Log("rodrodrodrod");

                        collided = false;
                        return collided;
                    }
                }   
            }
        }

        return collided;
    }

    private bool IsOverlapping(RectTransform otherRectTransform)
    {
        Rect rect1 = GetWorldRect(rectTransform);
        Rect rect2 = GetWorldRect(otherRectTransform);
        bool isOverlapping = rect1.Overlaps(rect2);
        Debug.Log($"{rectTransform.name} overlap with {otherRectTransform.name}: {isOverlapping}");
        return isOverlapping;
    }

    private Rect GetWorldRect(RectTransform rt)
    {
        // Chuyển đổi RectTransform thành Rect trong không gian thế giới
        Vector3[] corners = new Vector3[4];
        rt.GetWorldCorners(corners);

        float width = Vector3.Distance(corners[0], corners[3]);  // Khoảng cách giữa góc trái dưới và trái trên
        float height = Vector3.Distance(corners[0], corners[1]); // Khoảng cách giữa góc trái dưới và góc phải dưới
        Rect worldRect = new Rect(corners[0], new Vector2(width, height));

        return worldRect;
    }
}
