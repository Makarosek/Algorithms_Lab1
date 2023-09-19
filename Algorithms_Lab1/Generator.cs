using System;

namespace Algorithms_Lab1;

public class Generator
{
    public static int[] GeneranteNumbers(int NumberOfNumbers)
    {
        int[] res = new int[NumberOfNumbers];
        Random random = new Random();

        for (int i = 0; i < NumberOfNumbers; i++)
        {
            res[i] = random.Next(0, 10000);
        }

        return res;
    }
}