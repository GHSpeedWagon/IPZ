using UnityEngine;
using System;

public class Player : MonoBehaviour {
    public static event Action<int> OnHealthChanged;
    
    private int health = 100;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int amount) {
        health -= amount;
        OnHealthChanged?.Invoke(health);
    }
}