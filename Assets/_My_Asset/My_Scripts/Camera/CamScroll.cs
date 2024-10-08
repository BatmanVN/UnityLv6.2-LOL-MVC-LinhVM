using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScroll : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float camFov;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float mouseScrollInput;

    private void Start()
    {
        camFov = cam.fieldOfView;
    }
    private void Update()
    {
        mouseScrollInput = Input.GetAxis("Mouse ScrollWheel");

        camFov -= mouseScrollInput * zoomSpeed;
        camFov = Mathf.Clamp(camFov, 30, 60);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView,camFov,zoomSpeed);
    }
}
