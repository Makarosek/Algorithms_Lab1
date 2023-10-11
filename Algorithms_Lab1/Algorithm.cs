using System;

namespace Algorithms_Lab1;

public static class Algorithm
{
    public static void FirstAlg(int[] numbers)            //Кажется, всё - таки нужно возвращать еденицу, а не массив 1
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = 1;
        }
    }

    public static void Summ(int[] numbers)                //~~~~
    {
        int sum = 0;
        foreach (var VARIABLE in numbers)
        {
            sum += VARIABLE;
        }
    }
    
    public static void Mult(int[] numbers)                //~~~~
    {
        int mult = 1;
        foreach (var VARIABLE in numbers)
        {
            mult *= VARIABLE;
        }
    }
    
    // TODO Добавить алгоритм Горнера

    public static void BubbleSort(int[] numbers)
    {
        int temp;
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = 0; j < numbers.Length - 1; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    temp = numbers[j];
                    numbers[j] = numbers[j + 1];
                    numbers[j + 1] = temp;
                }
            }
        }
    }

    public static void QuickSort(int[] numbers)
    {
        quicksortUtil(numbers, 0, numbers.Length - 1);
    }
    
    private static void quicksortUtil(int[] arr, int start, int end)
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
    
    public static void TimSort(int[] numbers) 
    {
        int minRun = CalcMinRun(numbers.Length);
 
        for (int start = 0; start < numbers.Length; start += minRun) {
            int end = Math.Min(start + minRun - 1, numbers.Length - 1);
            InsertionSort(numbers, start, end);
        }
        int size = minRun;
        while (size < numbers.Length) {
            for (int left = 0; left < numbers.Length; left += 2 * size) {
                int middle = Math.Min(numbers.Length - 1, left + size - 1);
                int right = Math.Min(left + 2 * size - 1, numbers.Length - 1);
                if (middle < right) {
                    Merge(numbers, left, middle, right);
                }
            }
            size *= 2;
        }
    }
    static void Merge(int[] arr, int left, int middle, int right) 
    {
        int len1 = middle - left + 1, len2 = right - middle, i;
        int[] leftArr = new int[len1];
        int[] rightArr = new int[len2];
        for (i = 0; i < len1; i++) {
            leftArr[i] = arr[left + i];
        }
        for (i = 0; i < len2; i++) {
            rightArr[i] = arr[middle + 1 + i];
        }
 
        int j = 0, k = left;
        i = 0;
        while (i < len1 && j < len2) {
            if (leftArr[i] <= rightArr[j]) {
                arr[k] = leftArr[i];
                i++;
            } else {
                arr[k] = rightArr[j];
                j++;
            }
 
            k++;
        }
        while (i < len1) {
            arr[k] = leftArr[i];
            k++;
            i++;
        }
        while (j < len2) {
            arr[k] = rightArr[j];
            k++;
            j++;
        }
    }
    static void InsertionSort(int[] arr, int left, int right) 
    {
        int temp;
        for (int i = left + 1; i < right + 1; i++) {
            int j = i;
            while (j > left && arr[j] < arr[j - 1]) {
                temp = arr[j];
                arr[j] = arr[j - 1];
                arr[j - 1] = temp;
                j--;
            }
        }
    }
    static int CalcMinRun(int length) 
    {
        int r = 0;
        while (length >= 32) {
            r |= length & 1;
            length >>= 1;
        }
        return length + r;
    }
    
    
    
    public static void GnomeSort(int[] numbers)        // Сортировка Никиты
    {
        int i = 1;
        int temp;

        while (i < numbers.Length)
        {
            if (i == 0)
            {
                i = 1;
            }

            if (numbers[i - 1] <= numbers[i])
            {
                i++;
            }
            else
            {
                temp = numbers[i];
                numbers[i] = numbers[i - 1];
                numbers[i - 1] = temp;
                i--;
            }
        }
    }
    
    public static void SelectSort(int[] numbers)       // Сортировка Амира
    {
        int temp;
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[j] < numbers[minIndex])
                {
                    minIndex = j;
                }
            }
            temp = numbers[i];
            numbers[i] = numbers[minIndex];
            numbers[minIndex] = temp;
        }
    }
    
    public static void StoogeSort(int[] arr)            // Сортировка Анатолия
    {          
        StoogeSortUtil(arr, 0, arr.Length - 1);
    }
    private static void StoogeSortUtil(int[] arr, int start, int end)
    {
        if (arr[start] > arr[end]) {
            int temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
        }
        if (end - start + 1 > 2) {
            int delta = (end - start + 1) / 3;
            StoogeSortUtil(arr, start, end - delta);
            StoogeSortUtil(arr, start + delta, end);
            StoogeSortUtil(arr, start, end - delta);
        }
    }
    

    public static int Pow(double x, int n)
    {
        int counter = 0;
        for (int i = 1; i < n; i++)
        {
            x *= x;
            counter++;
        }
        return counter;
    }

    public static int RecPow(double x, int n)
    {
        int counter = 0;
        double f;
        if (n == 0)
        {
            f = 1;
            counter++;
        }
        else
        {
            f = RecPow(x, n / 2);
            
            f = n % 2 == 1 ? f * f
                :f * f * x;
            counter++;
        }
        return counter;
    }

    public static int QuickPow(double x, int n)
    {
        int counter = 0;
        double c = x;
        int k = n;

        double f = k % 2 == 1 ? c : 1;
        counter++;

        do
        {
            k = k / 2;
            counter++;

            c *= c;
            counter++;

            if (k % 2 == 1)
            {
                f *= c;
                counter++;
            }

        } while (k != 0);

        return counter;
    }

    public static int QuicPow1(double x, int n)
    {
        int counter = 0;
        double c = x;
        double f = 1;
        int k = n;

        while (k != 0)
        {
            if (k / 2 == 0)
            {
                c *= c;
                counter++;
                k /= 2;
                counter++;
            }
            else
            {
                f *= c;
                counter++;
                k--;
                counter++;
            }
        }
        return counter;
    }
    
    public static void MatrixProduct(int[][] matrixA, int[][] matrixB)
    {
        int n = matrixA.Length;
        
        int[][] result = new int[n][];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = new int[n];
        }

        for (int i = 0; i < n; ++i) // каждая строка A
        {
            for (int j = 0; j < n; ++j)// каждый столбец B
            {
                for (int k = 0; k < n; ++k)
                {
                    result[i][j] += matrixA[i][k] * matrixB[k][j];
                }
            }
        }
    }
    
}

