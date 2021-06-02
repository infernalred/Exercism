using System;
using System.Linq;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        //string validChar = string.Empty;
        string checkAlphabet = "abcdefghijklmnopqrstuvwxyz";
        input = input.ToLower();
        return !checkAlphabet.Any(ch => !input.Contains(ch));
    }
}