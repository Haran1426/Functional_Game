using DG.Tweening;
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

    public Transform scoreUI;
    private Vector2 firstPosition = new Vector2(-12, 2.5f);
    private Vector2 showPosition = new Vector2(-5.92f, 2.5f);

    public RectTransform scoreText_SIM;
    private Vector2 firstTextPosition = new Vector2(-1100, 255);
    private Vector2 showTextPosition = new Vector2(-615, 255);

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

        yield return new WaitForSeconds(1f);
        scoreUI.DOMove(showPosition, 1.0f).SetEase(Ease.OutQuint);
        scoreText_SIM.DOAnchorPos(showTextPosition, 1.0f).SetEase(Ease.OutQuint);

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
