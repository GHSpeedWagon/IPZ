using UnityEngine;
using System;

public class HealthUI : MonoBehaviour {
    private void OnEnable() {
        Player.OnHealthChanged += UpdateHealth;
    }

    private void OnDisable() {
        Player.OnHealthChanged -= UpdateHealth;
    }

    void UpdateHealth(int value) {
        Debug.Log("UI: Здоров'я гравця оновлено. Поточне HP: " + value);
    }
}