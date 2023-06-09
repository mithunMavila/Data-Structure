// See using System;
using System.Collections.Generic;

class Graph
{
    private Dictionary<string, HashSet<string>> adjacencyList;

    public Graph()
    {
        adjacencyList = new Dictionary<string, HashSet<string>>();
    }

    public void AddVertex(string vertex)
    {
        if (!adjacencyList.ContainsKey(vertex))
        {
            adjacencyList[vertex] = new HashSet<string>();
        }
    }

    public void AddEdge(string vertex1, string vertex2)
    {
        if (!adjacencyList.ContainsKey(vertex1))
        {
            AddVertex(vertex1);
        }
        if (!adjacencyList.ContainsKey(vertex2))
        {
            AddVertex(vertex2);
        }
        adjacencyList[vertex1].Add(vertex2);
        adjacencyList[vertex2].Add(vertex1);
    }

    public bool HasEdge(string vertex1, string vertex2)
    {
        return adjacencyList.ContainsKey(vertex1) &&
               adjacencyList.ContainsKey(vertex2) &&
               adjacencyList[vertex1].Contains(vertex2) &&
               adjacencyList[vertex2].Contains(vertex1);
    }

    public void RemoveEdge(string vertex1, string vertex2)
    {
        adjacencyList[vertex1].Remove(vertex2);
        adjacencyList[vertex2].Remove(vertex1);
    }

    public void RemoveVertex(string vertex)
    {
        if (!adjacencyList.ContainsKey(vertex))
        {
            return;
        }
        foreach (string adjacencyVertex in adjacencyList[vertex])
        {
            RemoveEdge(vertex, adjacencyVertex);
        }

        adjacencyList.Remove(vertex);
    }

    public void DFS(string startVertex)
    {
        HashSet<string> visited = new HashSet<string>();
        void Explore(string vertex)
        {
            visited.Add(vertex);
            Console.WriteLine(vertex);
            foreach (string neighbor in adjacencyList[vertex])
            {
                if (!visited.Contains(neighbor))
                {
                    Explore(neighbor);
                }
            }
        }

        Explore(startVertex);
    }

    public void BFS(string startVertex)
    {
        HashSet<string> visited = new HashSet<string>();
        Queue<string> queue = new Queue<string>();

        visited.Add(startVertex);
        queue.Enqueue(startVertex);
        while (queue.Count > 0)
        {
            string vertex = queue.Dequeue();
            Console.WriteLine(vertex);
            foreach (string neighbor in adjacencyList[vertex])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }
    }

    public void Display()
    {
        foreach (KeyValuePair<string, HashSet<string>> kvp in adjacencyList)
        {
            string vertex = kvp.Key;
            HashSet<string> neighbors = kvp.Value;
            Console.WriteLine($"{vertex} -> {string.Join(", ", neighbors)}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph();
        graph.AddEdge("A", "B");
        graph.AddEdge("B", "C");
        graph.Display();    // A -> B | B -> A,C | C -> B

        graph.DFS("A");     // A B C
        graph.BFS("A");     // A B C

        graph.RemoveEdge("A", "B");
        graph.Display();    // A -> | B -> C | C -> B

        graph.RemoveVertex("C");
        graph.Display();    // A -> | B ->

        Console.WriteLine(graph.HasEdge("A", "B")); // False
        Console.WriteLine(graph.HasEdge("A", "C")); // False
    }
}
