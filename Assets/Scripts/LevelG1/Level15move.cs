using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level15move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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
        AudioManager.ins.play1shot(AudioManager.ins.level15[1]);

        if (name == "drag")
        {
           Level15.ins.b2.gameObject.SetActive(true);
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
                    if ((other.name == "b1") && name == "melon1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level15[1]);

                        GameManager.ins.hint7 = true;
                        Level15.ins.chageString("lev15_6");

                        Level15.ins.melon2.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-506f, 30f, 0f);
                        Level15.ins.melon2.gameObject.SetActive(true);
                        Level15.ins.melon2.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-506f, -133f, 0f), 0.4f).OnComplete(() =>
                        {

                        });
                        Level15.ins.gameOver();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "b1") && name == "fish1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level15[1]);

                        GameManager.ins.hint1 = true;
                        Level15.ins.chageString("lev15_1");

                        Level15.ins.fish2.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-598f, 30f, 0f);
                        Level15.ins.fish2.gameObject.SetActive(true);
                        Level15.ins.fish2.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-598f, -200f, 0f), 0.4f).OnComplete(() =>
                        {

                        });
                        Level15.ins.gameOver();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "b1") && name == "soco1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level15[1]);

                        GameManager.ins.hint8 = true;
                        Level15.ins.chageString("lev15_7");

                        Level15.ins.soco2.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-613f, 30f, 0f);
                        Level15.ins.soco2.gameObject.SetActive(true);
                        Level15.ins.soco2.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-613f, -142f, 0f), 0.4f).OnComplete(() =>
                        {

                        });
                        Level15.ins.mushroom1.gameObject.SetActive(true);
                        Level15.ins.mushroom2.gameObject.SetActive(true);
                        Level15.ins.mushroom3.gameObject.SetActive(true);
                        Level15.ins.egg1.gameObject.SetActive(true);
                        Level15.ins.gameOver();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "b1") && name == "chicken1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level15[1]);

                        Level15.ins.l15aab += 1;
                        if (Level15.ins.l15aab == 2)
                        {
                            GameManager.ins.hint3 = true;
                        }

                        Level15.ins.chicken2.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-492f, 30f, 0f);
                        Level15.ins.chicken2.gameObject.SetActive(true);
                        Level15.ins.chicken2.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-492f, -226f, 0f), 0.4f).OnComplete(() =>
                        {
                            

                        });
                        Level15.ins.gameOver();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "b1") && name == "cream1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level15[1]);

                        Level15.ins.l15aab += 1;
                        if (Level15.ins.l15aab == 2)
                        {
                            GameManager.ins.hint3 = true;
                        }
                        Level15.ins.cream2.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-385f, 30f, 0f);
                        Level15.ins.cream2.gameObject.SetActive(true);
                        Level15.ins.cream2.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-385f, -136f, 0f), 0.4f).OnComplete(() =>
                        {


                        });
                        Level15.ins.gameOver();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "b1") && name == "cucumber1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level15[1]);

                        GameManager.ins.hint6 = true;
                        Level15.ins.chageString("lev15_5");

                        Level15.ins.cucumber2.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-356f, 30f, 0f);
                        Level15.ins.cucumber2.gameObject.SetActive(true);
                        Level15.ins.cucumber2.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-356f, -221f, 0f), 0.4f).OnComplete(() =>
                        {


                        });
                        Level15.ins.gameOver();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "b1") && name == "hair")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level15[1]);

                        GameManager.ins.hint2 = true;
                        Level15.ins.chageString("lev15_2");

                        Level15.ins.noodeles.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-258f, 30f, 0f);
                        Level15.ins.noodeles.gameObject.SetActive(true);
                        Level15.ins.noodeles.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-258f, -167f, 0f), 0.4f).OnComplete(() =>
                        {


                        });
                        Level15.ins.gameOver();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "b1") && name == "cabbage1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level15[1]);

                        GameManager.ins.hint5 = true;
                        Level15.ins.chageString("lev15_4");

                        Level15.ins.cabbage2.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-761f, 30f, 0f);
                        Level15.ins.cabbage2.gameObject.SetActive(true);
                        Level15.ins.cabbage2.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-761f, -160f, 0f), 0.4f).OnComplete(() =>
                        {


                        });
                        Level15.ins.gameOver();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "b1") && name == "carot1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level15[1]);

                        GameManager.ins.hint11 = true;
                        Level15.ins.chageString("lev15_3");

                        Level15.ins.carot2.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-294f, 30f, 0f);
                        Level15.ins.carot2.gameObject.SetActive(true);
                        Level15.ins.carot2.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-294f, -113f, 0f), 0.4f).OnComplete(() =>
                        {


                        });

                        Level15.ins.gameOver();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "b1") && name == "mushroom1")
                    {
                        GameManager.ins.hint10 = true;
                        Level15.ins.chageString("lev15_8");

                        Level15.ins.mushroom4.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-439f, 30f, 0f);
                        Level15.ins.mushroom4.gameObject.SetActive(true);
                        Level15.ins.mushroom4.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-439f, -91f, 0f), 0.4f).OnComplete(() =>
                        {


                        });
                        Level15.ins.gameOver();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "b1") && name == "mushroom2")
                    {
                        Level15.ins.chageString("lev15_10");

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, -400f, 0f);
                        Level15.ins.overGG();

                        return collided;
                    }
                    else if ((other.name == "b1") && name == "mushroom3")
                    {
                        Level15.ins.chageString("lev15_10");

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, -400f, 0f);
                        Level15.ins.overGG();

                        return collided;
                    }
                    else if ((other.name == "b1") && name == "egg1")
                    {
                        GameManager.ins.hint9 = true;
                        Level15.ins.chageString("lev15_9");

                        Level15.ins.egg2.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-255f, 30f, 0f);
                        Level15.ins.egg2.gameObject.SetActive(true);
                        Level15.ins.egg2.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-255f, -173f, 0f), 0.4f).OnComplete(() =>
                        {


                        });
                        Level15.ins.gameOver();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "b2") && name == "drag")
                    {

                        Level15.ins.hair.gameObject.SetActive(true);
                        Level15.ins.girl1.gameObject.SetActive(false);
                        Level15.ins.girl2.gameObject.SetActive(true);
                        Level15.ins.acheck = true;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "pot1") && name == "water")
                    {
                        GameManager.ins.hint4 = true;

                        Level15.ins.carot1.gameObject.SetActive(true);


                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else
                    {
                        Debug.Log("rodrodrodrod");

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
