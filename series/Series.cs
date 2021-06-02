using System;
using System.Collections.Generic;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (numbers == string.Empty || sliceLength < 1 || sliceLength > numbers.Length)
            throw new ArgumentException();
        int b = 0;
        List<string> sliceStr = new List<string>();
        for (int i = 0; i < numbers.Length; i++)
        {
            if (!(i+sliceLength > numbers.Length))
            { sliceStr.Add(numbers.Substring(i, sliceLength));
                ++b;
            }
        }
        return sliceStr.ToArray();
    }
    //public static string[] Slices(string numbers, int sliceLength)
    //{
    //    if (sliceLength > numbers.Length || sliceLength <= 0) throw new ArgumentException();

    //    return Enumerable.Range(0, numbers.Length - sliceLength + 1).Select(x => numbers.Substring(x, sliceLength)).ToArray();
    //}
}