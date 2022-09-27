using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet1
{
    internal class ProductDal
    {
        SqlConnection _connection =
                   new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=ETrade;integrated security=true");

        public List<Product> getAll()
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("select * from Products", _connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                Product product = new Product
                {
                    id = Convert.ToInt32(reader["Id"]),
                    name = reader["Name"].ToString(),
                    price = Convert.ToDecimal(reader["Price"]),
                    stok = Convert.ToInt32(reader["Stok"])
                };
                products.Add(product);
            }
            reader.Close();
            _connection.Close();
            return products;
        }

        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }


        public void Add(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("insert into Products values (@name,@price,@stok)", _connection);

            command.Parameters.AddWithValue("@name", product.name);
            command.Parameters.AddWithValue("@price", product.price);
            command.Parameters.AddWithValue("@stok", product.stok);
            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Update(Product product)
        {
            ConnectionControl();
            SqlCommand command =
                new SqlCommand("update Products set name = @name,price =@price,stok =@stok where id = @id", _connection);


            command.Parameters.AddWithValue("@name", product.name);
            command.Parameters.AddWithValue("@price", product.price);
            command.Parameters.AddWithValue("@stok", product.stok);
            command.Parameters.AddWithValue("@id", product.id);
            command.ExecuteNonQuery();

            _connection.Close();
        }
        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand command =
                new SqlCommand("Delete from Products where id = @id", _connection);

            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();

            _connection.Close();
        }


    }
}
