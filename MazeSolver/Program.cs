using System;
using System.Collections.Generic;
using System.IO;

namespace MazeSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter File Path: ");
            string path = Console.ReadLine();

            IEnumerable<string> result = File.ReadLines(path);

            foreach (string line in result)
            {

            }
        }
    }
}
