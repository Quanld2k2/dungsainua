using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level30move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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
      //  Debug.Log(rectTransform.position);

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
              //  Debug.Log("Kéo đã kết thúc");
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
                  //  Debug.Log($"{name} đang va chạm với {other.name}");
                    collided = true;
                    string[] validNames = { "tool1", "tool2", "tool3", "tool4", "tool5", "tool6", "tool7", "tool8", "tool9", "tool10", "tool11", "tool12", "tool13_1", "tool14_1" };
                  //  Debug.Log(validNames.Contains(name));
                    if ((other.name == "diaa1") && validNames.Contains(name))
                    {
                        int a = Level30.ins.t.Length - Level30.ins.num;
                        Debug.Log(a);
                        Level30.ins.t[a].gameObject.SetActive(false);
                        if (name == "tool1")
                        {
                            GameManager.ins.hint8 = true;

                            Level30.ins.num += 1;

                            Level30.ins.s1.gameObject.SetActive(false);
                            Level30.ins.SpawnAndPlaySpineAnimOnly(Level30.ins.prefabToSpawn1, "tool");
                        }
                        else if (name == "tool2")
                        {
                            GameManager.ins.hint7 = true;

                            Level30.ins.num += 1;
                            Level30.ins.s1.gameObject.SetActive(false);
                            Level30.ins.SpawnAndPlaySpineAnimOnly(Level30.ins.prefabToSpawn2, "tool");

                        }
                        else if (name == "tool3")
                        {
                            AudioManager.ins.play2shot(AudioManager.ins.level30[1]);
                            GameManager.ins.hint9 = true;

                            Level30.ins.num += 1;

                            Level30.ins.s1.gameObject.SetActive(false);
                            Level30.ins.SpawnAndPlaySpineAnimOnly(Level30.ins.prefabToSpawn3, "tool");

                        }
                        else if (name == "tool4")
                        {
                            GameManager.ins.hint5 = true;


                            Level30.ins.num += 1;

                            Level30.ins.s1.gameObject.SetActive(false);
                            Level30.ins.SpawnAndPlaySpineAnimOnly(Level30.ins.prefabToSpawn4, "tool");

                        }
                        else if (name == "tool5")
                        {
                            GameManager.ins.hint6 = true;

                            Level30.ins.num += 1;

                            Level30.ins.s1.gameObject.SetActive(false);
                            Level30.ins.SpawnAndPlaySpineAnimOnly(Level30.ins.prefabToSpawn5, "tool");

                        }
                        else if (name == "tool6")
                        {
                            GameManager.ins.hint4 = true;

                            Level30.ins.num += 1;

                            Level30.ins.s1.gameObject.SetActive(false);
                            Level30.ins.SpawnAndPlaySpineAnimOnly(Level30.ins.prefabToSpawn6, "tool");

                        }
                        else if (name == "tool7")
                        {
                            GameManager.ins.hint3 = true;

                            Level30.ins.num += 1;

                            Level30.ins.s1.gameObject.SetActive(false);
                            Level30.ins.SpawnAndPlaySpineAnimOnly(Level30.ins.prefabToSpawn7, "tool");

                        }
                        else if (name == "tool8")
                        {
                            GameManager.ins.hint1 = true;

                            Level30.ins.num += 1;

                            Level30.ins.s1.gameObject.SetActive(false);
                            Level30.ins.SpawnAndPlaySpineAnimOnly(Level30.ins.prefabToSpawn8, "tool");

                        }
                        else if (name == "tool9")
                        {
                            GameManager.ins.hint2 = true;

                            Level30.ins.num += 1;

                            Level30.ins.s1.gameObject.SetActive(false);
                            Level30.ins.SpawnAndPlaySpineAnimOnly(Level30.ins.prefabToSpawn9, "tool");

                        }
                        else if (name == "tool10")
                        {
                            GameManager.ins.hint10 = true;

                            Level30.ins.num += 1;

                            Level30.ins.s1.gameObject.SetActive(false);
                            Level30.ins.SpawnAndPlaySpineAnimOnly(Level30.ins.prefabToSpawn10, "tool");

                        }
                        else if (name == "tool11")
                        {
                            GameManager.ins.hint13 = true;

                            Level30.ins.num += 1;

                            Level30.ins.s1.gameObject.SetActive(false);
                            Level30.ins.SpawnAndPlaySpineAnimOnly(Level30.ins.prefabToSpawn11, "tool");

                        }
                        else if (name == "tool12")
                        {
                            GameManager.ins.hint14 = true;

                            Level30.ins.num += 1;

                            Level30.ins.s1.gameObject.SetActive(false);
                            Level30.ins.SpawnAndPlaySpineAnimOnly(Level30.ins.prefabToSpawn12, "tool");

                        }


                        else if (name == "tool13_1")
                        {
                            GameManager.ins.hint11 = true;

                            Level30.ins.num += 1;

                            Level30.ins.s1.gameObject.SetActive(false);
                            Level30.ins.SpawnAndPlaySpineAnimOnly(Level30.ins.prefabToSpawn13, "tool");

                        }
                        else if (name == "tool14_1")
                        {
                            GameManager.ins.hint12   = true;

                            Level30.ins.num += 1;

                            Level30.ins.s1.gameObject.SetActive(false);
                            Level30.ins.SpawnAndPlaySpineAnimOnly(Level30.ins.prefabToSpawn14, "tool");

                        }

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "fridge1") && name == "tool14")
                    {
                        Level30.ins.tool14_1.gameObject.SetActive(true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "fridge1") && name == "tool13")
                    {
                        Level30.ins.tool13_1.gameObject.SetActive(true);


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
