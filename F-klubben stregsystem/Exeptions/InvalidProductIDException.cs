using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    class InvalidProductIDException : Exception
    {
        public InvalidProductIDException(string message) : base(message)
        {

        }
    }
}
