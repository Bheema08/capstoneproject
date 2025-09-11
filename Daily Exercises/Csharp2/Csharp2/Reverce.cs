using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2
{
    internal class Reverce
    {
        static void Main()
        {
            String data;
            Console.WriteLine("Enter a String ");
                data=Console.ReadLine();
            string result = ReverseAlternateWords(data);
            Console.WriteLine(result);

        }
        static string ReverseAlternateWords(string sentence)
        { 
            string[] words = sentence.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (i % 2 == 1)
                {
                    words[i] = ReverseString(words[i]);
                }
            }

            return string.Join(" ", words);
        }
        static string ReverseString(string word)
        {
            char[] chars = word.ToCharArray();
            //Array.Reverse(chars);
            return new string(chars);
        }


    }
}
