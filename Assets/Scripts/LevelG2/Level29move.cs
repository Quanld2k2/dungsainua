using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level29move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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
                    if ((other.name == "anim_girl") && (name == "eyeshadow"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level29[1]);

                        GameManager.ins.hint5 = true;

                        Level29.ins.anim_girl.AnimationState.SetAnimation(1, "eyeshadow", false).MixDuration = 0f;
                        Level29.ins.ResetTimer();
                        Level29.ins.timeS();

                        Level29.ins.gameover += 1;
                        Level29.ins.endGame();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "anim_girl") && (name == "lipstick"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level29[1]);

                        GameManager.ins.hint1 = true;

                        Level29.ins.anim_girl.AnimationState.SetAnimation(1, "lipstick", false).MixDuration = 0f;
                        Level29.ins.ResetTimer();
                        Level29.ins.timeS();

                        Level29.ins.gameover += 1;
                        Level29.ins.endGame();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "anim_girl") && (name == "soap2"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level29[1]);

                        GameManager.ins.hint2 = true;

                        Level29.ins.anim_girl.AnimationState.SetAnimation(1, "soap2", false).MixDuration = 0f;
                        Level29.ins.ResetTimer();
                        Level29.ins.timeS();

                        Level29.ins.gameover += 1;
                        Level29.ins.endGame();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "anim_girl") && (name == "shortakirt"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level29[1]);

                        GameManager.ins.hint4 = true;

                        Level29.ins.anim_girl.AnimationState.SetAnimation(1, "short skirt", false).MixDuration = 0f;
                        Level29.ins.ResetTimer();
                        Level29.ins.timeS();

                        Level29.ins.gameover += 1;
                        Level29.ins.endGame();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "anim_girl") && (name == "bowtie"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level29[1]);

                        GameManager.ins.hint7 = true;

                        Level29.ins.anim_girl.AnimationState.SetAnimation(1, "bow tie", false).MixDuration = 0f;
                        Level29.ins.ResetTimer();
                        Level29.ins.timeS();

                        Level29.ins.gameover += 1;
                        Level29.ins.endGame();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "anim_girl") && (name == "hairstraightener"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level29[1]);

                        GameManager.ins.hint6 = true;

                        Level29.ins.anim_girl.AnimationState.SetAnimation(1, "hair straightener", false).MixDuration = 0f;
                        Level29.ins.ResetTimer();
                        Level29.ins.timeS();

                        Level29.ins.gameover += 1;
                        Level29.ins.endGame();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "anim_girl") && (name == "underwear"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level29[1]);

                        GameManager.ins.hint9 = true;

                        Level29.ins.anim_girl.AnimationState.SetAnimation(1, "underwear", false).MixDuration = 0f;
                        Level29.ins.ResetTimer();
                        Level29.ins.timeS();

                        Level29.ins.gameover += 1;
                        Level29.ins.endGame();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "anim_girl") && (name == "soap"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level29[1]);

                        GameManager.ins.hint3 = true;

                        Level29.ins.anim_girl.AnimationState.SetAnimation(1, "soap", false).MixDuration = 0f;
                        Level29.ins.ResetTimer();
                        Level29.ins.timeS();

                        Level29.ins.gameover += 1;
                        Level29.ins.endGame();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "anim_girl") && (name == "perfume"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level29[1]);

                        GameManager.ins.hint8 = true;

                        Level29.ins.anim_girl.AnimationState.SetAnimation(1, "perfume", false).MixDuration = 0f;
                        Level29.ins.ResetTimer();
                        Level29.ins.timeS();

                        Level29.ins.gameover += 1;
                        Level29.ins.endGame();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "anim_girl") && (name == "snake"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level29[0]);

                        Level29.ins.anim_girl.AnimationState.SetAnimation(1, "snake", false).MixDuration = 0f;
                        Level29.ins.ResetTimer();
                        Level29.ins.timeS();

                        Level29.ins.gameover = 100;
                        Level29.ins.endGame();

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
