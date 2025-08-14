using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class timeBar : MonoBehaviour
{
    public Slider timeSlider; // Thanh thời gian
    public float totalTime = 10f; // Thời gian chạy (10s)

    private float currentTime;
    private Coroutine timerCoroutine;
    public System.Action onTimeUp; // Sự kiện khi hết thời gian

    void Start()
    {
        ResetTimer(); // Khởi tạo thanh thời gian
    }

    public void StartTimer()
    {
        if (timerCoroutine != null) StopCoroutine(timerCoroutine);
        timerCoroutine = StartCoroutine(UpdateTimeBar());
    }

    public void ResetTimer()
    {
        if (timerCoroutine != null) StopCoroutine(timerCoroutine);
        currentTime = totalTime;
        timeSlider.maxValue = totalTime;
        timeSlider.value = totalTime;
    }

    IEnumerator UpdateTimeBar()
    {
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timeSlider.value = currentTime;
            yield return null;
        }
        timeSlider.value = 0;
        onTimeUp?.Invoke(); // Gọi sự kiện khi hết thời gian
        Debug.Log("Time's up!");
    }
}
