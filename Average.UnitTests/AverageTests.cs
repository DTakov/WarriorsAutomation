using NUnit.Framework;

namespace Services.UnitTests
{
    public class AverageTests
    {
        [TestCase(new[] { 10, 20 }, 15)]
        [TestCase(new[] { 5, 17, 20 }, 14)]
        [TestCase(new[] { -5, -15, -25 }, -15)]
        public void Test_Average_TwoPositiveNumbers(int [] numbers, int expected)
        {
            Assert.That(Summator.Average(numbers), Is.EqualTo(expected));
        }
    }
}
