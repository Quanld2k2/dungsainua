using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level19move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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
        AudioManager.ins.play1shot(AudioManager.ins.level15[1]);

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
                    if ((other.name == "q1") && name == "poster")
                    {
                        GameManager.ins.hint1 = true;

                        Level19.ins.poster1.gameObject.SetActive(true);
                        Level19.ins.q1.gameObject.SetActive(false);
                        Level19.ins.gameover += 1;
                        Level19.ins.endGame();
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "spiderweb1" || other.name == "spiderweb2") && name == "choi")
                    {
                        Level19.ins.nubm += 1;
                        if (Level19.ins.nubm <= 2)
                        {
                            if (other.name == "spiderweb1")
                            {
                                Level19.ins.a_choi2.gameObject.SetActive(true);
                                Level19.ins.a_choi2.AnimationState.SetAnimation(1, "animation", false);
                                //  Level19.ins.spiderweb1.gameObject.SetActive(false);
                                Level19.ins.gameover += 1;
                                Level19.ins.endGame();
                            }
                            else if (other.name == "spiderweb2")
                            {
                                Level19.ins.a_choi1.gameObject.SetActive(true);
                                Level19.ins.a_choi1.AnimationState.SetAnimation(1, "animation", false);
                                Level19.ins.gameover += 1;
                                Level19.ins.endGame();
                                // Level19.ins.spiderweb2.gameObject.SetActive(false);
                            }
                            if (Level19.ins.nubm == 2)
                            {
                                GameManager.ins.hint7 = true;
                            }
                        }
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false); 
                        return collided;
                    }
                    else if ((other.name == "bin1") && (name == "paper1" || name == "paper2" || name == "paper3"))
                    {
                        if (name == "paper1")
                        {
                            Level19.ins.nubm2 += 1;
                            Level19.ins.paper1.gameObject.SetActive(false);
                        }
                        else if (name == "paper2")
                        {
                            Level19.ins.nubm2 += 1;
                            Level19.ins.paper2.gameObject.SetActive(false);
                        }
                        else if (name == "paper3")
                        {
                            Level19.ins.nubm2 += 1;
                            Level19.ins.paper3.gameObject.SetActive(false);
                        }
                        if (Level19.ins.nubm2 == 3)
                        {
                            GameManager.ins.hint3 = true;

                            Level19.ins.bin1.gameObject.SetActive(false);
                            Level19.ins.bin2.gameObject.SetActive(true);
                            Level19.ins.gameover += 1;
                            Level19.ins.endGame();
                        }


                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false); 
                        return collided;
                    }
                    else if ((other.name == "ban" || other.name == "q5") && name == "choi2")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level19[2]);

                        GameManager.ins.hint8 = true;

                        Level19.ins.a_launha.gameObject.SetActive(true);
                        Level19.ins.a_launha.AnimationState.SetAnimation(1, "animation", false);

                        Level19.ins.gameover += 1;
                        Level19.ins.endGame();
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "maygiat1") && name == "quanao")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level19[3]);

                        Level19.ins.chem1 = true;
                        GameManager.ins.hint6 = true;


                        Level19.ins.maygiat1.gameObject.SetActive(false);
                        Level19.ins.a_maygiat.gameObject.SetActive(true);
                        Level19.ins.a_maygiat.AnimationState.SetAnimation(1, "animation", false);

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "maygiat1") && name == "chan2")
                    {
                        if (Level19.ins.chem4 == true)
                        {
                            AudioManager.ins.play1shot(AudioManager.ins.level19[3]);

                            GameManager.ins.hint9 = true;

                            Level19.ins.chem2 = true;

                            Level19.ins.maygiat1.gameObject.SetActive(false);

                            Level19.ins.a_maygiat.gameObject.SetActive(true);
                            Level19.ins.a_maygiat.AnimationState.SetAnimation(1, "animation", false);

                            Level19.ins.gameover += 1;
                            Level19.ins.endGame();

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
                    else if ((other.name == "maygiat1") && name == "goi3")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level19[3]);

                        Level19.ins.chem3 = true;
                        GameManager.ins.hint4 = true;

                        Level19.ins.maygiat1.gameObject.SetActive(false);
                        Level19.ins.gameover += 1;
                        Level19.ins.endGame();
                        Level19.ins.a_maygiat.gameObject.SetActive(true);
                        Level19.ins.a_maygiat.AnimationState.SetAnimation(1, "animation", false);


                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "tu3") && name == "quanao1")
                    {
                        GameManager.ins.hint10 = true;

                        Level19.ins.tu3.gameObject.SetActive(false);
                        Level19.ins.tu4.gameObject.SetActive(true);
                        Level19.ins.gameover += 1;
                        Level19.ins.endGame();
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "q4") && name == "balo")
                    {
                        GameManager.ins.hint11 = true;

                        Level19.ins.balo2.gameObject.SetActive(true);
                        Level19.ins.gameover += 1;
                        Level19.ins.endGame();
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "q4") && name == "book")
                    {
                        GameManager.ins.hint12 = true;

                        Level19.ins.book2.gameObject.SetActive(true);
                        Level19.ins.gameover += 1;
                        Level19.ins.endGame();
                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "q5") && name == "thuocxit")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level19[0]);

                        Level19.ins.chem4 = true;
                        GameManager.ins.hint5 = true;
                        Level19.ins.gian1.gameObject.SetActive(false);
                        Level19.ins.gian2.gameObject.SetActive(false);
                        Level19.ins.gian3.gameObject.SetActive(false);
                        Level19.ins.gian4.gameObject.SetActive(false);
                        Level19.ins.q5.gameObject.SetActive(false);

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
