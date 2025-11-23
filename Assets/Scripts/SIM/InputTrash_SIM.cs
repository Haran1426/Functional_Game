using UnityEngine;

public class InputTrash_SIM : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            ProcessByKey(TrashType.Food);

        if (Input.GetKeyDown(KeyCode.S))
            ProcessByKey(TrashType.Plastic);

        if (Input.GetKeyDown(KeyCode.Semicolon))
            ProcessByKey(TrashType.Can);

        if (Input.GetKeyDown(KeyCode.Quote))
            ProcessByKey(TrashType.Paper);
    }

    void ProcessByKey(TrashType inputType)
    {
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
