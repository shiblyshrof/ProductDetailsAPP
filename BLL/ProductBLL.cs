using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDetailsApp.BLL.DAO;
using ProductDetailsApp.BLL.Gateway;

namespace ProductDetailsApp.BLL
{
    class ProductBLL
    {
        private ProductGateway aProductGateway;
        private Product aProduct;
        public string Save(Product aProduct1)
        {
            string msg = "";
            aProductGateway=new ProductGateway();
            string productName = aProduct1.ProductName;
            string productCode = aProduct1.ProductCode;
            bool isDone = true;
            if (productName.Length<5 || productName.Length>10)
            {
                msg += "Sorry \nProduct Name Must Be \n In 5 To 10 Character Range.\n";
                isDone = false;
            }
            if (productCode.Length !=3 )
            {
                msg += "Sorry \nCode Must Be 3 Character Long.\n";
                isDone = false;
            }
            bool isDone1 = true;

            if (aProductGateway.ProductCodeExists(aProduct1.ProductCode)>0)
            {
                msg += "Sorry \n Product Code Exists.\n";
                isDone1 = false;
            }
            if (aProductGateway.ProductNameExists(aProduct1.ProductName)>0)
            {
                msg += "Sorry \n Product Name Exists.\n";
                isDone1 = false;
            }

            if (isDone1 == false || isDone == false)
            {
                return msg;
            }
            int affected = aProductGateway.Save(aProduct1);

            if (affected > 0)
            {
                msg += "Saved";
            }
            else
            {
                msg += "Could Not Saved.";

            }


            return msg;
        }

        public List<Product> ShowInListView()
        {
            string msg = "";
            List<Product> products = new List<Product>();
            aProductGateway =new ProductGateway();
             products = aProductGateway.GetAllProductFromDB();

            

            return products;
        }
        //public double CalculateTotalQuantity(double totalQuantity, double newQuantity)
        //{
        //    totalQuantity += newQuantity;

        //    return totalQuantity;
        //}
        }
    }

