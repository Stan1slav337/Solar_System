using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonOrbit : MonoBehaviour
{
    public Transform earth;
    public float semiMajorAxis = 2f;
    public float semiMinorAxis = 1.8f;
    public float orbitalPeriod = 27.3f;

    private Vector3 initialPosition;
    private float angle;

    void Start()
    {
        initialPosition = transform.position - earth.position;

        angle = Mathf.Atan2(initialPosition.z / semiMinorAxis, initialPosition.x / semiMajorAxis);
    }

    void Update()
    {
        angle += 2 * Mathf.PI / orbitalPeriod * Time.deltaTime;

        float x = semiMajorAxis * Mathf.Cos(angle);
        float z = semiMinorAxis * Mathf.Sin(angle);

        transform.position = new Vector3(x, 0, z) + earth.position;
    }
}
