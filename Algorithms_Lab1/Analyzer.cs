using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithms_Lab1;

public class Analyzer
{
    private static long[] GetTimes(int[][] arr, MainWindow.Alg alg)     //метод замера времени для любого алгоритма (не считает шаги)
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

        double middle = times.Average();                    //подсчёт среднего
        List<long> medianResults = new List<long>();

        foreach (var VARIABLE in times)
        {
            if ((VARIABLE + 1) <= 1.5 * (middle + 1))
            {
                medianResults.Add(VARIABLE);
            }
        }
        double res = medianResults.Average();

        return res / 10000;
    }

    public static double[] StepByStep(int[][] arr, MainWindow.Alg alg)      //TODO проверить
    {
        double[] times = new Double[arr[0].Length];         //массив со всеми медианами по порядку
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

}

