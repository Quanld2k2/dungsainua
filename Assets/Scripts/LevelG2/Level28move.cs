using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level28move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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
        if (this.gameObject.name == "anim_fish")
        {
            Level26.ins.fish.gameObject.SetActive(true);
            Level26.ins.a_fish.gameObject.SetActive(false);
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
                if (this.gameObject.name == "fish")
                {
                    Level26.ins.fish.gameObject.SetActive(false);
                    Level26.ins.a_fish.gameObject.SetActive(true);
                }
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
                    if ((other.name == "1") && name == "ballon")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level28[0]);

                        GameManager.ins.hint4 = true;

                        Level28.ins.q1[Level28.ins.intCK].gameObject.SetActive(false);

                        Level28.ins.intCK += 1;
                        Level28.ins.SpawnAndPlaySpineAnimOnly(Level28.ins.prefabToSpawn5, "animation5");

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;

                    }
                    else if ((other.name == "1") && name == "plane")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level28[2]);

                        GameManager.ins.hint1 = true;

                        Level28.ins.q1[Level28.ins.intCK].gameObject.SetActive(false);

                        Level28.ins.intCK += 1;
                        Level28.ins.SpawnAndPlaySpineAnimOnly(Level28.ins.prefabToSpawn4, "animation4");

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "1") && name == "rocket")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level28[6]);

                        GameManager.ins.hint3 = true;

                        Level28.ins.q1[Level28.ins.intCK].gameObject.SetActive(false);

                        Level28.ins.intCK += 1;
                        Level28.ins.SpawnAndPlaySpineAnimOnly(Level28.ins.prefabToSpawn6, "animation6");

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "1") && name == "bag")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level28[4]);

                        GameManager.ins.hint2 = true;

                        Level28.ins.q1[Level28.ins.intCK].gameObject.SetActive(false);

                        Level28.ins.intCK += 1;
                        Level28.ins.SpawnAndPlaySpineAnimOnly(Level28.ins.prefabToSpawn8, "animation8");

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "1") && name == "hook")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level28[3]);

                        GameManager.ins.hint7 = true;

                        Level28.ins.q1[Level28.ins.intCK].gameObject.SetActive(false);

                        Level28.ins.intCK += 1;
                        Level28.ins.SpawnAndPlaySpineAnimOnly(Level28.ins.prefabToSpawn9, "animation9");

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "1") && name == "tat")
                    {
                        GameManager.ins.hint6 = true;

                        Level28.ins.q1[Level28.ins.intCK].gameObject.SetActive(false);
                        Level28.ins.bolck = true;
                        Level28.ins.intCK += 1;
                        Level28.ins.SpawnAndPlaySpineAnimOnly(Level28.ins.prefabToSpawn1, "animation");

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "1") && (name == "egg1" || name == "egg2"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level28[1]);

                        Level28.ins.intEGG += 1;
                        if (Level28.ins.intEGG == 2)
                        {
                            GameManager.ins.hint5 = true;
                        }
                        Level28.ins.q1[Level28.ins.intCK].gameObject.SetActive(false);

                        Level28.ins.intCK += 1;
                        Level28.ins.SpawnAndPlaySpineAnimOnly(Level28.ins.prefabToSpawn7, "animation7");

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "1") && name == "cloud3")
                    {
                        GameManager.ins.hint10 = true;

                        Level28.ins.q1[Level28.ins.intCK].gameObject.SetActive(false);

                        Level28.ins.intCK += 1;
                        Level28.ins.SpawnAndPlaySpineAnimOnly(Level28.ins.prefabToSpawn2, "animation2");

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "1") && name == "thunder")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level28[5]);

                        GameManager.ins.hint9 = true;

                        Level28.ins.q1[Level28.ins.intCK].gameObject.SetActive(false);

                        Level28.ins.intCK += 1;
                        Level28.ins.SpawnAndPlaySpineAnimOnly(Level28.ins.prefabToSpawn3, "animation3");

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "cloud1") && name == "cloud2")
                    {
                        GameManager.ins.hint8 = true;

                        Level28.ins.cloud1.gameObject.SetActive(false);

                        Level28.ins.cloud3.gameObject.SetActive(true);
                        Level28.ins.thunder.gameObject.SetActive(true);

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
