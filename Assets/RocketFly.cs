using UnityEngine;
using Normal.Realtime;

public class FlyCamControl : MonoBehaviour
{
    public float speed = 5.0f;
    public Camera rocketCamera;
    private RealtimeView _realtimeView;

    private void Awake()
    {
        _realtimeView = GetComponent<RealtimeView>();
    }

    void Update()
    {
        if (_realtimeView.isOwnedLocallySelf && rocketCamera.enabled)
        {
            float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            float moveY = 0;

            if (Input.GetKey(KeyCode.Space))
            {
                moveY = speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                moveY = -speed * Time.deltaTime;
            }

            transform.Translate(moveX, moveY, moveZ);

            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(Vector3.up, -90 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(Vector3.up, 90 * Time.deltaTime);
            }
        }
    }
}