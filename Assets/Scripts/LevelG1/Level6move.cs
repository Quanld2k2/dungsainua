using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level6move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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
                    string[] validNames = { "dog1", "dog2", "dog3", "dog4", "dog5", "dog6", "dog7", "dog8", "dog9" };
                    Debug.Log(validNames.Contains(name));
                    if ((other.name == "laptop") && validNames.Contains(name))
                    {
                        // tiente1
                        AudioManager.ins.play1shot(AudioManager.ins.level6[0]);

                        Level6.ins.laptop.gameObject.SetActive(false);
                        Level6.ins.chageString("lev6_1");
                        GameManager.ins.hint10 = true;

                        Level6.ins.a_dog1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level6.ins.a_dog1.gameObject.SetActive(true);
                        Level6.ins.a_dog1.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
                        Level6.ins.a_dog1.AnimationState.SetAnimation(1, "animation", true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level6.ins.gameover += 1;
                        Level6.ins.gameOver();

                        return collided;
                    }
                    else if ((other.name == "a_phone") && validNames.Contains(name))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level6[3]);

                        // tiente2
                        Level6.ins.a_phone.gameObject.SetActive(false);
                        Level6.ins.chageString("lev6_2");

                        Level6.ins.a_dog2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level6.ins.a_dog2.gameObject.SetActive(true);
                        Level6.ins.a_dog2.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
                        Level6.ins.a_dog2.AnimationState.SetAnimation(1, "animation", true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level6.ins.gameover += 1;
                        Level6.ins.gameOver();

                        return collided;
                    }
                    else if ((other.name == "towel") && validNames.Contains(name))
                    {
                        // tiente2
                        Level6.ins.towel.gameObject.SetActive(false);
                        Level6.ins.chageString("lev6_3");
                        GameManager.ins.hint1 = true;

                        Level6.ins.a_dog5.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level6.ins.a_dog5.gameObject.SetActive(true);
                        Level6.ins.a_dog5.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
                        Level6.ins.a_dog5.AnimationState.SetAnimation(1, "animation", true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level6.ins.gameover += 1;
                        Level6.ins.gameOver();

                        return collided;
                    }
                    else if ((other.name == "money") && validNames.Contains(name))
                    {
                        // tiente2
                        Level6.ins.money.gameObject.SetActive(false);
                        Level6.ins.chageString("lev6_4");
                        GameManager.ins.hint2 = true;

                        Level6.ins.a_dog8.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level6.ins.a_dog8.gameObject.SetActive(true);
                        Level6.ins.a_dog8.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
                        Level6.ins.a_dog8.AnimationState.SetAnimation(1, "animation", true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level6.ins.gameover += 1;
                        Level6.ins.gameOver();

                        return collided;
                    }
                    else if ((other.name == "spiderwed") && validNames.Contains(name))
                    {
                        // tiente2
                        Level6.ins.spiderwed.gameObject.SetActive(false);
                        AudioManager.ins.play1shot(AudioManager.ins.level6[2]);
                        GameManager.ins.hint6 = true;

                        Level6.ins.a_dog9.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level6.ins.a_dog9.gameObject.SetActive(true);
                        Level6.ins.a_dog9.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
                        Level6.ins.a_dog9.AnimationState.SetAnimation(1, "animation", true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level6.ins.gameover += 1;
                        Level6.ins.gameOver();

                        return collided;
                    }
                    else if ((other.name == "5") && name == "book")
                    {
                        Level6.ins.chageString("lev6_9");
                        GameManager.ins.hint7 = true;

                        // tiente2
                        Level6.ins.book2.gameObject.SetActive(true);
                        Level6.ins.a2.gameObject.SetActive(true);
                        Level6.ins.a5.gameObject.SetActive(false);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);

                        return collided;
                    }
                    else if ((other.name == "2") && validNames.Contains(name))
                    {
                        // tiente2
                        Level6.ins.book2.gameObject.SetActive(false);
                        Level6.ins.a2.gameObject.SetActive(false);
                        Level6.ins.chageString("lev6_10");
                        GameManager.ins.hint8 = true;

                        Level6.ins.dog6.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level6.ins.dog6.gameObject.SetActive(true);
                        Level6.ins.dog6.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level6.ins.gameover += 1;
                        Level6.ins.gameOver();

                        return collided;
                    }
                    else if ((other.name == "1") && validNames.Contains(name))
                    {
                        // tiente2
                        Level6.ins.a1.gameObject.SetActive(false);
                        Level6.ins.chageString("lev6_5");
                        GameManager.ins.hint3 = true;

                        Level6.ins.dog7.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level6.ins.dog7.gameObject.SetActive(true);
                        Level6.ins.dog7.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level6.ins.gameover += 1;
                        Level6.ins.gameOver();

                        return collided;
                    }
                    else if ((other.name == "3") && validNames.Contains(name))
                    {
                        // tiente2
                        Level6.ins.a3.gameObject.SetActive(false);
                        Level6.ins.chageString("lev6_6");
                        GameManager.ins.hint4 = true;

                        Level6.ins.dog4.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level6.ins.dog4.gameObject.SetActive(true);
                        Level6.ins.dog4.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level6.ins.gameover += 1;
                        Level6.ins.gameOver();

                        return collided;
                    }
                    else if ((other.name == "4") && validNames.Contains(name))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level6[4]);
                        GameManager.ins.hint5 = true;

                        // tiente2
                        Level6.ins.a4.gameObject.SetActive(false);
                        Level6.ins.chageString("lev6_7");

                        Level6.ins.dog3.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level6.ins.dog3.gameObject.SetActive(true);
                        Level6.ins.dog3.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level6.ins.gameover += 1;
                        Level6.ins.gameOver();

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
