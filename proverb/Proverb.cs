﻿using System;

public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        if (subjects.Length == 0)
            return Array.Empty<string>();
        string[] song = new string[subjects.Length];
        for (int i = 0; i < subjects.Length; i++)
        {
            song[i] = subjects.Length == 1 || i == subjects.Length - 1
                ? $"And all for the want of a {subjects[0]}."
                : $"For want of a {subjects[i]} the {subjects[i + 1]} was lost.";
        }

        return song;
    }
}

//Enumerable.Range(0, subjects.Length - 1)
//                  .Select(x => $"For want of a {subjects[x]} the {subjects[x + 1]} was lost.")
//                  .Append($"And all for the want of a {subjects[0]}.")
//                  .ToArray();