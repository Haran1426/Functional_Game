using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerUI : MonoBehaviour
{
    public void OnClickHAN()
    {
        SceneManager.LoadScene("HAN");
    }
    public void OnClickJEONG()
    {
        SceneManager.LoadScene("JEONG");
    }
    public void OnClickNA()
    {
        SceneManager.LoadScene("NA");
    }
    
    public void OnClickSIM()
    {
        SceneManager.LoadScene("SIM");
    }
    public void OnClickTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void OnClickChoice()
    {
        SceneManager.LoadScene("Choice");
    }
    public void OnClickSelectStage()
    {
        SceneManager.LoadScene("SelectStage");
    }
    public void OnClickFlowerpot()
    {
        SceneManager.LoadScene("Flowerpot");
    }
}