using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSalgorithm
{
    public class Graph
    {
        private int numVertices;
        private List<int>[] adjLists;

        public Graph(int numVertices)
        {
            this.numVertices = numVertices;
            adjLists = new List<int>[numVertices];

            for (int i = 0; i < numVertices; i++)
            {
                adjLists[i] = new List<int>();
            }
        }

        public void AddEdge(int src, int dest) // add edge from src to dest
        {
            adjLists[src].Add(dest); // add dest to src's list
        }

        public void DFS(int startNode, bool[] visited)
        {
            visited[startNode] = true;
            Console.WriteLine(startNode + " ");

            foreach (int neighbor in adjLists[startNode]) // visit all neighbors of startNode
            {
                if (!visited[neighbor])
                {
                    DFS(neighbor, visited);
                }
            }
        }

        public void DFSTraversal(int startNode)
        {
            bool[] visited = new bool[numVertices]; // by default all values are false

            DFS(startNode, visited);
        }
    } // end of class

    public class Program
    {
        public static void Main(string[] args)
        {
            int numVertices = 10;
            Graph graph = new Graph(numVertices);

            graph.AddEdge(1, 2);
            graph.AddEdge(1, 9);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(2, 5);
            graph.AddEdge(5, 6);
            graph.AddEdge(5, 7);
            graph.AddEdge(9, 6);
            graph.AddEdge(6, 8);

            Console.WriteLine("Depth First Traversal (starting from vertex 1)");
            graph.DFSTraversal(1);
        }
    } // end of class
}
