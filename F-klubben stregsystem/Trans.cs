using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    /*make abstract class instead of interface to include the constructer*/
    interface Trans
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
