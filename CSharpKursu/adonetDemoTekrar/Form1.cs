using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adonetDemoTekrar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            
            dgwProducts.DataSource = productDal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            productDal.Add(new Product
            {
                name = tbxName.Text,
                price = Convert.ToDecimal(tbxPrice.Text),
                stok = Convert.ToInt32(tbxStok.Text)


            });
            dgwProducts.DataSource = productDal.GetAll();   
            MessageBox.Show("Ürün Eklendi: " + tbxName.Text);
            
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxName.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxPrice.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStok.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                name = tbxName.Text,
                price = Convert.ToDecimal(tbxPrice.Text),
                stok = Convert.ToInt32(tbxStok.Text)

            };
            productDal.Update(product);
            dgwProducts.DataSource = productDal.GetAll();
            MessageBox.Show("Ürün Güncellendi: " + tbxName.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value);         
            productDal.Delete(id);
            dgwProducts.DataSource = productDal.GetAll();
            MessageBox.Show("Ürün Silindi: " + tbxName.Text);
        }
    }
}
