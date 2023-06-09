using System.Security.Cryptography.X509Certificates;

internal class Program
{
    public class node
    {
        public int value;
        public node right;
        public node left;
    }
    public class tree
    {
        public node root;
        public tree()
        {
            root = null;
        }
        public node ReturnRoot()
        {
            return root;
        }
        public void insert(int value)
        {
            node node = new node() { value=value};
           if (root == null)
            {
                root = node;
            }
            else
            {
                node current = root;
                node parrent;
                while(true)
                {
                    parrent = current;
                    if (value < current.value)
                    {
                        current = current.left;
                        if(current==null)
                        {
                            parrent.left = node;
                           // current.value = value;
                            return ;
                        }
                   
                    }
                    else
                    {

                        current = current.right;
                        if (current == null)
                        {
                            parrent.right = node;
                           // current.value = value;
                            return ;
                        }
                    }
                }
            }
           

        }
        public void preOrder(node root)
        {
            if (root != null)
            {
                Console.Write(root.value + " ");
                preOrder(root.left);
                preOrder(root.right);
            }
        }
        public void inorder(node root)
        {
            if (root != null)
            {
                inorder(root.left);
                Console.Write(root.value + " ");
                inorder(root.right);
            }
        }
        public void postorder(node root)
        {
            if (root != null)
            {
              postorder(root.left);
               postorder(root.right);
                Console.Write(root.value + " ");
            }
        }

    }
    
   

    private static void Main(string[] args)
    {
       tree tree = new tree();
        tree.insert(30);
        tree.insert(35);
        tree.insert(50);
        tree.insert(15);
        tree.insert(60);
        tree.insert(40);
        tree.insert(80);
        tree.insert(75);
        tree.insert(65);
        tree.insert(90);
        tree.insert(85);
        Console.WriteLine("inorder traversal is");
        tree.inorder(tree.ReturnRoot());
        Console.WriteLine(" ");
        Console.WriteLine();
        Console.WriteLine("preorder traversal is ");
        tree.preOrder(tree.ReturnRoot());
        Console.WriteLine(" ");
        Console.WriteLine();
        Console.WriteLine("postorder traversal is");
        tree.postorder(tree.ReturnRoot());
        Console.WriteLine(" ");
        Console.WriteLine();
    }
}