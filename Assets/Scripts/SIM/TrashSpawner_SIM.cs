using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner_SIM : MonoBehaviour
{
    public static TrashSpawner_SIM Instance;

    public Transform[] slots;            // 슬롯 0~3 위치
    public GameObject[] trashPrefabs;    // 음식/플라스틱/캔/종이 프리팹 (4개)

    private List<GameObject> trashList = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InitTrash();
    }

    // 처음 4개 생성
    void InitTrash()
    {
        trashList.Clear();

        for (int i = 0; i < slots.Length; i++)
        {
            SpawnAtSlot(i);
        }
    }

    //  랜덤 프리팹을 해당 슬롯에 생성
    void SpawnAtSlot(int index)
    {
        int r = Random.Range(0, trashPrefabs.Length);  // 랜덤으로 0~3 뽑기
        GameObject prefab = trashPrefabs[r];

        GameObject obj = Instantiate(prefab, slots[index].position, Quaternion.identity);
        trashList.Insert(index, obj);
    }

    // 첫 번째 쓰레기 제거 + 쉬프트
    public void RemoveFirst()
    {
        Destroy(trashList[0]);
        trashList.RemoveAt(0);

        // 위로 이동 (남아있는 쓰레기 슬롯 위치 맞추기)
        for (int i = 0; i < trashList.Count; i++)
        {
            trashList[i].transform.position = slots[i].position;
        }

        // 맨 아래 슬롯에 새 쓰레기 생성
        SpawnAtSlot(trashList.Count);
    }

    // 현재 첫 번째 쓰레기 가져오기
    public Trash_SIM GetFirstTrash()
    {
        return trashList[0].GetComponent<Trash_SIM>();
    }
}
