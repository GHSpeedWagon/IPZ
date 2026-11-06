using UnityEngine;

public interface IInputController {
    Vector2 GetMovementDirection();
    bool IsAttackPressed();
}

public class OldInputSystem {
    public float GetHorizontalAxis() {
        return Input.GetAxis("Horizontal");
    }

    public float GetVerticalAxis() {
        return Input.GetAxis("Vertical");
    }

    public bool CheckSpacebar() {
        return Input.GetKeyDown(KeyCode.Space);
    }
}

public class InputAdapter : IInputController {
    private OldInputSystem oldSystem = new OldInputSystem();

    public Vector2 GetMovementDirection() {
        float x = oldSystem.GetHorizontalAxis();
        float y = oldSystem.GetVerticalAxis();
        return new Vector2(x, y);
    }

    public bool IsAttackPressed() {
        return oldSystem.CheckSpacebar();
    }
}

public interface IAudioService {
    void PlayEffect(string effectName);
}

public class UnityAudioService : IAudioService {
    public void PlayEffect(string effectName) {
        Debug.Log($"UnityAudio: Відтворення ефекту {effectName}");
    }
}

public class ExternalFMODSystem {
    public void TriggerFMODEvent(string eventPath) {
        Debug.Log($"FMOD: Відтворення події за шляхом {eventPath}");
    }
}

public class FMODAdapter : IAudioService {
    private ExternalFMODSystem fmodSystem = new ExternalFMODSystem();

    public void PlayEffect(string effectName) {
        fmodSystem.TriggerFMODEvent($"event:/effects/{effectName}");
    }
}

public class GameManager : MonoBehaviour {
    private IInputController inputController;
    private IAudioService audioService;

    void Start() {
        inputController = new InputAdapter();
        audioService = new FMODAdapter();
    }

    void Update() {
        Vector2 movement = inputController.GetMovementDirection();
        if (movement != Vector2.zero) {
            Debug.Log($"Рух гравця: {movement}");
        }

        if (inputController.IsAttackPressed()) {
            Debug.Log("Гравець атакує!");
            audioService.PlayEffect("sword_swing");
        }
    }
}