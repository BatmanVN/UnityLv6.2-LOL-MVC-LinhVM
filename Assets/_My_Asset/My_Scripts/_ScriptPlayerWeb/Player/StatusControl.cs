using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusControl : MonoBehaviour
{
    [SerializeField] protected PlayerController playerController;
    protected virtual void LockControl()
    {
        playerController.enabled = false;
        playerController.Agent.isStopped = true;
    }
    protected virtual void UnlockLockControl()
    {
        playerController.enabled = true;
        playerController.Agent.isStopped = false;
    }
    private void Start()
    {

    }
}
