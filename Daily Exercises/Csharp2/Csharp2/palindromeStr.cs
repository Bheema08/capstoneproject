using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2
{
    internal class palindromeStr
    {
        public void show(String name)
        {

            string[] data =name.Split(' ');
            foreach(string words in data)
            {
                if ((palindromeCheck(words))==true)
                {
                    Console.WriteLine(words);
                }
            }

        }
        public bool palindromeCheck(string words)
        {
            string Reverse = "";
            char[] chars = words.ToCharArray();
            for (int i = chars.Length - 1; i >=0; i--) {
                Reverse += chars[i];
            }
            if (Reverse.Equals(words))
            {
                return true;
            }
            else
            {
                return false;
            }
}

        static void Main()
        {
            String name=Console.ReadLine();
            palindromeStr palindromeStr = new palindromeStr(); 
            palindromeStr.show(name);
        }
    }
}
