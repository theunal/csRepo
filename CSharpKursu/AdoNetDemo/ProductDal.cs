using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemo
{
    internal class ProductDal
    {
        public DataTable getAll()
        {
            SqlConnection connection =
                new SqlConnection(@"server = (localdb)\mssqllocaldb; initial calatog = ETrade; integrated security = true");

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlCommand command = new SqlCommand("select * from Products", connection);
            SqlDataReader reader = command.ExecuteReader();

            DataTable data = new DataTable();
            data.Load(reader);
            reader.Close();
            connection.Close();
            return data;
        }




    }

}

