using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2
{
    internal class ReverseStr
    {
        static String Reverse(String data) { 
            String[] names = data.Split(' ');
            for (int i =names.Length-1;i>=0;i--)
            {
                if (i % 2 == 1)
                {
                   names[i]=ReverseAlter(names[i]);
                }
            }
            return string.Join(" ", names);
        }
        static String  ReverseAlter(String name)
        {
            return new string(name.Reverse().ToArray());
        }
        static void Main()
        {
            String data;
            Console.WriteLine("Enter a String");
            data = Console.ReadLine();
            String result= Reverse(data);
            Console.WriteLine(result);

        }
    }
}
