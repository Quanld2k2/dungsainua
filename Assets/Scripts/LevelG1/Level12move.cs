using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level12move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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
                    if ((other.name == "a_agirl") && name == "hand")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level12[1]);

                        GameManager.ins.hint5 = true;

                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().sprite = Level12.ins.hand2;
                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().SetNativeSize();
                        Level12.ins.done[Level12.ins.number].gameObject.SetActive(true);
                        Level12.ins.moveA();
                        Level12.ins.number += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a1") && name == "ax1")
                    {
                      //  AudioManager.ins.play1shot(AudioManager.ins.level12[1]);

                        GameManager.ins.hint9 = true;
                        Level12.ins.axc = true;
                        Level12.ins.a1.gameObject.SetActive(false);
                        Level12.ins.bough.gameObject.SetActive(true); 

                        // Level12.ins.number += 1;

                        collided = false;
                        return collided;
                    }
                    else if ((other.name == "a_agirl") && name == "snake")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level12[1]);

                        GameManager.ins.hint11 = true;

                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().sprite = Level12.ins.snake2;
                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().SetNativeSize();
                        Level12.ins.done[Level12.ins.number].gameObject.SetActive(true);
                        Level12.ins.moveA();
                        Level12.ins.number += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a_agirl") && name == "knife")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level12[1]);

                        GameManager.ins.hint4 = true;

                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().sprite = Level12.ins.knife2;
                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().SetNativeSize();
                        Level12.ins.done[Level12.ins.number].gameObject.SetActive(true);
                        Level12.ins.moveA();
                        Level12.ins.number += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a_agirl") && name == "flag")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level12[1]);

                        GameManager.ins.hint7 = true;

                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().sprite = Level12.ins.flag2;
                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().SetNativeSize();
                        Level12.ins.done[Level12.ins.number].gameObject.SetActive(true);
                        Level12.ins.moveA();
                        Level12.ins.number += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a_agirl") && name == "stick")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level12[1]);

                        GameManager.ins.hint1 = true;
                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().sprite = Level12.ins.stick2;
                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().SetNativeSize();
                        Level12.ins.done[Level12.ins.number].gameObject.SetActive(true);
                        Level12.ins.moveA();
                        Level12.ins.number += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a_agirl") && name == "rope")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level12[1]);

                        GameManager.ins.hint6 = true;

                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().sprite = Level12.ins.rope2;
                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().SetNativeSize();
                        Level12.ins.done[Level12.ins.number].gameObject.SetActive(true);
                        Level12.ins.moveA();
                        Level12.ins.number += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a_agirl") && name == "pestle")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level12[1]);

                        GameManager.ins.hint3 = true;

                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().sprite = Level12.ins.pestle2;
                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().SetNativeSize();
                        Level12.ins.done[Level12.ins.number].gameObject.SetActive(true);
                        Level12.ins.moveA();
                        Level12.ins.number += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a_agirl") && name == "guitar")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level12[1]);

                        GameManager.ins.hint2 = true;

                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().sprite = Level12.ins.guitar2;
                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().SetNativeSize();
                        Level12.ins.done[Level12.ins.number].gameObject.SetActive(true);
                        Level12.ins.moveA();
                        Level12.ins.number += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a_agirl") && name == "esi")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level12[1]);

                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().sprite = Level12.ins.esi2;
                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().SetNativeSize();
                        Level12.ins.done[Level12.ins.number].gameObject.SetActive(true);
                        Level12.ins.moveA();
                        Level12.ins.number += 1;
                        Level12.ins.iin += 1;
                        Debug.Log(Level12.ins.iin);

                        if (Level12.ins.iin == 2)
                        {
                            Debug.Log("iiniiniin");

                            GameManager.ins.hint8 = true;

                        }
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a_agirl") && name == "ola")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level12[1]);

                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().sprite = Level12.ins.ola2;
                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().SetNativeSize();
                        Level12.ins.done[Level12.ins.number].gameObject.SetActive(true);
                        Level12.ins.moveA();
                        Level12.ins.number += 1;
                        Level12.ins.iin += 1;
                        Debug.Log(Level12.ins.iin);
                        if (Level12.ins.iin == 2)
                        {
                            Debug.Log("iiniiniin");

                            GameManager.ins.hint8 = true;

                        }
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a_agirl") && name == "ax1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level12[1]);

                        GameManager.ins.hint10 = true;

                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().sprite = Level12.ins.ax2;
                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().SetNativeSize();
                        Level12.ins.done[Level12.ins.number].gameObject.SetActive(true);
                        Level12.ins.moveA();

                        if (Level12.ins.axc == true)
                        {
                            Level12.ins.number += 1;

                        }
                        else
                        {
                            GameManager.ins.Click1 += 225;

                        }

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);


                        return collided;
                    }
                    else if ((other.name == "a_agirl") && name == "bough")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level12[1]);

                        GameManager.ins.hint9 = true;

                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().sprite = Level12.ins.bough2;
                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().SetNativeSize();
                        Level12.ins.done[Level12.ins.number].gameObject.SetActive(true);
                        Level12.ins.moveA();
                        Level12.ins.number += 1;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a_agirl") && name == "bom1")
                    {
                        GameManager.ins.Click1 += 123;

                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().sprite = Level12.ins.boom2;
                        Level12.ins.done[Level12.ins.number].gameObject.GetComponent<Image>().SetNativeSize();
                        Level12.ins.done[Level12.ins.number].gameObject.SetActive(true);

                        Level12.ins.moveA();

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
