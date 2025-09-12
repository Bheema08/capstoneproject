using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 
namespace CaluclationLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Caluclation calculation = new Caluclation();
            Console.WriteLine(calculation.Sum(12, 5));
            Console.WriteLine(calculation.Sub(12, 5));
            Console.WriteLine(calculation.Mult(12, 5));
        }
    }
}
