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
    private Vector2 showPosition = new Vector2(-5.92f, 2.5f);

    public RectTransform scoreText_SIM;
    private Vector2 showTextPosition = new Vector2(-615, 255);

    public TextMeshProUGUI scoreText;

    public int correctCount = 0;
    public bool isCombo = false;

    public Transform comboUI;
    private Vector2 comboShowPos = new Vector2(-5.92f, 0f);   // 나올곳 위치
    private Vector2 comboHidePos = new Vector2(-12f, 0f);      // 숨은곳 위치

    private bool comboJustStarted = false;

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
        // 1개 맞출 때마다 카운트 증가
        correctCount++;

        // 10개 달성 → 콤보 연출 + 50점 + 리셋
        if (correctCount == 10)
        {
            StartCoroutine(ShowComboUI());

            score += 50;
            scoreText.text = score.ToString();

            correctCount = 0; // 다시 처음부터

            return; // 여기서 함수 종료 (아래 일반 점수 실행 안됨)
        }

        // 일반 점수 (10점)
        score += 10;
        scoreText.text = score.ToString();
    }

    // 콤보 UI — 콤보 발동 순간 딱 1번만 표시
    IEnumerator ShowComboUI()
    {
        comboUI.DOMove(comboShowPos, 0.6f).SetEase(Ease.OutQuint);
        yield return new WaitForSeconds(1.2f);
        comboUI.DOMove(comboHidePos, 0.6f).SetEase(Ease.OutQuint);
    }

    IEnumerator GameStart()
    {
        three_SIM.SetActive(true);
        Debug.Log("3");
        BGM_Manager_SIM.Instance.Count321SFX();
        yield return new WaitForSeconds(1f);
        three_SIM.SetActive(false);

        two_SIM.SetActive(true);
        Debug.Log("2");
        BGM_Manager_SIM.Instance.Count321SFX();
        yield return new WaitForSeconds(1f);
        two_SIM.SetActive(false);

        one_SIM.SetActive(true);
        Debug.Log("1");
        BGM_Manager_SIM.Instance.Count321SFX();
        yield return new WaitForSeconds(1f);
        one_SIM.SetActive(false);

        start_SIM.SetActive(true);
        Debug.Log("START!");
        BGM_Manager_SIM.Instance.PlayStartSFX();
        yield return new WaitForSeconds(1f);
        start_SIM.SetActive(false);

        isGameStart = true;

        scoreUI.DOMove(showPosition, 1.0f).SetEase(Ease.OutQuint);
        scoreText_SIM.DOAnchorPos(showTextPosition, 1.0f).SetEase(Ease.OutQuint);

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
