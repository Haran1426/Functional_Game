using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HANUIManager : MonoBehaviour
{
    public static HANUIManager instance;

    public int score;
    
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        
    }

    public void AddScore(int point)
    {
        score += point;
    }
}
