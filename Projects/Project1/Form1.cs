using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    

        private void Form1_Load(object sender, EventArgs e)
        {
            getProducts();
            getCategories();
        }

        private void getProducts()
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                dgwProduct.DataSource = context.Products.ToList();

            }
        }

        private void getCategories()
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                cbxCategory.DataSource = context.Categories.ToList();
                cbxCategory.DisplayMember = "CategoryName";
                cbxCategory.ValueMember = "CategoryId";

            }
        }


        private void getProductsByCategories(int categoryId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                dgwProduct.DataSource = context.Products.Where(p => p.CategoryId == categoryId).ToList();

            }
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                getProductsByCategories(Convert.ToInt32(cbxCategory.SelectedValue));
                
            }catch (Exception ex)
            {
                Console.WriteLine("hata");
            }
            
        }

        private void btnGetProducts_Click(object sender, EventArgs e)
        {
            getProducts();
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            ProductDal productDal = new ProductDal();
            var result = productDal.getProduct(tbxSearch.Text);
            dgwProduct.DataSource=result;
            
        }
    }
}
