using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level7move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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
                    string[] validNames = { "ticket1", "ticket2", "ticket3", "ticket4", "ticket5", "ticket6", "ticket7", "ticket8", "ticket9", "ticket10", "ticket11", "ticket12" };
                    //  Debug.Log(validNames.Contains(name));
                    if ((other.name == "1" ) && validNames.Contains(name))
                    {
                        Level7.ins.bed1.gameObject.SetActive(false);
                        //Level7.ins.bed2.gameObject.SetActive(true);
                        GameManager.ins.hint6 = true;
                        Level7.ins.overLoa = true;
                        Level7.ins.bed2.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                        Level7.ins.bed2.gameObject.SetActive(true);
                        Level7.ins.bed2.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack).OnComplete(() =>
                        {
                            Level7.ins.ticket11.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                            Level7.ins.ticket11.gameObject.SetActive(true);
                            Level7.ins.ticket11.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack).OnComplete(() =>
                            {
                                Level7.ins.ticket11.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-90f, -375f, 0f), 0.7f);
                                Level7.ins.chageString("lev7_1");

                            });

                            Level7.ins.ticket12.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                            Level7.ins.ticket12.gameObject.SetActive(true);
                            Level7.ins.ticket12.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack).OnComplete(() =>
                            {
                                Level7.ins.ticket12.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-90f, -375f, 0f), 0.7f).SetDelay(0.1f);

                            });
                        });

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level7.ins.gameover += 1;
                        Level7.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "light1") && validNames.Contains(name))
                    {
                        Level7.ins.chageString("lev7_5");

                        Level7.ins.light1.gameObject.SetActive(false);
                        GameManager.ins.hint2 = true;

                        Level7.ins.light2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level7.ins.light2.gameObject.SetActive(true);
                        Level7.ins.light2.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level7.ins.gameover += 1;
                        Level7.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "5") && validNames.Contains(name))
                    {
                        Level7.ins.chageString("lev7_7");

                        Level7.ins.desk.gameObject.SetActive(false);
                        GameManager.ins.hint4 = true;

                        Level7.ins.desk2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level7.ins.desk2.gameObject.SetActive(true);
                        Level7.ins.desk2.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level7.ins.gameover += 1;
                        Level7.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "2") && validNames.Contains(name))
                    {
                        Level7.ins.chageString("lev7_4");

                        Level7.ins.carpet1.gameObject.SetActive(false);
                        GameManager.ins.hint10 = true;

                        Level7.ins.carpet2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level7.ins.carpet2.gameObject.SetActive(true);
                        Level7.ins.carpet2.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level7.ins.gameover += 1;
                        Level7.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "pic1") && validNames.Contains(name))
                    {
                        Level7.ins.pic1.gameObject.SetActive(false);
                        GameManager.ins.hint8 = true;

                        Level7.ins.pic2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level7.ins.pic2.gameObject.SetActive(true);
                        Level7.ins.pic2.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level7.ins.gameover += 1;

                        Level7.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "chair") && validNames.Contains(name))
                    {
                        Level7.ins.chair.gameObject.SetActive(false);
                        GameManager.ins.hint5 = true;

                        Level7.ins.chair2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level7.ins.chair2.gameObject.SetActive(true);
                        Level7.ins.chair2.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level7.ins.gameover += 1;
                        Level7.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "gun1") && validNames.Contains(name))
                    {
                        Level7.ins.chageString("lev7_6");

                        Level7.ins.gun1.gameObject.SetActive(false);
                        GameManager.ins.hint12 = true;

                        Level7.ins.gun2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level7.ins.gun2.gameObject.SetActive(true);
                        Level7.ins.gun2.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level7.ins.gameover += 1;
                        Level7.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "3") && validNames.Contains(name))
                    {
                        Level7.ins.chageString("lev7_6");

                        Level7.ins.phone1.gameObject.SetActive(false);
                        GameManager.ins.hint11 = true;

                        Level7.ins.phone2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level7.ins.phone2.gameObject.SetActive(true);
                        Level7.ins.phone2.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level7.ins.gameover += 1;
                        Level7.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "a_girl1") && validNames.Contains(name))
                    {
                        Level7.ins.chageString("lev7_4");

                        Level7.ins.a_girl1.gameObject.SetActive(false);
                        GameManager.ins.hint9 = true;

                        Level7.ins.girl2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level7.ins.girl2.gameObject.SetActive(true);
                        Level7.ins.girl2.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level7.ins.gameover += 1;
                        Level7.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "6") && validNames.Contains(name))
                    {
                        Level7.ins.chageString("lev7_7");

                        Level7.ins.a_dog1.gameObject.SetActive(false);
                        GameManager.ins.hint3 = true;

                        Level7.ins.dog.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level7.ins.dog.gameObject.SetActive(true);
                        Level7.ins.dog.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level7.ins.gameover += 1;
                        Level7.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "bg1") && validNames.Contains(name))
                    {
                        Level7.ins.bg1.gameObject.SetActive(false);
                        Level7.ins.bg2.gameObject.SetActive(true);
                        GameManager.ins.hint1 = true;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level7.ins.gameover += 1;
                        Level7.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "4") && validNames.Contains(name))
                    {
                        Level7.ins.chageString("lev7_6");

                        Level7.ins.money1.gameObject.SetActive(false);
                        Level7.ins.money2.gameObject.SetActive(true);
                        GameManager.ins.hint13 = true;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level7.ins.gameover += 1;
                        Level7.ins.endGame();
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
