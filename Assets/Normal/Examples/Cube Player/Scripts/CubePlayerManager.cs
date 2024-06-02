﻿#if NORMCORE

using UnityEngine;

namespace Normal.Realtime.Examples {
    public class CubePlayerManager : MonoBehaviour {
        [SerializeField] private GameObject _prefab;
        
        private Realtime _realtime;
        private GameObject _localPlayer;

        private void Awake() {
            // Get the Realtime component on this game object
            _realtime = GetComponent<Realtime>();

            // Notify us when Realtime successfully connects to the room
            _realtime.didConnectToRoom += DidConnectToRoom;
        }

        private void DidConnectToRoom(Realtime realtime) {
            // Instantiate the CubePlayer for this client once we've successfully connected to the room. Position it 1 meter in the air.
            var options = new Realtime.InstantiateOptions {
                ownedByClient            = true,    // Make sure the RealtimeView on this prefab is owned by this client.
                preventOwnershipTakeover = true,    // Prevent other clients from calling RequestOwnership() on the root RealtimeView.
                useInstance              = realtime // Use the instance of Realtime that fired the didConnectToRoom event.
            };
            _localPlayer = Realtime.Instantiate(_prefab.name, new Vector3(10, 0, -10), Quaternion.identity, options);
            Debug.LogWarning("Instantiat");
        }

        // Method to get the reference to the local player
        public GameObject GetLocalPlayer() {
            return _localPlayer;
        }
    }
}

#endif
