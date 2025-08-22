using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Spine.Unity;
using Spine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class Home : MonoBehaviour
{
    public static Home ins;

    [SerializeField] public Button[] level;
    [SerializeField] public Image icon, iclock, bt_Vip;
    public SkeletonGraphic a_lock, a_sale, a_shop;

    private void Awake()
    {
        Home.ins = this;
    }
    private void Start()
    {
        LoadData();
        LoadData22();
        //   AddValue(2);
        //   AddValue(3);
        //   AddValue(5);
        // SaveData();
        // PrintValues();

        Home.ins.a_shop.gameObject.SetActive(true);
       // if (PlayerPrefs.GetInt("vipIap", 0) == 0)
       // {
            //    PlayerPrefs.SetInt("vipIap", 1);
            Home.ins.a_lock.gameObject.SetActive(true);
            Home.ins.bt_Vip.gameObject.SetActive(true);
       // }
       // else
        //{
        //    Home.ins.a_lock.gameObject.SetActive(false);
         //   Home.ins.bt_Vip.gameObject.SetActive(false);
        //}

        if (PlayerPrefs.GetInt("Iap_Removeads", 0) == 0)
        {
            int aload = PlayerPrefs.GetInt("anoyme1");
            if (aload >= 4)
            {
                Home.ins.a_sale.gameObject.SetActive(true);
            }
            else
            {
                Home.ins.a_sale.gameObject.SetActive(false);
            }
        }
        else
        {
            Home.ins.a_sale.gameObject.SetActive(false);
        }
    }

    public void StartHome()
    {
        
        if (GameManager.ins.numberAds == 3)
        {
            a_lock.gameObject.SetActive(false);
        }
        else
        {
            a_lock.gameObject.SetActive(true);
        }

        OpenUnlockLevel();
        OpenUnlockAllLevel();

    }

    public void  STHome()
    {
     // PlayerPrefs.SetInt("anoyme1", 23);

        int loadedScore = PlayerPrefs.GetInt("anoyme1");

        for (int i = 0; i < level.Length; i++)
        {
            Button button = level[i];
            Image[] childImages = button.GetComponentsInChildren<Image>(true);
            foreach (Image image in childImages)
            {
                if (i <= loadedScore )
                {
                    if (image.gameObject.name == "lock")
                    {
                        image.gameObject.SetActive(false);
                    }
                }
                else if (numbers.Contains(i))
                {
                    if (image.gameObject.name == "lock")
                    {
                        image.gameObject.SetActive(false);
                    }
                }
                else
                {
                    if (image.gameObject.name == "lock")
                    {
                        image.gameObject.SetActive(true);
                    }
                }

                 if (numbers2.Contains(i))
                {
                    if (image.gameObject.name == "done")
                    {
                        image.gameObject.SetActive(true);
                    }
                }
                else {
                    if (image.gameObject.name == "done")
                    {
                        image.gameObject.SetActive(false);
                    }
                }
                if (i == loadedScore)
                {
                    if (image.gameObject.name == "!")
                    {
                        image.gameObject.SetActive(true);
                    }
                }
                else
                {
                    if (image.gameObject.name == "!")
                    {
                        image.gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    public void unLockAll()
    {
        a_lock.gameObject.SetActive(false);
        int loadedScore = PlayerPrefs.GetInt("anoyme1");
        loadedScore = level.Length;
         PlayerPrefs.SetInt("anoyme1", 23);
         PlayerPrefs.SetInt("anoyme1", loadedScore);
         PlayerPrefs.Save();
        Debug.Log("unlockkelwlwl");
        for (int i = 0; i < level.Length; i++)
        {
            Button button = level[i];
            Image[] childImages = button.GetComponentsInChildren<Image>(true);
            foreach (Image image in childImages)
            {
                if (i <= loadedScore)
                {
                    if (image.gameObject.name == "lock")
                    {
                        image.gameObject.SetActive(false);
                    }
                }
                else
                {
                    if (image.gameObject.name == "lock")
                    {
                        image.gameObject.SetActive(true);
                    }
                }
                if (numbers2.Contains(i))
                {
                    if (image.gameObject.name == "done")
                    {
                        image.gameObject.SetActive(true);
                    }
                }
                else
                {
                    if (image.gameObject.name == "done")
                    {
                        image.gameObject.SetActive(false);
                    }
                }
                if (i == loadedScore)
                {
                    if (image.gameObject.name == "!")
                    {
                        image.gameObject.SetActive(true);
                    }
                }
                else
                {
                    if (image.gameObject.name == "!")
                    {
                        image.gameObject.SetActive(false);
                    }
                }

            }
        }
    }
    public void unLockLevel(int id)
    {
        Debug.Log("unLockLevel" + id);
        for (int i = 0; i < level.Length; i++)
        {
            Button button = level[i];
            Image[] childImages = button.GetComponentsInChildren<Image>(true);
            foreach (Image image in childImages)
            {
                if (i == id)
                {
                    if (image.gameObject.name == "lock")
                    {
                        image.gameObject.SetActive(false);
                    }
                    AddValue(id);
                    SaveData();
                  //  PrintValues();
                }
            }
        }
    }

    public List<int> numbers = new List<int>();
    public void AddValue(int value)
    {
        if (!numbers.Contains(value))
        {
            numbers.Add(value);
        }
    }
    public void SaveData()
    {
        string json = string.Join(",", numbers);
        PlayerPrefs.SetString("Numbers", json);
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        string json = PlayerPrefs.GetString("Numbers", "");
        numbers = json.Split(',').Where(x => int.TryParse(x, out _)).Select(int.Parse).ToList();
    }

    public void PrintValues()
    {
        Debug.Log("Mảng: " + string.Join(", ", numbers));   
    }
    public void CheckValueExists(int value)
    {
        if (numbers.Contains(value))
        {
            Debug.Log(value + " tồn tại trong mảng.");
        }
        else
        {
            Debug.Log(value + " không tồn tại trong mảng.");
        }
    }
    /////
    ///
    public List<int> numbers2 = new List<int>();
    public void AddValue2(int value)
    {
        if (!numbers2.Contains(value))
        {
            numbers2.Add(value);
        }
    }
    public void SaveData22()
    {
        string json = string.Join(",", numbers2);
        PlayerPrefs.SetString("Numbers2", json);
        PlayerPrefs.Save();
    }

    public void LoadData22()
    {
        string json = PlayerPrefs.GetString("Numbers2", "");
        numbers2 = json.Split(',').Where(x => int.TryParse(x, out _)).Select(int.Parse).ToList();
    }

    public void PrintValues22()
    {
        Debug.Log("Mảng: " + string.Join(", ", numbers2));
    }
    public void CheckValueExists22(int value)
    {
        if (numbers2.Contains(value))
        {
            Debug.Log(value + " tồn tại trong mảng.");
        }
        else
        {
            Debug.Log(value + " không tồn tại trong mảng.");
        }
    }


    public Image boardUn;
    public Button bt_VideoUn,bt_CloseUn;

    public void OpenUnlockLevel()
    {
        boardUn.gameObject.SetActive(false);
        bt_VideoUn.gameObject.SetActive(false);
        bt_CloseUn.gameObject.SetActive(false);

        boardUn.gameObject.SetActive(true);
        boardUn.transform.localScale = new Vector3(0f, 0f, 0f);
        boardUn.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            bt_VideoUn.gameObject.SetActive(true);
            bt_VideoUn.transform.localScale = new Vector3(0.5f, 1f, 1f);
            bt_VideoUn.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);

            bt_CloseUn.gameObject.SetActive(true);
            bt_CloseUn.transform.localScale = new Vector3(0.5f, 1f, 1f);
            bt_CloseUn.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);
        });
    }
    public void CloseUnlockLevel()
    {
        boardUn.gameObject.SetActive(false);
      
    }

    public Image boardAllUn;
    public Button bt_VideoAllUn, bt_CloseAllUn;

    public void OpenUnlockAllLevel()
    {
        boardAllUn.gameObject.SetActive(false);
        bt_VideoAllUn.gameObject.SetActive(false);
        bt_CloseAllUn.gameObject.SetActive(false);

        boardAllUn.gameObject.SetActive(true);
        boardAllUn.transform.localScale = new Vector3(0f, 0f, 0f);
        boardAllUn.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            bt_VideoAllUn.gameObject.SetActive(true);
            bt_VideoAllUn.transform.localScale = new Vector3(0.5f, 1f, 1f);
            bt_VideoAllUn.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack).OnComplete(() =>
            {
                bt_VideoAllUn.transform.DOScale(1.1f, 0.7f)
                              .SetLoops(-1, LoopType.Yoyo) // loop vô hạn, kiểu đi tới rồi quay về
                              .SetEase(Ease.InOutSine);
            });
            bt_CloseAllUn.gameObject.SetActive(true);
            bt_CloseAllUn.transform.localScale = new Vector3(0.5f, 1f, 1f);
            bt_CloseAllUn.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);
        });
    }
    public void CloseUnlockAllLevel()
    {
        boardAllUn.gameObject.SetActive(false);
        bt_VideoAllUn.DOKill();                  // hủy tween
        bt_VideoAllUn.transform.localScale = Vector3.one;  // trả về scale gốc
    }
}
