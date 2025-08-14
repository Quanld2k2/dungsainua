using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class Slideshow : MonoBehaviour
{
    public static Slideshow ins;

    public Sprite[] images;  // Mảng chứa ảnh
    public float changeInterval = 2f;  // Thời gian đổi ảnh
    public float slideDuration = 0.5f;  // Thời gian trượt

    private Image displayImage;
    private RectTransform imageRect;
    private int currentIndex = 0;

    private void Awake()
    {
        Slideshow.ins = this;
    }
    void Start()
    {
    //    displayImage = GetComponent<Image>();
        //imageRect = displayImage.GetComponent<RectTransform>();

      
    }

    public void ShowStart()
    {
        if (images.Length > 0)
        {
            displayImage.sprite = images[currentIndex];
            StartCoroutine(SlideshowLoop());
        }
    }

    IEnumerator SlideshowLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeInterval);

            // Trượt ảnh hiện tại sang trái
            imageRect.DOAnchorPosX(-imageRect.rect.width, slideDuration).OnComplete(() =>
            {
                // Đổi ảnh
                currentIndex = (currentIndex + 1) % images.Length;
                displayImage.sprite = images[currentIndex];

                // Đưa ảnh mới ra ngoài bên phải
                imageRect.anchoredPosition = new Vector2(imageRect.rect.width, 0);

                // Trượt ảnh mới vào vị trí cũ
                imageRect.DOAnchorPosX(0, slideDuration);
            });
        }
    }
}
