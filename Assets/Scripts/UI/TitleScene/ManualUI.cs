using DG.Tweening;
using UnityEngine;

public class ManualUI : MonoBehaviour
{
    public RectTransform manual;
    private Vector2 startPosition = new Vector2(0, 0);
    private Vector2 closePosition = new Vector2(0, -1500);

    public void ShowManual()
    {
        manual.DOAnchorPos(startPosition, 1.0f).SetEase(Ease.OutQuint);
    }

    public void CloseManual()
    {
        manual.DOAnchorPos(closePosition, 1.0f).SetEase(Ease.OutQuint);
    }
}
