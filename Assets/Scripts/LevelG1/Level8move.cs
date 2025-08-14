using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level8move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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

        //5+5+3+3+35
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
                  //  string[] validNames = { "ticket1", "ticket2", "ticket3", "ticket4", "ticket5", "ticket6", "ticket7", "ticket8", "ticket9", "ticket10" };
                    if ((other.name == "a_girl1") && name == "fish")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level8[2]);
                        Level8.ins.aa1 = 0;
                        Level8.ins.a_girl1.gameObject.SetActive(false);
                        Level8.ins.a_girl2.gameObject.SetActive(true);  
                        Level8.ins.a_girl2.AnimationState.SetAnimation(1, "anim2", false);
                        GameManager.ins.hint9 = true;
                        Level8.ins.fish2.gameObject.SetActive(true);
                        Level8.ins.fish2.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-300f, -292f, 0f), 1f);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level8.ins.PauseTimer();

                        return collided;
                    }
                    else if ((other.name == "a_girl1") && name == "bottle")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level8[2]);

                        Level8.ins.chageString("lev8_6");

                        Level8.ins.aa1 = 0;
                        Level8.ins.a_girl1.gameObject.SetActive(false);
                        Level8.ins.a_girl2.gameObject.SetActive(true);
                        Level8.ins.a_girl2.AnimationState.SetAnimation(1, "anim2", false);
                        GameManager.ins.hint6 = true;

                        Level8.ins.bottle2.gameObject.SetActive(true);
                        Level8.ins.bottle2.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(272f, -194f, 0f), 1f);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level8.ins.PauseTimer();

                        return collided;
                    }
                    else if ((other.name == "a_girl1") && name == "ballon")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level8[2]);

                        Level8.ins.chageString("lev8_8");

                        Level8.ins.aa1 = 0;
                        Level8.ins.a_girl1.gameObject.SetActive(false);
                        Level8.ins.a_girl2.gameObject.SetActive(true);
                        Level8.ins.a_girl2.AnimationState.SetAnimation(1, "anim2", false);
                        GameManager.ins.hint8 = true;

                        Level8.ins.ballon2.gameObject.SetActive(true);
                        Level8.ins.ballon2.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(295f, -383f, 0f), 1f);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level8.ins.PauseTimer();

                        return collided;
                    }
                    else if ((other.name == "a_girl1") && name == "tree")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level8[2]);

                        Level8.ins.chageString("lev8_3");

                        Level8.ins.aa1 = 0;
                        Level8.ins.a_girl1.gameObject.SetActive(false);
                        Level8.ins.a_girl2.gameObject.SetActive(true);
                        Level8.ins.a_girl2.AnimationState.SetAnimation(1, "anim2", false);
                        GameManager.ins.hint3 = true;

                        Level8.ins.tree2.gameObject.SetActive(true);
                        Level8.ins.tree2.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(506f, -127f, 0f), 1f);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level8.ins.PauseTimer();

                        return collided;
                    }
                    else if ((other.name == "a_girl1") && name == "bag")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level8[2]);

                        Level8.ins.chageString("lev8_7");

                        Level8.ins.aa1 = 0;
                        Level8.ins.a_girl1.gameObject.SetActive(false);
                        Level8.ins.a_girl2.gameObject.SetActive(true);
                        Level8.ins.a_girl2.AnimationState.SetAnimation(1, "anim2", false);
                        GameManager.ins.hint7 = true;

                        Level8.ins.bag2.gameObject.SetActive(true);
                        Level8.ins.bag2.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-342f, -427f, 0f), 1f);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level8.ins.PauseTimer();

                        return collided;
                    }
                    else if ((other.name == "a_girl1") && name == "duck")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level8[2]);

                        Level8.ins.chageString("lev8_2");

                        Level8.ins.aa1 = 0;
                        Level8.ins.a_girl1.gameObject.SetActive(false);
                        Level8.ins.a_girl2.gameObject.SetActive(true);
                        Level8.ins.a_girl2.AnimationState.SetAnimation(1, "anim2", false);
                        GameManager.ins.hint2 = true;

                        Level8.ins.duck2.gameObject.SetActive(true);
                        Level8.ins.duck2.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-424f, -11f, 0f), 1f);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level8.ins.PauseTimer();

                        return collided;
                    }
                    else if ((other.name == "a_girl1") && name == "lifebuoy")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level8[2]);

                        Level8.ins.chageString("lev8_5");

                        Level8.ins.aa1 = 0;
                        Level8.ins.a_girl1.gameObject.SetActive(false);
                        Level8.ins.a_girl2.gameObject.SetActive(true);
                        Level8.ins.a_girl2.AnimationState.SetAnimation(1, "anim2", false);
                        GameManager.ins.hint5 = true;

                        Level8.ins.lifebuoy2.gameObject.SetActive(true);
                        Level8.ins.lifebuoy2.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(214f, -43f, 0f), 1f);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level8.ins.PauseTimer();

                        return collided;
                    }
                    else if ((other.name == "a_girl1") && name == "shoe")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level8[2]);

                        Level8.ins.chageString("lev8_4");

                        Level8.ins.aa1 = 0;
                        Level8.ins.a_girl1.gameObject.SetActive(false);
                        Level8.ins.a_girl2.gameObject.SetActive(true);
                        Level8.ins.a_girl2.AnimationState.SetAnimation(1, "anim2", false);
                        GameManager.ins.hint4 = true;

                        Level8.ins.shoe2.gameObject.SetActive(true);
                        Level8.ins.shoe2.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-337f, -120f, 0f), 1f);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level8.ins.PauseTimer();

                        return collided;
                    }
                    else if ((other.name == "a_girl1") && name == "coconut")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level8[2]);

                        Level8.ins.chageString("lev8_1");

                        Level8.ins.aa1 = 0;
                        Level8.ins.a_girl1.gameObject.SetActive(false);
                        Level8.ins.a_girl2.gameObject.SetActive(true);
                        Level8.ins.a_girl2.AnimationState.SetAnimation(1, "anim2", false);
                        GameManager.ins.hint1 = true;

                        // Level8.ins.fish2.gameObject.SetActive(true);
                        // Level8.ins.fish2.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-300f, -292f, 0f), 0.4f);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level8.ins.PauseTimer();

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
