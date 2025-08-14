using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level25move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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
                    if ((other.name == "a_girl") && name == "a_curtain")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level25[2]);

                        Level25.ins.chageString("lev25_1");

                        GameManager.ins.hint1 = true;

                        Level25.ins.zilen[Level25.ins.iab].gameObject.SetActive(true);
                        Level25.ins.zilen[Level25.ins.iab].sprite = Level25.ins.q1_curtain;
                        Level25.ins.zilen[Level25.ins.iab].gameObject.GetComponent<Image>().SetNativeSize();

                        Level25.ins.iab += 1;
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level25.ins.gameover += 1;
                        Level25.ins.endGame();
                        return collided;


                    }
                    else if ((other.name == "a_girl") && name == "quanao")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level25[2]);

                        Level25.ins.chageString("lev25_3");

                        GameManager.ins.hint6 = true;

                        Level25.ins.zilen[Level25.ins.iab].gameObject.SetActive(true);
                        Level25.ins.zilen[Level25.ins.iab].sprite = Level25.ins.q2_quanao; Level25.ins.zilen[Level25.ins.iab].gameObject.GetComponent<Image>().SetNativeSize();

                        Level25.ins.iab += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level25.ins.gameover += 1;
                        Level25.ins.endGame();

                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "book")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level25[2]);

                        GameManager.ins.hint2 = true;
                        Level25.ins.chageString("lev25_4");

                        Level25.ins.zilen[Level25.ins.iab].gameObject.SetActive(true);
                        Level25.ins.zilen[Level25.ins.iab].sprite = Level25.ins.q4_sach; Level25.ins.zilen[Level25.ins.iab].gameObject.GetComponent<Image>().SetNativeSize();

                        Level25.ins.iab += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level25.ins.gameover += 1;
                        Level25.ins.endGame();

                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "tree")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level25[2]);

                        GameManager.ins.hint3 = true;
                        Level25.ins.chageString("lev25_13");

                        Level25.ins.zilen[Level25.ins.iab].gameObject.SetActive(true);
                        Level25.ins.zilen[Level25.ins.iab].sprite = Level25.ins.q3_tree; Level25.ins.zilen[Level25.ins.iab].gameObject.GetComponent<Image>().SetNativeSize();

                        Level25.ins.iab += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level25.ins.gameover += 1;
                        Level25.ins.endGame();

                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "blanket")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level25[2]);

                        Level25.ins.chageString("lev25_8");

                        GameManager.ins.hint5 = true;

                        Level25.ins.zilen[Level25.ins.iab].gameObject.SetActive(true);
                        Level25.ins.zilen[Level25.ins.iab].sprite = Level25.ins.q6_blanket2; Level25.ins.zilen[Level25.ins.iab].gameObject.GetComponent<Image>().SetNativeSize();

                        Level25.ins.iab += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level25.ins.gameover += 1;
                        Level25.ins.endGame();

                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "pic")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level25[2]);

                        Level25.ins.chageString("lev25_9");

                        GameManager.ins.hint4 = true;

                        Level25.ins.zilen[Level25.ins.iab].gameObject.SetActive(true);
                        Level25.ins.zilen[Level25.ins.iab].sprite = Level25.ins.q5_pic; Level25.ins.zilen[Level25.ins.iab].gameObject.GetComponent<Image>().SetNativeSize();

                        Level25.ins.iab += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level25.ins.gameover += 1;
                        Level25.ins.endGame();

                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "box1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level25[2]);

                        Level25.ins.chageString("lev25_10");

                        GameManager.ins.hint7 = true;

                        Level25.ins.zilen[Level25.ins.iab].gameObject.SetActive(true);
                        Level25.ins.zilen[Level25.ins.iab].sprite = Level25.ins.q7_box; Level25.ins.zilen[Level25.ins.iab].gameObject.GetComponent<Image>().SetNativeSize();

                        Level25.ins.iab += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level25.ins.gameover += 1;
                        Level25.ins.endGame();

                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "blanket2")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level25[2]);

                        GameManager.ins.hint14 = true;

                        Level25.ins.zilen[Level25.ins.iab].gameObject.SetActive(true);
                        Level25.ins.zilen[Level25.ins.iab].sprite = Level25.ins.q8_blanket22; Level25.ins.zilen[Level25.ins.iab].gameObject.GetComponent<Image>().SetNativeSize();

                        Level25.ins.iab += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level25.ins.gameover += 1;
                        Level25.ins.endGame();

                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "carpet")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level25[2]);

                        Level25.ins.chageString("lev25_11");

                        GameManager.ins.hint15 = true;

                        Level25.ins.zilen[Level25.ins.iab].gameObject.SetActive(true);
                        Level25.ins.zilen[Level25.ins.iab].sprite = Level25.ins.q9_carpet; Level25.ins.zilen[Level25.ins.iab].gameObject.GetComponent<Image>().SetNativeSize();

                        Level25.ins.iab += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level25.ins.gameover += 1;
                        Level25.ins.endGame();

                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "bread1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level25[2]);

                        Level25.ins.iab2 += 1;
                        if (Level25.ins.iab2 == 1)
                        {
                            Level25.ins.zilen[Level25.ins.iab].gameObject.SetActive(true);
                            Level25.ins.zilen[Level25.ins.iab].sprite = Level25.ins.q10_bread1; Level25.ins.zilen[Level25.ins.iab].gameObject.GetComponent<Image>().SetNativeSize();
                            Level25.ins.chageString("lev25_7");

                            Level25.ins.iab += 1;
                        }
                        else if(Level25.ins.iab2 == 2)
                        {
                            GameManager.ins.hint10 = true;

                            Level25.ins.zilen[Level25.ins.iab].gameObject.SetActive(true);
                            Level25.ins.zilen[Level25.ins.iab].sprite = Level25.ins.q11_bread2; Level25.ins.zilen[Level25.ins.iab].gameObject.GetComponent<Image>().SetNativeSize();

                            Level25.ins.iab += 1;
                        }

                    

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level25.ins.gameover += 1;
                        Level25.ins.endGame();

                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "bread2")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level25[2]);

                        Level25.ins.iab2 += 1;
                        if (Level25.ins.iab2 == 1)
                        {
                            Level25.ins.chageString("lev25_7");

                            Level25.ins.zilen[Level25.ins.iab].gameObject.SetActive(true);
                            Level25.ins.zilen[Level25.ins.iab].sprite = Level25.ins.q10_bread1; Level25.ins.zilen[Level25.ins.iab].gameObject.GetComponent<Image>().SetNativeSize();

                            Level25.ins.iab += 1;
                        }
                        else if (Level25.ins.iab2 == 2)
                        {
                            GameManager.ins.hint10 = true;

                            Level25.ins.zilen[Level25.ins.iab].gameObject.SetActive(true);
                            Level25.ins.zilen[Level25.ins.iab].sprite = Level25.ins.q11_bread2; Level25.ins.zilen[Level25.ins.iab].gameObject.GetComponent<Image>().SetNativeSize();

                            Level25.ins.iab += 1;
                        }

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level25.ins.gameover += 1;
                        Level25.ins.endGame();

                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "wool2")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level25[2]);

                        Level25.ins.chageString("lev25_5");

                        GameManager.ins.hint8 = true;

                        Level25.ins.zilen[Level25.ins.iab].gameObject.SetActive(true);
                        Level25.ins.zilen[Level25.ins.iab].sprite = Level25.ins.q12_wool; Level25.ins.zilen[Level25.ins.iab].gameObject.GetComponent<Image>().SetNativeSize();

                        Level25.ins.iab += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level25.ins.gameover += 1;
                        Level25.ins.endGame();

                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "towel1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level25[2]);

                        Level25.ins.chageString("lev25_12");

                        GameManager.ins.hint13   = true;

                        Level25.ins.zilen[Level25.ins.iab].gameObject.SetActive(true);
                        Level25.ins.zilen[Level25.ins.iab].sprite = Level25.ins.q13_towel; Level25.ins.zilen[Level25.ins.iab].gameObject.GetComponent<Image>().SetNativeSize();

                        Level25.ins.iab += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level25.ins.gameover += 1;
                        Level25.ins.endGame();

                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "cat2")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level25[2]);

                        Level25.ins.chageString("lev25_2");

                        GameManager.ins.hint12 = true;

                        Level25.ins.zilen[Level25.ins.iab].gameObject.SetActive(true);
                        Level25.ins.zilen[Level25.ins.iab].sprite = Level25.ins.q14_cat; Level25.ins.zilen[Level25.ins.iab].gameObject.GetComponent<Image>().SetNativeSize();

                        Level25.ins.iab += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level25.ins.gameover += 1;
                        Level25.ins.endGame();

                        return collided;
                    }
                    else if ((other.name == "bread") && name == "knife")
                    {
                        Level25.ins.chageString("lev25_6");

                        GameManager.ins.hint9 = true;

                        Level25.ins.bread.gameObject.SetActive(false);
                        Level25.ins.bread1.gameObject.SetActive(true);
                        Level25.ins.bread2.gameObject.SetActive(true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "wool") && name == "wool1")
                    {
                        Level25.ins.wool.gameObject.SetActive(false);
                        Level25.ins.wool2.gameObject.SetActive(true);
                       // Level25.ins.bread2.gameObject.SetActive(true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "cat") && name == "cut")
                    {
                        AudioManager.ins.play2shot(AudioManager.ins.level25[0]);

                        GameManager.ins.hint11 = true;

                        Level25.ins.cat.gameObject.SetActive(false);
                       // Level25.ins.bed2.gameObject.SetActive(false);

                        Level25.ins.a_cat2.gameObject.SetActive(true);
                        Level25.ins.a_cat2.AnimationState.SetAnimation(1, "animation", true);


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
