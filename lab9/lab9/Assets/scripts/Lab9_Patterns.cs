using UnityEngine;
using System.Collections.Generic;

public class GameManager {
    private static GameManager instance;
    public static GameManager Instance {
        get {
            if (instance == null) instance = new GameManager();
            return instance;
        }
    }
    
    public int score;
    public void AddScore(int value) => score += value;
}

public interface ISubscriber {
    void UpdateUI(string message);
}

public class EventManager {
    private List<ISubscriber> subscribers = new List<ISubscriber>();

    public void Subscribe(ISubscriber sub) {
        subscribers.Add(sub);
    }

    public void Unsubscribe(ISubscriber sub) {
        subscribers.Remove(sub);
    }

    public void Notify(string message) {
        foreach (ISubscriber sub in subscribers) {
            sub.UpdateUI(message);
        }
    }
}

public class UIManager : ISubscriber {
    public void UpdateUI(string message) {
        Debug.Log($"[UI System]: Відображення тексту на екрані -> '{message}'");
    }
}

public class ConsoleLogger : ISubscriber {
    public void UpdateUI(string message) {
        Debug.Log($"[Logger System]: Запис у файл логів -> Подія '{message}'");
    }
}

public class Lab9_Patterns : MonoBehaviour {
    void Start() {
        Debug.Log("--- Демонстрація SINGLETON ---");
        GameManager.Instance.AddScore(50);
        GameManager.Instance.AddScore(150);
        Debug.Log($"Поточний рахунок гравця: {GameManager.Instance.score}");

        Debug.Log("\n--- Демонстрація OBSERVER (Поглиблене завдання) ---");
        EventManager gameEvents = new EventManager();
        
        UIManager uiSystem = new UIManager();
        ConsoleLogger logSystem = new ConsoleLogger();

        gameEvents.Subscribe(uiSystem);
        gameEvents.Subscribe(logSystem);

        Debug.Log("Гравець піднімає предмет...");
        gameEvents.Notify("Отримано Меч Легенд!");
    }
}