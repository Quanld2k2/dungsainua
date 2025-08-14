using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level20move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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

            AudioManager.ins.play3shot(AudioManager.ins.level11[0]);

        }

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
        //    rectTransform.SetSiblingIndex(initialSiblingIndex);

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
                    if ((other.name == "girl") && (name == "broccoli"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level20[3]);

                        GameManager.ins.hint3 = true;

                        Level20.ins.broccoli2.gameObject.SetActive(true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level20.ins.gameover += 1;
                        Level20.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "girl") && (name == "spider"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level20[3]);

                        GameManager.ins.hint2 = true;

                        Level20.ins.spider2.gameObject.SetActive(true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level20.ins.gameover += 1;
                        Level20.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "girl") && (name == "cottoc"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level20[3]);

                        GameManager.ins.hint5 = true;

                        Level20.ins.cottoc2.gameObject.SetActive(true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level20.ins.gameover += 1;
                        Level20.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "girl") && (name == "img1"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level20[3]);

                        GameManager.ins.hint4 = true;

                        Level20.ins.img2.gameObject.SetActive(true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level20.ins.gameover += 1;
                        Level20.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "girl") && (name == "bouquet"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level20[3]);

                        GameManager.ins.hint1 = true;

                        Level20.ins.rose2.gameObject.SetActive(true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level20.ins.gameover += 1;
                        Level20.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "girl") && (name == "money"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level20[3]);

                        GameManager.ins.hint7 = true;

                        Level20.ins.money2.gameObject.SetActive(true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level20.ins.gameover += 1;
                        Level20.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "girl") && (name == "broom1"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level20[3]);

                        GameManager.ins.hint6 = true;

                        Level20.ins.broom2.gameObject.SetActive(true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level20.ins.gameover += 1;
                        Level20.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "girl") && (name == "towel1"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level20[3]);

                        GameManager.ins.hint7 = true;

                        Level20.ins.towel2.gameObject.SetActive(true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level20.ins.gameover += 1;
                        Level20.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "towel") && (name == "needle"))
                    {
                        Level20.ins.towel.gameObject.SetActive(false);
                        Level20.ins.towel1.gameObject.SetActive(true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        //   Level3.ins.gameover += 1;
                        //   Level3.ins.endGame();
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
