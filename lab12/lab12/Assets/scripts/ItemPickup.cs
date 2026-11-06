using UnityEngine;
using System;

public class ItemPickup : MonoBehaviour {
    public static event Action<string> OnItemCollected;

    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            OnItemCollected?.Invoke("Магічний кристал");
        }
    }
}