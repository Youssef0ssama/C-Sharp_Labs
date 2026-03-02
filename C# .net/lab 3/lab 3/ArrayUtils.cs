using System;

internal static class ArrayUtils
{
    public static void Reverse(int[] arr)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left < right)
        {
            int temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;

            left++;
            right--;
        }
    }

    public static int FindMax(int[] arr)
    {
        int max = arr[0];
        for (int i = 1; i < arr.Length; i++)
            if (arr[i] > max)
                max = arr[i];
        return max;
    }

    public static int FindMin(int[] arr)
    {
        int min = arr[0];
        for (int i = 1; i < arr.Length; i++)
            if (arr[i] < min)
                min = arr[i];
        return min;
    }

    public static bool IsSorted(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
            if (arr[i] > arr[i + 1])
                return false;
        return true;
    }

    public static int CountOccurrences(int[] arr, int value)
    {
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] == value)
                count++;
        return count;
    }

    public static int[] Merge(int[] arr1, int[] arr2)
    {
        int[] result = new int[arr1.Length + arr2.Length];
        int i = 0, j = 0, k = 0;
        while (i < arr1.Length && j < arr2.Length)
        {
            if (arr1[i] < arr2[j])
                result[k++] = arr1[i++];
            else
                result[k++] = arr2[j++];
        }

        while (i < arr1.Length)
            result[k++] = arr1[i++];
        while (j < arr2.Length)
            result[k++] = arr2[j++];

        return result;
    }
}