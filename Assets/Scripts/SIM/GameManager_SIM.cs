using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager_SIM : MonoBehaviour
{
    public static GameManager_SIM Instance;

    public bool isGameOver = false;
    public bool isGameStart = false;
    public int score = 0;

    public TextMeshProUGUI scoreText;

    void Start()
    {
        StartCoroutine(GameStart());
    }

    void Awake()
    {
        Instance = this;
    }

    public void AddScore()
    {
        score ++;
        Debug.Log("Score : " + score);

        scoreText.text = "" + score;
    }

    IEnumerator GameStart()
    {
        Debug.Log("3");
        yield return new WaitForSeconds(1f);

        Debug.Log("2");
        yield return new WaitForSeconds(1f);

        Debug.Log("1");
        yield return new WaitForSeconds(1f);

        Debug.Log("START!");

        isGameStart = true;

        TrashSpawner_SIM.Instance.InitTrash();
    }

    public void GameOver()
    {
        if (isGameOver) return; // 중복 호출 방지
        isGameStart = false;
        isGameOver = true;

        Debug.Log("GAME OVER!");
    }
}
