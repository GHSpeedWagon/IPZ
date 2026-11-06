using UnityEngine;

public interface IAttackStrategy {
    void Attack();
}

public class MeleeAttack : IAttackStrategy {
    public void Attack() {
        Debug.Log("Гравець б'є мечем!");
    }
}

public class RangedAttack : IAttackStrategy {
    public void Attack() {
        Debug.Log("Гравець стріляє з лука!");
    }
}

public class MagicAttack : IAttackStrategy {
    public void Attack() {
        Debug.Log("Гравець кастує вогняну кулю!");
    }
}

public class PoisonAttack : IAttackStrategy {
    public void Attack() {
        Debug.Log("Гравець кидає отруйну колбу!");
    }
}

public class Player : MonoBehaviour {
    private IAttackStrategy attackStrategy;

    void Start() {
        SetStrategy(new MeleeAttack());
    }

    public void SetStrategy(IAttackStrategy strategy) {
        attackStrategy = strategy;
        Debug.Log("Стратегія атаки змінена!");
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            SetStrategy(new MeleeAttack());
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            SetStrategy(new RangedAttack());
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            SetStrategy(new MagicAttack());
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            SetStrategy(new PoisonAttack());
        }
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            attackStrategy?.Attack();
        }
    }
}