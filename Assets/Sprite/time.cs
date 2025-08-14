using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;
using DG.Tweening;

public class time : MonoBehaviour
{
    public static time ins;
    public Text timerText, hiText, hiNumber;
    public float countdownTime = 180f; // 3 phút = 180 giây

    private float currentTime;
    private bool isRunning = false;
    private void Awake()
    {
        time.ins = this;
    }
    void Start()
    {
        // ResetCountdown();

       // startHi();
    }

    public void startHi()
    {
        // PlayerPrefs.SetInt("hiGame", 0);
        int hiNum = PlayerPrefs.GetInt("hiGame");
        Debug.Log("hinum");

        if (hiNum > 0)
        {
            hiNumber.gameObject.SetActive(true);
            hiText.gameObject.SetActive(false);
            hiNumber.text = $"{hiNum}";
        }
        else
        {
            hiText.gameObject.SetActive(true);
            hiNumber.gameObject.SetActive(false);
        }
    }

    public void StartCountdown()
    {
        if (!isRunning)
        {
            isRunning = true;
            StartCoroutine(UpdateTimer());
        }
    }

    public void PauseCountdown()
    {
        isRunning = false;
    }

    public void ResumeCountdown()
    {
        if (!isRunning)
        {
            isRunning = true;
            StartCoroutine(UpdateTimer());
        }
    }

    public void ResetCountdown()
    {
        isRunning = false;
        currentTime = countdownTime;
        UpdateTimerText();
    }

    public void AddTime(float seconds)
    {
        currentTime += seconds;
        
        UpdateTimerText();
        CloseTimeUp();
    }

    private IEnumerator UpdateTimer()
    {
     //   Debug.Log("Time's up!"+ isRunning);
       /// Debug.Log("Time's up!" + Time.deltaTime);


        while (isRunning && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
           // currentTime -= 0.016f; // Mỗi frame trừ 16ms
        //   Debug.Log("Time's up!" + currentTime);
            UpdateTimerText();
            yield return null;
        }

        if (currentTime <= 0)
        {
            isRunning = false;
            currentTime = 0;
            UpdateTimerText();
            Debug.Log("Time's up!");
            OpenTimeUp();
            AudioManager.ins.play3shot(AudioManager.ins.lose);

        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public GameObject timePopup;
    public void OpenTimeUp()
    {

        timePopup.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        timePopup.transform.localScale = new Vector3(0f, 0f, 0f);
        timePopup.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);
        timePopup.gameObject.SetActive(true);
    }
    public void CloseTimeUp()
    {
        ResumeCountdown();
        timePopup.GetComponent<RectTransform>().anchoredPosition = new Vector3(7000f, 5000f, 0f);
        timePopup.gameObject.SetActive(false);
    }



    public void conTent(int ind)
    {
        // Sử dụng localization để lấy text theo ngôn ngữ hiện tại
        string key = "";

        switch (ind)
        {
            case 0:
                key = "pl1"; // Khóa cho cấp độ 1
                break;
            case 1:
                key = "pl2"; 
                break;
            case 2:
                key = "pl3"; 
                break;
            case 3:
                key = "pl4"; 
                break;
            case 4:
                key = "pl5"; 
                break;
            case 5:
                key = "pl6"; 
                break;
            case 6:
                key = "pl7"; 
                break;
            case 7:
                key = "pl8"; 
                break;
            case 8:
                key = "pl9";
                break;
            case 9:
                key = "pl10";
                break;
            case 10:
                key = "pl11";
                break;
            case 11:
                key = "pl12";
                break;
            case 12:
                key = "pl13";
                break;
            case 13:
                key = "pl14";
                break;
            case 14:
                key = "pl15";
                break;
            case 15:
                key = "pl16";
                break;
            case 16:
                key = "pl17";
                break;
            case 17:
                key = "pl18";
                break;
            case 18:
                key = "pl19";
                break;
            case 19:
                key = "pl20";
                break;
            case 20:
                key = "pl21";
                break;
            case 21:
                key = "pl22";
                break;
            case 22:
                key = "pl23";
                break;
            case 23:
                key = "pl24";
                break;
            case 24:
                key = "pl25";
                break;
            case 25:
                key = "pl26";
                break;
            case 26:
                key = "pl27";
                break;
            case 27:
                key = "pl28";
                break;
            case 28:
                key = "pl29";
                break;
            case 29:
                key = "pl30";
                break;

        }

        ChangeDialogue(key); // Gọi phương thức để thay đổi đoạn hội thoại theo ngôn ngữ
    }

    public LocalizeStringEvent localizeStringEvent;
    public Text title;

    public void ChangeDialogue(string key)
    {
        if (localizeStringEvent != null)
        {
            localizeStringEvent.StringReference.TableEntryReference = key;
            localizeStringEvent.RefreshString();

            // Bắt đầu hiển thị từng chữ sau khi đổi ngôn ngữ
            StartCoroutine(ShowLocalizedText());
        }
        else
        {
            Debug.LogError("LocalizeStringEvent is not set.");
        }
    }

    private IEnumerator ShowLocalizedText()
    {
        Debug.Log("Bắt đầu hiển thị text...");

        // Làm trống text ban đầu
        title.text = "";

        // Chờ cho đến khi text được cập nhật từ localization
        yield return new WaitUntil(() => !string.IsNullOrEmpty(localizeStringEvent.StringReference.GetLocalizedString()));

        // Lấy đoạn văn bản đã dịch
        string localizedText = localizeStringEvent.StringReference.GetLocalizedString();

        // Delay 1 giây trước khi bắt đầu hiển thị từng ký tự
        yield return new WaitForSeconds(0.9f);

        // Lặp qua từng ký tự trong đoạn văn bản và hiển thị
        for (int i = 0; i < localizedText.Length; i++)
        {
            title.text += localizedText[i];  // Thêm từng ký tự vào Text
            yield return new WaitForSeconds(0.03f);  // Điều chỉnh tốc độ hiển thị
        }
    }
}
