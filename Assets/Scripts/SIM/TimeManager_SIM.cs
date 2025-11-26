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
        // 감소 속도 점점 빨라짐
        timeSpeed += speedIncreaseRate * Time.deltaTime;

        // 시간 감소
        totalTime -= timeSpeed * Time.deltaTime;

        if (totalTime < 0)
            totalTime = 0;

        // Slider 대신 이미지의 Fill로 표시
        if (timerBar != null)
        {
            float fill = totalTime / maxTime;  // 0~1 비율
            timerBar.fillAmount = fill;
        }
    }

    public void AddTime()
    {
        totalTime += addTime;

        if (totalTime > maxTime)
            totalTime = maxTime;
    }
}
