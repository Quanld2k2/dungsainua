using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level26move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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
        if (this.gameObject.name == "anim_fish")
        {
            Level26.ins.fish.gameObject.SetActive(true);
            Level26.ins.a_fish.gameObject.SetActive(false);
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
                if (this.gameObject.name == "fish")
                {
                    Level26.ins.fish.gameObject.SetActive(false);
                    Level26.ins.a_fish.gameObject.SetActive(true);
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
                    if ((other.name == "q1") && name == "lifebuoy")
                    {
                        GameManager.ins.hint1 = true;

                        Level26.ins.a_girl.gameObject.SetActive(false);
                        Level26.ins.a_girl3.gameObject.SetActive(true);
                        Level26.ins.a_girl3.AnimationState.SetAnimation(1, "Anim3", false);
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;

                    }
                    else if ((other.name == "q1") && name == "fish")
                    {
                        GameManager.ins.hint2 = true;

                        Level26.ins.a_girl.gameObject.SetActive(false);

                        Level26.ins.a_girl5.gameObject.SetActive(true);
                        Level26.ins.a_girl5.AnimationState.SetAnimation(1, "Anim5", false);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "q1") && name == "cloud")
                    {
                        GameManager.ins.hint4 = true;

                        Level26.ins.a_girl.gameObject.SetActive(false);

                        Level26.ins.a_girl6.gameObject.SetActive(true);
                        Level26.ins.a_girl6.AnimationState.SetAnimation(1, "Anim6", false);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "q1") && name == "stick")
                    {
                        GameManager.ins.hint5 = true;

                        Level26.ins.a_girl.gameObject.SetActive(false);

                        Level26.ins.a_girl4.gameObject.SetActive(true);
                        Level26.ins.a_girl4.AnimationState.SetAnimation(1, "Anim4", false);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "q1") && name == "rope")
                    {
                        GameManager.ins.hint3 = true;

                        Level26.ins.a_girl.gameObject.SetActive(false);

                        Level26.ins.a_girl2.gameObject.SetActive(true);
                        Level26.ins.a_girl2.AnimationState.SetAnimation(1, "Anim2", false);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "q1") && name == "anim_duck")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level26[1]);

                        GameManager.ins.hint7 = true;

                        Level26.ins.a_girl.gameObject.SetActive(false);

                        Level26.ins.a_girl7.gameObject.SetActive(true);
                        Level26.ins.a_girl7.AnimationState.SetAnimation(1, "Anim7", false);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "q1") && name == "sweetpotato")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level26[2]);

                        GameManager.ins.hint6 = true;

                        Level26.ins.a_girl.gameObject.SetActive(false);

                        Level26.ins.a_girl8.gameObject.SetActive(true);
                        Level26.ins.a_girl8.AnimationState.SetAnimation(1, "Anim8", false);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "shape") && name == "anim_hoe")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.dao_dat);

                        Level26.ins.a_hoe2.gameObject.SetActive(true);
                        Level26.ins.a_hoe2.AnimationState.SetAnimation(1, "animation", false);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "tree") && name == "saw")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level26[0]);

                        Level26.ins.tree.gameObject.SetActive(false);

                        Level26.ins.stick.gameObject.SetActive(true);

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
