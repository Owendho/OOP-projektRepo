using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    class InsufficientCreditsException : Exception
    {
        public InsufficientCreditsException(string message) : base(message)
        {
        }
    }
}
