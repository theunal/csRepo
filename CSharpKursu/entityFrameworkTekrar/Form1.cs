using EntityFrameworkTekrar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entityFrameworkTekrar
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
            GetAll();

        }

        private void GetAll()
        {
            dgwProducts.DataSource = productDal.GetAll();
        }

        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!tbxName.Text.Equals("") && !tbxPrice.Text.Equals("") && !tbxStok.Text.Equals(""))
            {
                productDal.Add(new Product
                {
                    Name = tbxName.Text,
                    Price = Convert.ToDecimal(tbxPrice.Text),
                    Stok = Convert.ToInt32(tbxStok.Text)
                });
                GetAll();
                Log("Ürün eklendi: ", tbxName.Text);
            }
                
          
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!tbxName.Text.Equals("") && !tbxPrice.Text.Equals("") && !tbxStok.Text.Equals(""))
            {
                productDal.Update(new Product
                {
                    ID = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                    Name = tbxName.Text,
                    Price = Convert.ToDecimal(tbxPrice.Text),
                    Stok = Convert.ToInt32(tbxStok.Text)
                }); ;
                GetAll();
                Log("Ürün güncellendi: ", tbxName.Text);             
            }
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxName.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxPrice.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStok.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            productDal.Delete(new Product
            {
                ID = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),             
            });
            String name = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            GetAll();
            Log("Ürün silindi: ",name);
            


        }
        private void GetSearch(String key)
        {
           var result = productDal.GetNameSearch(key);
            dgwProducts.DataSource = result;

        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            GetSearch(tbxSearch.Text);
    
        }
        
        private void tbxLog_TextChanged(object sender, EventArgs e)
        {
               tbxLog.ReadOnly = true;            
        }

        public void Log(String log,String metod)
        {
            tbxLog.Text += log + metod + Environment.NewLine;

        }

       
    }
}
