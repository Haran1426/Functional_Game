using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class Spwaner : MonoBehaviour
{
    [SerializeField] private GameObject prefab_1;
    [SerializeField] private GameObject prefab_2;
    [SerializeField] private GameObject prefab_3;

    [SerializeField]
    [Range(0, 1000)]
    private int maxItemcount = 100;
    [SerializeField]
    private Vector2 min = new Vector2(-8f, -4f);
    [SerializeField]
    private Vector2 max = new Vector2(8f, 4f);

    private IEnumerator Start()
    {
        int count = 0;

        while (count < maxItemcount)
        {
            Instantiate(
                prefab_1,
                new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y)),
                Quaternion.identity
            );
            count++;

            yield return new WaitForSeconds(0.05f);
        }
        count = 0;

        while (count < maxItemcount)
        {
            Instantiate(
                prefab_2,
                new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y)),
                Quaternion.identity
            );
            count++;

            yield return new WaitForSeconds(0.01f);
        }
        count = 0;

        while (count < maxItemcount)
        {
            Instantiate(
                prefab_3,
                new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y)),
                Quaternion.identity
            );
            count++;

            yield return new WaitForSeconds(0.01f);
        }
        count = 0;
    }
}
