using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractEx1
{
    internal abstract class Training
    {
        public abstract void Name();
        public abstract void Email();
        public void Company()
        {
            Console.WriteLine("Company is Wipro...");
        }
    }
}
