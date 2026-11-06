using UnityEngine;

public class GameLogger : MonoBehaviour {
    private void OnEnable() {
        ItemPickup.OnItemCollected += LogEvent;
    }

    private void OnDisable() {
        ItemPickup.OnItemCollected -= LogEvent;
    }

    void LogEvent(string itemName) {
        Debug.Log("Log: Запис у статистику. Зібрано предмет: " + itemName);
    }
}