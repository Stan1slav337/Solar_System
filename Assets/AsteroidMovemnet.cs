using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public Vector3 moveDirection = new Vector3(-1, 0, 0);
    public float speed = 5.0f;

    void Update()
    {
        transform.Translate(moveDirection.normalized * speed * Time.deltaTime);
    }
}
