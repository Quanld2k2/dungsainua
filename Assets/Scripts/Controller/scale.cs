using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class scale : MonoBehaviour
{
    [SerializeField] private float scaleFactor = 1.2f;
    [SerializeField] private float duration = 0.2f;

    private Button button;
    private Vector3 originalScale;

    void Start()
    {
        button = GetComponent<Button>();
        originalScale = transform.localScale;
        button.onClick.AddListener(PlayEffect);
    }

    void PlayEffect()
    {
        transform.DOScale(originalScale * scaleFactor, duration / 2)
                 .SetEase(Ease.OutBack)
                 .OnComplete(() =>
                 {
                     transform.DOScale(originalScale, duration / 2).SetEase(Ease.OutBack);
                 });
    }
}
