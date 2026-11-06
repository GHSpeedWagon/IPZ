using UnityEngine;
using System.Collections.Generic;

public class Student {
    private string name;
    private int age;
    private double grade;

    public string Name {
        get { return name; }
        set { name = value; }
    }

    public int Age {
        get { return age; }
        set { age = value; }
    }

    public double Grade {
        get { return grade; }
        set { grade = value; }
    }

    public Student(string n, int a, double g) {
        Name = n;
        Age = a;
        Grade = g;
    }

    public void ShowInfo() {
        Debug.Log($"Student: {Name}, Age: {Age}, Grade: {Grade}");
    }
}

public class Rectangle {
    public float width;
    public float height;

    public Rectangle(float w, float h) {
        width = w;
        height = h;
    }

    public float CalculateArea() {
        return width * height;
    }
}

public class Car {
    public string Mark { get; set; }
    public int Year { get; set; }
    public float Mileage { get; set; }

    public Car(string mark, int year, float mileage) {
        Mark = mark;
        Year = year;
        Mileage = mileage;
    }

    public void Drive(float distance) {
        Mileage += distance;
        Debug.Log($"Автомобіль {Mark} проїхав {distance} км. Новий пробіг: {Mileage} км.");
    }
}

public class Book {
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    public Book(string title, string author, int year) {
        Title = title;
        Author = author;
        Year = year;
    }

    public void DisplayInfo() {
        Debug.Log($"Книга: '{Title}', Автор: {Author}, Рік видання: {Year}");
    }
}

public class Lab6_Classes : MonoBehaviour {
    void Start() {        
        Student[] students = new Student[3];
        students[0] = new Student("Артем", 21, 95.5);
        students[1] = new Student("Анна", 20, 88.0);
        students[2] = new Student("Богдан", 22, 76.4);

        foreach (Student student in students) {
            student.ShowInfo();
        }

        Debug.Log("\nПрямокутники");
        Rectangle rect1 = new Rectangle(5.5f, 4.0f);
        Rectangle rect2 = new Rectangle(10f, 2.5f);
        Debug.Log($"Площа прямокутника 1: {rect1.CalculateArea()}");
        Debug.Log($"Площа прямокутника 2: {rect2.CalculateArea()}");

        Debug.Log("\nАвтомобілі та Книги");
        
        Car myCar = new Car("Volkswagen Passat", 2018, 120500f);
        Debug.Log($"Початковий пробіг {myCar.Mark}: {myCar.Mileage} км");
        myCar.Drive(350.5f);

        List<Book> library = new List<Book>();
        library.Add(new Book("1984", "Джордж Оруелл", 1949));
        library.Add(new Book("Кобзар", "Тарас Шевченко", 1840));
        library.Add(new Book("Володар перснів", "Дж. Р. Р. Толкін", 1954));

        Debug.Log("Список книг у бібліотеці:");
        foreach (Book book in library)
        {
            book.DisplayInfo();
        }
    }
}