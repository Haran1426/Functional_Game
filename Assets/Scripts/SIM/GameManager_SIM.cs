using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager_SIM : MonoBehaviour
{
    public static GameManager_SIM Instance;

    public bool isGameOver = false;
    public bool isGameStart = false;
    public int score = 0;

    public GameObject three_SIM;
    public GameObject two_SIM;
    public GameObject one_SIM;
    public GameObject start_SIM;

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
        three_SIM.SetActive(true);
        Debug.Log("3");
        yield return new WaitForSeconds(1f);
        three_SIM.SetActive(false);

        two_SIM.SetActive(true);
        Debug.Log("2");
        yield return new WaitForSeconds(1f);
        two_SIM.SetActive(false);

        one_SIM.SetActive(true);
        Debug.Log("1");
        yield return new WaitForSeconds(1f);
        one_SIM.SetActive(false);

        start_SIM.SetActive(true);
        Debug.Log("START!");
        yield return new WaitForSeconds(1f);
        start_SIM.SetActive(false);


        isGameStart = true;

        TrashSpawner_SIM.Instance.InitTrash();
    }

    public void GameOver()
    {
        if (isGameOver) return; // 중복 호출 방지
        isGameStart = false;
        isGameOver = true;


        GameOver_SIM.Instance.ShowGameOver();
        Debug.Log("GAME OVER!");
    }
}
