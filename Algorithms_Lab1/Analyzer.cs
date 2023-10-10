using System.Diagnostics;

namespace Algorithms_Lab1;

public class Analyzer
{
    public long[] GetTimes(int[][] arr, MainWindow.Alg alg)
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

        return res/100;
    }
}

