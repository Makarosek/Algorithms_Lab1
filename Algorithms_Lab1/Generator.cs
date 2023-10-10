using System;

namespace Algorithms_Lab1;

public class Generator
{
    public static int[][] GeneranteNumbers(int numberOfNumbers)
    {
        int[][] res = new int[5][];
        Random random = new Random();

        for (int i = 0; i < 5; i++)
        {
            res[i] = new int[numberOfNumbers];
            for (int j = 0; j < numberOfNumbers; j++)
            {
                res[i][j] = random.Next(0, 10000);
            }
        }

        return res;
    }
}