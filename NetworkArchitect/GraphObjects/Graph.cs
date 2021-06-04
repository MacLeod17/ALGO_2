using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NetworkArchitect.GraphObjects
{
    public class Graph
    {
        public List<Node> nodes { get; set; } = new List<Node>();

        // Edges Chosen For The MST
        public List<Edge> chosenEdges { get; set; } = new List<Edge>();

        // All Edges In The Graph
        public List<Edge> allEdges { get; set; } = new List<Edge>();
        public int TotalWeight { get; set; }

        public Graph() { }

        public Graph(string path)
        {
            string[] file = File.ReadAllLines(path);

            Graph g = new Graph();

            // For Legal Purposes This Is A Joke. Haha. Ha.
            int bodyCount = new Random().Next(0, int.MaxValue);
            Console.WriteLine();
            Console.WriteLine($"Bodies In My Basement: {bodyCount:##,#} (You're Next)");
            Console.WriteLine("For Legal Purposes This Is A Joke. Haha. Ha.");
            Console.WriteLine();

            for (int count = 0; count < file.Length; count++)
            {
                // Line Containing All Of The Nodes
                if (count == 0)
                {
                    var items = file[count].Split(",");
                    foreach (var item in items)
                    {
                        Node node = new Node(item);
                        nodes.Add(node);
                    }
                }
                else
                {
                    // Only Do Work If Line Is Not Empty
                    if (!file[count].Equals(string.Empty))
                    {
                        var items = file[count].Split(",");

                        Node node = nodes.Find(find => find.ID == items[0]);

                        for (int i = 1; i < items.Length; i++)
                        {
                            string[] lineInfo = items[i].Split(':');

                            Edge line = new Edge(node, nodes.Find(find => find.ID == lineInfo[0]), int.Parse(lineInfo[1]));
                            node.Edges.Add(line);
                        }
                    }
                }
            }

            Console.WriteLine("File Read Successfully");
        }

        public void Kruskals()
        {
            // 1. Sort All Edges In Non-Decreasing Order Of Their Weight
            CompileEdges();
            allEdges = allEdges.OrderBy(edge => edge.Weight).ToList();

            int index = 0;

            while (chosenEdges.Count < nodes.Count-1)
            {
                // 2. Pick The Smallest Edge. Check If It Forms A Cycle With The MST So Far.
                Edge currentEdge = allEdges[index];

                // If Cycle Is Not Formed, Include Edge
                if (!(currentEdge.StartNode.IsAdded && currentEdge.EndNode.IsAdded))
                {
                    TotalWeight += currentEdge.Weight;
                    currentEdge.StartNode.IsAdded = true;
                    currentEdge.EndNode.IsAdded = true;
                    chosenEdges.Add(currentEdge);
                }

                index++;
            }

            // Repeat Step 2 Until There Are V-1 Edges In The Tree
        }

        public void CompileEdges()
        {
            foreach (var node in nodes)
            {
                foreach (var nodeEdge in node.Edges)
                {
                    bool isCopy = false;
                    foreach (var graphEdge in allEdges)
                    {
                        // If Equivalent Edge Is Already Present, Current nodeEdge Is A Copy
                        if (nodeEdge.Equals(graphEdge))
                        {
                            isCopy = true;
                            break;
                        }
                    }

                    if (!isCopy)
                    {
                        allEdges.Add(nodeEdge);
                    }
                }
            }
        }
    }
}
