using UnityEngine;
using UnityEngine.UI;

public class HPUI_NA : MonoBehaviour
{
    public GameObject[] batterySlots; // 4개

    public void UpdateHP(int hp)
    {
        for (int i = 0; i < batterySlots.Length; i++)
        {
            if (i < hp)
                batterySlots[i].SetActive(true);
            else
                batterySlots[i].SetActive(false);
        }
    }
}
