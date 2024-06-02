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

        private Slider zoomSliderComponent; 
        private ZoomSlider zoomSliderScript;

        private void Awake() {
            _realtimeView = GetComponent<RealtimeView>();
        }

        private void Start() {
            _playerManager = FindObjectOfType<CubePlayerManager>();

            GameObject localPlayer = _playerManager.GetLocalPlayer();

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