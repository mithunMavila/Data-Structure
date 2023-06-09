using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        Hashtable hashtable = new Hashtable();

        hashtable.Add(1, "one");
        hashtable.Add(2, "two");
        hashtable.Add(3, "three");
        hashtable.Add(4, "four");
        hashtable.Add(5, "");

        String valueofone = (string)hashtable[1];

        Console.WriteLine(valueofone);

        /*foreach(DictionaryEntry hash in hashtable)
        {          
            Console.WriteLine($"key: { hash.Key} ,value:{ hash.Value}");
        }*/
        hashtable.Remove(5);

        foreach (var hash in hashtable.Keys)
        {
            Console.WriteLine(hash);
        }


    }
}