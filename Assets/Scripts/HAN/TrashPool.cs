using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class TrashPool : MonoBehaviour
{
    public static TrashPool instance;

    [SerializeField] private GameObject[] trashPrefabs;
    [SerializeField] private int poolSize = 50;

    private List<GameObject> pool = new List<GameObject>();


    void Start()
    {
        instance = this;
        CreatePool();
    }


    void Update()
    {
        
    }

    private void CreatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            var prefab = trashPrefabs[Random.Range(0, trashPrefabs.Length)];

            var obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetTrash()
    {
        foreach (var obj in pool)
        {
            if (!obj.activeSelf)
            {
                return obj;
            }
        }

        return null;
    }

    public void ReturnTrash(GameObject trash)
    {
        trash.SetActive(false);
    }
}
