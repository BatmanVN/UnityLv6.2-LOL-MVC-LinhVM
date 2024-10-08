using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkill : MonoBehaviour
{
    [SerializeField] private GameObject sword;
    private void Start()
    {
        if (this != null)
        {
            transform.rotation = sword.transform.rotation;
        }
    }
}
