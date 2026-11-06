using UnityEngine;
using System.Collections.Generic;

public interface IUIComponent {
    void Show();
    void Hide();
}

public class UIButton : IUIComponent {
    private string name;

    public UIButton(string name) {
        this.name = name;
    }

    public void Show() {
        Debug.Log($"Кнопка {name} відображена");
    }

    public void Hide() {
        Debug.Log($"Кнопка {name} прихована");
    }
}

public class UIText : IUIComponent {
    private string content;

    public UIText(string content) {
        this.content = content;
    }

    public void Show() {
        Debug.Log($"Текст '{content}' відображений");
    }

    public void Hide() {
        Debug.Log($"Текст '{content}' прихований");
    }
}

public class UIPanel : IUIComponent {
    private string panelName;
    private List<IUIComponent> elements = new List<IUIComponent>();

    public UIPanel(string panelName) {
        this.panelName = panelName;
    }

    public void Add(IUIComponent component) {
        elements.Add(component);
    }

    public void Remove(IUIComponent component) {
        elements.Remove(component);
    }

    public void Show() {
        Debug.Log($"--- Відкривається панель: {panelName} ---");
        foreach (var element in elements) {
            element.Show();
        }
    }

    public void Hide() {
        Debug.Log($"--- Закривається панель: {panelName} ---");
        foreach (var element in elements) {
            element.Hide();
        }
    }
}

public class UITester : MonoBehaviour {
    void Start() {
        IUIComponent startButton = new UIButton("Start");
        IUIComponent exitButton = new UIButton("Exit");
        IUIComponent titleText = new UIText("Головне Меню");

        UIPanel optionsPanel = new UIPanel("Налаштування");
        optionsPanel.Add(new UIButton("Audio"));
        optionsPanel.Add(new UIButton("Graphics"));

        UIPanel mainPanel = new UIPanel("Main Screen");
        mainPanel.Add(titleText);
        mainPanel.Add(startButton);
        mainPanel.Add(exitButton);
        mainPanel.Add(optionsPanel);

        mainPanel.Show();
        
        Debug.Log("Користувач закриває налаштування...");
        optionsPanel.Hide();
    }
}