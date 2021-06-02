using System;
using System.Collections.Generic;

public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        int[][] result1 = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            int start = 1;
            result1[i] = new int[i + 1];
            for (int j = 0; j <= i; j++)
            {
                result1[i][j] = start;
                start = start * (i - j) / (j + 1);
            }
        }
        return result1;
    }

}