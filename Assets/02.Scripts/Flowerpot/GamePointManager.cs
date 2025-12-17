using UnityEngine;

public class GamePointManager : MonoBehaviour
{
    public static GamePointManager Instance;

    public int point;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        point = PlayerPrefs.GetInt("GamePoint", 0);
    }

    public void AddPoint(int value)
    {
        point += value;
        PlayerPrefs.SetInt("GamePoint", point);
    }
}
