using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    class StregsystemCommandParser
    {
        public void ParseCommand(string command)
        {
            if (command.StartsWith(":"))
            {
                /*Admin commands*/
            }
            string[] splitCommand = command.Split(" ");
            if (splitCommand.Length == 1)
            {
                throw new CommandSyntaxError("invalid command");
            }
            string userName = splitCommand[0];
            string productID = splitCommand[1];

            doesUserNameExist = UserNamexists(stregsystemReference.users, userName);
            IsValidProductID = ValidProductID(stregsystemReference.products, productID);

            if (!doesUserNameExist)
            {
                throw new UsernameNotFoundException($"Username {userName} does not exist");
            }

            if (!IsValidProductID)
            {
                throw new InvalidProductIDException($"Username {userName} does not exist");
            }

            ConsoleKeyInfo key = Console.ReadKey();
            //How to decide whether to buy
            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    break;
                case ConsoleKey.UpArrow:

                    break;
                case ConsoleKey.DownArrow:

                    break;
                case ConsoleKey.Escape:

                    break;

                default:
                    break;

            }

        }

        private bool doesUserNameExist;
        private bool IsValidProductID;
        private IStregsystemUI IStregsystemReference;
        private Stregsystem stregsystemReference;
        private Dictionary<string, string> adminCommands;

        public bool UserNamexists(List<User> users, string userName)
        {
            foreach (User user in users)
            {
                if (userName == user.userName)
                {
                    return true;
                }
                
            }
            return false;
        }
        public bool ValidProductID(List<Product> products, string productID)
        {
            int parsedID = int.Parse(productID);
            foreach (Product product in products)
            {
                if (parsedID == Product.id)
                {
                    return true;
                }

            }
            return false;
        }
    }

    //syntax error when command does not have space between username and product id

    /*Parserfunktionalitet kunne implementers i Kla ssen StregsystemCommandParser.
     *Denne klasse der kan oversætte kommandoer i tekststrenge, der skrives af brugeren, til funktionalitet i form af metodekald:
     * */
}
