using System;
using System.Collections.Generic;

namespace DotNet_DepthFirstSearch
{
    class Program
    {
   
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Graph graph = new Graph(10);

            #region Edges

            graph.AddEdge(0, 8);

            graph.AddEdge(1, 3);
            graph.AddEdge(1, 7);
            graph.AddEdge(1, 9);
            graph.AddEdge(1, 2);

            graph.AddEdge(2, 8);
            graph.AddEdge(2, 1);
            graph.AddEdge(2, 4);

            graph.AddEdge(3, 4);
            graph.AddEdge(3, 5);
            graph.AddEdge(3, 1);

            graph.AddEdge(4, 2);
            graph.AddEdge(4, 3);

            graph.AddEdge(5, 3);
            graph.AddEdge(5, 6);

            graph.AddEdge(6, 7);
            graph.AddEdge(6, 5);

            graph.AddEdge(7, 1);
            graph.AddEdge(7, 6);

            graph.AddEdge(8, 2);
            graph.AddEdge(8, 0);
            graph.AddEdge(8, 9);

            graph.AddEdge(9, 1);
            graph.AddEdge(9, 8);

            #endregion

            graph.DFS(2);

            Console.ReadLine();

        }



    }
    public class Graph
    {
        readonly int Total;
        AdjacencyList adjacencyList;

        public Graph(int total)
        {
            Total = total;
            adjacencyList = new AdjacencyList();
        }

        public void AddEdge(int node, int edge)
        {
            adjacencyList.Add(node, edge);
        }

        public void DFS(int s)
        {
            bool[] flags = new bool[Total];

            RDFS(s, flags);
        }

        public void RDFS(int v, bool[] flags)
        {
            flags[v] = true;
            Console.Write(v + " ");

            List<int> hs = adjacencyList.List[v];
            
            for (int i = 0; i < hs.Count; i++)
            {
                if (flags[hs[i]] == false)
                {
                    RDFS(hs[i], flags);
                }
            }
        }
    }

    public class AdjacencyList
    {
        public Dictionary<int, List<int>> List;
        HashSet<int> hs = new HashSet<int>();

        public AdjacencyList()
        {
            List = new Dictionary<int, List<int>>();
        }

        public void Add(int node, int edge)
        {
            List<int> edges = new List<int>();

            if (hs.Add(node))
            {
                edges.Add(edge);

                List.Add(node, edges);
            }
            else
            {
                List.TryGetValue(node, out edges);
                edges.Add(edge);
                List[node] = edges;
            }
        }
    }
}
