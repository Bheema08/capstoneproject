using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExamples
{
    internal class DelegateExample1
    {
        public delegate void Mydelegate();
        public static void Show()
        {
            Console.WriteLine("Welcome to delegate");
        }

        static void Main()
        {
            Mydelegate obj=new Mydelegate(Show);
            obj();
        }
    }
}