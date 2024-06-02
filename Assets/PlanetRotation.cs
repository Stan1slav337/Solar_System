using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public float axialTilt = 23.44f;

    void Start()
    {
        transform.rotation = Quaternion.Euler(axialTilt, 0, 0) * transform.rotation;
    }

    void Update()
    {
        float direction = Mathf.Sign(rotationSpeed);

        transform.Rotate(Vector3.up, Mathf.Abs(rotationSpeed) * Time.deltaTime * direction, Space.Self);
    }
}
