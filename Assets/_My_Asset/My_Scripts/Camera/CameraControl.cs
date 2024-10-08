using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected Vector3 offSet;
    private void LateUpdate()
    {
        transform.position = target.position + offSet;
    }
}
