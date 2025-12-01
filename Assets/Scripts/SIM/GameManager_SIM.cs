using UnityEngine;

public class GameManager_SIM : MonoBehaviour
{
    public static GameManager_SIM Instance;

    public bool isGameOver = false;

    void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        if (isGameOver) return; // 중복 호출 방지
        isGameOver = true;

        Debug.Log("GAME OVER!");
    }
}
