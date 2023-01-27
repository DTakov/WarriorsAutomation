using NUnit.Framework;
using System.Security.Principal;

namespace Services.UnitTests
{
    public class CollectionTests
    {

        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            //ARRANGE
            var nums = new Collection<int>();

            //ASSERT
            Assert.That(nums.ToString, Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collection_InitialCapacity()
        {
            //ARRANGE
            var nums = new Collection<int>();
            int defaultCapacity = nums.Capacity;

            //ASSERT
            Assert.That(defaultCapacity, Is.EqualTo(16));
        }

        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            //ARRANGE
            var nums = new Collection<int>(10);

            //ASSERT
            Assert.That(nums[0], Is.EqualTo(10));
        }

        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            //ARRANGE
            var nums = new Collection<int>(10, 11, 22);

            //ASSERT
            Assert.That(nums.ToString, Is.EqualTo("[10, 11, 22]"));
        }

        [Test]
        public void Test_Collection_AddMethodSingleItem()
        {
            //ARRANGE
            var nums = new Collection<int>();

            //ACT
            nums.Add(5);

            //ASSERT
            Assert.That(nums[0], Is.EqualTo(5));
        }

        [TestCase]
        public void Test_Collection_AddMethodMultipleItems()
        {
            //ARRANGE
            var nums = new Collection<int>();

            //ACT
            nums.Add(5);
            nums.Add(11);

            //ASSERT
            Assert.That(nums.ToString, Is.EqualTo("[5, 11]"));
        }

        [Test]
        public void Test_Collection_AddRangeMethod()
        {
            //ARRANGE
            var nums = new Collection<int>();
            int initialCapacity = nums.Capacity;
            var newNums = Enumerable.Range(1000, 2000).ToArray();
            string expectedNums = "[" + string.Join(", ", newNums) + "]";

            //ACT
            nums.AddRange(newNums);

            //ASSERT
            Assert.Multiple(() =>
            {
                Assert.That(nums.ToString, Is.EqualTo(expectedNums));
                Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(initialCapacity));
            });
        }

        [Test]
        public void Test_Collection_GetByIndex()
        {
            //ARRANGE
            var names = new Collection<string>("Ivan", "Kris", "Dani");

            //ASSERT
            Assert.Multiple(() =>
            {
                Assert.That(names[0], Is.EqualTo("Ivan"));
                Assert.That(names[1], Is.EqualTo("Kris"));
                Assert.That(names[2], Is.EqualTo("Dani"));
            });
        }


        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            //ARRANGE
            var names = new Collection<string>();

            //ACT
            names.Add("Ivelin");

            //ASSERT
            Assert.Multiple(() =>
            {
                Assert.That(() => { var name = names[-1]; },
                    Throws.InstanceOf<ArgumentOutOfRangeException>());
                Assert.That(() => { var name = names[1]; },
                    Throws.InstanceOf<ArgumentOutOfRangeException>());
            });
        }

        [Test]
        public void Test_Collection_InsertAtMethod()
        {
            //ARRANGE
            var names = new Collection<string>("Dani", "Kris");
            string initialName = names[1];

            //ACT
            names.InsertAt(1, "Gabi");

            //ASSERT
            Assert.Multiple(() =>
            {
                Assert.That(initialName, Is.EqualTo("Kris"));
                Assert.That(names[1], Is.EqualTo("Gabi"));
                Assert.That(names[2], Is.EqualTo("Kris"));
            });
        }

        [Test]
        public void Test_Collection_ExchangeMethod()
        {
            //ARRANGE
            var names = new Collection<string>("Kris", "Gabi");

            //ACT
            names.Exchange(1, 0);

            //ASSERT
            Assert.Multiple(() =>
            {
                Assert.That(names[0], Is.EqualTo("Gabi"));
                Assert.That(names[1], Is.EqualTo("Kris"));
            });
        }
    }
}
