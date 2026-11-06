using UnityEngine;
using System;
using System.Collections.Generic;

public interface IEnemy {
    void Attack();
}

public class Goblin : IEnemy {
    public void Attack() {
        Debug.Log("Goblin attacks!");
    }
}

public class Troll : IEnemy {
    public void Attack() {
        Debug.Log("Troll smashes!");
    }
}

public class Orc : IEnemy {
    public void Attack() {
        Debug.Log("Orc crushes!");
    }
}

public class EnemyFactory {
    private Dictionary<string, Func<IEnemy>> enemyRegistry = new Dictionary<string, Func<IEnemy>>();

    public void RegisterEnemy(string type, Func<IEnemy> creator) {
        enemyRegistry[type] = creator;
    }

    public IEnemy CreateEnemy(string type) {
        if (enemyRegistry.ContainsKey(type)) {
            return enemyRegistry[type]();
        }
        Debug.Log("Тип ворога не знайдено: " + type);
        return null;
    }
}

public class EnemySpawner : MonoBehaviour {
    private EnemyFactory factory;

    void Start() {
        factory = new EnemyFactory();
        
        factory.RegisterEnemy("Goblin", () => new Goblin());
        factory.RegisterEnemy("Troll", () => new Troll());
        
        factory.RegisterEnemy("Orc", () => new Orc());

        SpawnEnemy("Goblin");
        SpawnEnemy("Troll");
        SpawnEnemy("Orc");
    }

    public void SpawnEnemy(string type) {
        IEnemy enemy = factory.CreateEnemy(type);
        if (enemy != null) {
            enemy.Attack();
        }
    }
}