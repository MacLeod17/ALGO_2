using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkArchitect.GraphObjects
{
    public class Edge : IComparable
    {
        public Edge() { }
        public Edge(Node start, Node end)
        {
            StartNode = start;
            EndNode = end;
        }
        public Edge(Node start, Node end, int w)
        {
            if (start.ID.CompareTo(end.ID) < 0)
            {
                StartNode = start;
                EndNode = end;
            }
            else
            {
                StartNode = end;
                EndNode = start;
            }
            
            Weight = w;
        }

        public Node StartNode { get; set; } = null;
        public Node EndNode { get; set; } = null;

        public int Weight { get; set; } = int.MaxValue;

        public int CompareTo(object obj)
        {
            Edge other = (Edge)obj;
            int compareValue;
            if (Weight < other.Weight) compareValue = -1;
            else if (Weight > other.Weight) compareValue = 1;
            else compareValue = 0;

            return compareValue;
        }

        public bool Equals(Edge edge)
        {
            return StartNode == edge.StartNode && EndNode == edge.EndNode && Weight == edge.Weight;
        }
    }
}
