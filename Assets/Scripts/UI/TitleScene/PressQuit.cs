using UnityEngine;
using UnityEngine.UI;

public class PressQuit : MonoBehaviour
{
    public RawImage[] images;

    public Texture selectedTexture;
    public Texture pressTexture;
    public Texture normalTexture;

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
}
