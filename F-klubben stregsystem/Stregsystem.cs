﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
//using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text.RegularExpressions;

namespace F_klubben_stregsystem
{

    /*Why have 2 delegates*/
    

    class Stregsystem : IStregsystem
    {
        public delegate void UserBalanceNotification(User user, decimal balanace);

        public Stregsystem()
        {
            CSVparser();
        }


        private List<Transaction> doneTransactions = new List<Transaction>();
        private List<Product> products;
        private List<User> users;

        private ILogger fileLog = new FileLog("Logfile.txt");


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
            fileLog.LogTransaction(transaction);
        }

        public Product getProductByID()
        {
            int id = 0;
            Product productID = products[id];
            return productID;
        }

        /*Learn about func*/
        public IEnumerable<User> GetUsers(Func<User, bool> predicate)
        {
            List<User> userList = new List<User>();
            foreach (User user in userList)
            {
                if (predicate(user))
                {
                    userList.Add(user);
                }
            }
            return userList;
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
            throw new UsernameNotFoundException($"{username} cold not be found");
        }

        /*Maybe use linq for this*/
        public IEnumerable<Transaction> GetTransactions(User TransUser, int count)
        {
            return doneTransactions.Where(t => t.user == TransUser).TakeLast(count).Reverse();
        }

        public IEnumerable<Product> ActiveProducts()
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

        public void CSVparser()
        {

            string filePath = @"C:\Users\owend\OneDrive\Documents\OOPprojekt\products.csv";
            
            using (TextFieldParser textfieldparser = new TextFieldParser(filePath))
            {
                textfieldparser.TextFieldType = FieldType.Delimited;
                textfieldparser.SetDelimiters(",");
                while (!textfieldparser.EndOfData)
                {
                    //Regex.Replace(textfieldparser, "<.*?>", String.Empty);
                    string[] rows = textfieldparser.ReadFields();
                }
            }
        }
        
    }
}
