using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    class StregsystemCommandParser
    {
        public StregsystemCommandParser(StregsystemCLI stregsystemCli, Stregsystem stregsystem)
        {
            str = stregsystem;
            strCLI = stregsystemCli;
        }


        private Stregsystem str;
        private StregsystemCLI strCLI;

        public void ParseCommand(string command)
        {
            commandType(command);
        }

        public void commandType(string command)
        {
            if (command.StartsWith(":"))
            {
                adminCommands(command);
            }   
            else
            {
                userCommands(command);
            }
        }
        private Product product;
        private User user;
        private void adminCommands(string admincommand)
        {
            string[] commandSplit = admincommand.Split(' ');
            switch (commandSplit[0])
            {
                case ":activate":
                    product = str.GetProductBYID(commandSplit[1]);
                    product.isactive = true;
                    break;
                case ":deactivate":
                    product = str.GetProductBYID(commandSplit[1]);
                    product.isactive = false;
                    break;
                case ":crediton":
                    product = str.GetProductBYID(commandSplit[1]);
                    product.canBeBoughtOnCredit = true;
                    break;
                case ":creditoff":
                    product = str.GetProductBYID(commandSplit[1]);
                    product.canBeBoughtOnCredit = false;
                    break;
                case ":addCredits":
                    user = str.GetUserByUsername(commandSplit[1]);
                    str.AddCreditsToAccount(user, (Convert.ToDecimal(commandSplit[2])));
                    break;
                case ":quit":
                    strCLI.Close();
                    break;
                case ":q":
                    strCLI.Close();
                    break;

                default:
                    strCLI.DisplayAdminCommandNotFoundMessage(admincommand);
                    break;

            }
        }

        private void userCommands(string userCommands)
        {
            string[] userCMSplit = userCommands.Split(' ');

            switch (userCMSplit.Length)
            {
                case 1:
                    try
                    {
                        user = str.GetUserByUsername(userCMSplit[0]);
                        strCLI.DisplayUserInfo(user);
                        strCLI.DisplayTransactions(str.GetTransactions(user, 10));
                        if (user.Balance < 50)
                        {
                            strCLI.DisplayLowBalance(user);
                        }
                    }
                    catch (UsernameNotFoundException e)
                    {
                        strCLI.DisplayGeneralError(e.Message);
                    }
                    break;
                case 2:
                    try
                    {
                        user = str.GetUserByUsername(userCMSplit[0]);
                        str.BuyProduct(user, str.GetProductBYID(userCMSplit[1]));
                        strCLI.DisplayUserBuysProduct(str.BuyProduct(user, str.GetProductBYID(userCMSplit[1])));
                    }
                    catch (UsernameNotFoundException e)
                    {
                        strCLI.DisplayGeneralError(e.Message);
                    }
                    catch (ProductNotFoundException p)
                    {
                        strCLI.DisplayGeneralError(p.Message);
                    }
                    catch(InsufficientCreditsException c)
                    {
                        strCLI.DisplayGeneralError(c.Message);
                    }
                    catch(IncorrectFormatException i)
                    {
                        strCLI.DisplayGeneralError(i.Message);
                    }
                    break;
                case 3:
                    try
                    {
                        user = str.GetUserByUsername(userCMSplit[0]);
                        str.MultiBuy(user, Convert.ToInt32(userCMSplit[1]), str.GetProductBYID(userCMSplit[2]));
                        strCLI.DisplayUserBuysProductM(Convert.ToInt32(userCMSplit[1]), str.MultiBuy(user, Convert.ToInt32(userCMSplit[1]), str.GetProductBYID(userCMSplit[2])));
                    }
                    catch (UsernameNotFoundException e)
                    {
                        strCLI.DisplayGeneralError(e.Message);
                    }
                    catch (ProductNotFoundException p)
                    {
                        strCLI.DisplayGeneralError(p.Message);
                    }
                    catch (InsufficientCreditsException c)
                    {
                        strCLI.DisplayGeneralError(c.Message);
                    }
                    catch (IncorrectFormatException i)
                    {
                        strCLI.DisplayGeneralError(i.Message);
                    }
                    break;
                default:
                    strCLI.DisplayAdminCommandNotFoundMessage(userCommands);
                    break;
            }
        }
    }



    //syntax error when command does not have space between username and product id

    /*Parserfunktionalitet kunne implementers i Kla ssen StregsystemCommandParser.
     *Denne klasse der kan oversætte kommandoer i tekststrenge, der skrives af brugeren, til funktionalitet i form af metodekald:
     * */
}
