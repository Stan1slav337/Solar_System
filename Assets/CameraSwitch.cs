using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera topDownCamera;
    public Camera mainCamera = null;
    public bool cameraWasSet = false;

    void Update()
    {
        if(!cameraWasSet)
        {
            mainCamera = Camera.main;
            if(mainCamera == null)
            {
                return;
            }
            else
            {
                cameraWasSet = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (mainCamera.enabled)
            {
                mainCamera.enabled = false;
                topDownCamera.enabled = true;
            }
            else
            {
                mainCamera.enabled = true;
                topDownCamera.enabled = false;
            }
        }
    }
}
