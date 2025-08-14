using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level24move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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
        initialPosition = rectTransform.anchoredPosition;
        Vector3 worldPoint;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out worldPoint))
        {
            rectTransform.position = worldPoint;
        }
        rectTransform.SetAsLastSibling(); // Đưa phần tử UI lên phía trên cùng
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
        rectTransform.SetSiblingIndex(initialSiblingIndex);
        // Kiểm tra va chạm trong quá trình kéo
        if (!CheckCollisionWithOtherUI())
        {
            // Nếu không có va chạm hợp lệ, di chuyển về vị trí ban đầu
            rectTransform.DOAnchorPos(initialPosition, 0.3f).OnComplete(() =>
            {
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
                    // Debug.Log($"{name} đang va chạm với {other.name}");
                    collided = true;
                    string[] validNames = { "q1", "q2", "q3", "q4", "q5", "q6", "q7", "q8", "q9", "q10" };
                    Debug.Log(validNames.Contains(name));
                    if ((other.name == "girl") && validNames.Contains(name))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level24[1]);

                        GameManager.ins.hint1 = true;

                        Level24.ins.chageString("lev24_1");

                        Level24.ins.girl.gameObject.SetActive(false);

                        Level24.ins.girl2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level24.ins.girl2.gameObject.SetActive(true);
                        Level24.ins.girl2.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level24.ins.gameover += 1;
                        Level24.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "dog") && validNames.Contains(name))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level24[1]);

                        GameManager.ins.hint2 = true;

                        Level24.ins.chageString("lev24_4");

                        Level24.ins.dog.gameObject.SetActive(false);

                        Level24.ins.dog2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level24.ins.dog2.gameObject.SetActive(true);
                        Level24.ins.dog2.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false); Level24.ins.gameover += 1;
                        Level24.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "gra2") && validNames.Contains(name))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level24[1]);

                        GameManager.ins.hint7 = true;

                        Level24.ins.gra2.gameObject.SetActive(false);

                        Level24.ins.gra3.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level24.ins.gra3.gameObject.SetActive(true);
                        Level24.ins.gra3.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false); Level24.ins.gameover += 1;
                        Level24.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "fa2") && validNames.Contains(name))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level24[1]);

                        GameManager.ins.hint8 = true;

                        Level24.ins.fa2.gameObject.SetActive(false);

                        Level24.ins.fa3.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level24.ins.fa3.gameObject.SetActive(true);
                        Level24.ins.fa3.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false); Level24.ins.gameover += 1;
                        Level24.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "tv1") && validNames.Contains(name))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level24[1]);

                        GameManager.ins.hint9 = true;

                        Level24.ins.chageString("lev24_7");

                        Level24.ins.tv1.gameObject.SetActive(false);

                       // Level24.ins.tv2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level24.ins.tv2.gameObject.SetActive(true);
                       //    Level24.ins.tv2.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false); Level24.ins.gameover += 1;
                        Level24.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "baba") && validNames.Contains(name))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level24[1]);

                        Level24.ins.chageString("lev24_6");

                        Level24.ins.baba.gameObject.SetActive(false);

                        Level24.ins.baba1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level24.ins.baba1.gameObject.SetActive(true);
                        Level24.ins.baba1.transform.DOScale(new Vector3(0.7f, 0.7f, 0.7f), 0.5f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false); Level24.ins.gameover += 1;
                        Level24.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "baba1") && validNames.Contains(name))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level24[1]);

                        GameManager.ins.hint6 = true;

                        Level24.ins.chageString("lev24_6");

                        Level24.ins.baba1.gameObject.SetActive(false);

                        Level24.ins.baba2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level24.ins.baba2.gameObject.SetActive(true);
                        Level24.ins.baba2.transform.DOScale(new Vector3(0.7f, 0.7f, 0.7f), 0.5f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false); Level24.ins.gameover += 1;
                        Level24.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "tree") && validNames.Contains(name))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level24[1]);

                        GameManager.ins.hint5 = true;

                        Level24.ins.chageString("lev24_2");

                        Level24.ins.tree.gameObject.SetActive(false);

                        Level24.ins.tree2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level24.ins.tree2.gameObject.SetActive(true);
                        Level24.ins.tree2.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false); Level24.ins.gameover += 1;
                        Level24.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "mom1") && validNames.Contains(name))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level24[1]);

                        GameManager.ins.hint3 = true;

                        Level24.ins.chageString("lev24_5");

                        Level24.ins.mom1.gameObject.SetActive(false);

                        Level24.ins.embe1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level24.ins.embe1.gameObject.SetActive(true);
                        Level24.ins.embe1.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false); Level24.ins.gameover += 1;
                        Level24.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "bed3") && validNames.Contains(name))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level24[1]);

                        GameManager.ins.hint4 = true;

                        Level24.ins.chageString("lev24_3");

                        Level24.ins.bed3.gameObject.SetActive(false);

                        Level24.ins.embe2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level24.ins.embe2.gameObject.SetActive(true);
                        Level24.ins.embe2.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false); Level24.ins.gameover += 1;
                        Level24.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "windown1") && validNames.Contains(name))
                    {
                        Level24.ins.chageString("lev24_8");

                        Level24.ins.gameover = 100;
                        Level24.ins.endGame();
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
