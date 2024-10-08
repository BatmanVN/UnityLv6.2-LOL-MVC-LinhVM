using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearRunIstate : Istate<SpearController>
{
    public void OnEnter(SpearController spear)
    {

    }

    public void OnExercute(SpearController spear)
    {
        if (spear.SpeedMove() > 0)
        {
            spear.MoveAnim(ConstString.moveParaname, spear.SpeedMove(), spear.SmoothTime());
        }
        else if (spear.SpeedMove() <= 0)
        {
            spear.ChangeState(new SpearIdleState());
            if (spear.CharacterHealth.dead)
            {
                spear.ChangeState(new SpearDeathState());
            }
        }
    }

    public void OnExit(SpearController spear)
    {

    }
}
