using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level10move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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
                   // string[] validNames = { "ticket1", "ticket2", "ticket3", "ticket4", "ticket5", "ticket6", "ticket7", "ticket8", "ticket9", "ticket10" };
                    if ((other.name == "bin") && (name == "garbage1" || name == "garbage2" || name == "garbage3" || name == "bottle"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level10[3]);
                        Level10.ins.dem += 1;
                        Level10.ins.gameover += 1;
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level10.ins.gameOver();
                        if (Level10.ins.dem == 4)
                        {
                            GameManager.ins.hint1 = true;

                        }

                        return collided;
                    }
                    else if ((other.name == "frog1" || other.name == "dog1") &&(name == "apple1" || name == "apple2"))
                    {
                        Level10.ins.gameover += 1;

                        if (other.name == "frog1")
                        {
                            AudioManager.ins.play1shot(AudioManager.ins.level10[5]);

                            Level10.ins.frog1.gameObject.SetActive(false);
                            Level10.ins.girl.gameObject.SetActive(true);
                            GameManager.ins.hint3 = true;
                        }
                        else
                        {
                            AudioManager.ins.play1shot(AudioManager.ins.level10[4]);

                            GameManager.ins.hint5 = true;
                            Level10.ins.dog1.gameObject.SetActive(false);
                            Level10.ins.dog2.gameObject.SetActive(true);
                        }

                        Level10.ins.gameOver();
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "table") && name == "girl")
                    {
                        Level10.ins.gameover += 1;
                        GameManager.ins.hint4 = true;
                        Level10.ins.food.gameObject.SetActive(true);
                        Level10.ins.gameOver();
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        //this.gameObject.SetActive(false); 
                        return collided;
                    }
                    else if ((other.name == "a_boy") && name == "scissors")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level10[2]);

                        Level10.ins.gameover += 1;
                        GameManager.ins.hint6 = true;
                        Level10.ins.a_boy.AnimationState.SetAnimation(1, "animation2", false);
                        Level10.ins.gameOver();
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "boy2") && name == "sunscreen")
                    {
                        Level10.ins.gameover += 1;
                        AudioManager.ins.play1shot(AudioManager.ins.level10[1]);

                        Level10.ins.boy2.gameObject.SetActive(false);
                        GameManager.ins.hint7 = true;
                        Level10.ins.boy3.gameObject.SetActive(true);
                        Level10.ins.gameOver();
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "x2") && name == "shovel")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.dao_dat);

                        Level10.ins.gameover += 100;

                        Level10.ins.a_shole1.gameObject.SetActive(true);

                        Level10.ins.a_shole1.AnimationState.SetAnimation(1, "animation", false);
                        Level10.ins.gameOver();
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "x") && name == "shovel")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.dao_dat);

                        Level10.ins.gameover += 1;
                        GameManager.ins.hint8 = true;
                        Level10.ins.a_shole2.gameObject.SetActive(true);

                        Level10.ins.a_shole2.AnimationState.SetAnimation(1, "animation", false);
                        Level10.ins.gameOver();
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
