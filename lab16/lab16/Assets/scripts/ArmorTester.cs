using UnityEngine;

public interface IArmor {
    void Defend();
}

public class BasicArmor : IArmor {
    public void Defend() {
        Debug.Log("Базовий захист броні.");
    }
}

public class MagicShieldDecorator : IArmor {
    private IArmor armor;

    public MagicShieldDecorator(IArmor armor) {
        this.armor = armor;
    }

    public void Defend() {
        armor.Defend();
        Debug.Log("...активовано магічний щит, який поглинає частину шкоди!");
    }
}

public class HealthRegenDecorator : IArmor {
    private IArmor armor;

    public HealthRegenDecorator(IArmor armor) {
        this.armor = armor;
    }

    public void Defend() {
        armor.Defend();
        Debug.Log("...спрацювало відновлення здоров'я!");
    }
}

public class ArmorTester : MonoBehaviour {
    private IArmor currentArmor;
    private bool isShieldActive = true;

    void Start() {
        UpdateArmor();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            currentArmor.Defend();
        }

        if (Input.GetKeyDown(KeyCode.T)) {
            ToggleShield();
        }
    }

    public void ToggleShield() {
        isShieldActive = !isShieldActive;
        UpdateArmor();
        Debug.Log(isShieldActive ? "Магічний щит УВІМКНЕНО." : "Магічний щит ВИМКНЕНО.");
    }

    private void UpdateArmor() {
        currentArmor = new BasicArmor();
        currentArmor = new HealthRegenDecorator(currentArmor);
        
        if (isShieldActive) {
            currentArmor = new MagicShieldDecorator(currentArmor);
        }
    }
}