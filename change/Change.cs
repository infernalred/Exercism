using System;
using System.Collections.Generic;
using System.Linq;

public static class Change
{
    //static List<int> coinsArray = new List<int>();
    public static int[] FindFewestCoins(int[] coins, int target)
    {
        if (target == 0)
            return Array.Empty<int>();
        if (target < coins.Min())
            throw new ArgumentException();
        if (coins.Contains(target))
            return new int[] { target };
        var result = CheckCoins(coins.Where(x => x <= target).Reverse().ToArray(), target, 0);
        var result2 = CheckCoins(coins.Where(x => x <= target).Reverse().ToArray(), target, 1);
        var resArray = result.Count() < result2.Count() ? result.ToArray() : result2.ToArray();
        if (resArray.Sum() != target)
            throw new ArgumentException();

        return (from num in resArray
                orderby num
                select num).ToArray();
    }


    private static IEnumerable<int> CheckCoins(int[] coins, int target, int start)
    {
        int tmp = 0;
        List<int> result2 = new List<int>();
        while (target > tmp)
        {
            if (target - coins[start] - tmp == 0 || target - coins[start] * 3 - tmp >= coins.Min() || target - coins[start] - tmp >= coins.Min())
            {
                result2.Add(coins[start]);
                tmp += coins[start];
            }
            else
            {
                start++;
                if (start == coins.Length)
                {
                    tmp += coins.Max();
                }
            }
        }
        

        return result2;
    }
}