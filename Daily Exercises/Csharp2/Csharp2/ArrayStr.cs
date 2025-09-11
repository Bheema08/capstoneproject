using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2
{
    internal class ArrayStr
    {
        public void Show()
        {
            String[] names=new string[]
            {
                "Deva","Datta","Bheema","Balu"
            }
        }
        static void Main()
        {
            ArrayStr array = new ArrayStr();
            array.Show();
        }
    }
}
