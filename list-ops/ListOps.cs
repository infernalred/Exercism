using System;
using System.Collections.Generic;
using System.Linq;

public static class ListOps
{
    public static int Length<T>(List<T> input) 
    {
        int i = 0;
        foreach (var item in input)
            i++;
        return i;
    } 

    public static List<T> Reverse<T>(List<T> input)
    {
        int size = Length(input);
        List<T> result = new List<T>();
        for (int i = size -1; i >= 0; i--)
        {
            result.Add(input[i]);
        }
        return result;
    }

    public static List<TOut> Map<TIn, TOut>(List<TIn> input, Func<TIn, TOut> map)
    {
        List<TOut> result = new List<TOut>();
        foreach (var item in input)
            result.Add(map(item));
        return result;
    }

    public static List<T> Filter<T>(List<T> input, Func<T, bool> predicate)
    {
        List<T> result = new List<T>();
        foreach (var item in input)
            if (predicate(item))
                result.Add(item);
        return result;
    }

    public static TOut Foldl<TIn, TOut>(List<TIn> input, TOut start, Func<TOut, TIn, TOut> func)
    {
        TOut o = start;
        foreach (var item in input)
            o = func(o, item);
        return o;
    }

    public static TOut Foldr<TIn, TOut>(List<TIn> input, TOut start, Func<TIn, TOut, TOut> func)
    {
        TOut o = start;
        foreach (var item in Reverse(input))
            o = func(item, o);
        return o;
    }

    public static List<T> Concat<T>(List<List<T>> input)
    {
        List<T> result = new List<T>();
        foreach (var list in input)
            foreach (var item in list)
                result.Add(item);
        return result;
    }

    public static List<T> Append<T>(List<T> left, List<T> right)
    {
        List<T> result = new List<T>();
        foreach (var item in left)
        {
            result.Add(item);
        }

        foreach (var item in right)
        {
            result.Add(item);
        }

        return result;
    }
}