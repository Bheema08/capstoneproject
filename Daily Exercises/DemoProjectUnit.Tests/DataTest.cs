using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoProject2;
namespace DemoProjectUnit.Tests
{
    [TestFixture]
    public class DataTest
    {
        [Test]
        public void TestSum()
        {
            Data data = new Data();
            Assert.AreEqual(5, data.Sum(2, 3));
            Assert.AreEqual(1, data.Sum(1, 0));
            Assert.AreEqual(-2, data.Sum(-5, 3));
            Assert.AreEqual(5, data.Sum(8, -3));

        }
        [Test]
        public void Testshow()
        {
            Data data = new Data();
            Assert.AreEqual("Welcome to unitTesting", data.show());
        }
        [Test]
        public void TestSub()
        {
            Data data = new Data();
            Assert.AreEqual(3, data.Sub(6, 3));
            Assert.AreEqual(4, data.Sub(6, 2));
            Assert.AreEqual(11, data.Sub(8, -3));
            Assert.AreEqual(8, data.Sub(6, -2));
        }
    }
}
