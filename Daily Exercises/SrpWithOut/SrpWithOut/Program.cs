using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpWithOut
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employ employ1 = new Employ();
            employ1.Empno = 88;
            employ1.Name = "datta";
            employ1.Basic = 85234;
            employ1.AddEmploy(employ1);
            List<Employ> employ2 = employ1.ShowEmploy();
            foreach (Employ employ in employ2)
            {
                Console.WriteLine(employ);
            }
        }
    }
}
