using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultAttackState : Istate<PlayerController>
{
    public void OnEnter(PlayerController player)
    {

    }

    public void OnExercute(PlayerController player)
    {
        if (player.isAttack && !player.Target.GetComponent<Health>().dead && !player.isSkill)
        {
            player.ChangeAnimBool(ConstString.attackParaname, true);
        }
        if (player.isSkill)
        {
            player.ChangeAnimBool(ConstString.attackParaname, false);
            player.ChangeState(new IdleState());
        }
        if (player.isMoving && !player.isAttack)
        {
            player.ChangeAnimBool(ConstString.attackParaname, false);
            player.ChangeState(new RunState());
        }
        if (player.CharacterHealth.dead)
        {
            player.ChangeAnimBool(ConstString.attackParaname, false);
            player.ChangeState(new DeathState());
        }
        if (player.Target != null && player.Target.GetComponent<Health>().dead)
        {
            player.ChangeAnimBool(ConstString.attackParaname, false);
            player.ChangeState(new IdleState());
        }
    }

    public void OnExit(PlayerController player)
    {

    }
}
