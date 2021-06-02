using System;
using System.Collections;

public class CircularBuffer<T>
{
    private readonly Queue queue;
    int capacity = 0;
    public CircularBuffer(int capacity)
    {
        this.capacity = capacity;
        queue = new Queue(capacity);
    }

    public T Read() => (T)queue.Dequeue();

    public void Write(T value)
    {
        if (capacity == queue.Count)
            throw new InvalidOperationException();
        queue.Enqueue(value);
    }

    public void Overwrite(T value)
    {
        if (capacity == queue.Count)
            queue.Dequeue();
        queue.Enqueue(value);
    }

    public void Clear() => queue.Clear();
}