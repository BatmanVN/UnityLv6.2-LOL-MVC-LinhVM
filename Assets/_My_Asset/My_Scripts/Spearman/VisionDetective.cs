using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionDetective : MonoBehaviour
{
    public bool isDetected;
    private void OnTriggerEnter(Collider vision)
    {
        if (vision.CompareTag(ConstString.playerTag))
        {
            isDetected = true;
        }
    }
    private void OnTriggerExit(Collider visison)
    {
        if (visison.CompareTag(ConstString.playerTag))
        {
            isDetected = false;
        }
    }
}
