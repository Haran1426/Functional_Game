using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoiceUI : MonoBehaviour
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
}
