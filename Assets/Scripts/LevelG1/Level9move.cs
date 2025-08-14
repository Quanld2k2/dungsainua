using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level9move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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
                    string[] validNames = { "g1", "g2", "g3", "g4", "g5", "g6", "g7" };
                    if (validNames.Contains(other.name) && name == "mirror")
                    {
                        Level9.ins.chageString("lev9_1");

                        Level9.ins.lose.gameObject.SetActive(true);
                        Level9.ins.gameover = 100;
                        Level9.ins.gameOver();
                        AudioManager.ins.play1shot(AudioManager.ins.level9[3]);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);

                        return collided;
                    }
                    else if (validNames.Contains(other.name) && name == "bear")
                    {
                        Level9.ins.chageString("lev9_4");
                        GameManager.ins.hint3 = true;

                        Level9.ins.ghost4.gameObject.SetActive(true);
                        Level9.ins.ghost[Level9.ins.aanim].gameObject.SetActive(false);

                        Level9.ins.aanim += 1;
                        Level9.ins.selec1(Level9.ins.ghost4.gameObject);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if (validNames.Contains(other.name) && name == "pt_boy")
                    {
                        Level9.ins.chageString("lev9_6");
                        GameManager.ins.hint5 = true;

                        Level9.ins.ghost6.gameObject.SetActive(true);
                        Level9.ins.ghost[Level9.ins.aanim].gameObject.SetActive(false);

                        Level9.ins.aanim += 1;
                        Level9.ins.selec1(Level9.ins.ghost6.gameObject);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if (validNames.Contains(other.name) && name == "knock")
                    {
                       // AudioManager.ins.play1shot(AudioManager.ins.level9[0]);

                        Level9.ins.chageString("lev9_7");
                        GameManager.ins.hint6 = true;

                        Level9.ins.ghost3.gameObject.SetActive(true);
                        Level9.ins.ghost[Level9.ins.aanim].gameObject.SetActive(false);

                        Level9.ins.aanim += 1;
                        Level9.ins.selects = true;

                        Level9.ins.a_nock.gameObject.SetActive(true);
                        Level9.ins.a_nock.AnimationState.SetAnimation(1, "animation", true);

                        
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if (validNames.Contains(other.name) && name == "ghost9")
                    {
                        Level9.ins.chageString("lev9_3");

                        Level9.ins.ghost7.gameObject.SetActive(true);
                        Level9.ins.ghost[Level9.ins.aanim].gameObject.SetActive(false);

                        Level9.ins.aanim += 1;
                        Level9.ins.selec1(Level9.ins.ghost7.gameObject);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if (validNames.Contains(other.name) && name == "ring")
                    {
                        Level9.ins.chageString("lev9_8");
                        GameManager.ins.hint7 = true;

                        Level9.ins.ghost5.gameObject.SetActive(true);
                        Level9.ins.ghost[Level9.ins.aanim].gameObject.SetActive(false);

                        Level9.ins.aanim += 1;
                        Level9.ins.selec1(Level9.ins.ghost5.gameObject);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if (other.name == "money1" && name == "candle1")
                    {
                        Level9.ins.money1.gameObject.SetActive(false);
                        GameManager.ins.hint1 = true;

                        Level9.ins.a_fire.gameObject.SetActive(true);
                        Level9.ins.a_fire.AnimationState.SetAnimation(1, "animation", true);


                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if (validNames.Contains(other.name) && name == "a_fire")
                    {
                        Level9.ins.chageString("lev9_2");

                        Level9.ins.ghost1.gameObject.SetActive(true);
                        Level9.ins.ghost[Level9.ins.aanim].gameObject.SetActive(false);

                        Level9.ins.aanim += 1;
                        Level9.ins.selec1(Level9.ins.ghost1.gameObject);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if (validNames.Contains(other.name) && name == "clock")
                    {
                        Level9.ins.chageString("lev9_5");

                        Level9.ins.ghost2.gameObject.SetActive(true);
                        Level9.ins.ghost[Level9.ins.aanim].gameObject.SetActive(false);
                        GameManager.ins.hint4 = true;

                        Level9.ins.aanim += 1;
                        Level9.ins.selec1(Level9.ins.ghost2.gameObject);

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
