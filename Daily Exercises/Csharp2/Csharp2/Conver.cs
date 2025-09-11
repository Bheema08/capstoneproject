using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2
{
    internal class Conver
    {
        int a, b;
        
        public Conver()
        {
             a = 9;
             b = 10;

        }
        public Conver(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public void show()
        {
            Console.WriteLine("Welcome to join in wipro: " + a + " " + b);
        }
        static void Main()
        {
            Conver obj1 = new Conver();
            obj1.show();
            Conver obj2 = new Conver(66, 12);
            obj2.show();
        }

    } }
