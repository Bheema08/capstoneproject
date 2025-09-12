using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractExample2
{
    internal class Lion : Animal
    {
        public override void Name()
        {
            Console.WriteLine("Lion");
        }
        public override void Description()
        {
            Console.WriteLine("Its a Wild Animal");
        }
    }
}
