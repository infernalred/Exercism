using System;
using System.Collections.Generic;
using System.Linq;

public class Matrix
{
    private readonly List<List<int>> numbers;
    public Matrix(string input) => numbers = input.Split("\n").Select(x => x.Split().Select(s => Convert.ToInt32(s)).ToList()).ToList();

    public int Rows => numbers.Count();

    public int Cols => numbers.First().Count();

    public int[] Row(int row) => numbers[row - 1].ToArray();

    public int[] Column(int col) => numbers.Select(r => r[col - 1]).ToArray();
}