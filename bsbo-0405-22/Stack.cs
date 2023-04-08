namespace bsbo_0405_22;

public class Stack
{
    private Item top = null;

    public bool isEmpty()
    {
        return top == null;
    }

    public void Push(Item item)
    {
        if (!isEmpty())
        {
            item.next = top;
        }

        top = item;
    }

    public Item Pop()
    {
        if (isEmpty())
        {
            throw new Exception("Stack is empty!");
        }

        Item result = top;
        top = top.next;

        result.next = null;
        return result;
    }

    public void Print()
    {
        Item current = top;
        while (current != null)
        {
            Console.Write($"{current.value} ");
            current = current.next;
        }
        Console.WriteLine();
    }

    public int Get(int pos, Stack tmp)
    {
        if (isEmpty())
        {
            throw new Exception("Stack is empty!");
        }

        for (int i = 0; i < pos; i++)
        {
            tmp.Push(Pop());
        }

        int result = top.value;

        while (!tmp.isEmpty())
        {
            Push(tmp.Pop());
        }

        return result;
    }
    
    public void Set(int pos, int newValue, Stack tmp)
    {
        if (isEmpty())
        {
            throw new Exception("Stack is empty!");
        }

        for (int i = 0; i < pos; i++)
        {
            tmp.Push(Pop());
        }

        top.value = newValue;

        while (!tmp.isEmpty())
        {
            Push(tmp.Pop());
        }
    }

    public int this[int index]
    {
        get => Get(index, new Stack());
        set => Set(index, value, new Stack());
    }
}