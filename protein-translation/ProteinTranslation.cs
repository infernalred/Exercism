using System;
using System.Collections.Generic;

public static class ProteinTranslation
{
    private static readonly Dictionary<string, string> RNA = new Dictionary<string, string>()
    {
        ["AUG"] = "Methionine", 
        ["UUU"] = "Phenylalanine", ["UUC"] = "Phenylalanine",
        ["UUA"] = "Leucine", ["UUG"] = "Leucine",
        ["UCU"] = "Serine", ["UCC"] = "Serine", ["UCA"] = "Serine", ["UCG"] = "Serine",
        ["UAU"] = "Tyrosine", ["UAC"] = "Tyrosine",
        ["UGU"] = "Cysteine", ["UGC"] = "Cysteine",
        ["UGG"] = "Tryptophan",
        ["UAA"] = "break", ["UAG"] = "break", ["UGA"] = "break"
    };
    public static string[] Proteins(string strand)
    {
        List<string> result = new List<string>();
        for (int i = 0; i < strand.Length; i += 3)
        {
            string strAdd = RNA[strand.Substring(i, 3)];
            if (strAdd == "break")
                break;
            result.Add(strAdd);
        }
        return result.ToArray();
    }
}