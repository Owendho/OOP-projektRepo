using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(User _User, decimal Amount) : base(_User, Amount)
        {
        }

        public override string ToString()
        {
            return $" Inserting cash: {amount} {user} {date}";
        }

        public override void Execute()
        {
            user.Balance += amount;
        }
    }
}
