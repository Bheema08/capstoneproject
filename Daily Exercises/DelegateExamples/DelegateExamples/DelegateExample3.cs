using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExamples
{
    internal class DelegateExample3
    {
        public delegate void MyDelegate(int a);
        public static void Fact(int a)
        {
            int f = 1;
            for (int i = 1; i <= a; i++)
            {
                f *= i;
            }
            Console.WriteLine(f);
        }
        public static void EvenOdd(int a)
        {
            if (a % 2 == 0)
            {
                Console.WriteLine("Even");
            }
            else
            {
                Console.WriteLine("Odd");
            }

        }
        public static void PogNeg(int a)
        {
            if (a < 0)
            {
                Console.WriteLine("Negative  Number");
            }
            else
            {
                Console.WriteLine("Positive");
            }
        }
        static void Main()
        {
            int a = Convert.ToInt32(Console.ReadLine());
            MyDelegate obj=new MyDelegate(Fact);
            obj +=new MyDelegate(EvenOdd);
            obj +=new MyDelegate(PogNeg);
            obj(a);
        }
    }
}
