using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    public interface IStregsystemUI
    {
        
        void DisplayUserNotFound(string username);
        void DisplayProductNotFound(string product);
        void DisplayUserInfo(User user); 
        void DisplayTooManyArgumentsError(string command); 
        void DisplayAdminCommandNotFoundMessage(string adminCommand); 
        void DisplayUserBuysProduct(BuyTransaction transaction);
        void DisplayUserBuysProductM(int count, List<BuyTransaction> transactions);
        void Close(); 
        void DisplayInsufficientCash(User user, Product product); 
        void DisplayGeneralError(string errorString); 
        void Start();
        event StregsystemEvent CommandEntered;
    }

    public delegate void StregsystemEvent(string command);
}
