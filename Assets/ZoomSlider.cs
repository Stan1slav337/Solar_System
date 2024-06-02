using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomSlider : MonoBehaviour
{
    public Camera cameraToMove;
    public Camera topCamera;
    public Slider zoomSlider;
    public float minDistance = 0f;
    public float maxDistance = 100f;
    public float lastValue = 0f;

    private float initialDistance;

    void Start()
    {
        if (zoomSlider != null && cameraToMove != null && topCamera != null)
        {
            initialDistance = cameraToMove.transform.localPosition.z;

            zoomSlider.minValue = minDistance;
            zoomSlider.maxValue = maxDistance;
            zoomSlider.value = Mathf.Abs(initialDistance);
            lastValue = zoomSlider.value;

            zoomSlider.onValueChanged.AddListener(HandleZoom);
        }
    }

    void HandleZoom(float value)
    {
        Vector3 localPosition = cameraToMove.transform.localPosition;
        localPosition.z = -value;
        cameraToMove.transform.localPosition = localPosition;
        topCamera.orthographicSize -= value - lastValue;
        lastValue = value;
    }
}
