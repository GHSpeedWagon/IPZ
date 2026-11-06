using UnityEngine;

public class AudioManager : MonoBehaviour {
    private void OnEnable() {
        Player.OnHealthChanged += PlayDamageSound;
    }

    private void OnDisable() {
        Player.OnHealthChanged -= PlayDamageSound;
    }

    void PlayDamageSound(int currentHealth) {
        Debug.Log("Audio: Відтворення звуку отримання шкоди!");
    }
}