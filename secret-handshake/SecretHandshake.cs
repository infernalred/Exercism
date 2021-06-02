using System;
using System.Collections.Generic;

public static class SecretHandshake
{
    public static string[] Commands(int commandValue)
    {
        var commands = new Dictionary<int, string>(){
           { 1 << 0, "wink" },
           { 1 << 1, "double blink" },
           { 1 << 2, "close your eyes" },
           { 1 << 3, "jump" }
        };

        var res = new List<string>();
        foreach (var entry in commands)
        {
            if ((entry.Key & commandValue) != 0)
            {
                res.Add(entry.Value);
            }
        }
        if ((commandValue & 16) != 0)
        {
            res.Reverse();
        }
        return res.ToArray();
    }
}
