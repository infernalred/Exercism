using System;
using System.Collections.Generic;
using System.Linq;

public static class AtbashCipher
{
    public static string Encode(string plainValue)
    {
        string sss = string.Concat(plainValue.Where(char.IsLetterOrDigit).Select(EncodeChar));
        return string.Concat(sss.Select((c, i) => c + ((i + 1) % 5 == 0 ? " " : ""))).Trim();
    }

    public static string Decode(string encodedValue) => string.Concat(encodedValue.Where(char.IsLetterOrDigit).Select(DecodeChar));

    private static char EncodeChar(char ch)
    {
        if (!char.IsLetter(ch))
            return ch;
        int ttt = char.IsLower(ch) ? 'a' : 'A';
        char ccc = (char)(('z' - ch) + ttt);
        return ccc;
    }

    private static char DecodeChar(char ch)
    {
        if (!char.IsLetter(ch))
            return ch;
        int ttt = char.IsLower(ch) ? 'a' : 'A';
        char ccc = (char)(('z' + ttt) - char.ToLower(ch));
        return ccc;
    }
}
