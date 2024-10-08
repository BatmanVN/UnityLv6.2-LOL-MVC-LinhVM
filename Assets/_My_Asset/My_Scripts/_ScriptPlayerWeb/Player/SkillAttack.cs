using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttack : MonoBehaviour
{
    [SerializeField] protected PlayerController player;
    [SerializeField] protected Health health;
    [SerializeField] protected GameObject targetEnemy;
    [SerializeField] protected float dameSkill;
    private void Update()
    {
        if (player.Target != null)
        {
            targetEnemy = player.Target.gameObject;
            health = targetEnemy.GetComponent<Health>();
        }
    }
    public void AttackBySkill1()
    {
        if (targetEnemy != null)
        {
            if (Vector3.Distance(player.transform.position, targetEnemy.transform.position) < player.Agent.stoppingDistance)
            {
                dameSkill = player.Dame + 20;
                health.TakeDame(targetEnemy, dameSkill);
            }
        }
    }
    public void AttackSkill2()
    {
        player.bonusDame.SetActive(true);
        if (targetEnemy != null)
        {
            if (Vector3.Distance(player.transform.position, targetEnemy.transform.position) < player.Agent.stoppingDistance)
            {
                dameSkill = player.Dame + 30;
                health.TakeDame(targetEnemy, dameSkill);
            }
        }
    }
    public void EnableSkill2Vfx()
    {
        player.bonusDame.SetActive(true);
    }
    public void DisableVfxSkill2()
    {
        player.isSkill = false;
        player.bonusDame.SetActive(false);
    }
}
