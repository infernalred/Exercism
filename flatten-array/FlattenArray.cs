using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        foreach (var item in input)
        {
            IEnumerable tmp = item as IEnumerable;
            if (tmp != null)
                foreach (var it in Flatten(tmp))
                {
                    yield return it;
                }
            else if (item != null)
                    yield return item;
        };
    }
}