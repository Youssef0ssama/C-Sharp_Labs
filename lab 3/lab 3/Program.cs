using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

internal class Program
{
    //task1
    static void reverse(int[] arr, int start, int end)
    {
        int temp = 0;
        for (int i = start, j = end; i < j; i++, j--)
        {
            temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
    static void rotate(int[] arr, int n)
    {
        int length = arr.Length;
        reverse(arr, 0, length - 1);
        reverse(arr, 0, n - 1);
        reverse(arr, n, length - 1);
    }
    //task spiral
    static int[,] Spiral(int n)
    {
        int top = 0, bottom = n - 1, left = 0, right = n - 1, cnt = 1;
        int[,] arr = new int[n, n];

        while (cnt <= n * n)
        {
            for (int i = left; i <= right; i++)
            {
                arr[top, i] = cnt++;
            }
            top++;
            for (int i = top; i <= bottom; i++)
            {
                arr[i, right] = cnt++;
            }
            right--;
            for (int i = right; i >= left; i--)
            {
                arr[bottom, i] = cnt++;
            }
            bottom--;
            for (int i = bottom; i >= top; i--)
            {
                arr[i, left] = cnt++;
            }
            left++;
        }
        return arr;
    }
    //task8 string dict
    static Dictionary<string, int> Frequency(string s)
    {
        var words = s.ToLower().Split(' ');
        var frequency = new Dictionary<string, int>();
        foreach (var word in words)
        {
            if (frequency.ContainsKey(word))
            {
                frequency[word]++;
            }
            else
            {
                frequency[word] = 1;
            }
        }
        return frequency;
    }
    //task4
    //bubble sort
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (arr[j] > arr[j + 1])
                {

                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
    //selection sort
    static void SelectionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }
            int temp = arr[i];
            arr[i] = arr[minIndex];
            arr[minIndex] = temp;
        }
    }

    // task 7


    private static void Main(string[] args)
    {
        //int n = int.Parse(Console.ReadLine());
        //int[,] result = Spiral(n);
        //for (int i = 0; i < n; i++)
        //{
        //    for (int j = 0; j < n; j++)
        //    {
        //        Console.Write(result[i, j] + " ");
        //    }
        //    Console.WriteLine();
        //}
        //string s = Console.ReadLine();
        //var freq = Frequency(s).OrderByDescending(x => x.Value);
        //foreach (var word in freq)
        //{
        //    Console.WriteLine(word);
        //}

        //task3
        // Note: Code assumes input n is provided.
        // For testing, you might need to uncomment Console.ReadLine above or hardcode a value.
        // The original code attempts to read 'n' here immediately:
        int n = int.Parse(Console.ReadLine());

        int[][] triangle = new int[n][];
        for (int i = 0; i < n; i++)
        {
            triangle[i] = new int[i + 1];
            for (int j = 0; j <= i; j++)
            {
                if (j == 0 || j == i)
                {
                    triangle[i][j] = 1;
                }
                else
                {
                    triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                }
            }
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                Console.Write(triangle[i][j] + " ");
            }
            Console.WriteLine();
        }
        //task6
        BankAccount acc1 = new BankAccount(1, "Ahmed", 5000);
        BankAccount acc2 = new BankAccount(2, "Ali", 3000);

        acc1.Deposit(1000);
        acc1.Withdraw(500);
        acc1.Transfer(acc2, 2000);

        acc1.DisplayInfo();
        acc2.DisplayInfo();
        //task7
        int[] arr = { 5, 2, 8, 1, 9 };


        Console.WriteLine(ArrayUtils.FindMax(arr));
        Console.WriteLine(ArrayUtils.FindMin(arr));
        Console.WriteLine(ArrayUtils.IsSorted(arr));
        ArrayUtils.Reverse(arr);
    }
}