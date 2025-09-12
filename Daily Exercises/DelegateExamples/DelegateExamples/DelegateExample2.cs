using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExamples
{
    internal class DelegateExample2
    {
        public delegate void MyDelegate(string a);
        public static void Show(string a)
        {
            Console.WriteLine(a);
        }
        static void Main()
        {
            MyDelegate obj = new MyDelegate(Show);
            obj("datta");
        }

    }
}
