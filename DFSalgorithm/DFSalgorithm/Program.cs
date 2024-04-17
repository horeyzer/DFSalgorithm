using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSalgorithm
{
    public class DFS
    {
        public List<int> Traverse(List<List<int>> graph, int start, bool stepByStep = true)
        {
            List<int> traversalResult = new List<int>();
            bool[] visited = new bool[graph.Count];

            if (stepByStep)
            {
                DFSStepByStep(graph, start - 1, visited, traversalResult);
            }
            else
            {
                DFSUtil(graph, start - 1, visited, traversalResult);
            }

            return traversalResult;
        }

        private void DFSStepByStep(List<List<int>> graph, int node, bool[] visited, List<int> traversalResult)
        {
            visited[node] = true;
            traversalResult.Add(node + 1);
            Console.WriteLine("Visited node: " + (node + 1));

            foreach (int neighbor in graph[node])
            {
                if (!visited[neighbor - 1])
                {
                    Console.WriteLine("Pushed node onto stack: " + neighbor);
                    DFSStepByStep(graph, neighbor - 1, visited, traversalResult);
                }
            }

            Console.WriteLine("Popped node from stack: " + (node + 1));
        }

        private void DFSUtil(List<List<int>> graph, int node, bool[] visited, List<int> traversalResult)
        {
            visited[node] = true;
            traversalResult.Add(node + 1);

            foreach (int neighbor in graph[node])
            {
                if (!visited[neighbor - 1])
                {
                    DFSUtil(graph, neighbor - 1, visited, traversalResult);
                }
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            List<List<int>> graph = new List<List<int>>()
        {
            new List<int>() { 2 },
            new List<int>() { 1, 3, 4 },
            new List<int>() { 2, 5, 6 },
            new List<int>() { 2 },
            new List<int>() { 3 },
            new List<int>() { 3 },
            new List<int>() { }
        };

            DFS dfs = new DFS();

            // Output step-by-step
            Console.WriteLine("Step-by-step traversal:");
            List<int> stepByStepResult = dfs.Traverse(graph, 1);

            // Print the final traversal result in ascending order
            Console.WriteLine("\nFinal traversal result:");
            List<int> finalResult = stepByStepResult;
            finalResult.Sort();
            Console.WriteLine(string.Join(" ", finalResult));
        }
    }
}
