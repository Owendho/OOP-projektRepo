using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    abstract class AbstractTransaction
    {
        AbstractTransaction(string User, int Amount)
        {
            user = User;
            amount = Amount;
            id++;
        }
        public static int id { get; set; }
        public string user { get; set; }

        /*Maybe use datetime object*/
        DateTime date = DateTime.Now;

        public int amount { get; set; }

        public override string ToString()
        {
            return $"{id} {user} {amount} {date}";
        }

        public abstract void Execute();

    }
}
