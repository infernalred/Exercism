using System;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number < 1)
            throw new ArgumentOutOfRangeException();
        int total = 0;
        for (int i = 1; i < number; i++)
        {
            if (number%i == 0)
                total += i;
        }
        //var sum = Enumerable.Range(1, number).Select(x => (number % x == 0 && number != x) ? x : 0).Sum();
        return total == number ? Classification.Perfect : total > number ? Classification.Abundant : Classification.Deficient;
    }
}
