using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class Wordy
{
    private static readonly Regex _mask = new Regex(@"(?<left>-?\d+) (?<operation>-?plus|minus|divided by|multiplied by) (?=(?<right>-?\d+))");
    private static readonly Dictionary<string, Func<int, int, int>> _op = new Dictionary<string, Func<int, int, int>>()
    {
        { "plus", (a, b) => a + b },
        { "minus", (a, b) => a - b },
        { "multiplied by", (a, b) => a * b },
        { "divided by", (a, b) => a / b }
    };
    
    public static int Answer(string question)
    {
        var phrase = _mask.Matches(question);
        if (phrase.Count == 0)
            throw new ArgumentException("Sorry, i can't parse.");
        int result = 0;
        int a = Convert.ToInt32(phrase[0].Groups["left"].Value);
        foreach (Match match in phrase)
        {
            string op = match.Groups["operation"].Value;
            int b = GetRightValue(match);
            result = _op[op](a, b);
        }


        return result;
    }

    private static int GetRightValue(Match match)
    {
        return Convert.ToInt32(match.Groups["right"].Value);
    }
}