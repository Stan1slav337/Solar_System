using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipticalOrbit : MonoBehaviour
{
    public Transform sun;
    public float semiMajorAxis = 10f;
    public float semiMinorAxis = 9.8f;
    public float orbitalPeriod = 365f;

    private Vector3 initialPosition;
    private float angle;

    void Start()
    {
        initialPosition = transform.position - sun.position;
        semiMajorAxis = initialPosition.z;
        semiMinorAxis = initialPosition.z * 0.95f;

        angle = Mathf.Atan2(initialPosition.z / semiMinorAxis, initialPosition.x / semiMajorAxis);
    }

    void Update()
    {
        angle += 2 * Mathf.PI / orbitalPeriod * Time.deltaTime;

        float x = semiMajorAxis * Mathf.Cos(angle);
        float z = semiMinorAxis * Mathf.Sin(angle);

        transform.position = new Vector3(x, 0, z) + sun.position;
    }
}
