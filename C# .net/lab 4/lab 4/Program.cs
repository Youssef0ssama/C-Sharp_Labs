using lab4;
using System;
class test
{
    static void Main(string[] args)
    {
        // Test Date class
        Date date1 = new Date();
        Date date2 = new Date(2023);
        Date date3 = new Date(15, 8, 1947);
        date1.print();
        date2.print();
        date3.print();
        // Test counter class
        counter c = new counter();
        counter c1 = new counter();
        Console.WriteLine($"counter id :{c1.id}");
        Employee emp1 = new Developer("Ali", 101, 50000, "C#");
        Employee emp2 = new Manager("ahmed", 102, 60000, 10, 5000);
        emp1.display();
        emp2.display();

        //test polymorphism
        Employee[] employees = new Employee[2];
        employees[0] = new Developer("Sara", 103, 55000, "Java");
        employees[1] = new Manager("Omar", 104, 70000, 15, 8000);
        foreach (Employee emp in employees)
        {
            emp.display();
        }
        Console.WriteLine("----------------------------");
        //shape overloading
        Rectangle rec = new Rectangle(5.0, 3.0);
        Console.WriteLine($"Area of Rectangle: {rec.Area()}");
        Circle cir = new Circle(4.0);
        Console.WriteLine($"Area of Circle: {cir.Area()}");
        Triangle tri = new Triangle(4.0, 5.0, 6.0);
        Console.WriteLine($"Area of Triangle: {tri.Area()}");

        //abstract class test
        Dog dog = new Dog();
        dog.MakeSound();
        dog.Move();
        Bird bird = new Bird();
        bird.MakeSound();
        Cat cat = new Cat();
        cat.MakeSound();
        cat.Move();
        //imovable test
        robot r = new robot();
        r.Move();
        r.Charge();

        Console.WriteLine("----------------------------");
        //student class test
        Student student = new Student();
        student.Name = "John Doe";
        student.Age = 20;
        Console.WriteLine($"Student Name: {student.Name}, Age: {student.Age}");
        //bank account test
        SavingsAccount sa = new SavingsAccount("Ali", 1001, 5000.0, 0.5);
        sa.CalculateInterest();
        sa.Print();
        CheckingAccount ca = new CheckingAccount("Ahmed", 1002, 2000.0, 1000.0);
        ca.CalculateInterest();
        ca.withdraw(2500.0);
        ca.Print();

    }

}