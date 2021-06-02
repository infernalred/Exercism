using System;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        char[] arstr = input.ToCharArray();
        Array.Reverse(arstr);
        string output = new string(arstr);
        return output;
    }
}