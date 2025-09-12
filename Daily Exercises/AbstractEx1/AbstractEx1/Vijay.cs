using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractEx1
{
    internal class Vijay : Training
    {
        public override void Name()
        {
            Console.WriteLine("my name is Vijay");
        }
        public override void Email()
        {
            Console.WriteLine("vijay@gmail.com");
        }
    }
}
