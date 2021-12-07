using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    

    class Transaction
    {
        public Transaction(string User, string Date, int Amount)
        {

        }

        public int id { get; set; }
        public string user { get; set; }

        /*Maybe use datetime object*/
        public string date { get; set; }

        public int amount { get; set; }
        public override string ToString()
        {
            return $"";

        }
        public void Execute()
        {

        }
    }
}
