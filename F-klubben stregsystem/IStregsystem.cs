using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    interface IStregsystem
    {
        InsertCashTransaction AddCreditsToAccount(User user, decimal amount);

        BuyTransaction BuyProduct(User user, Product product);
        User GetUserByUsername(string username);
        IEnumerable<User> GetUsers(Func<User, bool> predicate);

        IEnumerable<Transaction> GetTransactions(User TransUser, int count);

        //event UserBalanceNotification UserbalanceW;
    }
}
