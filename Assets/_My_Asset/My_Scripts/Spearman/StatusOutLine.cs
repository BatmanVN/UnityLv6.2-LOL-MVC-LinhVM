using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusOutLine : MonoBehaviour
{
    [SerializeField] protected Outline outline;

    private void Start()
    {
        outline.enabled = false;
    }
}
