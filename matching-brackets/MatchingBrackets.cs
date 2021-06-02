using System;
using System.Linq;

public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        var selected = string.Concat(input.Where(x => "[]{}()".Contains(x)).ToList());
        int oldLength = selected.Length;

        while (selected.Length > 0)
        {
            selected = string.Concat(selected.Replace("()", "").Replace("[]", "").Replace("{}", "").Replace("()", "").Replace("()", "").Replace("[]", "").Replace("()", ""));

            if (oldLength == selected.Length)
                return false;

            oldLength = selected.Length;
        }
        return selected.Length == 0;
    }
}
