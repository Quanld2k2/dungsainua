using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level5move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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
                    string[] validNames = { "a1", "a2", "a3", "a4", "a5", "a6", "a7", "a8" };
                    Debug.Log(validNames.Contains(name));
                    if ((other.name == "a_boy") && name == "headphone")
                    {
                        GameManager.ins.hint1 = true;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level5.ins.a_boy.AnimationState.SetAnimation(1, "Anim2", true);
                        Level5.ins.head = true;
                        Level5.ins.PauseTimer();
                        Level5.ins.timeS();
                        // Level5.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "a_girl" ) && name == "bottle2")
                    {
                        // tiente2
                        AudioManager.ins.play1shot(AudioManager.ins.level5[0]);
                        GameManager.ins.hint3 = true;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level5.ins.bottle4.gameObject.SetActive(true);
                        Level5.ins.bot1 = true;
                        Level5.ins.a_girl.gameObject.SetActive(false);

                        Level5.ins.a_G2.gameObject.SetActive(true);
                        Level5.ins.a_G2.AnimationState.SetAnimation(1, "anim2", false);
                        Level5.ins.PauseTimer();
                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "hat1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level5[0]);

                        // tiente2
                        GameManager.ins.hint8 = true;
                        Level5.ins.chageString("lev5_4");

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level5.ins.hat3.gameObject.SetActive(true);
                        Level5.ins.bot2 = true;

                        Level5.ins.a_girl.gameObject.SetActive(false);

                        Level5.ins.a_G2.gameObject.SetActive(true);
                        Level5.ins.a_G2.AnimationState.SetAnimation(1, "anim2", false);
                        Level5.ins.PauseTimer();
                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "nilon1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level5[0]);

                        // tiente2
                        GameManager.ins.hint10 = true;
                        Level5.ins.chageString("lev5_1");

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level5.ins.nilon2.gameObject.SetActive(true);
                        Level5.ins.bot3 = true;

                        Level5.ins.a_girl.gameObject.SetActive(false);

                        Level5.ins.a_G2.gameObject.SetActive(true);
                        Level5.ins.a_G2.AnimationState.SetAnimation(1, "anim2", false);
                        Level5.ins.PauseTimer();
                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "ballon1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level5[0]);

                        // tiente2
                        Level5.ins.chageString("lev5_2");
                        GameManager.ins.hint2 = true;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level5.ins.ballon2.gameObject.SetActive(true);
                        Level5.ins.bot8 = true;

                        Level5.ins.a_girl.gameObject.SetActive(false);

                        Level5.ins.a_G2.gameObject.SetActive(true);
                        Level5.ins.a_G2.AnimationState.SetAnimation(1, "anim2", false);
                        Level5.ins.PauseTimer();
                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "bag1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level5[0]);

                        // tiente2
                        GameManager.ins.hint5 = true;
                        Level5.ins.chageString("lev5_7");

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level5.ins.bag3.gameObject.SetActive(true);
                        Level5.ins.bot4 = true;

                        Level5.ins.a_girl.gameObject.SetActive(false);

                        Level5.ins.a_G2.gameObject.SetActive(true);
                        Level5.ins.a_G2.AnimationState.SetAnimation(1, "anim2", false);
                        Level5.ins.PauseTimer();
                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "fan")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level5[0]);

                        // tiente2
                        GameManager.ins.hint4 = true;
                        Level5.ins.chageString("lev5_6");

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level5.ins.a_fan.gameObject.SetActive(true);
                        Level5.ins.a_fan.AnimationState.SetAnimation(1, "animation", true);

                        Level5.ins.bot5 = true;

                        Level5.ins.a_girl.gameObject.SetActive(false);

                        Level5.ins.a_G2.gameObject.SetActive(true);
                        Level5.ins.a_G2.AnimationState.SetAnimation(1, "anim2", false);
                        Level5.ins.PauseTimer();
                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "durian2")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level5[0]);

                        // tiente2
                        Level5.ins.chageString("lev5_8");
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level5.ins.durian3.gameObject.SetActive(true);

                        Level5.ins.bot6 = true;

                        Level5.ins.a_girl.gameObject.SetActive(false);

                        Level5.ins.a_G2.gameObject.SetActive(true);
                        Level5.ins.a_G2.AnimationState.SetAnimation(1, "anim2", false);
                        Level5.ins.PauseTimer();
                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "snow1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level5[0]);

                        // tiente2
                        GameManager.ins.hint9 = true;
                        Level5.ins.chageString("lev5_3");

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level5.ins.snow3.gameObject.SetActive(true);

                        Level5.ins.bot7 = true;

                        Level5.ins.a_girl.gameObject.SetActive(false);

                        Level5.ins.a_G2.gameObject.SetActive(true);
                        Level5.ins.a_G2.AnimationState.SetAnimation(1, "anim2", false);
                        Level5.ins.PauseTimer();
                        return collided;
                    }
                    else if ((other.name == "bin" || other.name == "1") && name == "bottle1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level5[2]);

                        // tiente2

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level5.ins.a_bottle.gameObject.SetActive(true);
                        Level5.ins.a_bottle.AnimationState.SetAnimation(1, "animation", false);

                        return collided;
                    }
                    else if ((other.name == "durian1") && name == "knife")
                    {
                        // tiente2
                        GameManager.ins.hint6 = true;
                        AudioManager.ins.play1shot(AudioManager.ins.level5[1]);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level5.ins.durian1.gameObject.SetActive(false);
                        Level5.ins.durian2.gameObject.SetActive(true);


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
