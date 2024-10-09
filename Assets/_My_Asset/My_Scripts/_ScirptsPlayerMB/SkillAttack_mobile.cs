using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttack_mobile : Singleton<SkillAttack_mobile>
{
    [SerializeField] protected PlayerController_Mobile player;
    [SerializeField] protected Health health;
    [SerializeField] protected GameObject targetEnemy;
    [SerializeField] protected float dameSkill;
    [SerializeField] protected AudioSource[] audios;
    private float caculaterDirection;
    public Skill1_mobile skill1;
    public Skill2_mobile skill2;
    public Skill3_mobile skill3;
    public bool isCastSkill;
    private void Update()
    {
        if (player.Target != null)
        {
            targetEnemy = player.Target.gameObject;
            health = targetEnemy.GetComponent<Health>();
        }
        StatusSkill();
    }
    protected void AttackBySkill1()
    {
        if (targetEnemy != null)
        {
            AttackCondition(targetEnemy.transform);
            if (Vector3.Distance(player.transform.position, targetEnemy.transform.position) <= player.MinDistance && caculaterDirection > 0.9f)
            {
                dameSkill = player.Dame + 20;
                health.TakeDame(targetEnemy, dameSkill);
            }
        }
    }
    protected void AttackSkill2()
    {
        player.fireSkill.SetActive(true);
        if (targetEnemy != null)
        {
            AttackCondition(targetEnemy.transform);
            if (Vector3.Distance(player.transform.position,targetEnemy.transform.position) <= player.MinDistance && caculaterDirection > 0.9f)
            {
                dameSkill = player.Dame + 30;
                health.TakeDame(targetEnemy, dameSkill);
            }
        }
    }
    private void AttackCondition(Transform target)
    {
        Vector3 playerAngle = player.transform.TransformDirection(Vector3.forward);
        Vector3 direction = Vector3.Normalize(playerAngle - target.transform.position);
        caculaterDirection = Vector3.Dot(playerAngle, direction);
    }
    public void StatusSkill()
    {
        if (!player.CharaterHealth.dead)
        {
            if (!skill1.isClick && !skill1.IsSkillCD)
            {
                if (skill1.castSkill)
                {
                    RectTransform skillCanvas = skill1.Skill.GetComponent<RectTransform>();
                    player.transform.rotation = skillCanvas.transform.rotation;
                    player.ChangeAnim(ConstString.kickParaname);
                    skill1.castSkill = false;
                    skill1.IsSkillCD = true;
                    audios[0].Play();
                }
            }
            if (!skill2.isClick && !skill2.IsSkillCD)
            {
                if (skill2.castSkill)
                {
                    RectTransform skillCanvas = skill2.Skill.GetComponent<RectTransform>();
                    player.transform.rotation = skillCanvas.transform.rotation;
                    player.ChangeAnim(ConstString.swordParaname);
                    skill2.castSkill = false;
                    skill2.IsSkillCD = true;
                    audios[1].Play();
                }
            }
            if (skill3.isSkill3)
            {
                player.ChangeAnim(ConstString.powerUpParaname);
                player.BlessGod.SetActive(true);
                player.BonusDame.SetActive(true);
                skill3.isSkill3 = false;
                skill3.IsSkillCD = true;
                Invoke(nameof(DisableVFXBonusDame), 10f);
                audios[2].Play();
            }
        }
    }
    public void AttackSkill3()
    {
        player.CharaterHealth.Healing(player.gameObject, player.HealAmount);
    }
    public void CastSkill1()
    {
        player.kickSkill.SetActive(true);
    }
    public void DeCastSkill1()
    {
        player.kickSkill.SetActive(false);
        isCastSkill = false;
    }
    public void DisableVfxSkill2()
    {
        player.fireSkill.SetActive(false);
        isCastSkill = false;
    }
    public void DisableVfxSkill3()
    {
        player.BlessGod.SetActive(false);
        isCastSkill = false;
    }
    protected void DisableVFXBonusDame()
    {
        player.BonusDame.SetActive(false);
    }
}
