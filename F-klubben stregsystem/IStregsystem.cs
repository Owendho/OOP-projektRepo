using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    interface IStregsystem
    {
        void ExecuteTransaction(Transaction transaction);

        BuyTransaction BuyProduct(User user, Product product);
        User GetUserByUsername(string username);
        IEnumerable<User> GetUsers(Func<User, bool> predicate);

        IEnumerable<Transaction> GetTransactions(User TransUser, int count);
        IEnumerable<Product> ActiveProducts();

        //event UserBalanceNotification UserbalanceW;
    }
}
