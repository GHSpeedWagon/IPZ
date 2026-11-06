using UnityEngine;
using System.Collections.Generic;

public class Lab4_Arrays : MonoBehaviour
{
    void Start()
    {
        Debug.Log("2. Вивід елементів масиву");
        int[] numbers = new int[5] { 12, 5, 8, 20, 3 };
        for (int i = 0; i < numbers.Length; i++)
        {
            Debug.Log($"Елемент [{i}]: {numbers[i]}");
        }

        Debug.Log("\n--- 3. Статистика масиву ---");
        int sum = 0;
        int max = numbers[0];
        
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }
        double average = (double)sum / numbers.Length;
        Debug.Log($"Сума: {sum}\nСереднє значення: {average}\nНайбільше число: {max}");

        Debug.Log("\n--- 4. Масив рядків ---");
        string[] names = { "Anna", "Bohdan", "Ira" };
        foreach (string name in names)
        {
            Debug.Log($"Hello, {name}");
        }

        Debug.Log("\n--- 5. Робота зі списком List<T> ---");
        List<int> prices = new List<int>();
        prices.Add(15);
        prices.Add(20);
        prices.Add(5);
        prices.Add(35);
        
        Debug.Log($"Кількість елементів у списку (Count): {prices.Count}");
        
        prices.Remove(5);
        
        string pricesOutput = "Список після видалення елемента '5':\n";
        foreach (int p in prices)
        {
            pricesOutput += p + " ";
        }
        Debug.Log(pricesOutput);

        Debug.Log("\n--- 6. Пошук і фільтрація ---");
        if (prices.Contains(20))
        {
            Debug.Log("Value found (Значення 20 знайдено у списку)");
        }

        List<int> results = new List<int>();
        foreach (int p in prices)
        {
            if (p > 10)
            {
                results.Add(p);
            }
        }
        
        string resultsOutput = "Елементи, що більші за 10:\n";
        foreach (int r in results)
        {
            resultsOutput += r + " ";
        }
        Debug.Log(resultsOutput);

        Debug.Log("\n7. Оцінки студента");
        List<int> grades = new List<int> { 85, 90, 78, 95, 89 };
        int gradesSum = 0;
        foreach (int grade in grades)
        {
            gradesSum += grade;
        }
        
        double gradesAvg = (double)gradesSum / grades.Count;
        string feedback = "";

        if (gradesAvg >= 90) feedback = "Excellent";
        else if (gradesAvg >= 75) feedback = "Good";
        else feedback = "Satisfactory";

        Debug.Log($"Average = {gradesAvg} — Grade: {feedback}");
    }
}