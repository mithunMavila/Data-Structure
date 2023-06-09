using System.Security.Cryptography.X509Certificates;

internal class Program

{
    public class Queue
    {
        public int[] QueueArray;
        public int front = -1;
        public int back = -1;
        public Queue(int size)
        {
            QueueArray = new int[size];
        }
        public void EnQueue(int value)
        {
            if (back==QueueArray.Length-1)
            {
                throw new Exception();
            }
            else
            {
                back++;
                QueueArray[back] = value;
                if(front==-1)
                {
                    front = 0;
                }
            }
            
        }
        public void deQueue()
        {
            if (front == -1)
            {
                throw new Exception();
            }
           else if(front==back)
            {
                front = back = -1;
            }
            else
            {
                front++;
            }
        
        }
        public void display()
        {
          for(int i = front; i < QueueArray.Length; i++)
            {
                Console.WriteLine(QueueArray[i]);
            }
        }
    }
    private static void Main(string[] args)
    {
        Queue queue = new Queue(5);
        queue.EnQueue(1);
        queue.EnQueue(2);
        queue.EnQueue(3);   
        queue.EnQueue(4);
        queue.EnQueue(5);   
       queue.deQueue();
        queue.display();
    }
}