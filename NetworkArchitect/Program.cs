using NetworkArchitect.GraphObjects;
using System;

namespace NetworkArchitect
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
            C:\Users\Garrick Kilpack\source\repos\ALGO_2\NetworkArchitect\TestInput\NetworkInputTestA.txt
            C:\Users\Garrick Kilpack\source\repos\ALGO_2\NetworkArchitect\TestInput\NetworkInputTestB.txt
            */

            Console.WriteLine("Enter Path To File");

            Graph g = new Graph(Console.ReadLine());

            g.Kruskals();

            Console.WriteLine($"Cable Needed: {g.TotalWeight} FT");
        }
    }
}
