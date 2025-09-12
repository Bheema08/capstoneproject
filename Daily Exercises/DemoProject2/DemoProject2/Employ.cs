using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject2
{
    public class Employ
    {
        public int Empno { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employ() { }
        public Employ(int empno, string name, double salary)
        {
            Empno = empno;
            Name = name;
            Salary = salary;
        }
        public override string ToString()
        {
            return "Empno " + Empno + " Name " + Name + " Basic " + Salary;
        }
    }
}
