using System;
using System.Collections.Generic;
using System.Linq;

public static class PrimeFactors
{
    public static long[] Factors(long number)
    {
        int i = 2;
        List<long> primes = new List<long>();
        while (number != 1)
        {
            if (number % i == 0)
            {
                primes.Add(i);
                number /= i;
            }
            else i++;
        }
        return primes.ToArray();
    }
}