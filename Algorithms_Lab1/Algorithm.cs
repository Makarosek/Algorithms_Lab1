using System.Diagnostics;
using System;

namespace Algorithms_Lab1;

public class Algorithm
{
    public int[] FirstAlg(int[] numbers)
    {
        int[] res = new int[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            res[i] = 1;
        }
        return res;
    }

    public int[] Summ(int[] numbers)
    {
        int[] res = new int[numbers.Length];
        int sum = 0;
        foreach (var VARIABLE in numbers)
        {
            sum += VARIABLE;
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            res[i] = sum;
        }

        return res;
    }

    public int[] Mult(int[] numbers)
    {
        int[] res = new int[numbers.Length];
        int sum = 1;
        foreach (var VARIABLE in numbers)
        {
            sum *= VARIABLE;
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            res[i] = sum;
        }

        return res;
    }

    public int[] BubbleSort(int[] numbers)
    {
        int[] res = new int[numbers.Length];
        numbers.CopyTo(res, 0);

        int temp;
        for (int i = 0; i < res.Length - 1; i++)
        {
            for (int j = 0; j < res.Length - 1; j++)
            {
                if (res[j] > res[j + 1])
                {
                    temp = res[j];
                    res[j] = res[j + 1];
                    res[j + 1] = temp;
                }
            }
        }

        return res;
    }

    /*public int[] Horner(int[] numbers)
    {
        int[] res = new int[numbers.Length];
        numbers.CopyTo(res, 0);
        int n = res.Length - 1;
        var x = 1.5f;
        double result = res[n];
        for (int i = n - 1; i >= 0; i--)
        {
            result = result * x + res[i];
        }
        return res;
    }*/
    public int[] GnomeSort(int[] numbers)
    {

        int[] res = new int[numbers.Length];
        numbers.CopyTo(res, 0);
        int i = 1;
        int temp;

        while (i < res.Length)
        {
            if (i == 0)
            {
                i = 1;
            }

            if (res[i - 1] <= res[i])
            {
                i++;
            }
            else
            {
                temp = res[i];
                res[i] = res[i - 1];
                res[i - 1] = temp;
                i--;
            }
        }
        return res;
    }

    private int calcMinRun(int length)
    {
        int r = 0;
        while (length >= 32)
        {
            r |= length & 1;
            length >>= 1;
        }
        return length + r;
    }
    // Ввод
    //     arr - массив для сортировки
    //     left - индекс с которого начинается сортировка
    //     right - индекс на котором заканчивается сортировка
    // Вывод
    //     -

    private void insertionSort(int[] arr, int left, int right)
    {
        int temp;
        for (int i = left + 1; i < right + 1; i++)
        {
            int j = i;
            while (j > left && arr[j] < arr[j - 1])
            {
                temp = arr[j];
                arr[j] = arr[j - 1];
                arr[j - 1] = temp;
                j--;
            }
        }
    }
    // Ввод
    //     arr - массив
    //     left - левый индекс
    //     middle - средний индекс
    //     right - правый индекс
    // Вывод
    //     -
    private void merge(int[] arr, int left, int middle, int right)
    {
        int len1 = middle - left + 1, len2 = right - middle, i;
        int[] leftArr = new int[len1];
        int[] rightArr = new int[len2];
        for (i = 0; i < len1; i++)
        {
            leftArr[i] = arr[left + i];
        }
        for (i = 0; i < len2; i++)
        {
            rightArr[i] = arr[middle + 1 + i];
        }

        int j = 0, k = left;
        i = 0;
        while (i < len1 && j < len2)
        {
            if (leftArr[i] <= rightArr[j])
            {
                arr[k] = leftArr[i];
                i++;
            }
            else
            {
                arr[k] = rightArr[j];
                j++;
            }

            k++;
        }
        while (i < len1)
        {
            arr[k] = leftArr[i];
            k++;
            i++;
        }
        while (j < len2)
        {
            arr[k] = rightArr[j];
            k++;
            j++;
        }
    }
    // Ввод
    //     arr - массив для сортировки
    // Вывод
    //     -
    public int[] Timsort(int[] numbers)
    {
        int[] res = new int[numbers.Length];
        numbers.CopyTo(res, 0);


        int minRun = calcMinRun(res.Length);

        for (int start = 0; start < res.Length; start += minRun)
        {
            int end = Math.Min(start + minRun - 1, res.Length - 1);
            insertionSort(res, start, end);
        }
        int size = minRun;
        while (size < res.Length)
        {
            for (int left = 0; left < res.Length; left += 2 * size)
            {
                int middle = Math.Min(res.Length - 1, left + size - 1);
                int right = Math.Min(left + 2 * size - 1, res.Length - 1);
                if (middle < right)
                {
                    merge(res, left, middle, right);
                }
            }

            size *= 2;
        }
        return res;
    }


    private void quicksortUtil(int[] arr, int start, int end)
    {
        if (start < end)
        {
            int pivot = arr[end];
            int i = start - 1;
            int temp;

            for (int j = start; j < end; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            temp = arr[i + 1];
            arr[i + 1] = arr[end];
            arr[end] = temp;
            quicksortUtil(arr, start, i);
            quicksortUtil(arr, i + 2, end);
        }
    }



    public int[] SelectSort(int[] numbers)
    {
        int[] res = new int[numbers.Length];
        numbers.CopyTo(res, 0);
        int temp;
        for (int i = 0; i < res.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < res.Length; j++)
            {
                if (res[j] < res[minIndex])
                {
                    minIndex = j;
                }
            }
            temp = res[i];
            res[i] = res[minIndex];
            res[minIndex] = temp;
        }
        return res;
    }

    public int[] QuickSort(int[] numbers)
    {
        int[] res = new int[numbers.Length];
        numbers.CopyTo(res, 0);
        quicksortUtil(res, 0, res.Length - 1);
        return res;
    }




}





