using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipticalOrbit : MonoBehaviour
{
    public Transform sun; // Reference to the Sun (or Earth for the Moon's orbit)
    public float semiMajorAxis = 10f; // Semi-major axis of the ellipse
    public float semiMinorAxis = 9.8f; // Semi-minor axis of the ellipse
    public float orbitalPeriod = 365f; // Orbital period in days

    private Vector3 initialPosition;
    private float angle; // Current angle in radians

    void Start()
    {
        // Store the initial position of the object relative to the pivot
        initialPosition = transform.position - sun.position;
        semiMajorAxis = initialPosition.z;
        semiMinorAxis = initialPosition.z * 0.95f;

        // Calculate the initial angle based on the initial position
        angle = Mathf.Atan2(initialPosition.z / semiMinorAxis, initialPosition.x / semiMajorAxis);
    }

    void Update()
    {
        // Calculate the angle based on the time and orbital period
        angle += 2 * Mathf.PI / orbitalPeriod * Time.deltaTime;

        // Calculate the position in polar coordinates relative to the initial position
        float x = semiMajorAxis * Mathf.Cos(angle);
        float z = semiMinorAxis * Mathf.Sin(angle);

        // Set the position relative to the Sun
        transform.position = new Vector3(x, 0, z) + sun.position;
    }
}
