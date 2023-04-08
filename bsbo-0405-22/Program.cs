// See https://aka.ms/new-console-template for more information
using System;

namespace bsbo_0405_22;

static class Application
{
    static void PrintArray(int[] arr)
    {
        foreach (int item in arr)
        {
            Console.Write($"{item.ToString()} ");
        }

        Console.WriteLine();
    }

    static void SortBubble(int[] arr)
    {
        int N = arr.Length;
        
        bool flag = false;
        for (int i = 0; i < N; i++)
        {
            flag = false;
            for (int j = 0; j < N - 1 - i; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Способ №1 (доп. память)
                    // O(9), M(1)
                    // int tmp = arr[j];
                    // arr[j] = arr[j + 1];
                    // arr[j + 1] = tmp;
                    
                    
                    // Способ №2 (Без памяти)
                    // [4, 1]
                    // 1) (1) + (2) -> (2): [4, 5]
                    // 2) (2) - (1) -> (1): [1, 5]
                    // 3) (2) - (1) -> (2): [1, 4]
                    // O(20), M(0)
                    // arr[j + 1] = arr[j + 1] + arr[j];
                    // arr[j] = arr[j + 1] - arr[j];
                    // arr[j + 1] = arr[j + 1] - arr[j];

                    // Способ №3 (Tuple swap)
                    // O(6 + k), M(2k)
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    flag = true;
                }
            }

            if (!flag)
            {
                break;
            }
        }
    }

    static void Main(string[] args)
    {
        // Практика №1 (сортировка пузырьком)
        // int[] arr = new[] { 3, 9, -15, 0, 99, 156, -123, 9563 };
        //
        // PrintArray(arr);
        // SortBubble(arr);
        // PrintArray(arr);

        // Практика №2 (сортировка линейного списка Стэк)
        Stack stack = new Stack();
        Stack tmp = new Stack();
        int N = 10;

        Random rnd = new Random();

        for (int i = 0; i < N; i++)
        {
            stack.Push(new Item(rnd.Next(0, 1000)));
        }
        
        stack.Print();
        
        // Без перегрузки []
        // SortBubble(stack, tmp, N);
        
        // С перегрузкой []
        SortBubble(stack, N);
        
        stack.Print();
    }

    static void SortBubble(Stack stack, Stack tmp, int N)
    {
        bool flag = false;
        for (int i = 0; i < N; i++)
        {
            flag = false;
            for (int j = 0; j < N - i - 1; j++)
            {
                int current = stack.Get(j, tmp);
                int neighbor = stack.Get(j + 1, tmp);
                
                if (current > neighbor)
                {
                    stack.Set(j, neighbor, tmp);
                    stack.Set(j + 1, current, tmp);
                    flag = true;
                }
            }

            if (!flag)
                break;
        }
    }

    static void SortBubble(Stack stack, int N)
    {
        bool flag = false;
        for (int i = 0; i < N; i++)
        {
            flag = false;
            for (int j = 0; j < N - i - 1; j++)
            {
                if (stack[j] > stack[j + 1])
                {
                    (stack[j], stack[j + 1]) = (stack[j + 1], stack[j]);
                    flag = true;
                }
            }

            if (!flag)
                break;
        }
    }
}