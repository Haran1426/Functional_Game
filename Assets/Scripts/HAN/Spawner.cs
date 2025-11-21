using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class Spwaner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefab;

    [SerializeField]
    [Range(0, 500)]
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
            int index = Random.Range(0, prefab.Length);
            Instantiate(
                prefab[index],
                new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y)),
                Quaternion.identity
            );
            count++;
            Debug.Log(index + "가 생성되었습니다");

            yield return new WaitForSeconds(0.01f);
        }
    }
}
