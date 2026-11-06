using UnityEngine;
using System.Collections.Generic;

public interface IDamageable {
    void TakeDamage(int amount);
}

public interface IMovable {
    void Move();
}

public interface IAttackable {
    void Attack();
}

public abstract class Weapon {
    public string name;
    public abstract void Attack();

    public void ShowInfo() {
        Debug.Log($"Назва зброї: {name}");
    }
}

public class Enemy : IDamageable {
    public void TakeDamage(int amount) {
        Debug.Log($"Enemy took {amount} damage!");
    }
}

public class Player : IDamageable {
    public void TakeDamage(int amount) {
        Debug.Log($"Player lost {amount} HP!");
    }
}

public class Boss : IDamageable {
    public void TakeDamage(int amount) {
        Debug.Log($"Boss enraged after taking {amount} damage!");
    }
}

public class Sword : Weapon {
    public Sword() { name = "Екскалібур (Sword)"; }
    
    public override void Attack() {
        Debug.Log("Swing sword!");
    }
}

public class Bow : Weapon {
    public Bow() { name = "Ельфійський лук (Bow)"; }

    public override void Attack() {
        Debug.Log("Shoot arrow!");
    }
}

public class Character : IMovable, IAttackable {
    public void Move() {
        Debug.Log("Character рухається вперед.");
    }

    public void Attack() {
        Debug.Log("Character виконує базову атаку.");
    }
}


public interface IInteractable {
    void Interact();
}

public class Door : IInteractable {
    public void Interact() { Debug.Log("Двері зі скрипом відчиняються."); }
}

public class Chest : IInteractable {
    public void Interact() { Debug.Log("Ви відкрили скриню і знайшли золото!"); }
}

public class NPC : IInteractable {
    public void Interact() {
        Debug.Log("Ви підійшли до NPC.");
        Talk();
    }

    public void Talk() {
        Debug.Log("NPC каже: 'Вітаю, мандрівнику!'");
    }
}

public abstract class Shape {
    public abstract float GetArea();
}

public class Circle : Shape {
    public float radius;
    public Circle(float r) { radius = r; }
    
    public override float GetArea() {
        return Mathf.PI * radius * radius;
    }
}

public class Rectangle : Shape {
    public float width;
    public float height;
    public Rectangle(float w, float h) { width = w; height = h; }
    
    public override float GetArea() {
        return width * height;
    }
}

public class Lab8_Interfaces : MonoBehaviour {
    void Start() {
        Debug.Log("--- 6. ПОЛІМОРФІЗМ: Інтерфейси (IDamageable) ---");
        List<IDamageable> targets = new List<IDamageable>
        {
            new Player(),
            new Enemy(),
            new Boss()
        };

        foreach (IDamageable target in targets) {
            target.TakeDamage(25);
        }

        Debug.Log("\n--- 6. ПОЛІМОРФІЗМ: Абстрактні класи (Weapon) ---");
        Weapon[] arsenal = new Weapon[] {
            new Sword(),
            new Bow()
        };

        foreach (Weapon w in arsenal) {
            w.ShowInfo();
            w.Attack();
        }

        Debug.Log("\n--- 7. ПОГЛИБЛЕНЕ ЗАВДАННЯ (Кілька інтерфейсів) ---");
        Character hero = new Character();
        hero.Move();
        hero.Attack();

        Debug.Log("\n--- САМОСТІЙНА РОБОТА: Інтерфейси (IInteractable) ---");
        List<IInteractable> interactables = new List<IInteractable>
        {
            new Door(),
            new Chest(),
            new NPC()
        };

        foreach (IInteractable item in interactables) {
            item.Interact();
        }

        Debug.Log("\n--- САМОСТІЙНА РОБОТА: Фігури (Shape) ---");
        Shape[] shapes = new Shape[]
        {
            new Circle(5f),
            new Rectangle(4f, 6f)
        };

        foreach (Shape s in shapes) {
            Debug.Log($"Площа фігури: {s.GetArea()}");
        }
    }
}