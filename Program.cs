using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {


            // ...

            string connectionString = "Data Source=DESKTOP-V50PKCU\\SQLEXPRESS;Initial Catalog=A1;Integrated Security=True;";
            string sql = "select Price from dbo.productTable where Product_Name = 'Apple'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            double temp = reader.GetDouble(0);

                            Console.WriteLine(temp);
                           // Console.WriteLine(reader["Price"]);
                            
                           

                        }
                        Console.ReadKey();
                    }
                }




            }
        }
    }
}
