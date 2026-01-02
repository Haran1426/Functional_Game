using UnityEngine;
using System;

public class Unit : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] protected float maxHp = 100f;
    [SerializeField] protected float currentHp;

    public float MaxHp => maxHp;
    public float CurrentHp => currentHp;
    public bool isDead => currentHp <= 0f;

    public event Action<Unit> OnDead;
    public event Action<float, float> OnHpChanged;

    protected virtual void Awake()
    {
        currentHp = MaxHp;
    }

    public virtual void TakeDamage(float damage)
    {
        currentHp -= damage;
        OnHpChanged?.Invoke(currentHp, maxHp);


        if (currentHp <= 0f) Die();
    }
    protected virtual void Die()
    {
        OnDead?.Invoke(this);
    }
    
    void Update()
    {
        
    }
}
