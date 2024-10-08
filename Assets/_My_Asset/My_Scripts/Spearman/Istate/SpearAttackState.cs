using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearAttackState : Istate<SpearController>
{
    public void OnEnter(SpearController spear)
    {

    }

    public void OnExercute(SpearController spear)
    {
        if (spear.isAttack && !spear.Player.GetComponent<Health>().dead && spear.Player != null)
        {
            spear.ChangeAnimBool(ConstString.attackParaname,true);
            spear.isAttack = false;
            if (spear.CharacterHealth.dead)
            {
                spear.ChangeAnimBool(ConstString.attackParaname, false);
                spear.ChangeState(new SpearDeathState());
            }
        }
        else if (spear.isMoving && !spear.isAttack)
        {
            spear.ChangeAnimBool(ConstString.attackParaname, false);
            spear.ChangeState(new SpearRunIstate());
        }
        else if (spear.Player.GetComponent<Health>().dead)
        {
            spear.ChangeAnimBool(ConstString.attackParaname, false);
            spear.ChangeState(new SpearIdleState());
        }
    }

    public void OnExit(SpearController spear)
    {

    }
}
