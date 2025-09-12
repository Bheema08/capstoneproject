using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExamples
{
    internal class Actiondelegate
    {
        public delegate void Mydelegate(string s);
        public static void Greeting(string s)
        {
            Console.WriteLine("Good Morning  " + s);
        }
        static void Main()
        {
            Mydelegate obj = Greeting;
            obj("Murari Balavardhan");
        }
    }
}
