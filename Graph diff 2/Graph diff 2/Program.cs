internal class Program
{
    public class Graph
    {
        public Dictionary<string, List<string>> adjacencyList;
        public Graph()
        {
            adjacencyList = new Dictionary<string, List<string>>();
        }
        public void addVertex(string vertex)
        {
            if (!adjacencyList.ContainsKey(vertex))
            {
                adjacencyList[vertex] = new List<string>();
            }
        }
        public void addEdge(string vertex1, string vertex2)
        {
            if (!adjacencyList.ContainsKey(vertex1))
            {
                adjacencyList[vertex1] = new List<string>();
            }
            if (!adjacencyList.ContainsKey(vertex2))
            {
                adjacencyList[vertex2] = new List<string>();
            }
            adjacencyList[vertex1].Add(vertex2);
            adjacencyList[vertex2].Add(vertex1);
        }
        public bool HasEdge(string vertex1, string vertex2)
        {
            if (adjacencyList[vertex1].Contains(vertex2))
            {
                return true;
            }
            return false;
        }
        public void RemveEdge(string vertex1, string vertex2)
        {
            if (adjacencyList.ContainsKey(vertex1))
            {
                adjacencyList[vertex1].Remove(vertex2);
            }
            if (adjacencyList.ContainsKey(vertex2))
            {
                adjacencyList[vertex2].Remove(vertex1);
            }
        }
        public void RemoveVertex(string vertex)
        {
            if (adjacencyList.ContainsKey(vertex))
            {
                foreach (string adjacentVertex in adjacencyList[vertex])
                {
                    adjacencyList[adjacentVertex].Remove(vertex);
                }
            }
            adjacencyList.Remove(vertex);
        }
        public void DFS(string StartingVertex)
        {
            var visited = new List<string>();
            Explore(StartingVertex, visited);

        }
        public void Explore(string vertex, List<string> visited)
        {
            visited.Add(vertex);
            Console.WriteLine(vertex);
            foreach (string neighbour in adjacencyList[vertex])
            {
                if (!visited.Contains(neighbour))
                {

                    Explore(neighbour, visited);
                }
            }
        }
        public void BFS(string startingVertex)
        {
            var visited = new List<string>();
            Queue<string> queue = new Queue<string>();
            visited.Add(startingVertex);
            queue.Enqueue(startingVertex);
            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                Console.WriteLine(vertex);
                foreach (var neighbour in adjacencyList[vertex])
                {
                    if (!visited.Contains(neighbour))
                    {
                        visited.Add(neighbour);
                        queue.Enqueue(neighbour);
                    }
                }
            }
        }
        public void Display()
        {
            foreach (var vertex in adjacencyList)
            {
                Console.Write(vertex.Key + " -> ");
                Console.Write(string.Join(", ", vertex.Value));
                Console.WriteLine();
            }
        }

    }
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}