using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExamples
{
    internal class FunctionDelegate
    {
        public static int Fact(int n)
        {
            int f = 1;
            for (int i = 1; i <= n; i++)
            {
                f = f * i;
            }
            return f;
        }
        public static int Add(int a,int b)
        {
            return a + b;
        }

        static void Main()
        {
            int n;
            Console.WriteLine("Enter N value  ");
            n = Convert.ToInt32(Console.ReadLine());
            Func<int, int> obj = Fact;
            int a=Convert.ToInt32(Console.ReadLine());
            int b=Convert.ToInt32(Console.ReadLine());
            Func<int, int,int> func = Add;
            Console.WriteLine("Factorial Value  " + obj(n));
            Console.WriteLine("Add value : "+func(a,b));
        }
        }
}
