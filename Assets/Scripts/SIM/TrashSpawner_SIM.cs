using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner_SIM : MonoBehaviour
{
    public static TrashSpawner_SIM Instance;

    public Transform[] slots;            // 슬롯 0~3 위치
    public GameObject[] trashPrefabs;    // 음식/플라스틱/캔/종이 프리팹 (4개)

    private List<GameObject> trashList = new List<GameObject>();

    private bool isMoving = false;       // 이동 중이면 true

    private void Awake()
    {
        Instance = this;
    }

    // 처음 4개 생성
    public void InitTrash()
    {
        trashList.Clear();

        for (int i = 0; i < slots.Length; i++)
        {
            SpawnAtSlot(i);
        }
    }

    // 특정 슬롯 위치에 생성하되 리스트는 뒤에 추가만 한다
    void SpawnAtSlot(int index)
    {
        int r = Random.Range(0, trashPrefabs.Length);
        GameObject prefab = trashPrefabs[r];

        GameObject obj = Instantiate(prefab, slots[index].position, Quaternion.identity);

        // ⚠ Insert(index) 절대 금지 — 충돌의 원인
        trashList.Add(obj);
    }

    // 첫 번째 쓰레기 제거 + 쉬프트
    public void RemoveFirst()
    {
        // 이동 중에는 입력 무시
        if (isMoving) return;

        // 리스트 비어있는 상태 방지
        if (trashList.Count == 0) return;

        Destroy(trashList[0]);
        trashList.RemoveAt(0);

        StartCoroutine(MoveTrashRoutine());
    }

    // 현재 첫 번째 쓰레기 가져오기
    public Trash_SIM GetFirstTrash()
    {
        if (trashList.Count == 0) return null;
        return trashList[0].GetComponent<Trash_SIM>();
    }

    IEnumerator MoveTrashRoutine()
    {
        isMoving = true;

        float duration = 0.1f;
        float t = 0;

        Vector3[] startPositions = new Vector3[trashList.Count];
        Vector3[] endPositions = new Vector3[trashList.Count];

        // 현재 위치와 목표 위치 저장
        for (int i = 0; i < trashList.Count; i++)
        {
            startPositions[i] = trashList[i].transform.position;
            endPositions[i] = slots[i].position;
        }

        // 부드럽게 이동
        while (t < 1f)
        {
            t += Time.deltaTime / duration;

            for (int i = 0; i < trashList.Count; i++)
            {
                trashList[i].transform.position =
                    Vector3.Lerp(startPositions[i], endPositions[i], Mathf.SmoothStep(0, 1, t));
            }

            yield return null;
        }

        // 이동이 끝나면 새로운 쓰레기 생성
        SpawnAtSlot(slots.Length - 1);

        isMoving = false;
    }
}
