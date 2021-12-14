using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Extensions.Logging;


namespace F_klubben_stregsystem
{

    /*Why have 2 delegates*/


    class Stregsystem 
    {
        public delegate void UserBalanceNotification(User user, decimal balanace);


        private List<Transaction> doneTransactions = new List<Transaction>();
        private List<Product> products;
        private List<User> users;
        



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
            if (user.Balance < 50)
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

        /*Learn about func*/
        public bool GetUsers(Func<User, bool> predicate )
        {

            return true;
        }

        public User GetUserByUsername(string username)
        {
            User foundUser;
            foreach (User userFind in users)
            {
                if (userFind.userName == username)
                {
                    foundUser =  userFind;
                    return foundUser;
                }
            }
            throw new Exception("Username not found"); /*Make this a user defined exception*/


        }

        /*Maybe use linq for this*/
        public Transaction GetTransaction(User user, int count)
        {
            List<Transaction> foundTransactions = new List<Transaction>();

            for (int i = 0; i < count; i++)
            {
                foreach (Transaction item in doneTransactions)
                {
                    
                }
            }
        }

        public List<Product> ActiveProducts()
        {
            List<Product> activeProducts = new List<Product>();
            foreach (Product activeProduct in products)
            {
                if (activeProduct.active == true)
                {
                    activeProducts.Add(activeProduct);
                }
            }
            return activeProducts;
        }
    }
}
