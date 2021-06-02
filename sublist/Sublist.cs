using System;
using System.Collections.Generic;
using System.Linq;

public enum SublistType
{
    Equal,
    Unequal,
    Superlist,
    Sublist
}

public static class Sublist
{
    public static SublistType Classify<T>(List<T> list1, List<T> list2)
        where T : IComparable
    {
        if (list1.SequenceEqual(list2))
            return SublistType.Equal;

        if (CheckSublist(list1, list2))
            return SublistType.Sublist;

        if (CheckSublist(list2, list1))
            return SublistType.Superlist;

        return SublistType.Unequal;
    }

    public static bool CheckSublist<T>(List<T> list1, List<T> list2)
        where T : IComparable => list1.Count > list2.Count
            ? false
            : list1.Count == 0
            ? true
            : Enumerable.Range(0, list2.Count - list1.Count + 1).Any(i => list1.SequenceEqual(list2.Skip(i).Take(list1.Count)));

}