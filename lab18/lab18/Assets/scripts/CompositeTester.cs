using UnityEngine;
using System.Collections.Generic;

public interface IGameComponent {
    void Render();
}

public class Enemy : IGameComponent {
    public void Render() {
        Debug.Log("Відмальовується ворог");
    }
}

public class Tree : IGameComponent {
    public void Render() {
        Debug.Log("Відмальовується дерево");
    }
}

public class Building : IGameComponent {
    public void Render() {
        Debug.Log("Відмальовується будівля");
    }
}

public class Group : IGameComponent {
    private List<IGameComponent> children = new List<IGameComponent>();

    public void Add(IGameComponent component) {
        children.Add(component);
    }

    public void Remove(IGameComponent component) {
        children.Remove(component);
    }

    public void Render() {
        Debug.Log("--- Відмальовується група об'єктів ---");
        foreach (var child in children) {
            child.Render();
        }
    }
}

public class CompositeTester : MonoBehaviour {
    void Start() {
        IGameComponent enemy1 = new Enemy();
        IGameComponent tree1 = new Tree();
        IGameComponent building1 = new Building();

        Group subGroup = new Group();
        subGroup.Add(enemy1);
        subGroup.Add(tree1);

        Group mainGroup = new Group();
        mainGroup.Add(building1);
        mainGroup.Add(subGroup);

        mainGroup.Render();
    }
}