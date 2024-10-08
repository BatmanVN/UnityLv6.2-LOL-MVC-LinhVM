using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearDeathState : Istate<SpearController>
{
    public void OnEnter(SpearController spear)
    {
        spear.ChangeAnim(ConstString.dieParaname);
        spear.enabled = false;
        spear.coliider.isTrigger = true;
        spear.Agent.enabled = false;
        spear.healthBar.SetActive(false);
        foreach (var component in spear.Compenents)
        {
            component.enabled = false;
        }
    }

    public void OnExercute(SpearController spear)
    {

    }

    public void OnExit(SpearController spear)
    {

    }
}
