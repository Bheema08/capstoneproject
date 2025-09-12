using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractEx1
{
    internal class Datta : Training
    {
        public override void Name()
            {
            Console.WriteLine("Hi this datta");
        
        }
        public override void Email()
        {
            Console.WriteLine("datta@gmail.com");
        }
    }
}
