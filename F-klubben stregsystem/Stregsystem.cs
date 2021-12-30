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
            CSVparser();
            createProductsFromCsv(CSVparser());
        }


        private List<Transaction> doneTransactions = new List<Transaction>();
        public List<Product> products = new List<Product>();
        public List<User> users = new List<User>();

        private ILogger fileLog = new FileLog("Logfile.txt");


        /*
        public BuyTransaction BuyProduct(User user, Product product)
        {
            decimal amount = 0;
            return new BuyTransaction(user, amount, product);
        }
        */
        public BuyTransaction BuyProduct(User user, Product product)
        {
            Transaction transaction = new Transaction(user, product.price);
            BuyTransaction buyTransaction = new BuyTransaction(user, product.price, product);

            if (user.Balance == 0)
            {
                throw new InsufficientCreditsException($"User balance is {user.Balance}");
            }
            buyTransaction.Execute();
            ExecuteTransaction(transaction);
            return buyTransaction;
        }

        public void AddCreditsToAccount(User user, decimal amount)
        {

            InsertCashTransaction insertCash = new InsertCashTransaction(user, amount);
            insertCash.Execute();
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

        public Product GetProductByID()
        {
            int id = 0;
            Product productID = products[id];
            return productID;
        }

        public Product GetProductBYID(string productID)
        {
            int parsedID = Convert.ToInt32(productID);
            if (parsedID == 0)
            {
                throw new IncorrectFormatException($"{productID} is not a number");
            }
            foreach (Product product in products)
            {
                if (parsedID == product.id)
                {
                    return product;
                }

            }
            throw new ProductNotFoundException($"Product with id: {productID} cold not be found");
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


        public IEnumerable<Transaction> GetTransactions(User TransUser, int count)
        {
            return doneTransactions.Where(t => t.user == TransUser).TakeLast(count).Reverse();
        }

        public IEnumerable<Product> ActiveProducts()
        {
            List<Product> activeProducts = new List<Product>();
            foreach (Product activeProduct in products)
            {
                if (activeProduct.isactive == true)
                {
                    activeProducts.Add(activeProduct);
                }
            }
            return activeProducts;
        }


        public List<string> CSVparser()
        {
            string filePath = "../../../ProjectFiles/products.csv";
            string[] lines = File.ReadAllLines(filePath);
            List<string> activeProducts = new List<string>();
            List<string> productsFromCSV = new List<string>();

            int slc;
            string isActive = "";
            //Fix parser to return active products
            for (int i = 1; i < lines.Length; i++)
            {
                string name = Regex.Replace(lines[i], "<.*?>", "").Replace("\"", "");
                //replace æ,ø,å from product list


                /*
                if (name.Length >= 2)         
                {
                    slc = name.Length - 2;    
                    isActive = name.Substring(slc,1);
                }
                */
                //create objects here and add to product list
                //string[] product = name.Split(';');
                //Product newProduct = new Product() 
                /*
                if (isActive == "1")
                {
                    activeProducts.Add(name);
                    //Console.WriteLine(activeProducts[i]);
                    //Console.ReadLine();
                }
                */

                productsFromCSV.Add(name);

            }

            return productsFromCSV;

        }



        public void createProductsFromCsv(List<string> csvProducts)
        {
            string[] stringSplit;
            string[] csvArray = csvProducts.ToArray();

            for (int i = 0; i < csvProducts.Count; i++)
            {
                stringSplit = csvArray[i].Split(';');
                Product product = new Product(stringSplit[1], Convert.ToDecimal(stringSplit[2]));
                if (stringSplit[3] == "1")
                    product.isactive = true;
                else
                    product.isactive = false;

                products.Add(product);
                //Console.WriteLine(products[i].ToString());
            }
        }

        public void CSVparserU()
        {
            string filePath = "../../../ProjectFiles/users.csv";
            string[] lines = File.ReadAllLines(filePath);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] user = lines[i].Split(',');

                User userCSV = new User(user[1], user[2], user[3], user[5], Convert.ToDecimal(user[4]));
                users.Add(userCSV);

            }
        }



        //Have it be Ienum
        public List<BuyTransaction> MultiBuy(User user, int amount, Product product)
        {
            List<BuyTransaction> buyTransactions = new List<BuyTransaction>();
            for (int i = 0; i < amount; i++)
            {
                buyTransactions.Add(BuyProduct(user, product));

            }
            return buyTransactions;
        }


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
