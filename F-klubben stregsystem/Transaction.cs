using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    

    public class Transaction
    {
        public Transaction(User _User, decimal Amount)
        {
            user = _User;
            amount = Amount;
            id++;
        }

        public static int id { get; set; }
        public User user { get; set; }

        /*Maybe use datetime object*/
        public DateTime date = DateTime.Now;

        public decimal amount { get; set; }
        public override string ToString()
        {
            return $"{id} {user} {amount} {date}";

        }

        public virtual void Execute()
        {
        }
    }
}
