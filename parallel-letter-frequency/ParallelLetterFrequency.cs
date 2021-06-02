using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public static class ParallelLetterFrequency
{
    private static readonly Dictionary<char, int> words = new Dictionary<char, int>();
    private static readonly object threadLock = new object();
    public static Dictionary<char, int> Calculate(IEnumerable<string> texts)
    {
        words.Clear();
        Parallel.ForEach(texts, text =>
        {
            char[] str2 = text.ToLower().AsParallel().Where(char.IsLetter).ToArray();

            Parallel.ForEach(str2, str =>
            {
                lock (threadLock)
                    if (!words.ContainsKey(str))
                    { words.Add(str, 1); }

                    else { words[str] += 1; }
            });
        });
        return words;
    }
}

//=> texts
//        .AsParallel()
//        .SelectMany(t => t.ToLower())
//        .Where(c => char.IsLetter(c))
//        .GroupBy(c => c)
//        .ToDictionary(c => c.Key, c => c.Count());