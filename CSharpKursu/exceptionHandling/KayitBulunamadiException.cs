using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exceptionHandling
{
    internal class KayitBulunamadiException : Exception
    {
      
        public KayitBulunamadiException(string message) : base(message)
        {
         
        }

    }
}
