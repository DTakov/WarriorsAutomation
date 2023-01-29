using NUnit.Framework;


namespace Services.UnitTests
{
    public class SummatorTests
    {
        [Test]
        public void Test_Summator_SumTwoPositiveNumbers()
        {

            var nums = new int[] { 1, 2, };
            var actual = Summator.Sum(nums);

            var expected = 3;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Summator_SumTwoNegativeNumbers()
        {

            var nums = new int[] { -1, -99 };
            var actual = Summator.Sum(nums);

            var expected = -100;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Summator_OneNumber()
        {

            var nums = new int[] { 6 };
            var actual = Summator.Sum(nums);

            var expected = 6;

            Assert.That(actual, Is.EqualTo(expected));
        }


        [Test]
        public void Test_Summator_ZeroNumber()
        {

            var nums = new int[] { };
            var actual = Summator.Sum(nums);

            var expected = 0;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Even_Number()
        {

            var num = 10;
            var actual = Summator.EvenOddnumbers(num);

            var expected = num.ToString() + " is even!";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Odd_Number()
        {

            var num = 9;
            var actual = Summator.EvenOddnumbers(num);

            var expected = num.ToString() + " is odd!";

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}