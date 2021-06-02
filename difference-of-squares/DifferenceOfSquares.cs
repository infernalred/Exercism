using System;
using System.Collections.Generic;
using System.Linq;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        int square = Enumerable.Range(1, max).Sum();
        return square  * square;
    }

    public static int CalculateSumOfSquares(int max) => Enumerable.Range(1, max).Select(x => x * x).Sum();

    public static int CalculateDifferenceOfSquares(int max)
    {
        int square = CalculateSquareOfSum(max);
        int sum = CalculateSumOfSquares(max);
        return square - sum;
    }
}