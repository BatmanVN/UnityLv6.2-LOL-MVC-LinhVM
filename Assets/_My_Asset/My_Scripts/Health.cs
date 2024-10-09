using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    [SerializeField] private float healthPoint;
    [SerializeField] protected UnityEvent onDie;
    public bool beAttack;
    public bool playerBeAttack;
    public UnityEvent<float, float> onHealthChanged;
    public bool dead => HealthPoint <= 0;

    protected float HealthPoint { get => healthPoint; set => healthPoint = value; }

    private void Start()
    {
        HealthPoint = maxHealth;
    }
    public void TakeDame(GameObject target ,float dame)
    {
        if (dead) return;
        target.GetComponent<Health>().HealthPoint -= dame;
        onHealthChanged?.Invoke(target.GetComponent<Health>().HealthPoint, target.GetComponent<Health>().maxHealth);
        beAttack = true;
    }

    public void Healing(GameObject target ,float healAmount)
    {
        if (HealthPoint >= maxHealth) return;
        HealthPoint += healAmount;
        onHealthChanged?.Invoke(target.GetComponent<Health>().HealthPoint, target.GetComponent<Health>().maxHealth);
    }
    //public void Die()
    //{
    //    onDie?.Invoke();
    //}
}
