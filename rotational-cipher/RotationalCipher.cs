using System;
using System.Collections.Generic;
using System.Linq;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        char[] result = text.ToCharArray();
        for (int i = 0; i < result.Length; i++)
        {
            if (char.IsLetter(result[i]))
            {
                int numerate = char.IsLower(result[i]) ? 'a' : 'A';
                result[i] = (char)(numerate + ((result[i] - numerate + shiftKey) % 26));
            }

        }
        return string.Concat(result);
    }
}