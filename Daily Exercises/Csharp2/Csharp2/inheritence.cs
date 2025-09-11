using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2
{
     class C1{
       public  C1()
        {
            Console.WriteLine("Wlcome to join wipro");
        }
    }
    class C2 : C1
    {
        public   C2()
        {
            Console.WriteLine("welcome to introduce your self ");
        }
    }
    internal class inheritence
    {
        static void Main()
        {
            C2 c2 = new C2();  
            //obj.c();
            //obj.c1();
        }
    }
}
