using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    public Pathfinder finder;
    public Transform target;
    public float moveSpeed = 3f;

    List<Cell> path;
    int index;
    Vector2 lastTargetPos;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0;
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (path == null || Vector2.Distance(lastTargetPos, target.position) > 0.5f)
        {
            path = finder.GetPath(transform.position, target.position);
            index = 0;
            lastTargetPos = target.position;
        }
    }

    void FixedUpdate()
    {
        if (path == null || index >= path.Count)
            return;

        Vector2 next = path[index].pos;

        Vector2 newPos = Vector2.MoveTowards(
            rb.position,
            next,
            moveSpeed * Time.fixedDeltaTime
        );

        rb.MovePosition(newPos);

        if (Vector2.Distance(rb.position, next) < 0.05f)
            index++;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Camera.main.GetComponent<CameraShake>()?.Shake();
            StartCoroutine(GameOverDelay());
        }
    }

    IEnumerator GameOverDelay()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        HANUIManager.instance.GameOver();
    }

}
