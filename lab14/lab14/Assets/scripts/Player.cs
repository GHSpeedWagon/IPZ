using UnityEngine;

public interface IState {
    void Enter();
    void Update();
    void Exit();
}

public class IdleState : IState {
    public void Enter() {
        Debug.Log("Enter: Idle");
    }
    
    public void Update() {
        Debug.Log("Update: Standing still...");
    }
    
    public void Exit() {
        Debug.Log("Exit: Idle");
    }
}

public class RunState : IState {
    public void Enter() {
        Debug.Log("Enter: Run");
    }
    
    public void Update() {
        Debug.Log("Update: Running forward...");
    }
    
    public void Exit() {
        Debug.Log("Exit: Run");
    }
}

public class JumpState : IState {
    public void Enter() {
        Debug.Log("Enter: Jump");
    }
    
    public void Update() {
        Debug.Log("Update: Jumping in the air...");
    }
    
    public void Exit() {
        Debug.Log("Exit: Jump");
    }
}

public class Player : MonoBehaviour {
    private IState currentState;

    void Start() {
        SetState(new IdleState());
    }

    public void SetState(IState newState) {
        if (currentState != null) {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.W)) {
            SetState(new RunState());
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            SetState(new JumpState());
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            SetState(new IdleState());
        }
        
        if (currentState != null) {
            currentState.Update();
        }
    }
}