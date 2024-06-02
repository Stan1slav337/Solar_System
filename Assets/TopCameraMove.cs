using UnityEngine;

public class OrthographicCameraControl : MonoBehaviour
{
    public float speed = 5.0f;  // Speed of camera movement

    public Camera myCamera;  // To hold a reference to the Camera component

    void Start()
    {
        myCamera = GetComponent<Camera>();  // Get the Camera component attached to the same GameObject
    }
    
    void Update()
    {
        if (myCamera != null && myCamera.enabled)
        {
            float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

            transform.Translate(moveX, moveY, 0);
        }
    }
}
