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

    public static int[][] GenerateMatrix(int n)
    {
        int[][] result = new int[n][];
        Random random = new Random();
        
        for (int i = 0; i < n; i++)
        {
            result[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                result[i][j] = random.Next(0, 10000);
            }
        }

        return result;
    }

    public static int[] GeneratePowNumbers()
    {
        int[] res = new int[5];
        
        for (int i = 0; i < 5; i++) 
            res[i] = new Random().Next(1000);

        return res;
    }
}