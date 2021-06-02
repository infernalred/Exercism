using System;
using System.Collections.Generic;
using System.Linq;

public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        int h = matrix.GetLength(0);
        int w = matrix.GetLength(1);
        int[][] rows = Enumerable.Range(0, h).Select(i => Enumerable.Range(0, w).Select(k => matrix[i, k]).ToArray()).ToArray();
        int[][] columns = Enumerable.Range(0, w).Select(i => Enumerable.Range(0, h).Select(k => matrix[k, i]).ToArray()).ToArray();

        int[] max = Enumerable.Range(0, h).Select(i => rows[i].Max()).ToArray();
        int[] min = Enumerable.Range(0, w).Select(i => columns[i].Min()).ToArray();

        bool CheckSaddle(int i, int k) => matrix[i, k] == max[i] && matrix[i, k] == min[k];

        for (int i = 0; i < h; i++)
        {
            for (int k = 0; k < w; k++)
            {
                 if (CheckSaddle(i, k))
                   yield return (i + 1, k + 1);
            }
        }
    }
}
