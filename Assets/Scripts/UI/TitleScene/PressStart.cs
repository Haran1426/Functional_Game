using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PressStart : MonoBehaviour
{
    public RawImage[] images;

    public Texture selectedTexture;
    public Texture pressTexture;
    public Texture normalTexture;

    public RectTransform manual;
    private Vector2 startPosition = new Vector2(0, 0);
    private Vector2 closePosition = new Vector2(0, -1500);

    public void SelectButton(int val)
    {
        images[val].texture = selectedTexture;
    }

    public void PressButton(int val)
    {
        images[val].texture = pressTexture;
    }

    public void NormalButton(int val)
    {
        images[val].texture = normalTexture;
    }

    public void ClickStart()
    {
        manual.DOAnchorPos(startPosition, 1.0f).SetEase(Ease.OutQuint);
    }
}
