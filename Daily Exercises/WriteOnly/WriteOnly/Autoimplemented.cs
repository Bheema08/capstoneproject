using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteOnly
{
    class Emp
    {
        public int Id
        {
            get; set;
        }
        public string Name { get; set; }

    }
    internal class Autoimplemented
    {
        static void Main()
        {
            Emp emp1 = new Emp();
            Emp emp2 = new Emp();
            Emp emp3 = new Emp();
            emp1.Id = 1;
            emp1.Name = "Datta";
            emp2.Id = 2;
            emp2.Name = "Deva";
            emp3.Id = 3;
            emp3.Name = "Bheema";

            Console.WriteLine("Employee Records:");
            Console.WriteLine("Emp id : "+emp1.Id+" "+"Name: "+emp1.Name);
            Console.WriteLine("emp2 id: "+emp2.Id+" "+"Name: "+emp2.Name);
            Console.WriteLine("emp3 id: "+emp3.Id+" "+"Name: "+emp3.Name);
        }

    }
}
