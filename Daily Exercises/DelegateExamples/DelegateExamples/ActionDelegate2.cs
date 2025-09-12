using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExamples
{
    internal class ActionDelegate2
    {
        public delegate void MyDelegate();
        public static void Greeting(string s)
        {
            Console.WriteLine("Good Morning  " + s);
        }

        public static void EndNote(string s)
        {
            Console.WriteLine("Good Night " + s);
        }
        static void Main()
        {
            string s = Console.ReadLine();
            //MyDelegate obj= Greeting;
            Action<string> obj = Greeting;
            obj("Vardhan");
            obj += EndNote;
            obj(s);
        }
    }
}
