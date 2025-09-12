using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropartiesExample1
{
    internal class Program
    {
        class Bank
        {
            public int Id { get; } = 123;
            public string Name { get; } = "Hyd";
            public string Description { get; } = "Icici";
            public int Age { get; } = 22;
        }
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            Console.WriteLine("Account Nummber : "+bank.Id);
            Console.WriteLine("Account Nummber : " + bank.Name);
            Console.WriteLine("Account Nummber : " + bank.Description);
            Console.WriteLine("Account Nummber : " + bank.Age);
        }
    }
}
