using System.Collections.Generic;

namespace bsbo_0405_22;

public class QueueElem<T>: Queue<T>
{
    public T Get(int index)
    {
        if (Count < 1)
        {
            throw new Exception("QueueElem is empty");
        }

        if (index > Count - 1)
        {
            throw new Exception("QueueElem out of range");
        }

        if (index == 0)
        {
            return Peek();
        }
        
        for (int i = 0; i < index; i++)
        {
            Enqueue(Dequeue());
        }

        T result = Peek();
        
        for (int i = index; i < Count; i++)
        {
            Enqueue(Dequeue());
        }

        return result;
    }
    
    public void Set(int index, T newValue)
    {
        if (Count < 1)
        {
            throw new Exception("QueueElem is empty");
        }

        if (index > Count - 1)
        {
            throw new Exception("QueueElem out of range");
        }
        
        //[1, 2, 3, 4]
        // (2) = 7
        //[2, 3, 4, 1] (0)
        //[3, 4, 1, 2] (1)
        //[4, 1, 2, 7)
        //[1, 2, 7, 4]
        
        
        // [1, 2, 3, 4]
        // (1) = 7
        // [2, 3, 4, 1] (0)
        // [3, 4, 1, 7]
        // [4, 1, 7, 3] (2)
        // [1, 7, 3, 4] (3)

        for (int i = 0; i < index; i++)
        {
            Enqueue(Dequeue());
        }

        Dequeue();
        Enqueue(newValue);
        
        for (int i = index + 1; i < Count; i++)
        {
            Enqueue(Dequeue());
        }
    }

    public void Print()
    {
        for (int i = 0; i < Count; i++)
        {
            T elem = Dequeue();
            Console.Write($"{elem} ");
            Enqueue(elem);
        }
        Console.WriteLine();
    }

    public T this[int index]
    {
        get => Get(index);
        set => Set(index, value);
    }
}