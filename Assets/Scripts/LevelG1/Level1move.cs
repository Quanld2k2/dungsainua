using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level1move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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
                    string[] validNames = { "tien1", "tien2", "tien3", "tien4", "tien5", "tien6", "tien7", "tien8", "tien9" };
                    Debug.Log(validNames.Contains(name));
                    if ((other.name == "table1" || other.name == "1") && validNames.Contains(name))
                    {

                        // tiente1
                        Level1.ins.table1.gameObject.SetActive(false);

                        Level1.ins.table2.transform.localScale =new Vector3(0.5f,0.5f,0.5f);
                        Level1.ins.table2.gameObject.SetActive(true);
                        Level1.ins.table2.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);

                        Level1.ins.n1.gameObject.SetActive(false);
                        Level1.ins.chageString("lev1_2");
                        Level1.ins.gameover += 1;
                        AudioManager.ins.play1shot(AudioManager.ins.level1[3]);

                        Level1.ins.gameOver();
                        GameManager.ins.hint2 = true;
                        return collided;
                    }
                    else if ((other.name == "grandfather1" || other.name == "6") && validNames.Contains(name))
                    {

                        // tiente2
                        Level1.ins.grandfather1.gameObject.SetActive(false);

                        Level1.ins.grandfather2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level1.ins.grandfather2.gameObject.SetActive(true);
                        Level1.ins.grandfather2.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level1.ins.n6.gameObject.SetActive(false);

                        Level1.ins.chageString("lev1_6");
                        Level1.ins.gameover += 1;
                        AudioManager.ins.play2shot(AudioManager.ins.level1[4]);

                        Level1.ins.gameOver();
                        GameManager.ins.hint7 = true;

                        return collided;
                    }
                    else if (other.name == "wall1" && validNames.Contains(name))
                    {

                        // tiente3
                        Level1.ins.wall1.gameObject.SetActive(false);
                        Level1.ins.wall2.gameObject.SetActive(true);
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level1.ins.gameover += 1;
                        AudioManager.ins.play3shot(AudioManager.ins.level1[3]);

                        Level1.ins.gameOver();
                        GameManager.ins.hint10 = true;

                        return collided;
                    }
                    else if (other.name == "floor1" && validNames.Contains(name))
                    {

                        // tiente4
                        Level1.ins.floor1.gameObject.SetActive(false);
                        Level1.ins.floor2.gameObject.SetActive(true);
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false); Level1.ins.gameover += 1;
                        AudioManager.ins.play1shot(AudioManager.ins.level1[3]);

                        Level1.ins.gameOver();
                        GameManager.ins.hint9 = true;

                        return collided;
                    }
                    else if ((other.name == "window1" || other.name == "9") && validNames.Contains(name))
                    {

                        Level1.ins.chageString("lev1_5");
                        Level1.ins.n9.gameObject.SetActive(false);

                        // tiente1
                        Level1.ins.window1.gameObject.SetActive(false);

                        Level1.ins.window2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level1.ins.window2.gameObject.SetActive(true);
                        Level1.ins.window2.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false); Level1.ins.gameover += 1;
                        AudioManager.ins.play2shot(AudioManager.ins.level1[3]);

                        Level1.ins.gameOver();
                        GameManager.ins.hint6 = true;

                        return collided;
                    }
                    else if ((other.name == "dog1" || other.name == "11" || other.name == "2") && validNames.Contains(name))
                    {

                        // tien6
                        Level1.ins.chageString("lev1_4");
                        Level1.ins.n11.gameObject.SetActive(false);
                        Level1.ins.n2.gameObject.SetActive(false);

                        Level1.ins.dog1.gameObject.SetActive(false);

                        Level1.ins.dog2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level1.ins.dog2.gameObject.SetActive(true);
                        Level1.ins.dog2.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level1.ins.gameover += 1;
                        GameManager.ins.hint4 = true;
                        AudioManager.ins.play3shot(AudioManager.ins.level1[1]);

                        Level1.ins.gameOver();

                        return collided;
                    }
                    else if ((other.name == "candle1" || other.name == "4") && validNames.Contains(name))
                    {

                        // tien7
                        Level1.ins.candle1.gameObject.SetActive(false);

                        Level1.ins.candle2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level1.ins.candle2.gameObject.SetActive(true);
                        Level1.ins.candle2.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false); Level1.ins.gameover += 1;
                        AudioManager.ins.play1shot(AudioManager.ins.level1[3]);

                        Level1.ins.gameOver();
                        Level1.ins.n4.gameObject.SetActive(false);
                        GameManager.ins.hint5 = true;

                        return collided;
                    }
                    else if ((other.name == "broom1" || other.name == "7") && validNames.Contains(name))
                    {
                        Level1.ins.n7.gameObject.SetActive(false);

                        Level1.ins.chageString("lev1_7");
                        Level1.ins.gameover += 100;
                        Level1.ins.broom1.gameObject.SetActive(false);

                        Level1.ins.broom3.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level1.ins.broom3.gameObject.SetActive(true);
                        Level1.ins.broom3.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level1.ins.gameOver();
                        return collided;
                    }
                    else if ((other.name == "spider1" || other.name == "8") && validNames.Contains(name))
                    {
                        Level1.ins.n8.gameObject.SetActive(false);

                        Level1.ins.chageString("lev1_8");
                        Level1.ins.gameover += 100;
                        Level1.ins.spider1.gameObject.SetActive(false);

                        Level1.ins.spider2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level1.ins.spider2.gameObject.SetActive(true);
                        Level1.ins.spider2.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level1.ins.gameOver();
                        return collided;
                    }
                    else if ((other.name == "anim_girl" || other.name == "3") && validNames.Contains(name))
                    {

                        //tien8
                        Level1.ins.chageString("lev1_3");
                        Level1.ins.n3.gameObject.SetActive(false);

                        Level1.ins.anim_girl.gameObject.SetActive(false);
                        Level1.ins.girl2.gameObject.SetActive(true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false); 
                        Level1.ins.gameover += 1;
                        GameManager.ins.hint3 = true;
                        AudioManager.ins.play1shot(AudioManager.ins.level1[2]);

                        Level1.ins.gameOver();

                        return collided;
                    }
                    else if ((other.name == "anim_grama" || other.name == "5" || other.name == "carpet1") && validNames.Contains(name))
                    {

                        //tien9
                        Level1.ins.chageString("lev1_1");
                        Level1.ins.carpet1.gameObject.SetActive(false);
                        Level1.ins.carpet2.gameObject.SetActive(true);
                        Level1.ins.anim_grama.gameObject.SetActive(false);
                        Level1.ins.anim_yoga.gameObject.SetActive(true);
                        Level1.ins.anim_yoga.AnimationState.SetAnimation(1, "yoga_baba", true);
                        Level1.ins.gameover += 1;
                        AudioManager.ins.play1shot(AudioManager.ins.level1[0]);

                        Level1.ins.gameOver();

                        Level1.ins.n5.gameObject.SetActive(false);
                        GameManager.ins.hint1 = true;
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;

                    }
                    else if ((other.name == "spider1" || other.name == "8") &&  name == "broom1")
                    {
                        //tien10
                        Level1.ins.gameover += 1;
                        Level1.ins.gameOver();
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        Level1.ins.n8.gameObject.SetActive(false);
                        AudioManager.ins.play3shot(AudioManager.ins.level1[5]);

                        Level1.ins.broom1.gameObject.SetActive(false);
                        Level1.ins.spider1.gameObject.SetActive(false);
                        GameManager.ins.hint8 = true;

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
