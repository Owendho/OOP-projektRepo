using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    class StregsystemCLI : IStregsystemCLI
    {
        Stregsystem stregsystem = new Stregsystem();

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

        }
        public void Close()
        {

        }
        public void DisplayInsufficientCash(User user, Product product)
        {

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
            IEnumerable<Product> products = stregsystem.ActiveProducts();
            ActiveProducts = products.ToList();
            foreach (Product product in ActiveProducts)
            {
                Console.WriteLine(product.name);
            }



        }

        public void HandleInput()
        {

        }
    }
}
