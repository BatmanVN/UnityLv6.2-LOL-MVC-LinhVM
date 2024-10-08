using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DFAttack : MonoBehaviour
{
    [SerializeField] protected PlayerController_Mobile player;
    [SerializeField] protected Health health;
    [SerializeField] protected float radius;
    public bool isClick;
    public GameObject targetEnemy;
    public void Attack()
    {
        player.isAttack = true;
        isClick = true;
    }
    public void SetBackAttack()
    {
        player.isAttack = false;
        isClick = false;
    }
    public void StatusAttack()
    {
        if (player.isAttack && isClick)
        {
            player.ChangeAnimBool(ConstString.defaultAttack, true);
        }
        if(!player.isAttack && !isClick)
        {
            player.ChangeAnimBool(ConstString.defaultAttack, false);
        }
    }
    public void EnemyTakedame()
    {
        if(targetEnemy != null)
            health.TakeDame(targetEnemy, player.Dame);
    }
    private void Update()
    {
        if (player.Target != null)
        {
            targetEnemy = player.Target.gameObject;
            health = targetEnemy.GetComponent<Health>();
        }
        StatusAttack();
    }
}
