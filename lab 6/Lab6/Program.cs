using Lab6;
using System;
using System.Collections.Generic;

public class Program
{
    // Task 1 → calculator delegate
    public delegate double Operation(double a, double b);

    // Task 2 → notification delegate
    public delegate void Alert(string text);

    // notification handlers
    static void EmailHandler(string text)
    {
        Console.WriteLine("Email notification sent: " + text);
    }

    static void SmsHandler(string text)
    {
        Console.WriteLine("SMS notification sent: " + text);
    }

    static void FileLogger(string text)
    {
        Console.WriteLine("Log entry created -> " + text);
    }

    // Task 3 → filtering delegate
    public delegate bool NumberCondition(int number);

    static void PrintFiltered(int[] numbers, NumberCondition condition)
    {
        foreach (var n in numbers)
        {
            if (condition(n))
                Console.WriteLine(n);
        }
    }

    static bool IsEven(int n) => n % 2 == 0;
    static bool IsOdd(int n) => n % 2 != 0;

    public static void Main()
    {
        // ===== Task 1 =====
        Operation op = Calculator.Add;
        Console.WriteLine("Add result = " + op(5, 3));

        Console.WriteLine("================================");

        // ===== Task 2 =====
        Alert systemAlert = EmailHandler;
        systemAlert += SmsHandler;
        systemAlert += FileLogger;

        systemAlert("Security breach detected");
        systemAlert -= SmsHandler;
        systemAlert("System restored successfully");

        Console.WriteLine("================================");

        // ===== Task 3 =====
        int[] data = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        Console.WriteLine("Even numbers:");
        PrintFiltered(data, IsEven);

        Console.WriteLine("Odd numbers:");
        PrintFiltered(data, IsOdd);

        Console.WriteLine("================================");

        // ===== Task 4 → anonymous method =====
        PrintFiltered(data, delegate (int n)
        {
            return n > 5;
        });

        Console.WriteLine("================================");

        // ===== Task 5 → lambda expression =====
        PrintFiltered(data, n => n < 4);

        Console.WriteLine("================================");

        // ===== Task 6 → sorting with lambda =====
        var values = new List<int> { 5, 2, 9, 1, 5, 6 };

        values.Sort((x, y) => x.CompareTo(y));
        Console.WriteLine("Ascending order:");
        values.ForEach(v => Console.WriteLine(v));

        Console.WriteLine("------");

        values.Sort((x, y) => y.CompareTo(x));
        Console.WriteLine("Descending order:");
        values.ForEach(v => Console.WriteLine(v));

        Console.WriteLine("================================");

        // ===== Task 7 → temperature event =====
        TempSensor sensor = new TempSensor();
        sensor.tempHigh += (msg, t) =>
            Console.WriteLine($"WARNING: {msg} | Temperature = {t}");

        sensor.setTemp(20);
        sensor.setTemp(50);

        Console.WriteLine("================================");

        // ===== Task 8 → button event =====
        Button btn = new Button();
        btn.click += (sender, name) =>
            Console.WriteLine($"Button [{name}] was clicked");

        btn.performClick();
    }
}