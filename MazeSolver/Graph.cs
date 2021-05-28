using System;
using System.Collections.Generic;
using System.Text;

namespace MazeSolver
{
    public class Graph
    {
        public List<Vertex> Vertices { get; set; } = new List<Vertex>();

        public Vertex Start { get; set; } = null;
        public Vertex End { get; set; } = null;

        // Will Return The Solution For The Graph, From Start To Finish
        public string GetSolution()
        {
            bool found = false;

            Queue<Vertex> nodes = new Queue<Vertex>();
            Start.Cost = 0;
            nodes.Enqueue(Start);

            while (!found && nodes.Count > 0)
            {
                Vertex node = nodes.Dequeue();

                if (node == End)
                {
                    found = true;
                    continue;
                }

                foreach (Line edge in node.Lines)
                {
                    float cost = node.Cost + 1;

                    if (cost < edge.VertexB.Cost)
                    {
                        edge.VertexB.Cost = cost;
                        edge.VertexB.Parent = node;
                        
                        nodes.Enqueue(edge.VertexB);
                    }
                }
            }

            List<Vertex> path = new List<Vertex>();

            if (found)
            {
                Vertex node = End;
                while (node != null)
                {
                    path.Add(node);
                    node = node.Parent;
                }
                path.Reverse();
            }

            string result = string.Empty;
            foreach (var v in path)
            {
                result += $"{v.Value}, ";
            }
            if (result.Length > 2) result = result.Substring(0, result.Length - 2);

            return (found) ? result : "No Solution";
        }
    }
}
