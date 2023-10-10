using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Algorithms_Lab1;

public class Analyzer
{
    private long[] GetTimes(int[][] arr, MainWindow.Alg alg)     //метод замера времени для любого алгоритма (не считает шаги)
    {
        Stopwatch stopwatch = new Stopwatch();
        long[] res = new long[5];

        for (int i = 0; i < arr.Length; i++)
        {
            stopwatch.Start();
            alg(arr[i]);
            stopwatch.Stop();

            res[i] = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();

        }

        return res;
    }

    public double CalculateMedian(int[][]arr, MainWindow.Alg alg)
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

        return res;
    }
}

