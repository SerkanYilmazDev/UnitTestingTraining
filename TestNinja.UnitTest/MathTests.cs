using System.Collections.Generic;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;

        [SetUp]
        public void Setup()
        {
            _math = new Math();
        }

        [Test]
        [TestCase(1, 2, 3)]
        [TestCase(2, 2, 4)]
        public void Add_WhenCall_SumOfArguments(int a, int b, int expect)
        {
            var result = _math.Add(a, b);

            Assert.That(result, Is.EqualTo(expect));
        }

        [Test]
        [TestCase(1, 2, 2)]
        [TestCase(2, 2, 2)]
        public void Max_WhenCall_ReturnGreaterValue(int a, int b, int expect)
        {
            var result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expect));
        }

        [Test]
        public void GetOddNumbers_WhenCall_ReturnOddNumbers()
        {
            var result = _math.GetOddNumbers(5);

            Assert.That(result, Is.EqualTo(new List<int>() {1, 3, 5}));
        }

        
    }
}