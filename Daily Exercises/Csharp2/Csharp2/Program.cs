using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2
{
    internal class Program
    {
        public void show(String data)
        {
            data=data.ToLower();
            int count = 0;
            char[] chars = data.ToCharArray();
            foreach(char c in chars)
            {
                if (c == 'a' || c == 'e' || c == 'i'|| c == 'o' || c == 'u')
                    {
                    count++;
                }
            }
            Console.WriteLine("count of vowles in a data : "+count);
        }
        static void Main(string[] args)
        {
            String data;
            Console.WriteLine("Enter a string");
            data = Console.ReadLine();
            Program program = new Program();
            program.show(data);
        }
    }
}
