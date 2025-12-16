using UnityEngine;
using System.Collections;

public class TrashSpawner_NA : MonoBehaviour
{
    public GameObject[] trashPrefabs;
    public float spawnInterval = 1.5f;
    public float spawnY = 4.8f;

    [Header("Wall Settings")]
    public float wallPadding = 3.5f; // 벽 두께 + 여유 (중요)

    private float timer;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (!GameManager_NA.Instance.isGameStart)
            return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnTrash();
            timer = 0f;
            spawnInterval = Mathf.Max(0.4f, spawnInterval - 0.02f);
        }
    }

    void SpawnTrash()
    {
        // 화면 왼쪽/오른쪽 월드 좌표 구하기
        float leftX = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float rightX = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        // 벽 영역 제외
        float minX = leftX + wallPadding;
        float maxX = rightX - wallPadding;

        float x = Random.Range(minX, maxX);
        Vector3 pos = new Vector3(x, spawnY, 0);

        Instantiate(
            trashPrefabs[Random.Range(0, trashPrefabs.Length)],
            pos,
            Quaternion.identity
        );
    }
}
