using UnityEngine;

public class TrashManager_SIM : MonoBehaviour
{
    public static TrashManager_SIM Instance;

    private void Awake()
    {
        Instance = this;
    }

    // 올바르게 처리된 경우 (맨 첫 쓰레기 제거)
    public void ProcessCorrect(Trash_SIM trash)
    {
        // 보내준 trash가 현재 첫 번째 쓰레기인지 확인
        if (TrashSpawner_SIM.Instance.GetFirstTrash() == trash)
        {
            TrashSpawner_SIM.Instance.RemoveFirst();

            TimeManager_SIM.Instance.AddTime();
        }
        else
        {
            Debug.Log("This is not the first trash!");
        }
    }
}
