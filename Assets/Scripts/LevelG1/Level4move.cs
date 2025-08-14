using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level4move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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
                    string[] validNames = { "a1", "a2", "a3", "a4", "a5", "a6", "a7", "a8" };
                    Debug.Log(validNames.Contains(name));
                    if (validNames.Contains(other.name) && name == "a_ghost")
                    {
                        AudioManager.ins.stop1shot();
                        GameManager.ins.hint1 = true;
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level4.ins.a2[Level4.ins.aanim].gameObject.SetActive(false);

                        Level4.ins.aanim += 1;
                        Level4.ins.SpawnMoveAndDestroy(Level4.ins.prefabToSpawn1);

                        ////  Level4.ins.c1.AnimationState.ClearTrack(1);
                        //  Level4.ins.c1.gameObject.SetActive(true);
                        //  Level4.ins.c1.AnimationState.SetAnimation(1, "Anim1", true);
                        //  Level4.ins.c1.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(197f, 129f, 0f);  
                        //   Level4.ins.c1.GetComponent<RectTransform>().DOAnchorPos(new Vector3(674f, 8f, 0f), 1f)
                        //               .SetEase(Ease.Linear) // Điều chỉnh hiệu ứng nếu cần
                        //               .SetDelay(0.5f) // Delay 0.5 giây trước khi di chuyển
                        //               .OnComplete(() =>
                        //              {
                        //                   Level4.ins.c1.gameObject.SetActive(false);
                        //                   Level4.ins.selec2();
                        //                   // Hành động sau khi di chuyển xong
                        //               });
                        return collided;
                    }
                    else if ((other.name == "blanket") && name == "a_ghostboy")
                    {
                        // tiente2
                        
                        Level4.ins.chageString("lev4_1");
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level4.ins.a_ghost.gameObject.SetActive(true);
                        Level4.ins.a_ghost.AnimationState.SetAnimation(1, "animation", true);
                        Level4.ins.blanket.gameObject.SetActive(false);


                        return collided;
                    }
                    else if ((other.name == "basket") && name == "flute")
                    {
                        // tiente2
                        AudioManager.ins.play1shot(AudioManager.ins.level4[3]);

                        GameManager.ins.hint8 = true;
                        Level4.ins.chageString("lev4_2");
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        //Level4.ins.snake.gameObject.SetActive(true);
                        Level4.ins.basket.gameObject.SetActive(false);

                        Level4.ins.snake.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level4.ins.snake.gameObject.SetActive(true);
                        Level4.ins.snake.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

                        return collided;
                    }
                    else if (validNames.Contains(other.name) && name == "bucket")
                    {
                        GameManager.ins.hint2 = true;
                        Level4.ins.chageString("lev4_3");
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level4.ins.a2[Level4.ins.aanim].gameObject.SetActive(false);

                        Level4.ins.aanim += 1;
                        Level4.ins.SpawnMoveAndDestroy(Level4.ins.prefabToSpawn2);
                        return collided;
                    }
                    else if (validNames.Contains(other.name) && name == "skateboard")
                    {
                        GameManager.ins.hint3 = true;
                        Level4.ins.chageString("lev4_4");
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level4.ins.a2[Level4.ins.aanim].gameObject.SetActive(false);
                        Level4.ins.aanim += 1;
                        Level4.ins.SpawnMoveAndDestroy(Level4.ins.prefabToSpawn3);
                        return collided;
                    }
                    else if (validNames.Contains(other.name) && name == "umbrella")
                    {
                        GameManager.ins.hint6 = true;
                        Level4.ins.chageString("lev4_7");
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level4.ins.a2[Level4.ins.aanim].gameObject.SetActive(false);
                        Level4.ins.aanim += 1;
                        Level4.ins.SpawnMoveAndDestroy(Level4.ins.prefabToSpawn6);
                        return collided;
                    }
                    else if (validNames.Contains(other.name) && name == "snake")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level4[2]);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level4.ins.a2[Level4.ins.aanim].gameObject.SetActive(false);
                        Level4.ins.aanim += 1;
                        Level4.ins.SpawnMoveAndDestroy(Level4.ins.prefabToSpawn8);
                        return collided;
                    }
                    else if (validNames.Contains(other.name) && name == "socks")
                    {
                        GameManager.ins.hint5 = true;
                        Level4.ins.chageString("lev4_5");
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level4.ins.a2[Level4.ins.aanim].gameObject.SetActive(false);
                        Level4.ins.aanim += 1;
                        Level4.ins.SpawnMoveAndDestroy(Level4.ins.prefabToSpawn5);
                        return collided;
                    }
                    else if (validNames.Contains(other.name) && name == "garbage")
                    {
                        Level4.ins.chageString("lev4_6");
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level4.ins.a2[Level4.ins.aanim].gameObject.SetActive(false);
                        Level4.ins.aanim += 1;
                        Level4.ins.SpawnMoveAndDestroy(Level4.ins.prefabToSpawn4);
                        return collided;
                    }
                    else if (validNames.Contains(other.name) && name == "ufo")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level4[4]);

                        GameManager.ins.hint7 = true;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level4.ins.a2[Level4.ins.aanim].gameObject.SetActive(false);
                        Level4.ins.aanim += 1;
                        Level4.ins.SpawnMoveAndDestroy(Level4.ins.prefabToSpawn7);
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
