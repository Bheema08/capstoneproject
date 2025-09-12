using EmployProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace EmployProject.Dao
{
    public class EmployDaoImpl : IEmployDao
    {
        static List<Employ> employList;

        static EmployDaoImpl()
        {
            employList = new List<Employ>();
        }
        public string AddEmployDao(Employ employ)
        {
            employList.Add(employ);
            return "Employ Record Inserted...";
        }

        public string DeleteEmployDao(int empno)
        {
            Employ employFound= SearchEmployDao(empno);
            if (employFound != null)
            {
                employList.Remove(employFound);
                return "Employ Record Deleted Sucessfully.....";
            }
            return "Employ Record Not Found...";
        }

        public string ReadFileDao()
        {
            FileStream fs=new FileStream(@"c:\files\Employ.txt",FileMode.Open,FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            employList=(List<Employ>)bf.Deserialize(fs);
            return "Data recived from the data Suscessfully.....";
        }

        public Employ SearchEmployDao(int empno)
        {
            Employ employFound = null;
            foreach (Employ employ in employList)
            {
                if (employ.Empno == empno)
                {
                    employFound = employ;
                    break;
                }
            }
            return employFound;
        
        }

        public List<Employ> ShowEmployDao()
        {
            return employList;
        }

        public string UpdateEmployDao(Employ employUpdated)
        {
            Employ employFound=SearchEmployDao(employUpdated.Empno);
            if (employFound != null)
            {
                employFound.Name = employUpdated.Name;
                employFound.Gender = employUpdated.Gender;
                employFound.Dept = employUpdated.Dept;
                employFound.Desig = employUpdated.Desig;
                employFound.Basic = employUpdated.Basic;
                return "Employ Record updated ";
            }
            return "Emplloy Record not Found...";
        }

        public string WriteFileDao()
        {
            FileStream fs = new FileStream(@"c:\files\Employ.txt", FileMode.Create,FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, employList);
            fs.Close();
            return "Data stored Sucessfully....";
        }
    }
}
