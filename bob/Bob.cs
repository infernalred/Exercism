using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Bob
{
    public static string Response(string statement)
    {
        statement = statement.Trim();

        if (statement.Length == 0)
            return "Fine. Be that way!";

        //Question and yell
        if (statement.Any(char.IsUpper) && !statement.Any(char.IsLower) && statement.EndsWith("?"))
            return "Calm down, I know what I'm doing!";
        
        //Question
        if (statement.EndsWith("?"))
            return "Sure.";

        //Yell
        if (statement.Any(char.IsUpper) && (!statement.Any(char.IsLower)))
            return "Whoa, chill out!";

        return "Whatever.";
    }
}