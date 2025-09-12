using DemoProject2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProjectUnit.Tests
{
    [TestFixture]
    public class EmployTest
    {
        [Test]
        public void TestEmploy()
        {
            Employ employ = new Employ();
            Assert.IsNotNull(employ);
            Employ employ1 = new Employ(8,"Datta",9999);
           
           Assert.AreEqual(8, employ1.Empno);
            Assert.AreEqual("Datta",employ1.Name);
            Assert.AreEqual(9999, employ1.Salary);
        }
    }
}
