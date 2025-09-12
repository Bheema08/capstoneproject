using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractExample2
{
    internal class Cow : Animal
    {
        public override void Name()
        {
            Console.WriteLine("Cow");
        }
        public override void Description()
        {
            Console.WriteLine("Its a mammales Category");
        }
    }
}
