using System;
using System.Collections.Generic;
using System.Linq;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        List<int> num = new List<int>(Digits(number));
        var query = from digit in num
                    let tmp = Math.Pow(digit, num.Count)
                    select tmp;
        int temp = Convert.ToInt32(query.Sum());
        return (temp == number);
    }

    public static IEnumerable<int> Digits(this int numbers)
    {
        do
        {
            yield return numbers % 10;
            numbers /= 10;
        } while (numbers > 0);
        
    }
}