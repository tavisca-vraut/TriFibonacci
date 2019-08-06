using System;
using System.Linq;

namespace TryFibonacci
{
    class Program
    {
        static int complete(int[] A)
        {
            return TrippleSumFibonacci.FillAndCheckForTriFibonacci(A);
        }

        static void Main(string[] args)
        {
            string read = Console.ReadLine();
            while(read != "-1")
            {
                Console.WriteLine(complete(read.Split(',').Select(item => int.Parse(item)).ToArray()));
                read = Console.ReadLine();
            }
                
        }
    }
}
