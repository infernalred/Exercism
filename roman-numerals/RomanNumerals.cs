using System;
using System.Collections.Generic;
using System.Text;

public static class RomanNumeralExtension
{
    private static readonly List<Tuple<int, string>> _roman = new List<Tuple<int, string>>()
    {
            new Tuple<int, string>(1000, "M"),
            new Tuple<int, string>(900, "CM"),
            new Tuple<int, string>(500, "D"),
            new Tuple<int, string>(400, "CD"),
            new Tuple<int, string>(100, "C"),
            new Tuple<int, string>(90, "XC"),
            new Tuple<int, string>(50, "L"),
            new Tuple<int, string>(40, "XL"),
            new Tuple<int, string>(10, "X"),
            new Tuple<int, string>(9, "IX"),
            new Tuple<int, string>(5, "V"),
            new Tuple<int, string>(4, "IV"),
            new Tuple<int, string>(1, "I"),
    };
    public static string ToRoman(this int value)
    {
        if (value > 3000 || value < 0)
            throw new ArgumentOutOfRangeException();
        StringBuilder result = new StringBuilder();
        foreach (var item in _roman)
        {
            while (value >= item.Item1)
            {
                result.Append(item.Item2);
                value -= item.Item1;
            }
        }

        return result.ToString();
    }
}