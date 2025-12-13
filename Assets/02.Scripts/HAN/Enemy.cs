using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public Pathfinder finder;
    public Transform target;
    public float moveSpeed = 3f;

    List<Cell> path;
    int index;
    Vector2 lastTargetPos;

    void Update()
    {
        if (path == null || Vector2.Distance(lastTargetPos, target.position) > 0.5f)
        {
            path = finder.GetPath(transform.position, target.position);
            index = 0;
            lastTargetPos = target.position;
        }

        if (path == null || index >= path.Count)
            return;

        Vector2 next = path[index].pos;

        transform.position = Vector2.MoveTowards(
            transform.position,
            next,
            moveSpeed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, next) < 0.05f)
            index++;
    }
}
