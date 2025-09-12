using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpWith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employ employ1 = new Employ();
            employ1.Empno = 88;
            employ1.Name = "deva";
            employ1.Basic = 852534;

            EmployDao employDao = new EmployDaoImpl();
            employDao.AddEmployDao(employ1);
            List<Employ> employList=employDao.GetAllEmploys();

            foreach (Employ employ in employList)
            {
                Console.WriteLine(employ);
            }
        }
    }
}
