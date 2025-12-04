using UnityEngine;

public class InputTrash_SIM : MonoBehaviour
{
    void Update()
    {
        if (!GameManager_SIM.Instance.isGameStart)
            return;
        if (GameManager_SIM.Instance.isGameOver)
            return;

        if (Input.GetKeyDown(KeyCode.A))
            ProcessByKey(TrashType.Food);

        if (Input.GetKeyDown(KeyCode.S))
            ProcessByKey(TrashType.Plastic);

        if (Input.GetKeyDown(KeyCode.K))
            ProcessByKey(TrashType.Can);

        if (Input.GetKeyDown(KeyCode.L))
            ProcessByKey(TrashType.Paper);
    }

    void ProcessByKey(TrashType inputType)
    {
        //쓰래기가 생성되지 않았을떄에 키입력 방지용
        if (TrashSpawner_SIM.Instance.GetFirstTrash() == null)
            return;

        // 현재 첫 번째 쓰레기 가져오기
        Trash_SIM firstTrash = TrashSpawner_SIM.Instance.GetFirstTrash();
        if (firstTrash == null) return;

        // 해당 타입의 쓰레기통 찾기
        TrashBin_SIM[] bins = FindObjectsOfType<TrashBin_SIM>();
        foreach (var bin in bins)
        {
            if (bin.binType == inputType)
            {
                bin.TryProcess(firstTrash);
                return;
            }
        }
    }
}
