using System;
using System.Collections.Generic;
using System.Linq;

public static class ScaleGenerator
{
    private static readonly string[] _scales = new string[] { "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#" };
    private static readonly string[] _sharps = new string[] {"C", "G", "D", "A", "a", "E", "B", "F#", "e", "b", "f#", "c#", "g#", "d#"};
    private static readonly string[] _flats = new string[] {"A", "Bb", "B", "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab" };
    private static readonly string[] _isFlats = new string[] { "F", "Bb", "Eb", "Ab", "Db", "Gb", "d", "g", "c", "f", "bb", "eb" };
    public static string[] Chromatic(string tonic)
    {
        var scale = _sharps.Contains(tonic) ? _scales : _flats;
        var idx = GetIndex(scale, tonic);
        var list = scale.Skip(idx).ToList();
        list.AddRange(scale.Take(idx).ToList());
        return list.ToArray();
    }

    public static string[] Interval(string tonic, string pattern)
    {
        var scale = Chromatic(tonic);
        var list = new List<string>
        {
            scale[0]
        };

        int idx = 0;
        foreach (var ch in pattern.ToCharArray())
        {
            idx += GetInterval(ch);
            if (scale[idx % scale.Length] == scale[0])
            {
                return list.ToArray();
            }

            list.Add(scale[idx % scale.Length]);
        }

        return list.ToArray();
    }

    private static int GetIndex(string[] scale, string tonic)
    {
        for (int i = 0; i < scale.Length; i++)
        {
            if (scale[i].ToLower() == tonic.ToLower())
            {
                return i;
            }
        }

        return -1;
    }
    private static int GetInterval(char ch) => ch == 'm' ? 1 : ch == 'M' ? 2 : 3;

}