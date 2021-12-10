﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    class BuyTransaction : Transaction
    {
        BuyTransaction(User _User, int Amount, Product _Product) : base(_User, Amount)
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
            user.Balance -= product.price;
        }

        /*Create InsufficientCreditsException exception here*/

    }
}