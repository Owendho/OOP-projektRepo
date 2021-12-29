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
        //Stregsystem stregsystem = new Stregsystem();


        public delegate void StregsystemEvent(string command);

        public event StregsystemEvent CommandEntered;
        public StregsystemCLI(Stregsystem stregsystem)
        {
            stregsystem.CSVparser();
        }

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
            Console.WriteLine(user);
        }
        public void DisplayTooManyArgumentsError(string command)
        {

        }
        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {

        }
        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            Console.WriteLine(transaction.ToString());
        }
        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            //Til multibuy
        }
        public void Close()
        {

        }
        public void DisplayInsufficientCash(User user, Product product)
        {
            Console.WriteLine($"Insufficient balance for {product.name} {product.price}. Current balance is {user.Balance}");
        }
        public void DisplayGeneralError(string errorString)
        {

        }
        public void Start()
        {
            do
            {
                Show();
                HandleInput();
            } while (_running);

        }

        public void Show()
        {
          /*Maybe need to change some of the code*/
            List<Product> ActiveProducts = new List<Product>();
            Console.Clear();
            IEnumerable<Product> products = stregsystemref.ActiveProducts();
            ActiveProducts = products.ToList();
            foreach (Product product in ActiveProducts)
            {
                Console.WriteLine(product.name);
            }
        }

        int index = 0;

        private Stregsystem stregsystemref;
        StregsystemCommandParser commandParser = new StregsystemCommandParser();

        public void HandleInput()
        {
            ConsoleKeyInfo key = Console.ReadKey();

            string inputcommand = Console.ReadLine();

            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    Console.WriteLine(commandParser.ParseCommand(inputcommand));

                    break;
                case ConsoleKey.UpArrow:
                    //MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    //MoveDown();
                    break;
                case ConsoleKey.Escape:
                    //_running = false;
                    break;

                default:
                    break;

            }

            /*
            private Product SelectedProduct
            {
                get
                {
                    //return Products[index];
                }
            }
            ^*/

        }
    }
}
