using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterException
{
    internal class FilterException : ApplicationException
    {
        public FilterException( string error ) : base(error) { }
    }
}
