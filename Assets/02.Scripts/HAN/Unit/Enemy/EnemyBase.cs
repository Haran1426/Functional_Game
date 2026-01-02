using System;
using UnityEngine;

public class EnemyBase : Unit
{
    [Header("Refs")]
    public Transform target;

    public Rigidbody2D RB { get; private set; }

    public event Action<Collision2D> OnHitPlayer;

    protected virtual void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            OnHitPlayer?.Invoke(collision);
    }

    public virtual void Despawn()
    {
        gameObject.SetActive(false);
    }
}
