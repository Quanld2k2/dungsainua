using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using DG.Tweening;

public class SlideshowController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Sprite[] images;  // Mảng chứa ảnh
    public float changeInterval = 2f;  // Thời gian đổi ảnh
    public Transform dotsPanel;  // Panel chứa chấm tròn
    public GameObject dotPrefab; // Prefab của chấm tròn
    public Button playPauseButton; // Nút bật/tắt slideshow

    private Image displayImage;
    private int currentIndex = 0;
    private Coroutine slideshowCoroutine;
    private bool isPlaying = true;
    private GameObject[] dots;
    private Vector2 startDragPos;

    void Start()
    {
        displayImage = GetComponent<Image>();
        InitDots();
        StartSlideshow();

        playPauseButton.onClick.AddListener(ToggleSlideshow);
    }

    void InitDots()
    {
        dots = new GameObject[images.Length];

        for (int i = 0; i < images.Length; i++)
        {
            GameObject dot = Instantiate(dotPrefab, dotsPanel);
            dots[i] = dot;
        }
        UpdateDots();
    }

    void StartSlideshow()
    {
        if (slideshowCoroutine != null) StopCoroutine(slideshowCoroutine);
        slideshowCoroutine = StartCoroutine(SlideshowLoop());
    }

    IEnumerator SlideshowLoop()
    {
        while (isPlaying)
        {
            NextImage();
            yield return new WaitForSeconds(changeInterval);
        }
    }

    public void ToggleSlideshow()
    {
        isPlaying = !isPlaying;
        playPauseButton.GetComponentInChildren<Text>().text = isPlaying ? "Pause" : "Play";

        if (isPlaying)
            StartSlideshow();
        else
            StopCoroutine(slideshowCoroutine);
    }

    void NextImage()
    {
        currentIndex = (currentIndex + 1) % images.Length;
        ChangeImage(currentIndex);
    }

    void ChangeImage(int index)
    {
        displayImage.DOFade(0, 0.5f).OnComplete(() => {
            displayImage.sprite = images[index];
            displayImage.DOFade(1, 0.5f);
        });

        UpdateDots();
    }

    void UpdateDots()
    {
        for (int i = 0; i < dots.Length; i++)
        {
            dots[i].transform.localScale = (i == currentIndex) ? Vector3.one * 1.5f : Vector3.one;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        startDragPos = eventData.pressPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float dragDelta = eventData.position.x - startDragPos.x;

        if (Mathf.Abs(dragDelta) > 50) // Kéo đủ xa để đổi ảnh
        {
            if (dragDelta > 0)
                currentIndex = (currentIndex - 1 + images.Length) % images.Length; // Vuốt phải -> về ảnh trước
            else
                currentIndex = (currentIndex + 1) % images.Length; // Vuốt trái -> ảnh tiếp theo

            ChangeImage(currentIndex);
        }
    }
}
