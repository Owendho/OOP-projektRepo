﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    class UsernameNotFoundException : Exception
    {
        public UsernameNotFoundException(string message) : base(message)
        {
        }
    }
}
