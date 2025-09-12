using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractExample2
{
    internal class Crocodaiele : Animal
    {
        public override void Name()
        {
            Console.WriteLine("Crocodaile");
        }
        public override void Description()
        {
            Console.WriteLine("Its water Animal");
        }
    }
}
