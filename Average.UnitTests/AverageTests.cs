using NUnit.Framework;

namespace Services.UnitTests
{
    public class AverageTests
    {
        [Test]
        public void Test_Average_TwoPositiveNumbers()
        {
            var nums = new int[] { 10, 20 };
            Assert.That(Summator.Average(nums), Is.EqualTo(15));
        }

        [Test]
        public void Test_Average_ThreePositiveNumbers()
        {
            var nums = new int[] { 5, 17, 20 };
            Assert.That(Summator.Average(nums), Is.EqualTo(14));
        }

        [Test]
        public void Test_Average_ThreeNegativeNumbers()
        {
            var nums = new int[] { -5, -15, -25 };
            Assert.That(Summator.Average(nums), Is.EqualTo(-15));
        }
    }

}
