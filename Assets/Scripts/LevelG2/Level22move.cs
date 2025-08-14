using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level22move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 initialPosition;
    private int initialSiblingIndex;
    private bool isLocked = false;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(isLocked);
        /// if (isLocked) return;
        // isLocked = true;
        initialSiblingIndex = rectTransform.GetSiblingIndex();
        if (this.gameObject.GetComponent<Image>().raycastTarget == true)
        {
            this.gameObject.GetComponent<Image>().raycastTarget = false;
            //  Debug.Log(rectTransform.position);

            initialPosition = rectTransform.anchoredPosition;
            Vector3 worldPoint;
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out worldPoint))
            {
                rectTransform.position = worldPoint;
            }
            rectTransform.SetAsLastSibling(); // Đưa phần tử UI lên phía trên cùng

        }
        AudioManager.ins.play3shot(AudioManager.ins.level11[0]);

    }

    public void OnDrag(PointerEventData eventData)
    {
        // 
        Vector3 worldPoint;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out worldPoint))
        {
            rectTransform.position = worldPoint;

        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //  if (isLocked) return;
        Debug.Log("OnPointerUp");

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
                isLocked = false;
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
                    if ((other.name == "p2") && (name == "mouth"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level22[2]);

                        GameManager.ins.hint2 = true;

                        Level22.ins.p2.gameObject.SetActive(false);
                        Level22.ins.chageString("lev22_4");

                        Level22.ins.animbn2.gameObject.SetActive(true);
                        Level22.ins.animbn2.AnimationState.SetAnimation(1, "animation", true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "p3") && (name == "chili"))
                    {
                        GameManager.ins.hint3 = true;

                        Level22.ins.number2 = 200;
                        Level22.ins.p3.gameObject.SetActive(false);
                        Level22.ins.p3done.gameObject.SetActive(true);
                        Level22.ins.chageString("lev22_5");
                       
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "doctor1") && (name == "dress"))
                    {
                        if (Level22.ins.l21a5 == true)
                        {
                            AudioManager.ins.play1shot(AudioManager.ins.level22[4]);

                            GameManager.ins.hint4 = true;

                            Level22.ins.number2 = 300;
                            Level22.ins.dress.gameObject.SetActive(false);
                            Level22.ins.doctor1.gameObject.SetActive(false);
                            Level22.ins.bn4.gameObject.SetActive(true);

                            Level22.ins.chageString("lev22_7");

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
                    else if ((other.name == "animbn5") && (name == "hammer"))
                    {
                        Level22.ins.number2 = 400;
                        
                        Level22.ins.chageString("lev22_10");

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "t1") && (name == "hammer"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level22[0]);

                        Level22.ins.table.gameObject.SetActive(false);
                        Level22.ins.table2.gameObject.SetActive(true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "animbn5") && (name == "table2"))
                    {
                        GameManager.ins.hint5 = true;

                        Level22.ins.animbn5.gameObject.SetActive(false);
                        Level22.ins.p5done.gameObject.SetActive(true);

                        Level22.ins.ket1(4);

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
            }
        }

        return collided;
    }

    private bool IsOverlapping(RectTransform otherRectTransform)
    {
        Rect rect1 = GetWorldRect(rectTransform);
        Rect rect2 = GetWorldRect(otherRectTransform);
        bool isOverlapping = rect1.Overlaps(rect2);
        //  Debug.Log($"{rectTransform.name} overlap with {otherRectTransform.name}: {isOverlapping}");
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
