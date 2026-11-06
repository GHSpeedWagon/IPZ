using UnityEngine;
using System.Collections.Generic;

public interface ICommand {
    void Execute();
    void Undo();
    string GetCommandName();
}

public class MoveCommand : ICommand {
    private Transform player;
    private Vector3 direction;

    public MoveCommand(Transform player, Vector3 direction) {
        this.player = player;
        this.direction = direction;
    }

    public void Execute() {
        player.position += direction;
        Debug.Log($"Виконано рух. Напрямок: {direction}");
    }

    public void Undo() {
        player.position -= direction;
        Debug.Log($"Скасовано рух. Повернення: {-direction}");
    }

    public string GetCommandName() {
        return $"Move {direction}";
    }
}

public class DrawCommand : ICommand {
    private string lineName;

    public DrawCommand(string lineName) {
        this.lineName = lineName;
    }

    public void Execute() {
        Debug.Log($"Намальовано штрих: {lineName}");
    }

    public void Undo() {
        Debug.Log($"Стерто штрих: {lineName}");
    }

    public string GetCommandName() {
        return $"Draw {lineName}";
    }
}

public class DeleteCommand : ICommand {
    private GameObject targetObject;

    public DeleteCommand(GameObject targetObject) {
        this.targetObject = targetObject;
    }

    public void Execute() {
        targetObject.SetActive(false);
        Debug.Log($"Об'єкт {targetObject.name} видалено");
    }

    public void Undo() {
        targetObject.SetActive(true);
        Debug.Log($"Об'єкт {targetObject.name} відновлено");
    }

    public string GetCommandName() {
        return $"Delete {targetObject.name}";
    }
}

public class CommandInvoker {
    private Stack<ICommand> history = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command) {
        command.Execute();
        history.Push(command);
    }

    public void UndoLast() {
        if (history.Count > 0) {
            ICommand lastCommand = history.Pop();
            lastCommand.Undo();
        } else {
            Debug.Log("Історія порожня.");
        }
    }

    public void ClearHistory() {
        history.Clear();
        Debug.Log("Історію команд очищено.");
    }

    public void PrintHistory() {
        Debug.Log("--- ІСТОРІЯ ДІЙ ---");
        if (history.Count == 0) {
            Debug.Log("Порожньо");
        }
        foreach (ICommand cmd in history) {
            Debug.Log(cmd.GetCommandName());
        }
        Debug.Log("-------------------");
    }
}

public class PlayerController : MonoBehaviour {
    private CommandInvoker invoker = new CommandInvoker();
    public GameObject targetToDelete;

    void Update() {
        if (Input.GetKeyDown(KeyCode.W)) {
            invoker.ExecuteCommand(new MoveCommand(transform, Vector3.forward));
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            invoker.ExecuteCommand(new MoveCommand(transform, Vector3.back));
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            invoker.ExecuteCommand(new DrawCommand("Лінія_1"));
        }
        if (Input.GetKeyDown(KeyCode.X)) {
            if (targetToDelete != null && targetToDelete.activeSelf) {
                invoker.ExecuteCommand(new DeleteCommand(targetToDelete));
            }
        }
        if (Input.GetKeyDown(KeyCode.Z)) {
            invoker.UndoLast();
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            invoker.ClearHistory();
        }
        if (Input.GetKeyDown(KeyCode.H)) {
            invoker.PrintHistory();
        }
    }
}