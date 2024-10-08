using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleAttack : MonoBehaviour
{
    [SerializeField] protected PlayerController player;
    [SerializeField] protected Health health;
    public GameObject targetEnemy;

    private void Update()
    {
        if (player.Target != null)
        {
            targetEnemy = player.Target.gameObject;
            health = targetEnemy.GetComponent<Health>();
        }
    }
    public void AttackEnemy()
    {
        health.TakeDame(targetEnemy,player.Dame);
    }
}
