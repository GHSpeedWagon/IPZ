using UnityEngine;

public class ItemUI : MonoBehaviour {
    private void OnEnable() {
        ItemPickup.OnItemCollected += ShowItemNotification;
    }

    private void OnDisable() {
        ItemPickup.OnItemCollected -= ShowItemNotification;
    }

    void ShowItemNotification(string itemName) {
        Debug.Log("UI: Ви підібрали предмет - " + itemName);
    }
}