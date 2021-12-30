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
            //Console.Clear();
            Console.WriteLine(user.ToString() + user.Balance + " kr."+"\n");
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
            Console.WriteLine(count + "X " + transactions[0].ToString() + "\n"  );
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
            Transaction[] transactionArray = transactions.ToArray(); 
            for (int i = 0; i < transactionArray.Length; i++)
            {
                Console.WriteLine($"transactions: " + transactionArray[i].ToString());
            }

        }

        public void Start()
        {
            do
            {
                Show();
                consoleline = Console.ReadLine();
                Command = consoleline;

            } while (_running);

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
            List<Product> ActiveProducts = new List<Product>();
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
