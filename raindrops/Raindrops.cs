using System;
using System.Collections.Generic;

public static class Raindrops
{
    public static string Convert(int number)
    {
        Dictionary<int, string> numbers = new Dictionary<int, string>
        {
            { 3, "Pling" },
            { 5, "Plang" },
            { 7, "Plong" }
        };
        string result = string.Empty;
        foreach (var item in numbers.Keys)
        {
            if (number % item == 0)
                result += numbers[item];
        }
        if (result == string.Empty)
            result = number.ToString();
        return result;
    }
}