using System;

class Heap
{
    private int[] heap;

    public Heap()
    {
        heap = new int[0];
    }

    public void MinHeap(int[] array)
    {
        BuildHeap(array);
    }

    public void BuildHeap(int[] array)
    {
        heap = array;
        for (int i = Parent(heap.Length - 1); i >= 0; i--)
        {
            ShiftDown(i);
        }
    }

    public void ShiftDown(int current)
    {
        int endIndex = heap.Length - 1;
        int leftIndex = LeftChild(current);
        while (leftIndex <= endIndex)
        {
            int rightIndex = RightChild(current);
            int shiftToBe;
            if (rightIndex <= endIndex && heap[rightIndex] < heap[leftIndex])
            {
                shiftToBe = rightIndex;
            }
            else
            {
                shiftToBe = leftIndex;
            }
            if (heap[current] > heap[shiftToBe])
            {
                int temp = heap[current];
                heap[current] = heap[shiftToBe];
                heap[shiftToBe] = temp;
                current = shiftToBe;
                leftIndex = LeftChild(current);
            }
            else
            {
                return;
            }
        }
    }

    public void ShiftUp(int current)
    {
        int parent = Parent(current);
        while (current > 0 && heap[current] < heap[parent])
        {
            int temp = heap[current];
            heap[current] = heap[parent];
            heap[parent] = temp;
            current = parent;
            parent = Parent(current);
        }
    }

    public int Peek()
    {
        return heap[0];
    }

    public int Parent(int i)
    {
        return (i - 1) / 2;
    }

    public int LeftChild(int i)
    {
        return (i * 2) + 1;
    }

    public int RightChild(int i)
    {
        return (i * 2) + 2;
    }

    public int Remove()
    {
        int temp = heap[0];
        heap[0] = heap[heap.Length - 1];
        heap[heap.Length - 1] = temp;
        int number = heap[heap.Length - 1];
        Array.Resize(ref heap, heap.Length - 1);
        ShiftDown(0);
        return number;
    }

    public void Insert(int value)
    {
        Array.Resize(ref heap, heap.Length + 1);
        heap[heap.Length - 1] = value;
        ShiftUp(heap.Length - 1);
    }

    public void Display()
    {
        for (int i = 0; i < heap.Length; i++)
        {
            Console.WriteLine(heap[i]);
        }
    }

    public void HeapSort(int[] array)
    {
        BuildHeap(array);
        int[] sortedArray = new int[array.Length];
        int length = array.Length;
        for (int i = 0; i < length; i++)
        {
            sortedArray[i] = Remove();
        }
        Console.WriteLine(string.Join(", ", sortedArray));
    }
}

class Program
{
    static void Main(string[] args)
    {
        Heap heap = new Heap();
        int[] array = { 10, 5, 15, 3, 8 };
        heap.BuildHeap(array);
       // heap.Insert(1);
        //heap.Remove();
        heap.Display();
        heap.HeapSort(array);
    }
}
