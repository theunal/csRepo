using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonetDemoTekrar
{
    public class ProductDal
    {
        SqlConnection connection =
                new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=ETrade;integrated security=true");


        public List<Product> GetAll()
        {
            Connecting();
           

            SqlCommand command = new SqlCommand("select * from Products", connection);
            SqlDataReader reader = command.ExecuteReader();


            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                Product product = new Product
                {
                    id = Convert.ToInt32(reader["Id"]),
                    name = reader["name"].ToString(),
                    price = Convert.ToDecimal(reader["price"]),
                    stok = Convert.ToInt32(reader["stok"])
                };
                products.Add(product);
            }
            reader.Close();
            connection.Close();
            return products;



        }

        private void Connecting()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();

            }
        }


        public void Add(Product product)
        {
            Connecting();

            SqlCommand command = new SqlCommand("insert into Products values (@name,@price,@stok)",connection);
            command.Parameters.AddWithValue("@name", product.name);
            command.Parameters.AddWithValue("@price", product.price);
            command.Parameters.AddWithValue("@stok", product.stok);
            command.ExecuteNonQuery(); // etkilenen kayıt sayısını da döndürmeye yarar
  
            connection.Close();
           
        }



        public void Update(Product product)
        {
            Connecting();

            SqlCommand command = new SqlCommand("update Products set name=@name, price=@price, stok=@stok where id=@id",connection);

            command.Parameters.AddWithValue("@name",product.name);
            command.Parameters.AddWithValue("@price", product.price);
            command.Parameters.AddWithValue("@stok", product.stok);
            command.Parameters.AddWithValue("@id", product.id);
            command.ExecuteNonQuery();

            connection.Close();


        }


        public void Delete(int id)
        {
            Connecting();

            SqlCommand command = new SqlCommand("delete from Products where id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            connection.Close();


        }




    }
}
