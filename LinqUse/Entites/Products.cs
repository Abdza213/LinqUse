using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqUse.Entites
{
    public class Products
    {

        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal UnitInPrice { get; set; }

        public int UnitInStock { get; set; }
    }
}
