internal class Program
{
    public class Node
    {
        public int Value;
        public Node next;
    }
    public class stack
    {
        public Node Head;
        public int count = 0;
        public void push(int value)
        {
            Node node = new Node() { Value=value};
            if (Head == null)
            {
                Head = node;
                count++;

            }
            else
            {
                node.next = Head;
                Head = node;
                count++;
            }
        }
        public void pop()
        {
            Head=Head.next;
        }
        public void print()
        {
            Node current = Head;
            while (current != null)
            {
                Console.WriteLine(current.Value + " ");
                current = current.next;
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
        stack.pop();
        stack.print();
    }
}