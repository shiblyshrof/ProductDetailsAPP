using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDetailsApp.BLL.DAO
{
    class Product
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double Quantity { get; set; }

        public Product()
        {
        }

        public Product(string productCode, string productName, double quantity)
        {
            ProductCode = productCode;
            ProductName = productName;
            Quantity = quantity;
        }
    }
}
