using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    class StregsystemCommandParser
    {
        public StregsystemCommandParser()
        {
            /*:activate og :deactivate (efterfulgt af produkt-id)*/
            /*
            adminCommands.Add($":active",(Product p) =>p.active == true);
            adminCommands.Add(":deactivate", (Product p) => p.active == false);
            adminCommands.Add(":quit", (StregsystemCLI s) => s.Close);
            adminCommands.Add(":q", (StregsystemCLI s) => s.Close);

            /*:crediton og :creditoff (efterfulgt af produkt-id)*/
            /*
            adminCommands.Add(":crediton", (Product p) => p.canBeBoughtOnCredit == true);
            adminCommands.Add(":creditoff", (Product p) => p.canBeBoughtOnCredit == false);
            /*:addcredits (efterfulgt af brugernavn og tal)*/

        }

        public string ParseCommand(string command)
        {
            //Maybe use switch statement
            Product product;
            if (command.StartsWith(":"))
            {
                /*Admin commands*/
            }
            string[] splitCommand = command.Split(" ");
            if (splitCommand.Length == 1)
            {
                /*der skal vises brugernavn, fulde navn og saldo
                  ▪ en liste over tidligere køb, op til 10, sorteret, så sidste køb kommer øverst. 
                ▪ Hvis saldo er under 50 kr skal brugeren informeres med tekst 
                ▪ hvis brugernavnet ikke eksisterer, skal brugeren informeres
                 */
                string commandUsername = splitCommand[0];

                //userCommand
                try
                {
                    string foundUser = userCommand(commandUsername);
                }
                catch (UsernameNotFoundException m)
                {
                    return m.Message;
                    throw;
                }


            }
            
            if (splitCommand.Length == 2)
            {
                string userName = splitCommand[0];
                string productID = splitCommand[1];

                try
                {

                    product = stregsystemRef.GetProductBYID(stregsystemRef.products, productID);
                }
                catch (ProductNotFoundException c)
                {
                    return c.Message;
                    throw;
                }
            }


            return " ";

            
            /*
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
            */

        }

        private bool doesUserNameExist;
        private bool IsValidProductID;
        private IStregsystemUI IStregsystemReference;
        private readonly Stregsystem stregsystemRef;
        //private Dictionary<string, Func<string, bool>> adminCommands;
        //private Dictionary<string, object> adminCommands;
        private Dictionary<string, bool> adminCommands;


        public string userCommand(string command)
        {
            //use struct
            string userInfo;
            try
            {
                User user = stregsystemRef.GetUserByUsername(command);
                userInfo = user.ToString();
                stregsystemRef.GetTransactions(user, 10);
                
                if (user.Balance < 50)
                {
                    return userInfo + "@\n" + "Balance is under 50 kr.";
                }
                return userInfo;
            }
            catch (UsernameNotFoundException e)
            {
                return e.Message;
            }

        }

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
