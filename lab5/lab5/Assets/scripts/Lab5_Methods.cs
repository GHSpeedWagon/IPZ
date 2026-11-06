using UnityEngine;

public class Lab5_Methods : MonoBehaviour
{
    void Start()
    {
        Debug.Log("--- 2. Простий метод без параметрів ---");
        Hello();

        Debug.Log("\n--- 3. Метод із параметрами ---");
        GreetUser("Artem"); 
        GreetUser("Студент");

        Debug.Log("\n--- 4. Метод, який повертає значення ---");
        int product = Multiply(5, 7);
        Debug.Log($"Результат множення 5 на 7 дорівнює: {product}");

        Debug.Log("\n--- 5. Використання ключових слів out ---");
        int squaredResult;
        Square(6, out squaredResult); 
        Debug.Log($"Квадрат числа 6 дорівнює: {squaredResult}");

        Debug.Log("\n--- 6. Методи з умовами і циклами ---");
        int[] myNumbers = { 1, 2, 3, 4, 5, 6, 8 };
        int evenSum = SumEven(myNumbers);
        Debug.Log($"Сума парних елементів масиву: {evenSum}");

        Debug.Log("\n--- 7. Додаткове завдання (Мінімум, Максимум, Середнє) ---");
        int a = 10, b = 25, c = 15;
        Debug.Log($"Аналіз чисел: {a}, {b}, {c}");
        Debug.Log($"Мінімальне: {GetMin(a, b, c)}");
        Debug.Log($"Максимальне: {GetMax(a, b, c)}");
        Debug.Log($"Середнє арифметичне: {GetAverage(a, b, c)}");
    }

    void Hello()
    {
        Debug.Log("Hello, World!");
    }

    void GreetUser(string name)
    {
        Debug.Log("Hello, " + name + "!");
    }

    int Multiply(int a, int b)
    {
        return a * b;
    }

    void Square(int value, out int result)
    {
        result = value * value;
    }

    int SumEven(int[] numbers)
    {
        int sum = 0;
        foreach (int n in numbers)
        {
            if (n % 2 == 0) sum += n;
        }
        return sum;
    }

    int GetMin(int a, int b, int c)
    {
        int minAB = a < b ? a : b;
        return minAB < c ? minAB : c;
    }

    int GetMax(int a, int b, int c)
    {
        int maxAB = a > b ? a : b;
        return maxAB > c ? maxAB : c;
    }

    float GetAverage(int a, int b, int c)
    {
        return (a + b + c) / 3.0f;
}
}