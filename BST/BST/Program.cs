internal class Program
{
    public class Node
    {
        public int value;
        public Node right;
        public Node left;
        public Node (int value)
        {
            this.value = value;
            this.right = null;
            this.left = null;
        }
    }
    public class BinarySearchTree
    {
        public Node root;
        public void insert(int value)
        {
            Node node = new Node(value);
            if (root == null)
            {
                root = node;
            }
            else
            {
                InsertNode(root, node);
            }
        }
        private void InsertNode(Node root, Node node)
        {
            if (node.value < root.value)
            {
                if (root.left == null)
                {
                    root.left = node;
                }
                else
                {
                    InsertNode(root.left, node);
                }
            }
            else
            {
                if (root.right == null)
                {
                    root.right = node;
                }
                else
                {
                    InsertNode(root.right, node);
                }
            }

        }
        public bool Search(Node root, int value)
        {
            if (root == null)
            {
                return false;
            }
            else if (root.value == value)
            {
                return true;
            }
            else if (value < root.value)
            {
                return Search(root.left, value);
            }
            else
            {
                return Search(root.right, value);
            }
        }
        public void preorder(Node root)
        {
            if (root != null)
            {
                Console.Write(root.value + " ");
                preorder(root.left);
                preorder(root.right);
            }
        }
        public void InOrder(Node root)
        {
            if (root != null)
            {
                InOrder(root.left);
                Console.Write(root.value + " ");
                InOrder(root.right);
            }
        }
        public void PostOrder(Node root)
        {
            if (root != null)
            {
                PostOrder(root.left);
                PostOrder(root.right);
                Console.Write(root.value + " ");
            }
        }
        public void LevelOrder()
        {
            if (root == null)
            {
                return;
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();
                Console.Write(current.value + " ");

                if (current.left != null)
                {
                    queue.Enqueue(current.left);
                }

                if (current.right != null)
                {
                    queue.Enqueue(current.right);
                }
            }
        }
        public int Min()
        {
            if (root == null)
            {
                throw new InvalidOperationException("The tree is empty.");
            }

            Node current = root;
            while (current.left != null)
            {
                current = current.left;
            }

            return current.value;
        }
        public int Max()
        {
            if (root == null)
            {
                throw new InvalidOperationException("The tree is empty.");
            }

            Node current = root;
            while (current.right != null)
            {
                current = current.right;
            }

            return current.value;
        }
        public Node Delete(Node root, int value)
        {
            if (root == null)
            {
                return root;
            }
            if (value < root.value)
            {
                root.left = Delete(root.left, value);
            }
            else if (value > root.value)
            {
                root.right = Delete(root.right, value);
            }
            else
            {
                if (root.left == null && root.right == null)
                {
                    root = null;
                }
                else if (root.left == null)
                {
                    root = root.right;
                }
                else if (root.right == null)
                {
                    root = root.left;
                }
                else
                {
                    root.value = MinValue(root.right);
                    root.right = Delete(root.right, root.value);
                }
            }

            return root;
        }
        private int MinValue(Node root)
        {
            int min = root.value;
            while (root.left != null)
            {
                min = root.left.value;
                root = root.left;
            }
            return min;
        }
        public bool IsBST(Node root, int min, int max)
        {
            if (root == null)
            {
                return true;
            }

            if (root.value < min || root.value > max)
            {
                return false;
            }

            return IsBST(root.left, min, root.value - 1) && IsBST(root.right, root.value + 1, max);
        }
    }
    private static void Main(string[] args)
    {
        BinarySearchTree bst = new BinarySearchTree();
        bst.insert(10);
        bst.insert(5);
        bst.insert(6);
        bst.insert(3);
        bst.insert(11);
        bst.insert(7);
        bst.Delete(bst.root, 5);
        Console.WriteLine(bst.Search(bst.root,6)); // true
        bst.preorder(bst.root);  // 10 5 3 6 11 
        Console.WriteLine();
        bst.InOrder(bst.root);   // 3 5 6 10 11
        Console.WriteLine();
        bst.PostOrder(bst.root); // 3 6 5 11 10
        Console.WriteLine();
        bst.LevelOrder(); // 10 5 11 3 6
        Console.WriteLine();
        Console.WriteLine(bst.Min()); // 3
        Console.WriteLine(bst.Max()); // 11
        
        int min=bst.Min();
        int max=bst.Max();
        Console.WriteLine(bst.IsBST(bst.root,min,max)); // true
    }
}