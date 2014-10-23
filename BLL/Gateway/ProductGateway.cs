using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDetailsApp.BLL.DAO;

namespace ProductDetailsApp.BLL.Gateway
{
    class ProductGateway
    {
        private SqlConnection connection;
        private Product aProduct;

        public ProductGateway()
        {
            connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }

        public int ProductCodeExists(string productCode)
        {
            int affected = 0;
            connection.Open();

            string query = string.Format("SELECT * FROM t_Product WHERE ProductCode = '{0}'", productCode);

            SqlCommand command = new SqlCommand(query, connection);





            SqlDataReader aReader = command.ExecuteReader();
            if (aReader.HasRows)
            {
                affected = 1;
            }

            connection.Close();
            return affected;
          
        }

        public int ProductNameExists(string productName)
        {
            int affected = 0;
            connection.Open();

            string query = string.Format("SELECT * FROM t_Product WHERE ProductName = '{0}'", productName);

            SqlCommand command = new SqlCommand(query, connection);





            SqlDataReader aReader = command.ExecuteReader();
            if (aReader.HasRows)
            {
                affected = 1;
            }

            connection.Close();
            return affected;
        }

        public int Save(Product aProduct1)
        {
            int affected = 0;

            connection.Open();


            string query = string.Format("INSERT INTO t_Product VALUES('{0}' , '{1}' , '{2}')",
                aProduct1.ProductCode, aProduct1.ProductName, aProduct1.Quantity
                );

            SqlCommand command = new SqlCommand(query, connection);
            affected = command.ExecuteNonQuery();



            connection.Close();

            return affected;
        }

        public List<Product> GetAllProductFromDB()
        {
            connection.Open();

            List<Product> products = new List<Product>();
            string query = string.Format("SELECT * FROM t_Product");

            SqlCommand command = new SqlCommand(query, connection);


            SqlDataReader aReader = command.ExecuteReader();


            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    aProduct = new Product();
                    aProduct.ProductCode= aReader[1].ToString();
                    aProduct.ProductName = aReader[2].ToString();
                    aProduct.Quantity = Convert.ToDouble(aReader[3]);


                    products.Add(aProduct);

                }
            }


            connection.Close();

            return products;
        }
    }
}
