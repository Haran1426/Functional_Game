using DG.Tweening.Core.Easing;
using TMPro;
using UnityEngine;

public class GameManager_NA : MonoBehaviour
{
    public static GameManager_NA Instance;

    public int hp = 4;
    public HPUI_NA hpUI;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        hpUI.UpdateHP(hp); // 시작 시 전체 표시
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore()
    {
        score += 10;
        scoreText.text = score.ToString();
    }

    public void TakeDamage()
    {
        hp--;

        if (hp < 0)
            hp = 0;

        hpUI.UpdateHP(hp);

        if (hp <= 0)
            GameOver();
    }

    void GameOver()
    {
        Debug.Log("GAME OVER");
        Time.timeScale = 0f;
    }
}
