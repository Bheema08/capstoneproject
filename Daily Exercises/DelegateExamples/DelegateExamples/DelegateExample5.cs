using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExamples
{
    internal class DelegateExample5
    {
        public delegate void MyDelegate();
        public static void Project()
        {
            Console.WriteLine("Capstone Project to be done Last Phase...");
        }
        public static void MileStone1()
        {
            Console.WriteLine("Milestone 1 to be Conducted on core Topics...");
        }
        public static void MileStone2()
        {
            Console.WriteLine("Milestone 2 to be Conducted on Dotnet core");
        }
        public static void MileStone3()
        {
            Console.WriteLine("Milestone 3 to be Conducted on Asp.net core web API");
        }
        public static void MileStone4()
        {
            Console.WriteLine("Milestone 4 to be conducted on React Framework");
        }
        static void Main()
        {
            MyDelegate obj = new MyDelegate(MileStone1);
            obj += new MyDelegate(MileStone2);
            obj += new MyDelegate(MileStone3); 
            obj += new MyDelegate(MileStone4);
            obj += new MyDelegate(Project);
            obj();
        }
    }
}
