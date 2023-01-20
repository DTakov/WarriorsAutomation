using System.Diagnostics;

namespace Summator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 5, 6, 15 };

            Console.WriteLine("Summata e ravna na: " + Summator.Sum(numbers));
            Console.WriteLine($"Srednata stoinost na chislata: {numbers[0]}, {numbers[1]}, {numbers[2]} e {Summator.Average(numbers)}");

        }
    }
}
