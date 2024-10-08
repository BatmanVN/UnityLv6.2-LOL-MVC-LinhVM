using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : Istate<PlayerController>
{
    public void OnEnter(PlayerController player)
    {
        
    }

    public void OnExercute(PlayerController player)
    {
        if (player.CharacterHealth.beAttack)
        {
            player.ChangeAnim(ConstString.hitParaname);
            player.CharacterHealth.beAttack = false;
        }
        if (player.CheckSpeedMovement() > 0)
        {
            player.ChangeState(new RunState());
        }
        if (player.isSkill)
        {
            player.ChangeState(new SkillState());
        }
        if (player.isAttack)
        {
            player.ChangeState(new DefaultAttackState());
        }
        if (player.CharacterHealth.dead)
        {
            player.ChangeState(new DeathState());
        }
    }

    public void OnExit(PlayerController player)
    {
        
    }

}
