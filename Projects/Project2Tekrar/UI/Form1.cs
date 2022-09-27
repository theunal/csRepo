using Business.Abstract;
using Business.Concrete;
using Business.DependecyResolver.Ninject;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            productService = InstanceFactory.GetInstance<IProductService>();
            categoryService = InstanceFactory.GetInstance<ICategoryService>();
            gecmisService = new GecmisManager(new GecmisDal());
        }


        private IProductService productService;
        private ICategoryService categoryService;
        private IGecmisService gecmisService;


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
            LoadAddedCategories();
        }

        private void LoadCategories()
        {
            cbxCategory.DataSource = categoryService.GetAll();
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryId";


        }

        private void LoadAddedCategories()
        {
            cbxCategoryId.DataSource = categoryService.GetAll();
            cbxCategoryId.DisplayMember = "CategoryName";
            cbxCategoryId.ValueMember = "CategoryId";
        }

        private void LoadProducts()
        {
            dgwProduct.DataSource = productService.GetAll();
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProduct.DataSource = productService.GetProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch
            { }
        }
        private void btnGetProducts_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxSearch.Text))
            {
                dgwProduct.DataSource = productService.GetProductsByProductName(tbxSearch.Text);

            }
            else
            {
                LoadProducts();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                productService.Add(new Product()
                {
                    CategoryId = Convert.ToInt32(cbxCategoryId.SelectedValue),
                    ProductName = tbxName.Text,
                    UnitPrice = Convert.ToDecimal(tbxPrice.Text),
                    UnitsInStock = Convert.ToInt16(tbxStok.Text),
                    QuantityPerUnit = tbxQuantityPerUnit.Text
                });
                gecmisService.Add(new Gecmis()
                {
                    Gecmisvar = "deneme1"
                });
                LoadProducts();
                // AddGecmis("deneme1");
                tbxLog.Text += "Ürün eklendi: " + tbxName.Text.ToString() + " - " + DateTime.Now.ToString() + Environment.NewLine;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                productService.Update(new Product
                {
                    ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                    CategoryId = Convert.ToInt32(cbxCategoryId.SelectedValue),
                    ProductName = tbxName.Text,
                    UnitPrice = Convert.ToDecimal(tbxPrice.Text),
                    UnitsInStock = Convert.ToInt16(tbxStok.Text),
                    QuantityPerUnit = tbxQuantityPerUnit.Text

                });
                LoadProducts();
                tbxLog.Text += "Ürün güncellendi: " + tbxName.Text.ToString() + " - " + DateTime.Now.ToString() + Environment.NewLine;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgwProduct.CurrentRow != null)
            {
                productService.Delete(new Product()
                {
                    ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value.ToString()),
                    ProductName = dgwProduct.CurrentRow.Cells[2].Value.ToString()
                });
            }
            LoadProducts();
            tbxLog.Text += "Ürün silindi: " + tbxName.Text.ToString() + " - " + DateTime.Now.ToString() + Environment.NewLine;
        }
        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbxCategoryId.SelectedValue = Convert.ToInt32(dgwProduct.CurrentRow.Cells[1].Value);
            tbxName.Text = dgwProduct.CurrentRow.Cells[2].Value.ToString();
            tbxPrice.Text = dgwProduct.CurrentRow.Cells[3].Value.ToString();
            tbxStok.Text = dgwProduct.CurrentRow.Cells[4].Value.ToString();
            tbxQuantityPerUnit.Text = dgwProduct.CurrentRow.Cells[5].Value.ToString();
        }
        private void tbxLog_TextChanged(object sender, EventArgs e)
        {
            tbxLog.ReadOnly = true;
        }
    }
}
