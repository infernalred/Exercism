using System;
using System.Collections.Generic;
using System.Linq;

public static class PalindromeProducts
{
    public static (int, IEnumerable<(int,int)>) Largest(int minFactor, int maxFactor)
    {
        int largestvalue = 0;
        List<(int, int)> largestfactors = new List<(int, int)>();
        for (int ii = minFactor; ii <= maxFactor; ii++)
        {
            for (int jj = ii; jj <= maxFactor; jj++)
            {
                int product = ii * jj;
                if (isPalindrome(product))
                {
                    if (largestvalue <= product)
                    {
                        if (largestvalue < product)
                            largestfactors.Clear();
                        largestvalue = product;
                        largestfactors.Add((ii, jj));
                    }
                }
            }
        }
        if (largestfactors.Count < 1) throw new ArgumentException();
        return (largestvalue, largestfactors.ToArray());
    }

    public static (int, IEnumerable<(int,int)>) Smallest(int minFactor, int maxFactor)
    {
        int smallestvalue = maxFactor * maxFactor;
        List<(int, int)> smallestfactors = new List<(int, int)>();
        for (int ii = minFactor; ii <= maxFactor; ii++)
        {
            for (int jj = ii; jj <= maxFactor; jj++)
            {
                int product = ii * jj;
                if (isPalindrome(product))
                {
                    if (smallestvalue >= product)
                    {
                        if (smallestvalue > product)
                            smallestfactors.Clear();
                        smallestvalue = product;
                        smallestfactors.Add((ii, jj));
                    }
                }
            }
        }
        if (smallestfactors.Count < 1) throw new ArgumentException();
        return (smallestvalue, smallestfactors.ToArray());
    }

    private static bool isPalindrome(int n)
    {
        string nstring = n.ToString();
        for (int ii = 0; ii < nstring.Length / 2; ii++)
        {
            if (nstring[ii] != nstring[nstring.Length - 1 - ii]) return false;
        }
        return true;
    }
}
