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

        Product product;

        public override string ToString()
        {
            return $"Buying product: {amount} {user} {date}";
        }

        public new void Execute()
        {
            user.Balance -= product.price;
        }
        
    }
}
