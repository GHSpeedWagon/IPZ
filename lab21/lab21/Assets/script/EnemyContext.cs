using UnityEngine;
using System;
using System.Collections.Generic;

public interface ICommand {
    void Execute();
    void Undo();
}

public class MoveCommand : ICommand {
    private Transform target;
    private Vector3 direction;

    public MoveCommand(Transform t, Vector3 dir) {
        target = t;
        direction = dir;
    }

    public void Execute() {
        target.Translate(direction);
        Debug.Log($"Гравець перемістився: {direction}");
    }

    public void Undo() {
        target.Translate(-direction);
        Debug.Log("Дію переміщення відмінено");
    }
}

public class CommandInvoker {
    private Stack<ICommand> history = new Stack<ICommand>();

    public void ExecuteCommand(ICommand cmd) {
        cmd.Execute();
        history.Push(cmd);
    }

    public void UndoLast() {
        if (history.Count > 0) {
            history.Pop().Undo();
        } else {
            Debug.Log("Історія дій порожня");
        }
    }
}

public interface IEnemyState {
    void UpdateState(EnemyContext enemy);
}

public class PatrolState : IEnemyState {
    public void UpdateState(EnemyContext enemy) {
        Debug.Log("Ворог знаходиться у стані патрулювання");
    }
}

public class AttackState : IEnemyState {
    public void UpdateState(EnemyContext enemy) {
        Debug.Log("Ворог перейшов у стан атаки");
    }
}

public class EnemyContext : MonoBehaviour {
    private IEnemyState currentState;

    void Start() {
        currentState = new PatrolState();
    }

    public void SetState(IEnemyState state) {
        currentState = state;
    }

    public void PerformAction() {
        currentState.UpdateState(this);
    }
}

public class EnemyFactory {
    public GameObject CreateEnemy(GameObject prefab, Vector3 position) {
        GameObject enemy = UnityEngine.Object.Instantiate(prefab, position, Quaternion.identity);
        enemy.AddComponent<EnemyContext>();
        Debug.Log("Фабрика успішно створила ворога");
        return enemy;
    }
}

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }
    public event Action OnGameStarted;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void StartGameLogic() {
        Debug.Log("GameManager: Сигнал старту гри");
        OnGameStarted?.Invoke();
    }
}

public class UIManager : MonoBehaviour {
    private void OnEnable() {
        if (GameManager.Instance != null) {
            GameManager.Instance.OnGameStarted += ShowStartMessage;
        }
    }

    private void OnDisable() {
        if (GameManager.Instance != null) {
            GameManager.Instance.OnGameStarted -= ShowStartMessage;
        }
    }

    private void ShowStartMessage() {
        Debug.Log("Observer UI: Відображено головний екран гри");
    }
}

public class GameFacade : MonoBehaviour {
    public GameObject enemyPrefab;
    private EnemyFactory factory = new EnemyFactory();
    private CommandInvoker invoker = new CommandInvoker();
    private Transform playerTransform;

    void Start() {
        playerTransform = new GameObject("Player").transform;
        gameObject.AddComponent<GameManager>();
        gameObject.AddComponent<UIManager>();
    }

    public void StartGame() {
        GameManager.Instance.StartGameLogic();
    }

    public void SpawnEnemy() {
        if (enemyPrefab != null) {
            GameObject enemy = factory.CreateEnemy(enemyPrefab, new Vector3(0, 0, 5));
            enemy.GetComponent<EnemyContext>().PerformAction();
        } else {
            Debug.Log("Префаб ворога не призначено у фасаді");
        }
    }

    public void MovePlayerUp() {
        invoker.ExecuteCommand(new MoveCommand(playerTransform, Vector3.forward));
    }

    public void UndoPlayerAction() {
        invoker.UndoLast();
    }
}

public class ArchTester : MonoBehaviour {
    private GameFacade facade;

    void Start() {
        facade = GetComponent<GameFacade>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) facade.StartGame();
        if (Input.GetKeyDown(KeyCode.Space)) facade.SpawnEnemy();
        if (Input.GetKeyDown(KeyCode.W)) facade.MovePlayerUp();
        if (Input.GetKeyDown(KeyCode.Z)) facade.UndoPlayerAction();
    }
}