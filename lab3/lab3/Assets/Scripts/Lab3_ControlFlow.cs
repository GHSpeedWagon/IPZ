using UnityEngine;

public class Lab3_ControlFlow : MonoBehaviour
{
    void Start()
    {
        Debug.Log("if та if...else");
        int score = 15;
        CheckScore(score);
        
        score = 8;
        CheckScore(score);

        Debug.Log("switch-case");
        int level = 2;
        switch (level)
        {
            case 1:
                Debug.Log("Easy");
                break;
            case 2:
                Debug.Log("Medium");
                break;
            case 3:
                Debug.Log("Hard");
                break;
            default:
                Debug.Log("Invalid level");
                break;
        }

        Debug.Log("for і while");
        
        string forResult = "Цикл for (1-5): ";
        for (int i = 1; i <= 5; i++)
        {
            forResult += i + " ";
        }
        Debug.Log(forResult);
        
        string whileResult = "Цикл while (зворотний порядок): ";
        int j = 5;
        while (j >= 1)
        {
            whileResult += j + " ";
            j--;
        }
        Debug.Log(whileResult);

        Debug.Log("сума парних 1-50");
        int sumEven = 0;
        for (int i = 1; i <= 50; i++)
        {
            if (i % 2 == 0)
            {
                sumEven += i;
            }
        }
        Debug.Log($"Сума парних чисел від 1 до 50: {sumEven}");

        Debug.Log("do...while");
        int simulatedInput = 3; 
        do
        {
            Debug.Log($"Залишилося спроб (симуляція вводу): {simulatedInput}");
            simulatedInput--;
        } 
        while (simulatedInput > 0);
        
        Debug.Log("Логіку завершено.");
    }

    void CheckScore(int s)
    {
        if (s > 10)
        {
            Debug.Log($"Рахунок {s}: Значення перевищує 10");
        }
        else
        {
            Debug.Log($"Рахунок {s}: Значення менше або дорівнює 10");
        }
    }
}