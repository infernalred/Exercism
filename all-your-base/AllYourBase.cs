using System;
using System.Linq;

public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (inputBase < 2 || inputDigits.Any(x => x < 0 || x >= inputBase))
            throw new ArgumentException();

        if (outputBase < 2)
            throw new ArgumentException();

        int base10 = inputDigits.Reverse().Select((x, i) => x * (int)Math.Pow(inputBase, i)).Sum();
        var result = Enumerable.Empty<int>();
        while (base10 >= outputBase)
        {
            result = result.Append(base10 % outputBase);
            base10 /= outputBase;
        }
        result = result.Append(base10 % outputBase);

        return result.Reverse().ToArray();
    }
}