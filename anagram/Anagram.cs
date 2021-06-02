using System;
using System.Collections.Generic;
using System.Linq;

public class Anagram
{
    private readonly string _base;
    public Anagram(string baseWord)
    {
        _base = baseWord.ToLower();
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        List<string> result = new List<string>();
        foreach (var item in potentialMatches)
        {
            if (item.Length == _base.Length && item.ToLower() != _base)
            {
                List<char> wordChars = new List<char>(item.ToLower());
                foreach (var ch in _base.Where(wordChars.Contains))
                {
                    wordChars.Remove(ch);
                }
                if (wordChars.Count == 0)
                    result.Add(item);
            }
        }
        return result.ToArray();
    }
}