using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_klubben_stregsystem
{
    class SeasonalProduct: Product
    {
        public SeasonalProduct(string Name, decimal Price) : base(Name, Price)
        {

        }

        DateTime SeasonStartDate { get; set; }
        DateTime SeasonEndDate { get; set; }

    }
}
