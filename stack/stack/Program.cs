using System.Security.Cryptography.X509Certificates;

internal class Program
{
    public class stack
    {
        public List<int> elements = new List<int>();
        

        public stack()
        {
            elements= new List<int>();

        }
        public bool isEmpty()
        {
            return elements.Count == 0;
        }
        public void push(int value)
        {
            elements.Insert(0,value);
        }
        public void pop()
        {

            if (isEmpty())
            {
                throw new InvalidOperationException();
            }
            else
            {
              //  int value = elements[elements.Count-1];
                elements.RemoveAt(0);
               // return value;
            }

        }
        public int middle()
        {
            if (isEmpty())
            {
                throw new InvalidOperationException();
            }
            else
            {
                int slowPointer=0;
                int fastPointer = 0;
                while(fastPointer+2 < elements.Count  )
                {
                    slowPointer++;
                    fastPointer+=2;
                }
                return elements[ slowPointer ];

            }
            
        }
        public int peek( int index)
        {
            if (isEmpty())
            {
                throw new InvalidOperationException();
            }
            else
            {
               int value= elements[ index ];
                return value;

            }
        }
        public void Display()
        {
            foreach (int i in elements)
            {
                Console.WriteLine(i);
            }
        }

    }
    private static void Main(string[] args)
    {
        stack stack = new stack();  
        stack.push(1);
        stack.push(2);
        stack.push(3);
        stack.push(4);
        stack.push(5);
        stack.push(6);
        stack.push(7);
        
        stack.Display();
       // stack.pop();
     // stack.Display();
     int middle=stack.middle();
        Console.WriteLine(middle);
        int count=stack.elements.Count;
        Console.WriteLine(count);
        int peak = stack.peek(4);
        Console.WriteLine(peak);
        
        
    }
}