using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    public class BuyTransaction : Transaction
    {
        public BuyTransaction(User _User, decimal Amount, Product _Product) : base(_User, Amount)
        {
            amount = Amount;
            product = _Product;
        }

        Product product { get; set; }

        public override string ToString()
        {
            return $" Buyiing product: {amount} {user} {date}";
        }

        public new void Execute()
        {
            if (user.Balance < 50)
            {
                throw new InsufficientCreditsException($"{user} has insufficient credits for " + product.name );
            }
            user.Balance -= product.price;
        }
        
    }
}
