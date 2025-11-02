using DG.Tweening;
using UnityEngine;

public class SettingUI : MonoBehaviour
{
    public RectTransform setting;
    private Vector2 startPosition = new Vector2(509, -150);
    private Vector2 closePosition = new Vector2(1409, -150);
    
    public void ShowSetting()
    {
        setting.DOAnchorPos(startPosition, 1.0f).SetEase(Ease.OutQuint);
    }

    public void CloseSetting()
    {
        setting.DOAnchorPos(closePosition, 1.0f).SetEase(Ease.OutQuint);
    }
}
