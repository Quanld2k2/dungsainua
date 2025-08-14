using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level14move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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
                    if ((other.name == "hole1") && name == "a2")
                    {
                        GameManager.ins.hint1 = true;

                        Level14.ins.horizontalLayoutGroup.enabled = true;
                        Level14.ins.contentSizeFitter.enabled = true;

                        Level14.ins.hole1.gameObject.SetActive(false);
                        Level14.ins.hole2.gameObject.SetActive(true);
                        Level14.ins.a_rain.gameObject.SetActive(false);

                        Level14.ins.gameover += 1;
                        Level14.ins.gameOver();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "hole2") && name == "a5")
                    {
                        GameManager.ins.hint8 = true;

                        Level14.ins.horizontalLayoutGroup.enabled = true;
                        Level14.ins.contentSizeFitter.enabled = true;

                        Level14.ins.hole2.gameObject.SetActive(false);

                        Level14.ins.gameover += 1;
                        Level14.ins.gameOver();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "pipe1") && name == "a3")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level14[5]);

                        GameManager.ins.hint2 = true;

                        Level14.ins.horizontalLayoutGroup.enabled = true;
                        Level14.ins.contentSizeFitter.enabled = true;

                        Level14.ins.pipe1.gameObject.SetActive(false);
                        Level14.ins.a_waterpipe.gameObject.SetActive(true);
                        Level14.ins.a_waterpipe.AnimationState.SetAnimation(1, "animation", false);

                        Level14.ins.gameover += 1;
                        Level14.ins.gameOver();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a_water3") && name == "a7")
                    {
                        GameManager.ins.hint3 = true;

                        Level14.ins.horizontalLayoutGroup.enabled = true;
                        Level14.ins.contentSizeFitter.enabled = true;

                        Level14.ins.a_water3.gameObject.SetActive(false);
                        Level14.ins.wood.gameObject.SetActive(true);

                        Level14.ins.gameover += 1;
                        Level14.ins.gameOver();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "door1") && name == "a6")
                    {
                        if (Level14.ins.q1 == true)
                        {
                            AudioManager.ins.play1shot(AudioManager.ins.level14[2]);

                            AudioManager.ins.stopmusicgame();

                            GameManager.ins.hint6 = true;

                            Level14.ins.horizontalLayoutGroup.enabled = true;
                            Level14.ins.contentSizeFitter.enabled = true;

                            Level14.ins.door1.gameObject.SetActive(false);
                            Level14.ins.door2.gameObject.SetActive(true);
                            Level14.ins.a_h2o.gameObject.SetActive(false);
                            //  Level14.ins.a_h2o.AnimationState.SetAnimation(1, "animation5", true);
                            Level14.ins.shark2.gameObject.SetActive(false);
                            Level14.ins.b1.gameObject.SetActive(true);

                            Level14.ins.gameover += 1;
                            Level14.ins.gameOver();

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
                    else if ((other.name == "a_water2") && name == "a1")
                    {
                        GameManager.ins.hint4 = true;

                        Level14.ins.horizontalLayoutGroup.enabled = true;
                        Level14.ins.contentSizeFitter.enabled = true;

                        Level14.ins.a_pump.gameObject.SetActive(true);
                        Level14.ins.a_pump.AnimationState.SetAnimation(1, "animation", false);

                        Level14.ins.gameover += 1;
                        Level14.ins.gameOver();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "shark") && name == "a4")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level14[0]);

                        GameManager.ins.hint5 = true;

                        Level14.ins.horizontalLayoutGroup.enabled = true;
                        Level14.ins.contentSizeFitter.enabled = true;

                        Level14.ins.shark.gameObject.SetActive(false);
                        Level14.ins.shark2.gameObject.SetActive(true);
                        Level14.ins.q1 = true;

                        Level14.ins.gameover += 1;
                        Level14.ins.gameOver();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "b1") && name == "a8")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level14[3]);

                        GameManager.ins.hint7 = true;

                        Level14.ins.w1.gameObject.SetActive(false);
                        Level14.ins.w2.gameObject.SetActive(false);
                        Level14.ins.w3.gameObject.SetActive(false);
                        Level14.ins.w4.gameObject.SetActive(false);

                        Level14.ins.gameover += 1;
                        Level14.ins.gameOver();

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
