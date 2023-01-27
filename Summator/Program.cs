namespace Services
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 5, 6, 15 };

            Console.WriteLine("The sum is equal to: " + Summator.Sum(numbers));

            Console.WriteLine($"The avarage value of the numbers : " +
                $"{numbers[0]}, " +
                $"{numbers[1]}, " +
                $"{numbers[2]} is " +
                $"{Summator.Average(numbers)}");

            Console.WriteLine($"The deduction of 15 from the following numbers sum : " +
                $"{numbers[0]}, " +
                $"{numbers[1]}, " +
                $"{numbers[2]} is " +
                $" {Summator.DeductFromSum(numbers, 15)}");
        }
    }
}