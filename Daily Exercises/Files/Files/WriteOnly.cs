using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Files
{
    internal class WriteOnly
    {
        static void Main(string[] args)
        {
            Employ employ1 = new Employ();
            employ1.Empno = 1;
            employ1.Name = "Rajesh";
            employ1.Basic = 83823;
            FileStream fs = new FileStream(@"c:\files\Employ.txt", FileMode.Create, FileAccess.Write);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fs, employ1);
            fs.Close();
            Console.WriteLine("Employ Data Stored in File...");

        }
    }
}
