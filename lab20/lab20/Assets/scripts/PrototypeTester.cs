using UnityEngine;
using System.Collections.Generic;

public abstract class EnemyPrototype {
    public string Name;
    public int Health;
    public abstract EnemyPrototype Clone();
}

public class Goblin : EnemyPrototype {
    public Goblin() {
        Name = "Goblin";
        Health = 100;
    }
    public override EnemyPrototype Clone() {
        return (EnemyPrototype)this.MemberwiseClone();
    }
}

public class Troll : EnemyPrototype {
    public Troll() {
        Name = "Troll";
        Health = 300;
    }
    public override EnemyPrototype Clone() {
        return (EnemyPrototype)this.MemberwiseClone();
    }
}

public class Orc : EnemyPrototype {
    public Orc() {
        Name = "Orc";
        Health = 200;
    }
    public override EnemyPrototype Clone() {
        return (EnemyPrototype)this.MemberwiseClone();
    }
}

public class PrototypeTester : MonoBehaviour {
    public GameObject unityPrefab;

    void Start() {
        EnemyPrototype baseGoblin = new Goblin();
        EnemyPrototype baseTroll = new Troll();
        EnemyPrototype baseOrc = new Orc();

        List<EnemyPrototype> army = new List<EnemyPrototype>();

        EnemyPrototype mutantGoblin = baseGoblin.Clone();
        mutantGoblin.Name = "Mutant Goblin";
        mutantGoblin.Health = 150;
        army.Add(mutantGoblin);

        EnemyPrototype eliteTroll = baseTroll.Clone();
        eliteTroll.Name = "Elite Troll";
        eliteTroll.Health = 500;
        army.Add(eliteTroll);
        
        EnemyPrototype armoredOrc = baseOrc.Clone();
        armoredOrc.Name = "Armored Orc";
        armoredOrc.Health = 350;
        army.Add(armoredOrc);

        foreach (var enemy in army) {
            Debug.Log($"Створено клона: {enemy.Name}, Здоров'я: {enemy.Health}");
        }

        if (unityPrefab != null) {
            GameObject clone = Instantiate(unityPrefab, Vector3.zero, Quaternion.identity);
            clone.name = "Unity Prefab Clone";
            clone.transform.localScale = new Vector3(2, 2, 2);
            Debug.Log("Створено клон через Instantiate зі зміненим розміром");
        }
    }
}