using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractEx1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Training[] training = new Training[]
            {
                new Datta(),
                new Vijay(),
                new Vrdhan()
            };
            foreach (Training t in training) {
                t.Name();
                t.Email();
}
        }
    }
}
