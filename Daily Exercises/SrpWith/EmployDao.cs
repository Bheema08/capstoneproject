using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpWith
{
    internal interface EmployDao
    {
        string AddEmployDao(Employ employ);
        List<Employ> GetAllEmploys();
    }
}
