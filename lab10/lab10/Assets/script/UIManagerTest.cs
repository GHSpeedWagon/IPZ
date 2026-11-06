using UnityEngine;

public class UIManagerTest : MonoBehaviour {
    private void Start() {
        AudioManager.Instance.PlayBackgroundMusic();
        
        GameManager.Instance.AddScore(15);
        GameManager.Instance.AddScore(35);
        
        Debug.Log($"UIManager: Підсумковий рахунок на екрані = {GameManager.Instance.Score}");
    }
}