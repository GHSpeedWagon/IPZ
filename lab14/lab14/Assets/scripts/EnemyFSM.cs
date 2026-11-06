using UnityEngine;

public interface IEnemyState {
    void Enter();
    void Update(EnemyFSM enemy);
    void Exit();
}

public class PatrolState : IEnemyState {
    public void Enter() {
        Debug.Log("PatrolState: Початок патрулювання.");
    }
    
    public void Update(EnemyFSM enemy) {
        if (enemy.distanceToPlayer <= 10f && enemy.distanceToPlayer > 2f) {
            enemy.SetState(new ChaseState());
        }
    }
    
    public void Exit() {
        Debug.Log("PatrolState: Завершення патрулювання.");
    }
}

public class ChaseState : IEnemyState {
    public void Enter() {
        Debug.Log("ChaseState: Початок переслідування.");
    }
    
    public void Update(EnemyFSM enemy) {
        if (enemy.distanceToPlayer <= 2f) {
            enemy.SetState(new AttackState());
        }
        if (enemy.distanceToPlayer > 10f) {
            enemy.SetState(new PatrolState());
        }
    }
    
    public void Exit() {
        Debug.Log("ChaseState: Завершення переслідування, зупинка анімації бігу.");
    }
}

public class AttackState : IEnemyState {
    public void Enter() {
        Debug.Log("AttackState: Початок атаки.");
    }
    
    public void Update(EnemyFSM enemy) {
        if (enemy.distanceToPlayer > 2f) {
            enemy.SetState(new ChaseState());
        }
    }
    
    public void Exit() {
        Debug.Log("AttackState: Завершення атаки, очищення цілі.");
    }
}

public class EnemyFSM : MonoBehaviour {
    private IEnemyState currentState;
    public float distanceToPlayer = 15f;

    void Start() {
        SetState(new PatrolState());
    }

    public void SetState(IEnemyState newState) {
        if (currentState != null) {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            distanceToPlayer -= 3f;
            Debug.Log("Дистанція: " + distanceToPlayer);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            distanceToPlayer += 3f;
            Debug.Log("Дистанція: " + distanceToPlayer);
        }

        if (currentState != null) {
            currentState.Update(this);
        }
    }
}