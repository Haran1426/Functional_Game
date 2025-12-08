using UnityEngine;
using UnityEngine.UI;

public class TextureUI : MonoBehaviour
{
    public RawImage[] images; //기본버튼들 시작,나가기

    public Texture selectedStartTexture; //시작버튼 이미지 변경
    public Texture pressStartTexture;
    public Texture normalStartTexture;

    public Texture selectedQuitTexture; //나가기버튼 이미지 변경
    public Texture pressQuitTexture;
    public Texture normalQuitTexture;

    public Texture selectedSettingTexture; //세팅버튼 이미지 변경
    public Texture pressSettingTexture;
    public Texture normalSettingTexture;

    public Texture selectedCloseTexture; //뒤로가기버튼 이미지 변경
    public Texture pressCloseTexture;   
    public Texture normalCloseTexture;

    //시작버튼
    public void SelectStartButton(int val)
    {
        images[val].texture = selectedStartTexture;
    }

    public void PressStartButton(int val)
    {
        images[val].texture = pressStartTexture;
    }

    public void NormalStartButton(int val)
    {
        images[val].texture = normalStartTexture;
    }

    //나가기버튼
    public void SelectQuitButton(int val)
    {
        images[val].texture = selectedQuitTexture;
    }

    public void PressQuitButton(int val)
    {
        images[val].texture = pressQuitTexture;
    }

    public void NormalQuitButton(int val)
    {
        images[val].texture = normalQuitTexture;
    }

    //세팅버튼
    public void SelectSettingButton(int val)
    {
        images[val].texture = selectedSettingTexture;
    }

    public void PressSettingButton(int val)
    {
        images[val].texture = pressSettingTexture;
    }

    public void NormalSettingButton(int val)
    {
        images[val].texture = normalSettingTexture;
    }

    //뒤로가기버튼
    public void SelectCloseButton(int val)
    {
        images[val].texture = selectedCloseTexture;
    }

    public void PressCloseButton(int val)
    {
        images[val].texture = pressCloseTexture;
    }

    public void NormalCloseButton(int val)
    {
        images[val].texture = normalCloseTexture;
    }
}
