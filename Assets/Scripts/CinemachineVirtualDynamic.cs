using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineVirtualDynamic : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    void Start()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        if (cinemachineVirtualCamera == null)
        {
            Debug.LogError("CinemachineVirtualDynamic script requires a CinemachineVirtualCamera component.");
            return;
        }

        cinemachineVirtualCamera.m_Lens.NearClipPlane = -1;

        
    }
}
