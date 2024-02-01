using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
              [Test]
        public void Test_AddMethod()
        {
            BasicMaths bm = new TestCase();
            double res = bm.Add(10, 10);
            Assert.AreEqual(res, 20);
        }
        [Test]
        public void Test_SubstractMethod()
        {
            TestCase bm = new TestCase();
            double res = bm.Substract(10, 10);
            Assert.AreEqual(res, 0);
        }
        [Test]
        public void Test_DivideMethod()
        {
            TestCase bm = new TestCase();
            double res = bm.divide(10, 5);
            Assert.AreEqual(res, 2);
        }
        [Test]
        public void Test_MultiplyMethod()
        {
            TestCase bm = new TestCase();
            double res = bm.Multiply(10, 10);
            Assert.AreEqual(res, 100);
        }
    }
    }
}