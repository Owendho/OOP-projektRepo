using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    class Product
    {
        public Product(string Name, int Price)
        {
            name = Name;
            price = Price;
            ID = ID + 1;
            active = true;
        }


        public int ID { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public bool active { get; set; }

        public bool canBeBoughtOnCredit { get; set; }


        public override string ToString()
        {
            return $"{ID} {name} {price}";
        }

        /*Remove functions*/

        /*Maybe not have it be a bool*/
        public bool isProductActive()
        {
            if (active == true)
            {
                active = false;
            }
            else
            {
                active = true;
            }
            return active;
        }

        public string productCanBeboughOnCredit(User user)
        {
            string productAlert = "";
            if(user.Balance < 50)
            {
                productAlert = "Insuffiecient money to buy this product";
            }

            return productAlert;
        }
    }
}
