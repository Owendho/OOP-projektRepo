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
            id = globalId++;
            isactive = true;
            canBeBoughtOnCredit = false;
        }

        private static int globalId = 1;
        public int id { get; set; }

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
        public bool isactive { get; set; }

        public bool canBeBoughtOnCredit { get; set; }

        public override string ToString()
        {
            return $"{id} {name} {price}";
        }
    }
}
