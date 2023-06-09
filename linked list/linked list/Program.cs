using System.Security.Cryptography.X509Certificates;

internal class Program
{
   public class Node
    {
        public int value;
        public Node next;
    }
    public class LinkedList
    {
        public Node Head;
        public int count = 0;

     /* bool isempty()
        {
            return count == 0;

        }*/
        public void prepend(int value)
        {
            Node node = new Node() { value=value};
            /*  if(isempty())
              {
                  Head = node;
                  count++;
              }*/
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
        public void append(int value)
        {
            Node node =new Node() { value=value};
            /* if(isempty())
             {
                 Head=node;
                 count++;
             }*/
            if (Head == null)
            {
                Head = node;
                count++;
            }
            else
            {
                Node current=Head;
                while(current.next != null)
                {
                    current=current.next;
                }
                current.next = node;
                count++;
            }
        }
        public void print()
        {
            Node current = Head;
            while(current != null)
            {
                Console.WriteLine(current.value+" ");
                current = current.next;
            }
        }
        public void insert(int value,int index)
        {
            Node node = new Node() { value=value};
           if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
           if (index==0)
            {
                node.next = Head;
                Head=node;
                count++;
            }
            Node current = Head;
            for(int i=0;i<index-1;i++)
            {
               if (current == null)
                {
                    throw new IndexOutOfRangeException();
                }
               current = current.next;
            }
            node.next = current.next;
            current.next = node;
            count++;
        }
        public void remove(int index)
        {
            Node node = new Node();
            if(Head == null)
            {
                throw new IndexOutOfRangeException();
            }
            if (index <= 0)
            {
                throw new IndexOutOfRangeException();
            }
            
            //Node current = Head;
          if (Head.value == index)
            {
                Head=Head.next;
                count--;
            }
          Node current = Head;
            while(current.next != null && current.next.value!= index)
            {
                current = current.next;
            }
            if (current.next != null)
            {
                current.next=current.next.next;
                count--;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public void removeIndex(int index)
        {
           // Node node = new Node();
            if(index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if(index==0)
            {
                
                Head = Head.next;
            }
            Node current = Head;
            for(int i=0; i<index-1; i++)
            {
                current=current.next;
            }
            current.next= current.next.next;
        }

    }


    
        
   
    private static void Main(string[] args)
    {
       LinkedList linkedList = new LinkedList();
        linkedList.append(1);
        linkedList.append(2);  
        linkedList.append(3);
        linkedList.append(4);
        // linkedList.insert(5, 3);
        // linkedList.remove(5);
        linkedList.removeIndex(2);
        linkedList.print();
    }
}