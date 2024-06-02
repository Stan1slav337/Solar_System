using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCamera : MonoBehaviour
{
    void Start()
    {
        EnableFirstChildCamera();
    }

    void Update()
    {
        
    }

    void EnableFirstChildCamera()
    {
        Camera childCamera = GetComponentInChildren<Camera>();

        if (childCamera != null)
        {
            childCamera.enabled = true;
            Debug.LogWarning("Enabled camera");
        }
        else
        {
            Debug.LogWarning("No child camera found on " + gameObject.name);
        }
    }
}
