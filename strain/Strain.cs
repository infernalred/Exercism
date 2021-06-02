using System;
using System.Collections.Generic;

public static class Strain
{
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        foreach (var item in collection)
        {
            if (predicate(item) == true)
                yield return item;
        }
    }
    //=> collection.Where(x => !predicate(x));
public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        foreach (var item in collection)
        {
            if (predicate(item) != true)
                yield return item;
        }
    }
}