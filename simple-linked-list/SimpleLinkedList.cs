using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    //private SimpleLinkedList<T> _next;
    //private SimpleLinkedList<T> _previous;

    public SimpleLinkedList(T value) => Value = value;

    public SimpleLinkedList(IEnumerable<T> values)
    {
        Value = values.First();
        SimpleLinkedList<T> next = this;
        foreach (var item in values.Skip(1))
        {
            next.Next = new SimpleLinkedList<T>(item);
            next = next.Next;
        }
    }

    public T Value { get; private set; }

    public SimpleLinkedList<T> Next { get; private set; }

    public SimpleLinkedList<T> Add(T value)
    {
        var node = this;
        while (node.Next != null)
            node = node.Next;
        node.Next = new SimpleLinkedList<T>(value);
        return node;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var next = this;
        do
        {
            yield return next.Value;
            next = next.Next;
        } while (next != null);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}