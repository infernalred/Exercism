using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public class Robot
{
    private readonly Random rand = new Random();
    public string Name { get; private set; }

    private static readonly HashSet<string> names = new HashSet<string>();

    public void Reset() => Name = RandomLetters();

    private string RandomLetters()
    {
        const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string abc = letters[rand.Next(0, letters.Length)].ToString() + letters[rand.Next(0, letters.Length)].ToString() + rand.Next(100, 999).ToString();
        if (names.Contains(abc))
            abc = RandomLetters();

        names.Add(abc);
        return abc;
    }

    public Robot() => Name = RandomLetters();


}