using System;
using System.Collections.Generic;
using System.Linq;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 2)
            throw new ArgumentOutOfRangeException();
        List<int> listNumbers = Enumerable.Range(2, limit - 1).ToList();
        for (int i = 0; i < listNumbers.Count; i++)
        {
            for (int k = 2; k < limit; k++)
            {
                listNumbers.Remove(listNumbers[i] * k);
            }
        }
        return listNumbers.ToArray();
    }
}