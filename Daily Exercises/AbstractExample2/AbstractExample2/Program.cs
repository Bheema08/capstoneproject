using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractExample2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal[] animal = new Animal[] {
            new Cow(),
            new Lion(),
            new Crocodaiele()
            };
            foreach (Animal anima in animal)
            {
                anima.Name();
                anima.Description();
            }
        }
    }
}
