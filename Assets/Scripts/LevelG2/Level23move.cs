using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level23move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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
                    if ((other.name == "a_door") && name == "sofa")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level23[3]);

                        GameManager.ins.hint5 = true;
                        Level23.ins.chageString("lev23_1");

                        Level23.ins.sofa2.gameObject.SetActive(true);

                            Level23.ins.gameover += 1;
                            Level23.ins.endGame();

                            this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                            this.gameObject.SetActive(false);
                            return collided;
                   

                    }
                    else if ((other.name == "table") && name == "hammer" )
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level23[1]);

                        Level23.ins.chageString("lev23_2");

                        GameManager.ins.hint1 = true;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);

                        Level23.ins.a_hammer.gameObject.SetActive(true);
                        Level23.ins.a_hammer.AnimationState.SetAnimation(1, "animation", false);

                    
                        return collided;
                    }
                    else if ((other.name == "z2") && name == "hammer")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level23[3]);

                        GameManager.ins.hint3 = true;

                        Level23.ins.z2.gameObject.SetActive(false);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);

                        Level23.ins.a_zombie2.gameObject.SetActive(true);
                        Level23.ins.a_zombie2.AnimationState.SetAnimation(1, "animation2", false);

                        Level23.ins.gameover += 1;
                        Level23.ins.endGame();
                        
                        return collided;
                    }
                    else if ((other.name == "z1") && name == "table2")
                    {
                        Level23.ins.chageString("lev23_3");

                        GameManager.ins.hint2 = true;

                        Level23.ins.z1.gameObject.SetActive(false);

                        Level23.ins.windown.gameObject.SetActive(true);
                        Level23.ins.gameover += 1;
                        Level23.ins.endGame();
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a_box1") && name == "bangdinh")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level23[0]);

                        Level23.ins.chageString("lev23_4");

                        GameManager.ins.hint4 = true;

                        Level23.ins.a_box1.gameObject.SetActive(false);

                        Level23.ins.a_box2.gameObject.SetActive(true);
                        Level23.ins.a_box2.AnimationState.SetAnimation(1, "animation", false);
                        Level23.ins.gameover += 1;
                        Level23.ins.endGame();
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "shape3") && name == "maykhoan")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level23[2]);

                        Level23.ins.chageString("lev23_5");

                        GameManager.ins.hint6 = true;

                        Level23.ins.shape3.gameObject.SetActive(false);

                        Level23.ins.floor.gameObject.SetActive(true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "floor") && name == "rope")
                    {
                        Debug.Log(Level23.ins.gameover);
                        if (Level23.ins.gameover == 4)
                        {
                            Level23.ins.chageString("lev23_6");

                            GameManager.ins.hint7 = true;

                            Level23.ins.floor.gameObject.SetActive(false);
                            Level23.ins.a_girl.gameObject.SetActive(false);

                            Level23.ins.a_end.gameObject.SetActive(true);
                            Level23.ins.a_end.AnimationState.SetAnimation(1, "animation", false);
                          //  Level23.ins.gameover += 1;
                            //Level23.ins.endGame();
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
