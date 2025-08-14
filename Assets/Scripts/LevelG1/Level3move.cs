using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level3move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 initialPosition;
    private int initialSiblingIndex;
    private bool isLocked = false;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(isLocked);
        /// if (isLocked) return;
        // isLocked = true;
        initialSiblingIndex = rectTransform.GetSiblingIndex();
        if (this.gameObject.GetComponent<Image>().raycastTarget == true)
        {
            this.gameObject.GetComponent<Image>().raycastTarget = false;
            //  Debug.Log(rectTransform.position);

            initialPosition = rectTransform.anchoredPosition;
            Vector3 worldPoint;
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out worldPoint))
            {
                rectTransform.position = worldPoint;
            }
           rectTransform.SetAsLastSibling(); // Đưa phần tử UI lên phía trên cùng
            AudioManager.ins.play3shot(AudioManager.ins.level11[0]);

        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        // 
        Vector3 worldPoint;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out worldPoint))
        {
            rectTransform.position = worldPoint;

        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //  if (isLocked) return;
        Debug.Log("OnPointerUp");

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
                isLocked = false;
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
                    //  string[] validNames = { "tien1", "tien2", "tien3", "tien4", "tien5", "tien6", "tien7", "tien8", "tien9" };
                    //  Debug.Log(validNames.Contains(name));
                    if ((other.name == "a_stone") && (name == "stone1"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level3[0]);
                        Level3.ins.stoneC = true;
                        Level3.ins.a_stone.AnimationState.SetAnimation(1, "anim2", false);
                        Level3.ins.chageString("lev3_4");

                        GameManager.ins.hint2 = true;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level3.ins.gameover += 1;
                        Level3.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "sign1") && (name == "sign"))
                    {

                        // Level3.ins.sign2.gameObject.SetActive(true);
                        GameManager.ins.hint1 = true;

                        Level3.ins.sign2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level3.ins.sign2.gameObject.SetActive(true);
                        Level3.ins.sign2.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);


                        Level3.ins.chageString("lev3_3");

                        Level3.ins.a_oto.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-1030f, 800f, 0f), 1f).OnComplete(() =>
                        {
                            Level3.ins.a_oto.gameObject.SetActive(false);

                        }); AudioManager.ins.play1shot(AudioManager.ins.level3[1]);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        Level3.ins.gameover += 1;
                        Level3.ins.endGame();
                        return collided;
                    }
                    else if ((other.name == "4") && (name == "watertap1"))
                    {
                        Level3.ins.a_watertap.gameObject.SetActive(true);
                        Level3.ins.n2.gameObject.SetActive(true);
                        Level3.ins.n4.gameObject.SetActive(false);


                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "bowl1") && (name == "dogfood"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level3[3]);

                        Level3.ins.chageString("lev3_5");
                        GameManager.ins.hint3 = true;

                        Level3.ins.bowl1.gameObject.SetActive(false);
                        Level3.ins.bowl2.gameObject.SetActive(true);
                        Level3.ins.a_dog.gameObject.SetActive(false);
                        Level3.ins.a_dogun.gameObject.SetActive(true);
                        Level3.ins.a_dogun.AnimationState.SetAnimation(1, "animation", true);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "2") && (name == "bucket1"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level3[5]);

                        Level3.ins.bucket3.gameObject.SetActive(true);
                        Level3.ins.a_watertap.AnimationState.SetAnimation(1, "animation", true);
                        GameManager.ins.hint4 = true;

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "hole1") && (name == "cement"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level3[4]);

                        //Level3.ins.hole2.gameObject.SetActive(true);
                        Level3.ins.hole1.gameObject.SetActive(false);
                        GameManager.ins.hint5 = true;

                        Level3.ins.hole2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level3.ins.hole2.gameObject.SetActive(true);
                        Level3.ins.hole2.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "hole2") && (name == "bucket2"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level3[2]);

                        GameManager.ins.hint6 = true;

                        //Level3.ins.hole3.gameObject.SetActive(true);

                        Level3.ins.hole3.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Level3.ins.hole3.gameObject.SetActive(true);
                        Level3.ins.hole3.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

                        Level3.ins.hole2.gameObject.SetActive(false);
                        Level3.ins.chageString("lev3_6");


                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "hole3") && (name == "beater"))
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level3[2]);

                        GameManager.ins.hint7 = true;

                        Level3.ins.beater.gameObject.SetActive(true);

                        Level3.ins.a_hole.gameObject.SetActive(true);
                        Level3.ins.a_hole.AnimationState.SetAnimation(1, "animation", false);
                        Level3.ins.stone1.gameObject.SetActive(false);
                        Level3.ins.stone2.gameObject.SetActive(false);

                        if (Level3.ins.stoneC == true)
                        {
                            Level3.ins.gameover += 1;
                            Level3.ins.endGame();
                        }
                        else
                        {
                            Level3.ins.gameover = 100;
                            Level3.ins.endGame();
                        }
                       

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
        //  Debug.Log($"{rectTransform.name} overlap with {otherRectTransform.name}: {isOverlapping}");
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
