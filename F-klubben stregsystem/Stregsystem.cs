using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Extensions.Logging;


namespace F_klubben_stregsystem
{


    class Stregsystem 
    {
        public delegate void UserBalanceNotification(User user, decimal balanace);


        private List<Transaction> doneTransactions = new List<Transaction>();
        private List<Product> products;
        private List<User> users;

        //private readonly ILogger _logger;


        public BuyTransaction BuyProduct(User user, Product product)
        {
            decimal amount = 0;
            return new BuyTransaction(user, amount, product);
        }

        public InsertCashTransaction AddCreditsToAccount(User user, decimal amount)
        {
            return new InsertCashTransaction(user, amount);
        }


        public event UserBalanceNotification UserbalanceW;

        public void ExecuteTransaction(Transaction transaction)
        {
            transaction.Execute();
            User user = transaction.user;
            if (user.Balance < 50 )
            {
                UserbalanceW.Invoke(user, user.Balance);
                doneTransactions.Add(transaction);
            }
        }

        public Product getProductByID()
        {
            int id = 0;
            Product productID = products[id];

            return productID;
        }
    }
}
