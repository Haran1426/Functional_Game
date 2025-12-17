using UnityEngine;
using UnityEngine.UI;

public class HANUIManager : MonoBehaviour
{
    public static HANUIManager instance;

    public int CurrentScore;
    public int MaxScore = 3;

    public Slider scoreSlider;
    public GameObject gameOverPanel;
    public GameObject clearPanel;

    bool isGameEnd;

    void Awake()
    {
        instance = this;

        if (scoreSlider != null)
        {
            scoreSlider.minValue = 0;
            scoreSlider.maxValue = MaxScore;
            scoreSlider.value = CurrentScore;
        }

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (clearPanel != null)
            clearPanel.SetActive(false);

        isGameEnd = false;
        Time.timeScale = 1f;
    }

    public void AddScore(int point)
    {
        if (isGameEnd) return;

        CurrentScore += point;
        CurrentScore = Mathf.Clamp(CurrentScore, 0, MaxScore);

        if (scoreSlider != null)
            scoreSlider.value = CurrentScore;

        if (CurrentScore >= MaxScore)
            ClearGame();
    }

    public void GameOver()
    {
        if (isGameEnd) return;
        isGameEnd = true;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    void ClearGame()
    {
        if (isGameEnd) return;
        isGameEnd = true;

        if (clearPanel != null)
            clearPanel.SetActive(true);

        Time.timeScale = 0f;
    }
}
