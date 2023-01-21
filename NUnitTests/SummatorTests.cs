using NUnit.Framework;

namespace NUnitTests
{
    public class SummatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_SumTwoNumbers()
        {
            if (Sum(new int[] { 1, 2 }) != 3)
            {
                throw new Exception("1+2 != 3");
            }
            else
            {
                Console.WriteLine("Test SumTwoNumbers Pass!");
            }
        }
    }
}