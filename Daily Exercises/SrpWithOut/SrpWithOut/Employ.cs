using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpWithOut
{
    internal class Employ
    {
        public int Empno {  get; set; }
        public string Name { get; set; }
        public double Basic {  get; set; }


        public override string ToString()
        {
            return "Empno "+" "+Empno+" "+"Name "+Name+" "+"Basic Salary "+Basic;
        }


        static List<Employ> employList;
        public Employ()
        {
            employList = new List<Employ>();
        }
        public List<Employ> ShowEmploy()
        {
            return employList;
        }
        public string AddEmploy(Employ employ)
        {

            employList.Add(employ);
            return "Employ data Inserted Sucessfully....";
        }
    }
}
