using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    public RectTransform setting; //세팅창 띄우기 닫기
    private Vector2 startSettingPosition = new Vector2(780, -150);
    private Vector2 closeSettingPosition = new Vector2(2580, -100);

    public RectTransform manual; //메뉴얼 띄우기 닫기
    private Vector2 startManualPosition = new Vector2(0, 0);
    private Vector2 closeManualPosition = new Vector2(0, -1500);

    public TitleCutsceneController cutscene;

    private void Start()
    {

    }

    //게임시작
    public void ClickStart()
    {
        cutscene.onCutsceneEnd = LoadNextScene;
        cutscene.PlayCutscene();
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("Choice");
    }

    //게임나가기
    public void ClickExit()
    {
        Application.Quit();
    }

    //세팅창 보이기
    public void ShowSetting()
    {
        setting.DOAnchorPos(startSettingPosition, 1.0f).SetEase(Ease.OutQuint);
    }

    //세팅창 닫기
    public void CloseSetting()
    {
        setting.DOAnchorPos(closeSettingPosition, 1.0f).SetEase(Ease.OutQuint);
    }

    //메뉴얼 보이기
    public void ShowManual()
    {
        manual.DOAnchorPos(startManualPosition, 1.0f).SetEase(Ease.OutQuint);
    }

    //메뉴얼 닫기
    public void CloseManual()
    {
        manual.DOAnchorPos(closeManualPosition, 1.0f).SetEase(Ease.OutQuint);
    }
}
