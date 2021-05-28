using System;
using System.Collections.Generic;
using System.IO;

namespace MazeSolver
{
    public class Program
    {
        public static Graph Graph { get; set; } = new Graph();
        public static List<string> Solutions { get; set; } = new List<string>();

        public static void Main(string[] args)
        {
            // My File Path
            /*
            C:\Users\Garrick Kilpack\source\repos\ALGO_2\MazeSolver\TestInput\TestMazes.txt
            */
            Console.WriteLine("Enter file path: ");

            GraphControl(File.ReadLines(Console.ReadLine()));
            OutputSolutions();
        }

        public static void GraphControl(IEnumerable<string> result)
        {
            int count = 0;

            foreach (string val in result)
            {
                // Line Containing All Of The Vertices
                if (count == 0)
                {
                    var items = val.Split(",");
                    foreach (var item in items)
                    {
                        Vertex node = new Vertex();
                        node.Value = item;
                        Graph.Vertices.Add(node);
                    }
                }

                // Line Containing Start And End Vertices
                else if (count == 1)
                {
                    var items = val.Split(",");
                    foreach (var item in items)
                    {
                        Vertex node = new Vertex();
                        node.Value = item;
                        if (Graph.Start == null) Graph.Start = node;
                        else Graph.End = node;
                    }
                }

                else
                {
                    // Only Do Work If Line Is Not A Comment
                    if (!val.Contains("//") || val.Equals("// Should not work"))
                    {
                        // If Line Is Empty, Find Solution For Graph
                        if (val.Equals(string.Empty) || val.Equals("// Should not work"))
                        {
                            // Update Start and End Now That Lines Have Been Figured Out
                            Graph.Start = Graph.Vertices.Find(find => find.Value == Graph.Start.Value);
                            Graph.End = Graph.Vertices.Find(find => find.Value == Graph.End.Value);

                            // Get Solution
                            string solution = Graph.GetSolution();
                            Solutions.Add(solution);
                            Graph = new Graph();
                            count = 0;
                            continue;
                        }

                        // If Line Is Not Empty, Add Connections Based On First Vertex Of Line
                        else
                        {
                            var items = val.Split(",");

                            Vertex node = Graph.Vertices.Find(find => find.Value == items[0]);
                            for (int i=1; i < items.Length; i++)
                            {
                                Line line = new Line();
                                line.VertexA = node;
                                line.VertexB = Graph.Vertices.Find(find => find.Value == items[i]);
                                node.Lines.Add(line);
                            }
                        }
                    }
                }
                count++;
            }
        }

        // Write Solutions To Console
        public static void OutputSolutions()
        {
            for (int i = 0; i < Solutions.Count; i++)
            {
                Console.WriteLine($"Maze {i+1} Solution: {Solutions[i]}");
            }
        }
    }
}
