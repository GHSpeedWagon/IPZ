using UnityEngine;
using System.Collections.Generic;

public class Character {
    public string name;
    public int health;

    public Character(string name, int health) {
        this.name = name;
        this.health = health;
    }

    public virtual void ShowInfo() {
        Debug.Log($"Character: {name}, Health: {health}");
    }

    public virtual void Action() {
        Debug.Log($"{name} is ready for action.");
    }
}

public class Warrior : Character {
    public int strength;

    public Warrior(string name, int health, int strength) : base(name, health) {
        this.strength = strength;
    }

    public void Attack() {
        Debug.Log($"{name} swings a sword with strength {strength}!");
    }

    public override void ShowInfo() {
        base.ShowInfo();
        Debug.Log($"Strength: {strength}");
    }

    public override void Action() {
        Debug.Log($"{name} (Warrior) attacks!");
    }
}

public class Mage : Character {
    public int mana;

    public Mage(string name, int health, int mana) : base(name, health) {
        this.mana = mana;
    }

    public void CastSpell() {
        Debug.Log($"{name} casts a spell using {mana} mana!");
    }

    public override void ShowInfo() {
        base.ShowInfo();
        Debug.Log($"Mana: {mana}");
    }

    public override void Action() {
        Debug.Log($"{name} (Mage) casts a fireball!");
    }
}

public class Healer : Character{
    public int healingPower;

    public Healer(string name, int health, int healingPower) : base(name, health) {
        this.healingPower = healingPower;
    }

    public void Heal() {
        Debug.Log($"{name} is healing an ally with power {healingPower}...");
    }

    public override void ShowInfo() {
        base.ShowInfo();
        Debug.Log($"Healing Power: {healingPower}");
    }

    public override void Action() {
        Debug.Log($"{name} (Healer) heals the party!");
    }
}

public class Vehicle {
    public string brand;

    public Vehicle(string brand) {
        this.brand = brand;
    }

    public virtual void Move() {
        Debug.Log($"Транспортний засіб {brand} починає рух.");
    }
}

public class Car : Vehicle
{
    public int EnginePower { get; set; }

    public Car(string brand, int enginePower) : base(brand) {
        EnginePower = enginePower;
    }

    public override void Move() {
        base.Move();
        Debug.Log($"Автомобіль {brand} їде завдяки двигуну на {EnginePower} к.с.");
    }
}

public class Bicycle : Vehicle
{
    public int NumberOfGears { get; set; }

    public Bicycle(string brand, int numberOfGears) : base(brand)
    {
        NumberOfGears = numberOfGears;
    }

    public override void Move()
    {
        base.Move();
        Debug.Log($"Велосипед {brand} їде, використовуючи {NumberOfGears} передач.");
    }
}

public class Lab7_Inheritance : MonoBehaviour
{
    void Start()
    {
        Debug.Log("--- ОСНОВНЕ ЗАВДАННЯ: Створення та виклик методів ---");
        
        Warrior arthur = new Warrior("Arthur", 100, 25);
        Mage merlin = new Mage("Merlin", 60, 150);
        
        arthur.ShowInfo();
        arthur.Attack();
        
        merlin.ShowInfo();
        merlin.CastSpell();

        Debug.Log("\n--- ДЕМОНСТРАЦІЯ ПОЛІМОРФІЗМУ (Масив Character) ---");
        
        Character[] party = new Character[3];
        party[0] = new Warrior("Garen", 120, 30);
        party[1] = new Mage("Ryze", 70, 200);
        party[2] = new Healer("Soraka", 80, 50);

        foreach (Character member in party)
        {
            member.Action();
        }

        Debug.Log("\n--- САМОСТІЙНА РОБОТА: Транспортні засоби ---");
        
        Vehicle[] garage = new Vehicle[2];
        garage[0] = new Car("Volkswagen Passat", 170);
        garage[1] = new Bicycle("Trek", 21);

        foreach (Vehicle v in garage)
        {
            v.Move();
        }
    }
}