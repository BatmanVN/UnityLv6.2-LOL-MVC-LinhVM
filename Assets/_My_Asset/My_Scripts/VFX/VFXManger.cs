using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManger : Singleton<VFXManger>
{
    public List<GameObject> vfx;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            vfx.Add(child.gameObject);
        }
    }
}
