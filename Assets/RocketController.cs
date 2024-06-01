using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Normal.Realtime;

namespace Normal.Realtime.Examples {
    public class RocketController : MonoBehaviour
    {
        private CubePlayerManager _playerManager;
        private RealtimeView _realtimeView;

        private Slider zoomSliderComponent; // This will be assigned dynamically
        private ZoomSlider zoomSliderScript; // Reference to ZoomSlider script

        private void Awake() {
            _realtimeView = GetComponent<RealtimeView>();
        }

        private void Start() {
            // Find the CubePlayerManager component in the scene
            _playerManager = FindObjectOfType<CubePlayerManager>();

            // Get the reference to the local player instance
            GameObject localPlayer = _playerManager.GetLocalPlayer();

            // Do something with the local player instance
            if (localPlayer != null) {
                
            }

            if (_realtimeView.isOwnedLocallySelf) {
                Camera childCamera = GetComponentInChildren<Camera>();

                if (childCamera != null) {
                    childCamera.enabled = true;

                    GameObject zoomSliderObject = GameObject.FindWithTag("ZoomSlider");
                    if (zoomSliderObject != null) {
                        zoomSliderComponent = zoomSliderObject.GetComponent<Slider>();
                        zoomSliderScript = zoomSliderObject.GetComponent<ZoomSlider>();

                        if (zoomSliderComponent != null && zoomSliderScript != null) {
                            zoomSliderScript.cameraToMove = childCamera;
                            zoomSliderScript.enabled = true;
                        } else {
                            Debug.LogError("ZoomSlider component not found on the object.");
                        }
                    } else {
                        Debug.LogError("ZoomSlider object not found in the scene.");
                    }
                }
            } else {
                Camera childCamera = GetComponentInChildren<Camera>();

                if (childCamera != null) {
                    childCamera.enabled = false;
                }
            }
        }
    }
}