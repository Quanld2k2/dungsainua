using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level21move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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
                    if ((other.name == "hotpot") && (name == "chili" || name == "chil3"))
                    {
                        if (Level21.ins.l21a == false)
                        {
                            Level21.ins.chageString("lev21_2");
                            AudioManager.ins.play1shot(AudioManager.ins.level21[1]);

                            Level21.ins.l21a = true;
                            Level21.ins.chili2.gameObject.SetActive(true);
                            GameManager.ins.hint2 = true;

                            Level21.ins.ResetTimer();
                            Level21.ins.timeS();

                            Level21.ins.gameover += 1;
                            Level21.ins.endGame();

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
                    else if ((other.name == "blender") && (name == "chili" || name == "chil3"))
                    {

                        Level21.ins.blender.gameObject.SetActive(false);
                        Level21.ins.blender2.gameObject.SetActive(true);

                        Level21.ins.ResetTimer();
                        Level21.ins.timeS();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "blender2") && name == "glass1")
                    {
                        Level21.ins.glass2.gameObject.SetActive(true);

                        Level21.ins.ResetTimer();
                        Level21.ins.timeS();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "bbd") && name == "wine")
                    {
                        Level21.ins.chageString("lev21_8");

                        GameManager.ins.hint8 = true;

                        Level21.ins.boy1.gameObject.SetActive(true);
                        Level21.ins.a_boy.gameObject.SetActive(false);
                        Level21.ins.StartCoroutine(Level21.ins.edededed());
                        Level21.ins.l21a2 = true;
                        Level21.ins.ResetTimer();
                        Level21.ins.timeS();

                        Level21.ins.gameover += 1;
                        Level21.ins.endGame();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "bbd") && name == "glass2")
                    {
                        Level21.ins.chageString("lev21_9");

                        GameManager.ins.hint3 = true;

                        Level21.ins.boy1.gameObject.SetActive(true);
                        Level21.ins.a_boy.gameObject.SetActive(false);
                        Level21.ins.StartCoroutine(Level21.ins.edededed());
                        Level21.ins.l21a2 = true;

                        Level21.ins.ResetTimer();
                        Level21.ins.timeS();

                        Level21.ins.gameover += 1;
                        Level21.ins.endGame();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    } 
                    else if ((other.name == "hotpot") && name == "chinsu")
                    {
                        Level21.ins.chageString("lev21_3");
                        AudioManager.ins.play1shot(AudioManager.ins.level21[1]);

                        GameManager.ins.hint6 = true;

                        Level21.ins.chinsu.gameObject.SetActive(false);
                        Level21.ins.chinsu2.gameObject.SetActive(true);

                        Level21.ins.ResetTimer();
                        Level21.ins.timeS();

                        Level21.ins.gameover += 1;
                        Level21.ins.endGame();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "hotpot") && name == "otbot1")
                    {
                        Level21.ins.chageString("lev21_5");
                        AudioManager.ins.play1shot(AudioManager.ins.level21[1]);

                        GameManager.ins.hint5 = true;

                        Level21.ins.otbot1.gameObject.SetActive(false);
                        Level21.ins.otbot2.gameObject.SetActive(true);

                        Level21.ins.ResetTimer();
                        Level21.ins.timeS();

                        Level21.ins.gameover += 1;
                        Level21.ins.endGame();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "hotpot") && name == "mutat")
                    {
                        Level21.ins.chageString("lev21_4");
                        AudioManager.ins.play1shot(AudioManager.ins.level21[1]);

                        GameManager.ins.hint7 = true;

                        Level21.ins.mutat.gameObject.SetActive(false);
                        Level21.ins.mutat2.gameObject.SetActive(true);

                        Level21.ins.ResetTimer();
                        Level21.ins.timeS();

                        Level21.ins.gameover += 1;
                        Level21.ins.endGame();

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "hotpot") && name == "garlic1")
                    {
                        Level21.ins.chageString("lev21_6");
                        AudioManager.ins.play1shot(AudioManager.ins.level21[1]);

                        GameManager.ins.hint4 = true;

                        Level21.ins.garlic1.gameObject.SetActive(false);
                        Level21.ins.garlic2.gameObject.SetActive(true);

                        Level21.ins.ResetTimer();
                        Level21.ins.timeS();

                        Level21.ins.gameover += 1;
                        Level21.ins.endGame();

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
