using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Spine.Unity;
using Spine;
using System.Collections;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;
using System;
public class unlockLevel : MonoBehaviour
{
    public static unlockLevel ins;
    public Image v1,v2,v3;
    public Sprite video1,video2;

    private void Awake()
    {
        unlockLevel.ins = this;
    }

    private void Start()
    {
        
    }
    public void startUnlock()
    {
        v1.sprite = video1;
        v2.sprite = video1;
        v3.sprite = video1;
    //    ResetImageTime();
    }

    public void UnlockAll()
    {
        if (GameManager.ins.numberAds == 1)
        {
            v1.sprite = video2;
        }
        else if (GameManager.ins.numberAds == 2)
        {
            v2.sprite = video2;
        }
        else if (GameManager.ins.numberAds == 3)
        {
            v3.sprite = video2;
        }
    }
    private string keyTime = "ImageShowTime";

    //public GameObject targetImage; // Ảnh cần ẩn
    public void CheckImageVisibility()
    {
        // Kiểm tra xem đã có dữ liệu thời gian lưu chưa
        if (PlayerPrefs.HasKey("ImageShowTime"))
        {
            string savedTime = PlayerPrefs.GetString(keyTime);
            DateTime lastShownTime = DateTime.Parse(savedTime);
            DateTime now = DateTime.Now;

            // Nếu đã qua 24h, ẩn ảnh
            if ((now - lastShownTime).TotalHours >= 24)
            {
                Home.ins.STHome();
                Debug.Log("Ảnh đã bị ẩn sau 24h.");
            }
            else
            {
                Home.ins.unLockAll();
            }
        }
        else
        {
            Home.ins.STHome();

        }
    }
    public void ResetImageTime()
    {
        PlayerPrefs.DeleteKey("ImageShowTime");
        PlayerPrefs.Save();
        Debug.Log("Reset thời gian ảnh!");
    }
}
