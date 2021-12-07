using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    class SeasonalProduct: Product
    {
        public SeasonalProduct(string Name, int Price) : base(Name, Price)
        {

        }

        /*Make this date time*/
        public double SeasonStartDate { get; set; }
        public double SeasonEndDate { get; set; }

    }
}
