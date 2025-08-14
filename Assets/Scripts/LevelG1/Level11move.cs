using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class Level11move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private RectTransform rectTransform;
    private Transform originalParent;
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
        originalParent = rectTransform.parent;
        initialSiblingIndex = rectTransform.GetSiblingIndex();
        initialPosition = rectTransform.anchoredPosition;


        Vector3 worldPoint;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out worldPoint))
        {
            rectTransform.position = worldPoint;
        }

        // Đưa lên trên cùng để không bị che UI
        rectTransform.SetParent(Level11.ins.a_girl.transform.parent); // cùng cấp với a_girl
        rectTransform.SetAsLastSibling(); // đưa lên trên cùng UI
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
        // Trả về đúng vị trí và cấp cha ban đầu
        rectTransform.SetParent(originalParent);
        rectTransform.SetSiblingIndex(initialSiblingIndex);
        // rectTransform.anchoredPosition = initialPosition;


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
                    if ((other.name == "a_girl") && name == "wire1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level11[0]);

                        Level11.ins.chageString("lev11_1");

                        GameManager.ins.hint1 = true;

                        Level11.ins.wire2.gameObject.SetActive(true);
                        Level11.ins.a_girl.gameObject.GetComponent<RectTransform>()
                            .DOAnchorPos(new Vector3(-263f, 135f, 0f), 0.8f).OnComplete(() => { });

                        Level11.ins.g12.GetComponent<RectTransform>()
                            .DOAnchorPos(new Vector3(0f, 400f, 0f), 0.8f).OnComplete(() => { });

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);

                        Level11.ins.t1 = true;

                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "dress1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level11[0]);

                        if (Level11.ins.t1 == true)
                        {
                            GameManager.ins.hint2 = true;
                            Level11.ins.chageString("lev11_2");

                            if (Level11.ins.l11 == false)
                            {

                                Level11.ins.l11 = true;
                                Level11.ins.dress3.gameObject.SetActive(true);
                                Level11.ins.g12.GetComponent<RectTransform>()
                                        .DOAnchorPos(new Vector3(0f, 800f, 0f), 0.8f).OnComplete(() => { });
                            }
                            else
                            {
                                Level11.ins.dress2.gameObject.SetActive(true);
                                Level11.ins.g12.GetComponent<RectTransform>()
                                       .DOAnchorPos(new Vector3(0f, 1200f, 0f), 0.8f).OnComplete(() => { });
                                Level11.ins.t1 = false;
                                Level11.ins.t2 = true;

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
                    else if ((other.name == "a_girl") && name == "hair1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level11[0]);

                        if (Level11.ins.t1 == true)
                        {
                            Level11.ins.chageString("lev11_3");

                            GameManager.ins.hint3 = true;

                            if (Level11.ins.l11 == false)
                            {
                                Level11.ins.l11 = true;
                                Level11.ins.hair2.gameObject.SetActive(true);
                                Level11.ins.g12.GetComponent<RectTransform>()
                                        .DOAnchorPos(new Vector3(0f, 800f, 0f), 0.8f).OnComplete(() => { });
                            }
                            else
                            {
                                Level11.ins.hair3.gameObject.SetActive(true);
                                Level11.ins.g12.GetComponent<RectTransform>()
                                       .DOAnchorPos(new Vector3(0f, 1200f, 0f), 0.8f).OnComplete(() => { });
                                Level11.ins.t1 = false;
                                Level11.ins.t2 = true;

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
                    else if ((other.name == "a_girl") && name == "clothes1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level11[0]);

                        if (Level11.ins.t2 == true)
                        {
                            GameManager.ins.hint5 = true;
                            Level11.ins.chageString("lev11_5");

                            if (Level11.ins.l12 == false)
                            {
                                Level11.ins.l12 = true;
                                Level11.ins.clothers2.gameObject.SetActive(true);
                                Level11.ins.g12.GetComponent<RectTransform>()
                                      .DOAnchorPos(new Vector3(0f, 1400f, 0f), 0.8f).OnComplete(() => { });
                            }
                            else
                            {
                                Level11.ins.clothers3.gameObject.SetActive(true);

                                Level11.ins.g12.GetComponent<RectTransform>()
                                      .DOAnchorPos(new Vector3(0f, 1800f, 0f), 0.8f).OnComplete(() => { });
                                Level11.ins.t2 = false;
                                Level11.ins.t3 = true;
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
                    else if ((other.name == "a_girl") && name == "dumbbell1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level11[0]);

                        if (Level11.ins.t2 == true)
                        {
                            Level11.ins.chageString("lev11_4");

                            GameManager.ins.hint4 = true;

                            if (Level11.ins.l12 == false)
                            {
                                Level11.ins.l12 = true;
                                Level11.ins.dumbell3.gameObject.SetActive(true);
                                Level11.ins.g12.GetComponent<RectTransform>()
                                      .DOAnchorPos(new Vector3(0f, 1400f, 0f), 0.8f).OnComplete(() => { });
                            }
                            else
                            {
                                Level11.ins.dumbell2.gameObject.SetActive(true);
                                Level11.ins.g12.GetComponent<RectTransform>()
                                      .DOAnchorPos(new Vector3(0f, 1800f, 0f), 0.8f).OnComplete(() => { });
                                Level11.ins.t2 = false;
                                Level11.ins.t3 = true;
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
                    else if ((other.name == "a_girl") && name == "cat1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level11[0]);

                        if (Level11.ins.t3 == true)
                        {
                            Level11.ins.chageString("lev11_6");

                            GameManager.ins.hint6 = true;

                            if (Level11.ins.l13 == false)
                            {
                                Level11.ins.l13 = true;
                                Level11.ins.cat3.gameObject.SetActive(true);
                                Level11.ins.g12.GetComponent<RectTransform>()
                                      .DOAnchorPos(new Vector3(0f, 2200f, 0f), 0.8f).OnComplete(() => { });
                            }
                            else
                            {
                                Level11.ins.cat2.gameObject.SetActive(true);
                                Level11.ins.g12.GetComponent<RectTransform>()
                                      .DOAnchorPos(new Vector3(0f, 2500f, 0f), 0.8f).OnComplete(() => { });
                                Level11.ins.t3 = false;
                                Level11.ins.t4 = true;
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
                    else if ((other.name == "a_girl") && name == "towel1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level11[0]);

                        if (Level11.ins.t3 == true)
                        {
                            GameManager.ins.hint7 = true;
                            Level11.ins.chageString("lev11_7");

                            if (Level11.ins.l13 == false)
                            {
                                Level11.ins.l13 = true;
                                Level11.ins.towel2.gameObject.SetActive(true);
                                Level11.ins.g12.GetComponent<RectTransform>()
                                      .DOAnchorPos(new Vector3(0f, 2200f, 0f), 0.8f).OnComplete(() => { });
                            }
                            else
                            {
                                Level11.ins.towel3.gameObject.SetActive(true);
                                Level11.ins.g12.GetComponent<RectTransform>()
                                      .DOAnchorPos(new Vector3(0f, 2500f, 0f), 0.8f).OnComplete(() => { });
                                Level11.ins.t3 = false;
                                Level11.ins.t4 = true;
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
                    else if ((other.name == "a_girl") && name == "wool1")
                    {
                        if (Level11.ins.l13 == false)
                        {
                            Level11.ins.l13 = true;
                            Level11.ins.wool2.gameObject.SetActive(true);
                            Level11.ins.g12.GetComponent<RectTransform>()
                                      .DOAnchorPos(new Vector3(0f, 2200f, 0f), 0.4f).OnComplete(() =>
                                      {
                                          Level11.ins.a_girl.gameObject.SetActive(false);
                                          Level11.ins.girl_lose.gameObject.SetActive(true);
                                          Level11.ins.girl_lose.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-260f, 100f, 0f);
                                          Level11.ins.girl_lose.GetComponent<RectTransform>()
                                                    .DOAnchorPos(new Vector3(-260f, -1000f, 0f), 0.8f).OnComplete(() =>
                                                    {
                                                        Level11.ins.overGG();
                                                    });
                                      });
                        }
                        else
                        {
                            Level11.ins.wool3.gameObject.SetActive(true);
                            Level11.ins.g12.GetComponent<RectTransform>()
                                      .DOAnchorPos(new Vector3(0f, 2500f, 0f), 0.4f).OnComplete(() =>
                                      {
                                          Level11.ins.a_girl.gameObject.SetActive(false);
                                          Level11.ins.girl_lose.gameObject.SetActive(true);
                                          Level11.ins.girl_lose.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-260f, 100f, 0f);
                                          Level11.ins.girl_lose.GetComponent<RectTransform>()
                                                    .DOAnchorPos(new Vector3(-260f, -1000f, 0f), 0.8f).OnComplete(() =>
                                                    {
                                                        Level11.ins.overGG();
                                                    });
                                      });
                        }
                        

                        this.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPosition;
                        this.gameObject.SetActive(false);
                        return collided;
                    }
                    else if ((other.name == "a_girl") && name == "broom1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level11[0]);

                        if (Level11.ins.t4 == true)
                        {
                            Level11.ins.chageString("lev11_8");

                            GameManager.ins.hint8 = true;

                            if (Level11.ins.l14 == false)
                            {
                                Level11.ins.l14 = true;
                                Level11.ins.broom2.gameObject.SetActive(true);
                                Level11.ins.g12.GetComponent<RectTransform>()
                                      .DOAnchorPos(new Vector3(0f, 2800f, 0f), 0.8f).OnComplete(() => { });
                            }
                            else
                            {
                                Level11.ins.broom3.gameObject.SetActive(true);
                                Level11.ins.g12.GetComponent<RectTransform>()
                                      .DOAnchorPos(new Vector3(0f, 3200f, 0f), 0.8f).OnComplete(() => { });
                                Level11.ins.t4 = false;
                                Level11.ins.t5 = true;
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
                    else if ((other.name == "a_girl") && name == "blanket1")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level11[0]);

                        if (Level11.ins.t4 == true)
                        {
                            Level11.ins.chageString("lev11_9");

                            GameManager.ins.hint9 = true;

                            if (Level11.ins.l14 == false)
                            {
                                Level11.ins.l14 = true;
                                Level11.ins.blanket3.gameObject.SetActive(true);
                                Level11.ins.g12.GetComponent<RectTransform>()
                                      .DOAnchorPos(new Vector3(0f, 2800f, 0f), 0.8f).OnComplete(() => { });
                            }
                            else
                            {
                                Level11.ins.blanket2.gameObject.SetActive(true);
                                Level11.ins.g12.GetComponent<RectTransform>()
                                      .DOAnchorPos(new Vector3(0f, 3200f, 0f), 0.8f).OnComplete(() => { });
                                Level11.ins.t4 = false;
                                Level11.ins.t5 = true;
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
                    else if ((other.name == "a_girl") && name == "bart21")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level11[0]);

                        if (Level11.ins.t5 == true)
                        {
                            GameManager.ins.hint11 = true;
                            Level11.ins.chageString("lev11_11");

                            if (Level11.ins.l15 == false)
                            {
                                Level11.ins.l15 = true;
                                Level11.ins.bart22.gameObject.SetActive(true);
                                Level11.ins.g12.GetComponent<RectTransform>()
                                      .DOAnchorPos(new Vector3(0f, 3500f, 0f), 0.8f).OnComplete(() => { });
                            }
                            else
                            {
                                Level11.ins.t4 = false;
                                Level11.ins.t5 = false;
                                Level11.ins.bart23.gameObject.SetActive(true);
                                Level11.ins.g12.GetComponent<RectTransform>()
                                      .DOAnchorPos(new Vector3(0f, 3700f, 0f), 0.8f).OnComplete(() => {

                                          Level11.ins.a_girl.gameObject.SetActive(false);
                                          Level11.ins.girl_win.gameObject.SetActive(true);
                                          Level11.ins.girl_win.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-290f, 130f, 0f);
                                          Level11.ins.girl_win.GetComponent<RectTransform>()
                                                    .DOAnchorPos(new Vector3(-290f, -280f, 0f), 0.8f).OnComplete(() =>
                                                    {
                                                        Level11.ins.gameOver();
                                                    });
                                      });
                                Level11.ins.t5 = false;

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
                    else if ((other.name == "a_girl") && name == "towelt21")
                    {
                        AudioManager.ins.play1shot(AudioManager.ins.level11[0]);

                        if (Level11.ins.t5 == true)
                        {
                            GameManager.ins.hint10 = true;
                            Level11.ins.chageString("lev11_10");

                            if (Level11.ins.l15 == false)
                            {
                                Level11.ins.l15 = true;
                                Level11.ins.towelt23.gameObject.SetActive(true);
                                Level11.ins.g12.GetComponent<RectTransform>()
                                      .DOAnchorPos(new Vector3(0f, 3500f, 0f), 0.8f).OnComplete(() =>
                                      {



                                      });
                            }
                            else
                            {
                                Level11.ins.towelt22.gameObject.SetActive(true);
                                Level11.ins.g12.GetComponent<RectTransform>()
                                      .DOAnchorPos(new Vector3(0f, 3700f, 0f), 0.8f).OnComplete(() =>
                                      {

                                          Level11.ins.a_girl.gameObject.SetActive(false);
                                          Level11.ins.girl_win.gameObject.SetActive(true);
                                          Level11.ins.girl_win.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-290f, 130f, 0f);
                                          Level11.ins.girl_win.GetComponent<RectTransform>()
                                                    .DOAnchorPos(new Vector3(-290f, -280f, 0f), 0.8f).OnComplete(() =>
                                                    {
                                                        Level11.ins.gameOver();
                                                    });

                                      });
                                Level11.ins.t5 = false;

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
