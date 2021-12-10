using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    class InsertCashTransaction : Transaction
    {
        InsertCashTransaction(User _User, int Amount) : base(_User, Amount)
        {

        }

        public override string ToString()
        {
            return $" Inserting cash: {amount} {user} {date}";
        }

        public new void Execute()
        {
            user.Balance += amount;
        }


    }
}
