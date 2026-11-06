using UnityEngine;

public class CombatAnimation {
    public void PlayEnterAnimation() {
        Debug.Log("Анімація: Вихід на арену");
    }
    
    public void PlayVictoryAnimation() {
        Debug.Log("Анімація: Переможна стійка");
    }
}

public class CombatAudio {
    public void PlayBattleTheme() {
        Debug.Log("Аудіо: Бойова музика увімкнена");
    }
    
    public void PlayVictoryFanfare() {
        Debug.Log("Аудіо: Звук перемоги");
    }
}

public class DamageCalculator {
    public void ResetStats() {
        Debug.Log("Шкода: Характеристики обнулено для нового бою");
    }
    
    public void CalculateFinalScore() {
        Debug.Log("Шкода: Підрахунок фінального рейтингу");
    }
}

public class BattleUI {
    public void ShowHealthBars() {
        Debug.Log("UI: Смуги здоров'я відображено");
    }
    
    public void ShowVictoryScreen() {
        Debug.Log("UI: Екран перемоги відкрито");
    }
}

public class BattleFacade {
    private CombatAnimation anim = new CombatAnimation();
    private CombatAudio audio = new CombatAudio();
    private DamageCalculator damage = new DamageCalculator();
    private BattleUI ui = new BattleUI();

    public void StartBattle() {
        Debug.Log("- ПОЧАТОК БОЮ -");
        damage.ResetStats();
        anim.PlayEnterAnimation();
        ui.ShowHealthBars();
        audio.PlayBattleTheme();
    }

    public void EndBattle() {
        Debug.Log("- ЗАВЕРШЕННЯ БОЮ -");
        audio.PlayVictoryFanfare();
        anim.PlayVictoryAnimation();
        damage.CalculateFinalScore();
        ui.ShowVictoryScreen();
    }
}

public class BattleTester : MonoBehaviour {
    private BattleFacade battle = new BattleFacade();

    void Update() {
        if (Input.GetKeyDown(KeyCode.B)) {
            battle.StartBattle();
        }
        if (Input.GetKeyDown(KeyCode.V)) {
            battle.EndBattle();
        }
    }
}