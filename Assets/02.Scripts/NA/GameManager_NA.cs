using System.Collections;
using DG.Tweening;
using DG.Tweening.Core.Easing;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager_NA : MonoBehaviour
{
    public static GameManager_NA Instance;

    public bool isGameOver = false;
    public bool isGameStart = false;

    public GameObject three_NA;
    public GameObject two_NA;
    public GameObject one_NA;
    public GameObject start_NA;

    public int hp = 4;
    public HPUI_NA hpUI;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        hpUI.UpdateHP(hp); // 시작 시 전체 표시
        StartCoroutine(GameStart());
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    IEnumerator GameStart()
    {
        three_NA.SetActive(true);
        Debug.Log("3");
        yield return new WaitForSeconds(1f);
        three_NA.SetActive(false);

        two_NA.SetActive(true);
        Debug.Log("2");
        yield return new WaitForSeconds(1f);
        two_NA.SetActive(false);

        one_NA.SetActive(true);
        Debug.Log("1");
        yield return new WaitForSeconds(1f);
        one_NA.SetActive(false);

        start_NA.SetActive(true);
        Debug.Log("START!");
        yield return new WaitForSeconds(1f);
        start_NA.SetActive(false);
        isGameStart = true;
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
        if (isGameOver) return; // 중복 호출 방지
        isGameStart = false;
        isGameOver = true;

        Debug.Log("GAME OVER");
        Time.timeScale = 0f;

        GameOver_NA.Instance.ShowGameOver();
    }
}
