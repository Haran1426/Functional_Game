using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;


[System.Serializable]
public class Trash
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    [Range(0f, 50f)]
    private float chance = 0;

    public float weight { set; get; }
    public GameObject Prefab => prefab;
    public float Chance => chance;

}
public class Spwaner : MonoBehaviour
{
    [SerializeField] private Trash[] trashs;

    [SerializeField]
    [Range(0, 500)]
    private int maxItemcount = 100;
    [SerializeField]
    private Vector2 min = new Vector2(-8f, -4f);
    [SerializeField]
    private Vector2 max = new Vector2(8f, 4f);

    private float accumulatedweights;

    private void Awake()
    {
        calulateWeights();
    }

    private IEnumerator Start()
    {
        int count = 0;

        while (count < maxItemcount)
        {
            SpawnTrash(new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y)));
            count++;

            yield return new WaitForSeconds(0.01f);
        }
    }

    private void calulateWeights()
    {
        accumulatedweights = 0;
        foreach ( var trash in trashs)
        {
            accumulatedweights += trash.Chance;
            trash.weight = accumulatedweights;
        }

    }
    private void SpawnTrash(Vector2 position)
    {
        var clone = trashs[GetRandomIndex()];
        Instantiate(clone.Prefab, position, Quaternion.identity );
    }
    private int GetRandomIndex()
    {   
        float random = Random.value * accumulatedweights;

        for ( int i = 0; i < trashs.Length; ++i)
        {
            if (trashs[i].weight >= random) return i;
        }
        return 0;
    }

}
