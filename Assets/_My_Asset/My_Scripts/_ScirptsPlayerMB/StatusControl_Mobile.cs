using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusControl_Mobile : MonoBehaviour
{
    [SerializeField] protected PlayerController_Mobile playerController;
    protected virtual void LockControl()
    {
        playerController.enabled = false;
        //playerController.Agent.isStopped = true;
    }
    protected virtual void UnlockLockControl()
    {
        playerController.enabled = true;
        //playerController.Agent.isStopped = false;
    }
    private void Start()
    {

    }
}
