using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunState : Istate<PlayerController>
{
    public void OnEnter(PlayerController player)
    {

    }

    public void OnExercute(PlayerController player)
    {
        if (player.CheckSpeedMovement() > 0)
        {
            player.MoveAnim(ConstString.moveParaname, player.CheckSpeedMovement(), player.SmothTime);

        }
        if (player.CheckSpeedMovement() <= 0)
        {
            player.ChangeState(new IdleState());
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
