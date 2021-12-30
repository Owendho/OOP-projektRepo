using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    class IncorrectFormatException : Exception
    {
        public IncorrectFormatException(string message) : base(message)
        {

        }
    }
}
