using System;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (!(firstStrand.Length == secondStrand.Length))
            throw new ArgumentException();
        int differences = 0;
        for (int i = 0; i < firstStrand.Length; i++)
        {
            if (firstStrand[i] != secondStrand[i])
                differences += 1;
        }

        return differences;
    }
}