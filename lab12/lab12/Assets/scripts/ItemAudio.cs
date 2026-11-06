using UnityEngine;

public class ItemAudio : MonoBehaviour {
    private void OnEnable() {
        ItemPickup.OnItemCollected += PlayPickupSound;
    }

    private void OnDisable() {
        ItemPickup.OnItemCollected -= PlayPickupSound;
    }

    void PlayPickupSound(string itemName) {
        Debug.Log("Audio: Відтворення звуку підбору предмета!");
    }
}