using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraControl : MonoBehaviour
{
    [SerializeField] protected GameObject mobile;
    [SerializeField] protected GameObject webGl;
    [SerializeField] protected Transform playerWeb;
    [SerializeField] protected Transform playerMobile;
    [SerializeField] protected CinemachineVirtualCamera virtualCamera;
    public bool active;

    public void CheckVersion()
    {
        bool status = active;
        if (active)
        {
            mobile.SetActive(status);
            virtualCamera.Follow = playerMobile;
            webGl.SetActive(!status);
        }
        else
        {
            mobile.SetActive(status);
            virtualCamera.Follow = playerWeb;
            webGl.SetActive(!status);
        }
    }
    private void Update()
    {
        CheckVersion();
    }
}
