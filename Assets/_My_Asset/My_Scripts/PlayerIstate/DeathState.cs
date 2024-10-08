using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : MonoBehaviour, Istate<PlayerController>
{
    public void OnEnter(PlayerController player)
    {
        player.ChangeAnim(ConstString.dieParaname);
        player.enabled = false;
        player.Invoke(nameof(EnableUILoseTime), 3f);
        foreach (var component in player.Compenents)
        {
            component.enabled = false;
        }
    }
    public void EnableUILoseTime()
    {
        UiManager.Instance.UiGames[1].SetActive(true);  
    }
    public void OnExercute(PlayerController player)
    {
    }

    public void OnExit(PlayerController player)
    {

    }
}
