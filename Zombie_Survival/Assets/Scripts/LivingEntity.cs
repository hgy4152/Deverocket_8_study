using System;
using UnityEngine;
using UnityEngine.Events;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public float startingHealth = 100f;
    public float Health {  get; private set; }
    public bool IsDead { get; private set; }
    public UnityEvent OnDead;

    protected virtual void OnEnable()
    {
        IsDead = false;
        Health = startingHealth;

    }
    public virtual void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        Health -= damage;
        Debug.Log("피격");
        if (Health <= 0) 
        {
            Health = 0;
            Die();
        }
    }

    public virtual void Die()
    {
        IsDead = true;
        OnDead?.Invoke();


    }

    public void Heal(int heal)
    {
        Health += heal;
        if (Health >= startingHealth)
        {
            Health = startingHealth;
        }
    }
}
