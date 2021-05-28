using System;
using System.Collections.Generic;
using System.Text;

namespace MazeSolver
{
    public class Vertex
    {
        public Vertex Parent { get; set; } = null;

        public string Value { get; set; }
        public float Cost { get; set; } = float.MaxValue;

        // Every Vertex "this" Is Connected To
        public List<Line> Lines { get; set; } = new List<Line>();
    }
}
