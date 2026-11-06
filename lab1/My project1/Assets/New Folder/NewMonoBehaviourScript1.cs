using UnityEngine;

public class NewMonoBehaviourScript1 : MonoBehaviour
{
public string playerName = "Artem";
    public int playerAge = 20;
    public float playerHeight = 193.0f;
    public bool isAlive = true;

    void Start()
    {
        Debug.Log("Ім'я: " + playerName);
        Debug.Log("Вік: " + playerAge);
        Debug.Log("Зріст: " + playerHeight);
        Debug.Log("Статус (живий): " + isAlive);

        int a = 50;
        int b = 15;

        Debug.Log("Сума: " + (a + b));
        Debug.Log("Різниця: " + (a - b));
        Debug.Log("Добуток: " + (a * b));

        int health = 100;
        bool isHealthAboveZero = health > 0;
        Debug.Log("Чи здоров'я більше 0: " + isHealthAboveZero);

        string fullInfo = "Гравець " + playerName + " має зріст " + playerHeight + " см.";
        Debug.Log(fullInfo);
    }
}
