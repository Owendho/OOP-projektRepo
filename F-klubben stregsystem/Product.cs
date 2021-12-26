using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    public class Product
    {
        public Product(string Name, decimal Price)
        {
            name = Name;
            price = Price;
            id++;
            active = true;
            canBeBoughtOnCredit = false;
            Console.WriteLine(id);
        }


        public static int id { get; set; }

        private string _name;
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(name)); 
                }
                _name = value;
            }
        }
        public decimal price { get; set; }
        public bool active { get; set; }

        public bool canBeBoughtOnCredit { get; set; }


        public override string ToString()
        {
            return $"{id} {name} {price}";
        }



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


    }
}
