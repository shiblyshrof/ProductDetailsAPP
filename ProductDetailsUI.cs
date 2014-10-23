using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductDetailsApp.BLL;
using ProductDetailsApp.BLL.DAO;

namespace ProductDetailsApp
{
    public partial class ProductDetailsUI : Form
    {
        private Product aProduct;
        private ProductBLL aProductBll;

        public ProductDetailsUI()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            aProductBll = new ProductBLL();
            aProduct = new Product(productCodeTextBox.Text,productNameTextBox.Text,Convert.ToDouble(quantityTextBox.Text));
            string msg = aProductBll.Save(aProduct);
            MessageBox.Show(msg);
        }

        private void viewAllButton_Click(object sender, EventArgs e)
        {
            productDetailsListView.Items.Clear();
            List<Product>products=new List<Product>();
            aProductBll=new ProductBLL();
            products = aProductBll.ShowInListView();
            double total = 0;
            foreach (Product product in products)
            {
                ListViewItem aItem = new ListViewItem(product.ProductCode);

                aItem.SubItems.Add(product.ProductName);
                aItem.SubItems.Add(product.Quantity.ToString());


                productDetailsListView.Items.Add(aItem);
                total += product.Quantity;

            }

            totalQuantityTextBox.Text = total.ToString();
        }
    }
}
