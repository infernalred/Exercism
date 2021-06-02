using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class Isogram
{
    
    public static bool IsIsogram(string word)
    {
        string checkAlphabet = "abcdefghijklmnopqrstuvwxyz";
        word = word.ToLower();
        HashSet<char> alphabet = new HashSet<char>();
        bool dubl = true;
        for (int i = 0; i < word.Length; i++)
        {
            if (alphabet.Contains(word[i]))
                return false;
            
            if (!word.Any(ch => !checkAlphabet.Contains(word[i])))
                alphabet.Add(word[i]);
        }
        return dubl;
    }
}


//Regex pattern = new Regex(@"(\w).*\1", RegexOptions.IgnoreCase);

//return !pattern.Match(word).Success;



//var lowerCaseLetters = word.ToLower().Where(char.IsLetter).ToList();
//return lowerCaseLetters.Distinct().Count() == lowerCaseLetters.Count;