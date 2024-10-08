using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : Istate<PlayerController>
{
    public void OnEnter(PlayerController player)
    {
        player.MoveAnim(ConstString.moveParaname, 0f, player.SmothTime);
    }

    public virtual void OnExercute(PlayerController player)
    {
        if (player.Target != null)
        {
            player.ChangeState(new RunState());
            player.MoveToPoint(player.Target.transform.position);
        }
        if (player.CheckSpeedMovement() <= 0)
        {
            player.MoveAnim(ConstString.moveParaname, 0f, player.SmothTime);
            if (player.isAttack && !player.isSkill)
            {
                player.ChangeState(new DefaultAttackState());
            }
            if (player.CurrentSkill == 1 || player.CurrentSkill == 2 || player.CurrentSkill == 3)
            {
                player.ChangeState(new SkillState());
            }
            if (player.CharacterHealth.beAttack)
            {
                player.ChangeState(new HitState());
            }
        }
        if (player.CheckSpeedMovement() > 0)
        {
            player.ChangeState(new RunState());
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
