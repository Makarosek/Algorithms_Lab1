using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Algorithms_Lab1;

public class Analyzer
{
    private static long[] GetTimes(int[][] arr, MainWindow.Alg alg)     
    {
        Stopwatch stopwatch = new Stopwatch();
        long[] res = new long[5];
        
        for (int i = 0; i < 5; i++)
        {
            stopwatch.Start();
            alg(arr[i]);
            stopwatch.Stop();
    
            res[i] = stopwatch.ElapsedTicks;
            stopwatch.Reset();
        }

        return res;
    }

    public static double CalculateMedian(int[][]arr, MainWindow.Alg alg)
    {
        long[] times = GetTimes(arr, alg);

        double middle = times.Average();                            
        List<long> medianResults = new List<long>();

        foreach (var VARIABLE in times)
        {
            if ((VARIABLE + 1) <= 1.2 * (middle + 1))
            {
                medianResults.Add(VARIABLE);
            }
        }
        double res = medianResults.Average();

        return res / 10000;
    } 

    public static double[] GetAlgsResult(int[][] arr, MainWindow.Alg alg)
    {
        double[] times = new Double[arr[0].Length]; 
        for (int i = 1; i < arr[0].Length; i++)
            {
                int[][] temp = new int[5][];
            
                for (int k = 0; k < 5; k++)
                {
                    temp[k] = new int[i];
                    for (int j = 0; j < i; j++)
                    {
                        temp[k][j] = arr[k][j];
                    }
                }
                times[i] = CalculateMedian(temp, alg);
            }
        return times;
    }
    
    public static double[] GetPowsResult(int[] x, int n, MainWindow.Pow pow)
    {
        double[] res = new double[n];
        for (int i = 1; i <= n; i++)
        {
            int[] temp = new int[5];
            for (int k = 0; k < 5; k++)
            {
                temp[i] = pow(x[k], i);
            }

            res[i] = CalculateMedian(temp);
        }

        return res;
    }

    private static double CalculateMedian(int[] numbers)
    {
        double average = numbers.Average();

        List<int> temp = new List<int>();

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] <= average * 1.2)
            {
                temp.Add(numbers[i]);
            }
        }

        double median = temp.Average();
        return median;
    }

    public static double[] GetMatrixResult(int[][] matrixA, MainWindow.Matrix matrix)
    {
        double[] times = new double[matrixA.Length];

        for (int i = 1; i <= matrixA.Length; i++)
        {
            int[][] temp = new int[i][];
            
            for (int j = 0; j < i; j++)
            {
                temp[j] = new int[i];
                for (int k = 0; k < i; k++)
                {
                    temp[j][k] = matrixA[j][k];
                }
            }

            times[i - 1] = (double)GetTimes(temp, matrix) / 10000;
        }
        
        return times;
    }

    private static long GetTimes(int[][] matrixA, MainWindow.Matrix matrix)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        matrix(matrixA, matrixA);
        stopwatch.Stop();

        return stopwatch.ElapsedTicks;
    }
    
    
    
    
    
    
}

