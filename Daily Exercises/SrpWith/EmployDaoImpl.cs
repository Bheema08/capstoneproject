using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpWith
{
    internal class EmployDaoImpl : EmployDao
    {
        static List<Employ> employList;
        public EmployDaoImpl()
        {
            employList = new List<Employ>();
        }
        public string AddEmployDao(Employ employ)
        {
            employList.Add(employ);
            return "Employ Data Inserted Sucessfully...";
        }

        public List<Employ> GetAllEmploys()
        {
            return employList;
        }
    }
}
