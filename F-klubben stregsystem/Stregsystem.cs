using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
//using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text.RegularExpressions;
using CsvHelper;
using System.IO;
using System.Globalization;


namespace F_klubben_stregsystem
{

    /*Why have 2 delegates*/
    

    class Stregsystem : IStregsystem
    {
        public delegate void UserBalanceNotification(User user, decimal balanace);


        public Stregsystem()
        {
            //CSVparser();
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
            string filePath = "../../../ProjectFiles/products.csv";
            string[] lines = File.ReadAllLines(filePath);
            List<string> activeProducts = new List<string>();

            for (int i = 1; i < lines.Length; i++)
            {
                string name = Regex.Replace(lines[i], "<.*?>", "").Replace("\"", "");
                if (name.LastIndexOf("1") != -1) 
                {
                    activeProducts.Add(name);
                    Console.WriteLine(activeProducts);
                    //Console.ReadLine();
                }

            }


            //string name = Regex.Replace(product[1], "<.*?>", "").Replace("\"", "");
            string lineString;
            string removedHTMLtags;

            //Regex regex = new Regex(@"/[,;]$/, "" ");
            /*
            foreach (string line in lines)
            {

                //lineString = line.Trim(new char[] { ',',';'});
                //lineString = line.Replace(',', ' ');
                removedHTMLtags = RemoveHtmlTags(line);
    

                Console.ReadLine();
            }
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i].Replace(',', ' ');
                string name = Regex.Replace(lines[0], "<.*?>", "").Replace("\"", "");
                Console.WriteLine(lineString);
                Console.ReadLine();
            }
            */
        }


        private static bool HaveHtmlTags(string line)
        {
            return line.Contains('<');
        }

        private static string RemoveHtmlTags(string line)
        {
            string modifierLine = line;
            do
            {
                modifierLine = modifierLine.Remove(modifierLine.IndexOf('<'), modifierLine.IndexOf('>') - modifierLine.IndexOf('<') + 1);
            } while (HaveHtmlTags(modifierLine));

            return modifierLine;
        }


        /*
        public string RemoveHTMLTags(string html)
        {
            return Regex.Replace(html, "<.*?>", string.Empty);
        }
        */
        /*
        private bool _running = true;
        public void HandleInput()
        {
            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    break;
                case ConsoleKey.UpArrow:
                    MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    MoveDown();
                    break;
                case ConsoleKey.Escape:
                    _running = false;
                    break;

                default:
                    break;

            }
        }

        int index = 0;

        private Product SelectedProduct
        {
            get
            {
                return products[index];
            }
        }




        public void MoveUp()
        {
            index--;
        }

        public void MoveDown()
        {
            index++;
        }
        */

    }
}
