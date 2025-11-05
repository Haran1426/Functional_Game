using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public void ClickStart()
    {
        SceneManager.LoadScene("MainScene"); //씬 이름 집어넣기
    }
}
