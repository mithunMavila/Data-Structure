using System;

class Fibonacci
{
    static int FibonacciRecursive(int n)
    {
        if (n <= 1)
            return n;

        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
    }

    static void Main()
    {
        int count = 10; // number of Fibonacci numbers to generate

        Console.WriteLine("Fibonacci Series:");

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(FibonacciRecursive(i));
        }
    }
}
