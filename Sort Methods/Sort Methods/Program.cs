using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    public static void BubbleSort(int[] array)
    {
        bool swapped;
        do
        {
            swapped = false;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    int temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                    swapped = true;
                }
            }
        }
        while (swapped);

    }
    public static void InsertionSort(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int insert = array[i];
            int j = i - 1;
            while (j >= 0 && array[j] > insert)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = insert;
        }
    }

    public static int[] QuickSort(int[] array)
    {
        if (array.Length < 2)
        {
            return array;
        }

        int pivot = array[array.Length - 1];

        List<int> left = new List<int>();
        List<int> right = new List<int>();
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] > pivot)
            {

                right.Add(array[i]);
            }
            else
            {

                left.Add(array[i]);
            }
        }

        List<int> sorted = new List<int>();

        sorted.AddRange(QuickSort(left.ToArray()));
        sorted.Add(pivot);
        sorted.AddRange(QuickSort(right.ToArray()));



        return sorted.ToArray()
            ;

    }
    public static void selectionSort(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int min = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[min])
                {
                    min = j;
                }
            }
            if (min != i)
            {
                int temp = array[min];
                array[min] = array[i];
                array[i] = temp;
            }
        }
    }
    static int[] MergeSort(int[] array)
    {
        if (array.Length < 2)
        {
            return array;
        }

        int mid = array.Length / 2;
        int[] leftArr = new int[mid];
        int[] rightArr = new int[array.Length - mid];

        Array.Copy(array, 0, leftArr, 0, mid);
        Array.Copy(array, mid, rightArr, 0, array.Length - mid);

        return Merge(MergeSort(leftArr), MergeSort(rightArr));
    }
    static int[] Merge(int[] leftArr, int[] rightArr)
    {
        int[] sortedArray = new int[leftArr.Length + rightArr.Length];
        int i = 0, j = 0, k = 0;

        while (i < leftArr.Length && j < rightArr.Length)
        {
            if (leftArr[i] <= rightArr[j])
            {
                sortedArray[k] = leftArr[i];
                i++;
            }
            else
            {
                sortedArray[k] = rightArr[j];
                j++;
            }
            k++;
        }

        while (i < leftArr.Length)
        {
            sortedArray[k] = leftArr[i];
            i++;
            k++;
        }

        while (j < rightArr.Length)
        {
            sortedArray[k] = rightArr[j];
            j++;
            k++;
        }

        return sortedArray;
    }





    public static void print(int[] array)
    {
        foreach (int i in array)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();
    }
    private static void Main(string[] args)
    {
        int[] array = { 10, 16, 8, 19, 5, 20 };
        // BubbleSort(array);
        //InsertionSort(array);
        //int[] result=  QuickSort(array);
        // selectionSort(array);
        int[] sortedArray = MergeSort(array);
        print(sortedArray);

    }
}