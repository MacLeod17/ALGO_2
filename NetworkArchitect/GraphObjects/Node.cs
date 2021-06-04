using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkArchitect.GraphObjects
{
    public class Node
    {
        public Node() { }
        public Node(string id)
        {
            ID = id;
        }

        public Node Parent { get; set; } = null;
        public List<Edge> Edges { get; set; } = new List<Edge>();

        public bool IsAdded { get; set; }
        public string ID { get; set; }
    }
}
