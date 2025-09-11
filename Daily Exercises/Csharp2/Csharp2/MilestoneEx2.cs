using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2
{
    internal class MilestoneEx2
    {
        static void Main()
        {
            String data;
            Console.WriteLine("Enter a String ");
            data= Console.ReadLine();
            String[]names=data.Split(' ');
            foreach(String name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
