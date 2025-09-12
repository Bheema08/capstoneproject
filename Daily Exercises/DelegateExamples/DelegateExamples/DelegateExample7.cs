using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExamples
{
    internal class DelegateExample7
    {
        public delegate void MyDelegate(string s);
        static void Main()
        {
            MyDelegate obj = delegate (string str)
            {
                Console.WriteLine("This is Anonymous Method : " + str);
            };
            obj("Datta");
        }
    }
}
