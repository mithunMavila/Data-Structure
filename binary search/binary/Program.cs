internal class Program
{
    static int BinarySearch(int[] arr, int target)
    {
        int startIndex = 0;
        int endIndex = arr.Length - 1;

        while (startIndex <= endIndex)
        {
            int MiddleIndex = (startIndex + endIndex) / 2;

            if (target == arr[MiddleIndex])
            {
                return MiddleIndex;
            }
            else if (target < arr[MiddleIndex])
            {
                endIndex = MiddleIndex - 1;
            }
            else
            {
                startIndex = MiddleIndex + 1;
            }
        }
        return -1;

    }

    private static void Main(string[] args)
    {
        int[] arr1 = { 2, 5, 6, 9, 10 };
        int target = 5;
        int result = BinarySearch(arr1, target);
        if (result == -1)
        {
            Console.WriteLine("Target value not found in the array.");
        }
        else
        {
            Console.WriteLine("Target value found at index: " + result);
        }

    }
}