using System;
using System.Collections.Generic;
using System.Linq;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span) 
    {
        if (span < 0 || span > digits.Length)
            throw new ArgumentException();
        if (span > 0 && digits == string.Empty)
            throw new ArgumentException();
        if (span == 0)
            return 1;
        long result = 0;
        int j = 0;
        while (j + span <= digits.Length)
        {
            List<long> tmp = new List<long>();
            for (int i = j; i < j + span; i++)
            {
                try
                {
                    tmp.Add(Convert.ToInt64(digits[i].ToString()));
                }
                catch (Exception)
                {

                    throw new ArgumentException();
                }
            }
            long query = tmp.Aggregate((x, y) => x * y);
            if (query > result)
                result = query;
            j++;
        }

        return result;
    }
}

//private static IEnumerable<int> Products(string digits, int span)
//{
//    int chunkCount = digits.Count() - span + 1;
//    foreach (int start in Enumerable.Range(0, chunkCount))
//    {
//        yield return digits.Substring(start, span)
//            .Select(c => (int)Char.GetNumericValue(c))
//            .Aggregate(1, (a, b) => a * b);
//    }
//}

//public static long GetLargestProduct(string digits, int span)
//{
//    if (span > digits.Count())
//        throw new ArgumentException("span can't be longer than digits");
//    if (span < 0)
//        throw new ArgumentException("span can't be negative");
//    if (!digits.All(c => Char.IsNumber(c)))
//        throw new ArgumentException("digits must be numeric");
//    return Products(digits, span).Max();
//}