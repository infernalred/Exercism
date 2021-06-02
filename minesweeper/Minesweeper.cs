using System;
using System.Collections.Generic;
using System.Linq;

public static class Minesweeper
{
    public static string[] Annotate(string[] input)
    {
        if (input.Length == 0)
            return Array.Empty<string>();

        return Enumerable.Range(0, input.Length).Select(x => { var r = input[x]; return string.Concat(Enumerable.Range(0, input[x].Length).Select(i => r[i] == '*' ? '*' : GetNumberInBox(x, i, input))); }).ToArray();
    }


    private static char GetNumberInBox(int k, int l, string[] input)
    {
        List<(int, int)> ffff = new List<(int x, int y)>
        {
            (x: k - 1, y: l - 1 ),
            (x: k - 1, y: l ),
            (x: k - 1, y: l + 1 ),
            (x: k, y: l - 1 ),
            (x: k, y: l + 1 ),
            (x: k + 1, y: l - 1 ),
            (x: k + 1, y: l),
            (x: k + 1, y: l + 1 ),
        };
        int result = ffff.Select(cell => CheckMines(cell.Item1, cell.Item2, input)).Sum();
        return result == 0 ? ' ' : (char)('0' + result);
    }

    private static int CheckMines(int i, int j, string[] input)
    {
        if (i < 0 || i >= input.Length || j < 0 || j >= input[i].Length)
            return 0;
        
        return input[i][j] == '*' ? 1 : 0;
    }
}
