using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level16move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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

        if (name == "waterbottle")
        {
            Level16.ins.a2.gameObject.SetActive(true);
        }
        if (name == "wheel2")
        {
            Level16.ins.a3.gameObject.SetActive(true);
        }
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
                if (name == "wheel2")
                {
                    Level16.ins.a3.gameObject.SetActive(false);
                }
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
                    //   string[] validNames = { "ticket1", "ticket2", "ticket3", "ticket4", "ticket5", "ticket6", "ticket7", "ticket8", "ticket9", "ticket10" };
                    if ((other.name == "a1" || other.name == "a2") && name == "dumbell")
                    {
                        GameManager.ins.hint6 = true;

                        AudioManager.ins.play1shot(AudioManager.ins.level16[0]);

                        Level16.ins.a_boy.gameObject.SetActive(false);
                        Level16.ins.a_dumbell.gameObject.SetActive(true);
                        Level16.ins.estry = true;
                        Level16.ins.entry3 = Level16.ins.a_dumbell.AnimationState.SetAnimation(1, "animation", true);
                        Level16.ins.entrysss();

                        Level16.ins.gameover += 1;
                        Level16.ins.gameOver();

                        Level16.ins.chageString("lev16_1");

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a1" || other.name == "a2") && name == "watermelon")
                    {
                        GameManager.ins.hint5 = true;

                        AudioManager.ins.play1shot(AudioManager.ins.level16[0]);

                        Level16.ins.a_watermelon.gameObject.SetActive(true);

                        Level16.ins.entry2 = Level16.ins.a_watermelon.AnimationState.SetAnimation(1, "animation", true);
                        Level16.ins.chageString("lev16_1");

                        Level16.ins.entrysss();
                        Level16.ins.gameover += 1;
                        Level16.ins.gameOver();
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a1") && name == "stick")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level16[0]);

                        Level16.ins.a_stick.gameObject.SetActive(true);
                        GameManager.ins.hint1 = true;

                        Level16.ins.entry4 = Level16.ins.a_stick.AnimationState.SetAnimation(1, "animation", true);
                        Level16.ins.estry2 = true;
                        Level16.ins.entrysss();
                        Level16.ins.gameover += 1;
                        Level16.ins.gameOver();
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a1" || other.name == "a2") && name == "shoe")
                    {
                        GameManager.ins.hint7 = true;

                        AudioManager.ins.play1shot(AudioManager.ins.level16[0]);

                        Level16.ins.a_shoe.gameObject.SetActive(true);

                        Level16.ins.entry5 = Level16.ins.a_shoe.AnimationState.SetAnimation(1, "animation", true);

                        Level16.ins.entrysss();
                        Level16.ins.gameover += 1;
                        Level16.ins.gameOver();
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a1" || other.name == "a2") && name == "bucket")
                    {
                        if (Level16.ins.estry2 == true)
                        {
                            AudioManager.ins.play1shot(AudioManager.ins.level16[0]);

                            Level16.ins.a_bucket.gameObject.SetActive(true);

                            Level16.ins.entry6 = Level16.ins.a_bucket.AnimationState.SetAnimation(1, "animation", true);
                            Level16.ins.entrysss();

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
                    else if ((other.name == "a1" || other.name == "a2") && (name == "wheel3" || name == "wheel4"))
                    {
                        if (Level16.ins.estry2 == true)
                        {
                            GameManager.ins.hint4 = true;

                            AudioManager.ins.play1shot(AudioManager.ins.level16[0]);

                            Level16.ins.a_stick.gameObject.SetActive(false);

                            Level16.ins.a_wheel.gameObject.SetActive(true);
                            Level16.ins.chageString("lev16_2");

                            Level16.ins.entry4 = Level16.ins.a_wheel.AnimationState.SetAnimation(1, "animation", true);
                            Level16.ins.entrysss();
                            Level16.ins.gameover += 1;
                            Level16.ins.gameOver();
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
                    else if ((other.name == "wheel2") && name == "wheel1")
                    {
                        Level16.ins.wheel2.gameObject.SetActive(false);
                        Level16.ins.wheel3.gameObject.SetActive(true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a3") && name == "wheel2")
                    {
                        Level16.ins.wheel1.gameObject.SetActive(false);
                        Level16.ins.wheel4.gameObject.SetActive(true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "app1") && (name == "app2" || name == "app3"))
                    {
                        Level16.ins.app1.gameObject.SetActive(false);

                        Level16.ins.app1_2.gameObject.SetActive(true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "app2") && (name == "app1" || name == "app3"))
                    {
                        Level16.ins.app2.gameObject.SetActive(false);

                        Level16.ins.app2_2.gameObject.SetActive(true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "app3") && (name == "app1" || name == "app2"))
                    {
                        Level16.ins.app3.gameObject.SetActive(false);
                        Level16.ins.app3_2.gameObject.SetActive(true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "app1_2" || other.name == "app2_2" || other.name == "app3_2") && (name == "app1" || name == "app2" || name == "app3"))
                    {
                        if (other.name == "app1_2")
                        {
                            Level16.ins.app1_2.gameObject.SetActive(false);
                            Level16.ins.app1_3.gameObject.SetActive(true);
                        }
                        else if (other.name == "app2_2")
                        {
                            Level16.ins.app2_2.gameObject.SetActive(false);
                            Level16.ins.app2_3.gameObject.SetActive(true);
                        }
                        else if (other.name == "app3_2")
                        {
                            Level16.ins.app3_2.gameObject.SetActive(false);
                            Level16.ins.app3_3.gameObject.SetActive(true);
                        }

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((name == "app1_2" || name == "app2_2" || name == "app3_2") && (other.name == "app1" || other.name == "app2" || other.name == "app3"))
                    {
                        if (other.name == "app1")
                        {
                            Level16.ins.app1.gameObject.SetActive(false);
                            Level16.ins.app1_3.gameObject.SetActive(true);
                        }
                        else if (other.name == "app2")
                        {
                            Level16.ins.app2.gameObject.SetActive(false);
                            Level16.ins.app2_3.gameObject.SetActive(true);
                        }
                        else if (other.name == "app3")
                        {
                            Level16.ins.app3.gameObject.SetActive(false);
                            Level16.ins.app3_3.gameObject.SetActive(true);
                        }

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a1" || other.name == "a2") && (name == "app1_3" || name == "app2_3" || name == "app3_3"))
                    {
                        GameManager.ins.hint2 = true;

                        Level16.ins.a_pumkin.gameObject.SetActive(true);

                        Level16.ins.entry7 = Level16.ins.a_pumkin.AnimationState.SetAnimation(1, "animation", true);
                        Level16.ins.entrysss();
                        Level16.ins.chageString("lev16_2");

                        Level16.ins.gameover += 1;
                        Level16.ins.gameOver();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a2") && (name == "waterbottle"))
                    {
                        GameManager.ins.hint3 = true;
                        Level16.ins.gameover += 1;
                        Level16.ins.gameOver();


                        Level16.ins.a_waterbottle1.gameObject.SetActive(true);
                        Level16.ins.a_waterbottle2.gameObject.SetActive(true);

                        Level16.ins.a_waterbottle1.AnimationState.SetAnimation(1, "animation", false);
                        Level16.ins.a_waterbottle2.AnimationState.SetAnimation(1, "animation", false);

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
