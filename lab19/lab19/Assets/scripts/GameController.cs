using UnityEngine;

public class AudioSystem {
    public void PlayMusic() {
        Debug.Log("Відтворення фонової музики...");
    }
    
    public void StopMusic() {
        Debug.Log("Зупинка музики...");
    }
}

public class SaveSystem {
    public void SaveGame() {
        Debug.Log("Гру збережено!");
    }
    
    public void LoadGame() {
        Debug.Log("Гру завантажено!");
    }
}

public class UISystem {
    public void ShowMainMenu() {
        Debug.Log("Головне меню відображено на екрані");
    }
    
    public void HideMainMenu() {
        Debug.Log("Головне меню приховано");
    }
}

public class AnalyticsSystem {
    public void LogEvent(string eventName) {
        Debug.Log("Аналітика: Записано подію - " + eventName);
    }
}

public class GameFacade {
    private AudioSystem audio = new AudioSystem();
    private SaveSystem save = new SaveSystem();
    private UISystem ui = new UISystem();
    private AnalyticsSystem analytics = new AnalyticsSystem();

    public void StartGame() {
        Debug.Log("- Запуск гри через Facade -");
        ui.ShowMainMenu();
        save.LoadGame();
        audio.PlayMusic();
        analytics.LogEvent("Game_Started");
    }

    public void ExitGame() {
        Debug.Log("- Вихід з гри через Facade -");
        save.SaveGame();
        audio.StopMusic();
        ui.HideMainMenu();
        analytics.LogEvent("Game_Exited");
    }
}

public class GameController : MonoBehaviour {
    private GameFacade game = new GameFacade();

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            game.StartGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            game.ExitGame();
        }
    }
}