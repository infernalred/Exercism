using System;
using System.Collections.Generic;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        var expected = new Dictionary<char, int>
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 0,
            ['T'] = 0
        };
        foreach (var item in sequence)
        {
            if (expected.ContainsKey(item) != true)
                throw new ArgumentException();

            expected[item] += 1;
        }
        return expected;
    }
}