using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EnableFirstChildCamera();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnableFirstChildCamera()
    {
        // Get the first child object of type Camera
        Camera childCamera = GetComponentInChildren<Camera>();

        // If a camera component is found, enable it
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
