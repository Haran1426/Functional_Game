using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_SIM : MonoBehaviour
{
    public static GameOver_SIM Instance;

    public GameObject gameOverUI;        // 게임오버 UI
    public TextMeshProUGUI scoreText;    // 점수를 표시할 텍스트
    public float delayBeforeLoad = 3f;   // 씬 이동 전 딜레이
    public string nextSceneName = "SelectStage";

    void Awake()
    {
        Instance = this;
        gameOverUI.SetActive(false); // 시작 시 숨기기
    }

    public void ShowGameOver()
    {
        // 점수 표시
        int finalScore = GameManager_SIM.Instance.score;
        scoreText.text = " " + finalScore;

        // UI 활성화
        gameOverUI.SetActive(true);

        // 씬 이동
        StartCoroutine(LoadSceneAfterDelay());
    }

    IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoad);
        SceneManager.LoadScene(nextSceneName);
    }
}
