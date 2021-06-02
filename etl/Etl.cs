using System;
using System.Collections.Generic;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        Dictionary<string, int> dic = new Dictionary<string, int>();
        foreach (var item in old)
        {
            foreach (var str in item.Value)
            {
                dic.Add(str.ToLower(), item.Key);
            }
        }
        return dic;
    }
}