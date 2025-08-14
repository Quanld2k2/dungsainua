using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level2move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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
        initialPosition = rectTransform.anchoredPosition;
        Vector3 worldPoint;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out worldPoint))
        {
            rectTransform.position = worldPoint;
        }
        rectTransform.SetAsLastSibling(); // Đưa phần tử UI lên phía trên cùng
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
                   // Debug.Log($"{name} đang va chạm với {other.name}");
                    collided = true;
                  //  string[] validNames = { "tien1", "tien2", "tien3", "tien4", "tien5", "tien6", "tien7", "tien8", "tien9" };
                  //  Debug.Log(validNames.Contains(name));
                    if ((other.name == "knife" || other.name == "1") &&(name == "money1" || name == "money2" || name == "money3") )
                    {
                        Level2.ins.knife.gameObject.SetActive(false);
                        Level2.ins.axe.gameObject.SetActive(true);
                        GameManager.ins.hint3 = true;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);

                        return collided;
                    }
                    else if ((other.name == "dog") && (name == "money1" || name == "money2" || name == "money3"))
                    {
                        Level2.ins.bone.gameObject.SetActive(true);
                        GameManager.ins.hint6 = true;

                        AudioManager.ins.play2shot(AudioManager.ins.level2[3]);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if (other.name == "d1" && name == "key1")
                    {
                        Level2.ins.l3v = true;

                        Level2.ins.d1.gameObject.SetActive(false);
                        Level2.ins.door1.gameObject.SetActive(true);
                        Level2.ins.door1.AnimationState.SetAnimation(1, "animation", false);
                        GameManager.ins.hint1 = true;

                        AudioManager.ins.play2shot(AudioManager.ins.level2[5]);


                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "2") && name == "axe")
                    {

                        Level2.ins.d2.gameObject.SetActive(false);
                        Level2.ins.door2.gameObject.SetActive(true);
                        Level2.ins.door2.AnimationState.SetAnimation(1, "animation", false);
                        AudioManager.ins.play2shot(AudioManager.ins.level2[0]);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "4") && name == "key2")
                    {
                        Level2.ins.d4.gameObject.SetActive(false);
                        Level2.ins.door4.gameObject.SetActive(true);
                        Level2.ins.door4.AnimationState.SetAnimation(1, "animation", false);

                        AudioManager.ins.play1shot(AudioManager.ins.level2[5]);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "5") && name == "bone")
                    {
                        Level2.ins.d5.gameObject.SetActive(false);
                        Level2.ins.door5.gameObject.SetActive(true);
                        Level2.ins.door5.AnimationState.SetAnimation(1, "animation", false);

                        AudioManager.ins.play2shot(AudioManager.ins.level2[5]);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "phone" || other.name == "6") && (name == "money1" || name == "money2" || name == "money3"))
                    {
                        if (Level2.ins.l3v == true)
                        {
                            Level2.ins.chageString("lev2_5");
                            GameManager.ins.hint4 = true;
                            AudioManager.ins.stop1shot();
                           Level2.ins.d3.gameObject.SetActive(false);
                            Level2.ins.door3.gameObject.SetActive(true);
                            Level2.ins.bride.gameObject.SetActive(true);
                            Level2.ins.phone.gameObject.SetActive(false);
                            Level2.ins.bride.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-1200f, -314f, 0f);

                            Level2.ins.bride.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-222f, -314f, 0f), 0.4f).OnComplete(() =>
                            {
                                AudioManager.ins.play2shot(AudioManager.ins.level2[2]);

                                Level2.ins.door3.AnimationState.SetAnimation(1, "animation", false);
                            });
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
