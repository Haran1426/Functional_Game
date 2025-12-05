using UnityEngine;
using UnityEngine.UI;

public class TimeManager_SIM : MonoBehaviour
{
    public static TimeManager_SIM Instance;

    public float totalTime = 30f;      // 현재 시간
    public float maxTime = 30f;        // 최대 시간
    public float addTime = 2f;         // 쓰레기 처리 시 회복
    public float timeSpeed = 1f;       // 시간 감소 속도
    public float speedIncreaseRate = 0.05f; // 시간 가속 증가량

    public Image timerBar;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (!GameManager_SIM.Instance.isGameStart)
            return;

        // 감소 속도 점점 빨라짐
        timeSpeed += speedIncreaseRate * Time.deltaTime;

        // 시간 감소
        totalTime -= timeSpeed * Time.deltaTime;

        if (totalTime < 0)
            totalTime = 0;

        // 타임바 업데이트
        if (timerBar != null)
        {
            float fill = totalTime / maxTime;
            timerBar.fillAmount = fill;
        }

        // 시간이 다 됐는지 확인 GameManager에 알림
        if (totalTime <= 0 && !GameManager_SIM.Instance.isGameOver)
        {
            GameManager_SIM.Instance.GameOver();
        }
    }

    public void AddTime()
    {
        totalTime += addTime;

        if (totalTime > maxTime)
            totalTime = maxTime;
    }

    public void DecreaseTime(float amount)
    {
        totalTime -= amount;
        if (totalTime < 0f) totalTime = 0f;
    }
}
