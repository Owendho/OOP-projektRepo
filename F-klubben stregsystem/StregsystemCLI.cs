using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    class StregsystemCLI : IStregsystemUI
    {

        public StregsystemCLI(Stregsystem stregsystem)
        {
            str = stregsystem;
            stregsystem.CSVparser();
            stregsystem.CSVparserU();
        }


        public event StregsystemEvent CommandEntered;
        
        /*
        public StregsystemCLI(Stregsystem stregsystem)
        {
            //stregsystem.CSVparser();
        }
        */

        private bool _running = true;
        public void DisplayUserNotFound(string username)
        {
            Console.WriteLine($"User {username} not found");
        }

        public void DisplayProductNotFound(string product)
        {
            Console.WriteLine($"User {product} not found");
        }
        public void DisplayUserInfo(User user) 
        {
            Console.WriteLine(user.ToString() + user.Balance + " kr.");
        }
        public void DisplayTooManyArgumentsError(string command)
        {

        }
        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            Console.WriteLine($"{adminCommand} was not found");
        }
        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            Console.WriteLine(transaction.ToString());
        }
        public void DisplayUserBuysProductM(int count, List<BuyTransaction> transactions)
        {
            //Til multibuy
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(transactions[i].ToString());
            }
        }

        public void DisplayInsufficientCash(User user, Product product)
        {
            Console.WriteLine($"Insufficient balance for {product.name} {product.price}. Current balance is {user.Balance}");
        }

        public void DisplayLowBalance(User user)
        {
            Console.WriteLine($"WARNING: user balance is {user.Balance}");
        }

        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine(errorString);
        }

        public void DisplayTransactions(IEnumerable<Transaction> transactions)
        {
            foreach (IEnumerable<Transaction> transaction in transactions)
            {
                Console.WriteLine($"transactions: " + transaction.ToString());
            }

        }

        public void Start()
        {
            while (_running)
            {

                Show();
                //HandleInput();
                this.consoleline = Console.ReadLine();
                Command = consoleline;

            }

        }

        public string consoleline { get; set; }
        private string _command;

        public string Command
        {
            get
            {
                return _command;
            }
            set
            {
                CommandEntered?.Invoke(value);
                 _command = value;
                 
   
            }
        }

        Stregsystem str;

        public void Show()
        {
          /*Maybe need to change some of the code*/
            List<Product> ActiveProducts = new List<Product>();
            Console.Clear();
            IEnumerable<Product> products = str.ActiveProducts();
            ActiveProducts = products.ToList();
            foreach (Product product in ActiveProducts)
            {
                Console.WriteLine(product.id + "." + product.name + " " + product.price);
            }
            Console.WriteLine("\n");
        }

       
        public void Close()
        {
            Environment.Exit(0);
        }



        
    }

}
