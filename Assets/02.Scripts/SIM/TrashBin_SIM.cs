using UnityEngine;

public class TrashBin_SIM : MonoBehaviour
{
    public TrashType binType;

    public void TryProcess(Trash_SIM trash)
    {
        if (trash.type == binType)
        {
            // 맞게 분류됨 → TrashManager에 전달
            TrashManager_SIM.Instance.ProcessCorrect(trash);
            PlayerMove_SIM.Instance.PlayCorrectAnimation();
        }
        else
        {
            Debug.Log("Wrong Bin!");
            TimeManager_SIM.Instance.DecreaseTime(2f);
            GameManager_SIM.Instance.correctCount = 0;
        }
    }
}
