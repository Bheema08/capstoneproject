using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2
{
    internal class Array
    {
        static void Main()
        {
            Array array = new Array();
            array.show();
        }
        public void show()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5 };
            foreach (int i in arr)
            {
                Console.WriteLine(i);

            }
 
        }
    }
}
