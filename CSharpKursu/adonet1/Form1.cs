using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adonet1
{
    public partial class Form1 : Form
    {
        ProductDal _productDal = new ProductDal();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getProducts();
        }

        private void getProducts()
        {
            dgwProduct.DataSource = _productDal.getAll();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                name = tbxName.Text,
                price = Convert.ToDecimal(tbxPrice.Text),
                stok = Convert.ToInt32(tbxStok.Text),
            });

            getProducts();
            MessageBox.Show("Ürün eklendi: "+tbxName.Text);
            

        }

        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxName.Text = dgwProduct.CurrentRow.Cells[1].Value.ToString();
            tbxPrice.Text = dgwProduct.CurrentRow.Cells[2].Value.ToString();
            tbxStok.Text = dgwProduct.CurrentRow.Cells[3].Value.ToString();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                id = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                name = tbxName.Text,
                price = Convert.ToDecimal(tbxPrice.Text),
                stok = Convert.ToInt32(tbxStok.Text)
            };
            _productDal.Update(product);
            getProducts();
            MessageBox.Show("Ürün güncellendi: " + tbxName.Text);


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value);
            _productDal.Delete(id);
            getProducts();
            MessageBox.Show("Ürün silindi: " + tbxName.Text);
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }

}



