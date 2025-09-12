using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
        [Serializable]
        internal class Employ
        {
            public int Empno { get; set; }
            public string Name { get; set; }
            public double Basic { get; set; }

            public override string ToString()
            {
                return "Employ No  " + Empno + " Employ Name " + Name + " Basic  " + Basic;
            }
        }
}
