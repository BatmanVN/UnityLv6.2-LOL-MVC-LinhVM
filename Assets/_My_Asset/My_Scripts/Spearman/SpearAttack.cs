using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearAttack : MonoBehaviour
{
    [SerializeField] protected SpearController spear;
    [SerializeField] protected Health playerHealth;
    protected GameObject targetPlayer;
    private void Update()
    {
        if (spear.Player != null)
        {
            targetPlayer = spear.Player.gameObject;
            playerHealth = targetPlayer.GetComponent<Health>();
        }
    }
    public void AttackPlayer()
    {
        playerHealth.TakeDame(targetPlayer,spear.Dame);
    }
}
