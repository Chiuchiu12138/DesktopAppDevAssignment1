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


            // ... designing tests to incorperate into main class..



            string fruit = "Raspberry";                 // input from textbox...
            decimal weight = Convert.ToDecimal(12);     // input from textbox...




            string connectionString = "Data Source=DESKTOP-V50PKCU\\SQLEXPRESS;Initial Catalog=A1;Integrated Security=True;";
            string sql = "select Price from dbo.productTable where Product_Name = '"+fruit+"'";

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
                            decimal price = Convert.ToDecimal(temp);
                            decimal finalPrice = weight * price;
                            Console.WriteLine("your final price :" + finalPrice);




                        }
                        Console.ReadKey();
                    }
                }




            }
        }
    }
}
