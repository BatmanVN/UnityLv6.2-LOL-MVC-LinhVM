using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DFAttack : MonoBehaviour
{
    [SerializeField] protected PlayerController_Mobile player;
    [SerializeField] protected Health health;
    [SerializeField] protected float radius;
    [SerializeField] protected AudioSource slashAudio;
    private float caculaterDirection;
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
        if(!player.isAttack && !isClick || SkillAttack_mobile.Instance.isCastSkill || player.CharaterHealth.dead)
        {
            player.ChangeAnimBool(ConstString.defaultAttack, false);
        }
    }
    public void EnemyTakedame()
    {
        float attackDistance = 0f;
        if (player.Target != null)
        {
            attackDistance = Vector3.Distance(transform.position, player.Target.transform.position);
            AttackCondition(player.Target);
        }
        if (targetEnemy != null && attackDistance <= player.MinDistance && caculaterDirection >0.9f)
            health.TakeDame(targetEnemy, player.Dame);
    }
    private void AttackCondition(Transform target)
    {
        Vector3 playerAngle = player.transform.TransformDirection(Vector3.forward);
        Vector3 direction = Vector3.Normalize(playerAngle - target.transform.position);
        caculaterDirection = Vector3.Dot(playerAngle, direction);
    }
    public void EnableSound()
    {
        slashAudio.Play();
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
