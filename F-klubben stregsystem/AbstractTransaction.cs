using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    abstract class AbstractTransaction
    {
        public int id { get; set; }
        public string user { get; set; }

        /*Maybe use datetime object*/
        public string date { get; set; }

        public int amount { get; set; }
        string ToString();
        void Execute();
    }
}
