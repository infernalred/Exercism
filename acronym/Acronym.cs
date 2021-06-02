using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        
        char[] symbols = new char[] { ' ', ',', '-', '_' };
        return new string(string.Join("", phrase.Split(symbols, StringSplitOptions.RemoveEmptyEntries).Select(ch => ch[0]))).ToUpper();
    }
}

//public static string Abbreviate(string phrase) => new string(Words(phrase).Select(AcronymLetter).ToArray());

//private static IEnumerable<string> Words(string phrase) => Regex.Split(phrase, @"[^\w]+");

//private static char AcronymLetter(string word) => char.ToUpper(word[0]);