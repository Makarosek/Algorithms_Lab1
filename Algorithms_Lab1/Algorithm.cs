namespace Algorithms_Lab1;

public class Algorithm
{
    public int[] FirstAlg(int[] numbers)            //Кажется, всё - таки нужно возвращать еденицу, а не массив 1
    {
        int[] res = new int[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            res[i] = 1;
        }
        return res;
    }

    public int[] Summ(int[] numbers)                //~~~~
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
    
    public int[] Mult(int[] numbers)                //~~~~
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
        numbers.CopyTo(res,0);

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
}

