using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSliderBar : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] protected Health health;
    [SerializeField] protected Slider healthValue;
    Transform cameraTransform;
   
    private void LateUpdate()
    {
        transform.LookAt(transform.position + cameraTransform.rotation * -Vector3.forward,cameraTransform.rotation * Vector3.up);
    }
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        health.onHealthChanged.AddListener(UpdateHp);
    }
    public void UpdateHp(float healthPoint, float maxHealthPoint)
    {

        healthValue.value = healthPoint / maxHealthPoint;
    }
}
