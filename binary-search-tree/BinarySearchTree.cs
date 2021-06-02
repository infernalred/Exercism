using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree : IEnumerable<int>
{
    public BinarySearchTree(int value) => Value = value;

    public BinarySearchTree(IEnumerable<int> values)
    {
        Value = values.First();
        foreach (var item in values.Skip(1))
        {
            Add(item);
        }
    }

    public int Value { get; }

    public BinarySearchTree Left { get; private set; }
    public BinarySearchTree Right { get; private set; }

    public BinarySearchTree Add(int value)
    {
        if (value <= Value)
            Left = Left?.Add(value) ?? new BinarySearchTree(value);
        else
            Right = Right?.Add(value) ?? new BinarySearchTree(value);

        return this;
    }

    public IEnumerator<int> GetEnumerator()
    {
        if (Left != null)
            foreach (var LeftValue in Left)
            {
                yield return LeftValue;
            }

        yield return Value;

        if (Right != null)
            foreach (var RigthValue in Right)
            {
                yield return RigthValue;
            }
            
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}