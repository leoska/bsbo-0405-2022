namespace bsbo_0405_22;

public class Stack
{
    private Item top = null;

    public bool isEmpty()
    {
        Application.countOpers++;
        return top == null;
    }

    public void Push(Item item)
    {
        if (!isEmpty()) // 1
        {
            item.next = top; // 2
        }

        top = item; // 1

        Application.countOpers += 4;
    }

    public Item Pop()
    {
        if (isEmpty()) // 1
        {
            throw new Exception("Stack is empty!");
        }

        Item result = top; // 1
        top = top.next; // 2

        result.next = null; // 2

        Application.countOpers += 6;
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
        Application.countOpers += 1;
        if (isEmpty()) // 1
        {
            throw new Exception("Stack is empty!");
        }

        Application.countOpers += 2;
        for (int i = 0; i < pos; i++)
        {
            tmp.Push(Pop()); // 6 + 4 = 10 + 1 = 11
            Application.countOpers += 13;
        }
        
        int result = top.value;
        Application.countOpers += 2;

        Application.countOpers += 3;
        while (!tmp.isEmpty()) // 3
        {
            Push(tmp.Pop()); // 11
            Application.countOpers += 14; // 11 + 3
        }

        return result;
    }
    
    public void Set(int pos, int newValue, Stack tmp)
    {
        Application.countOpers += 1;
        if (isEmpty())
        {
            throw new Exception("Stack is empty!");
        }

        Application.countOpers += 2;
        for (int i = 0; i < pos; i++)
        {
            tmp.Push(Pop());
            Application.countOpers += 13;
        }

        top.value = newValue;
        Application.countOpers += 2;

        Application.countOpers += 3;
        while (!tmp.isEmpty())
        {
            Push(tmp.Pop());
            Application.countOpers += 14;
        }
    }

    public int this[int index]
    {
        get
        {
            Application.countOpers += 4;
            return Get(index, new Stack());
        }
        set
        {
            Application.countOpers += 5;
            Set(index, value, new Stack());
        }
    }
}