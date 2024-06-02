using UnityEngine;

public class OrthographicCameraControl : MonoBehaviour
{
    public float speed = 5.0f;

    public Camera myCamera; 

    void Start()
    {
        myCamera = GetComponent<Camera>(); 
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
