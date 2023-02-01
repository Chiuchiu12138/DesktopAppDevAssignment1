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



            string fruit = "apple";                 // input from textbox...
            decimal weight = Convert.ToDecimal(12);     // input from textbox...




            string connectionString = "Data Source=DESKTOP-V50PKCU\\SQLEXPRESS;Initial Catalog=A1;Integrated Security=True;";
            string sql = "select * from dbo.productTable where Product_Name = '"+fruit+"'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            //double temp = reader.GetDouble(0);
                            //decimal price = Convert.ToDecimal(temp);
                            //decimal finalPrice = weight * price;
                            //Console.WriteLine("your final price : " + finalPrice);

                            Console.WriteLine(reader["Product_ID"] + " " + reader["Product_Name"] + " " + reader["KG"] + " " + reader["Price"]);

                            
                            double temp = Convert.ToDouble(reader["Price"]);
                            decimal price = Convert.ToDecimal(temp);
                            decimal finalPrice = weight * price;
                            Console.WriteLine("your final price : " + finalPrice);



                           
                           string sql = "INSERT into dbo.Cart values(@Product_ID, @Product_Name,@KG,@Price";

                            SqlCommand command1 = new SqlCommand(sql, connection);
                           command.Parameters.AddWithValue("@Product_ID", reader["Product_ID"]);
                           command.Parameters.AddWithValue("@Product_Name", reader["Product_Name"]);
                           command.Parameters.AddWithValue("@KG", weight);
                           command.Parameters.AddWithValue("@Price", reader["Price"]);


                            string sql = "select *";
                            SqlCommand command2 = new SqlCommand(sql, connection);
                            Console.WriteLine(reader["Product_ID"] + " " + reader["Product_Name"] + " " + reader["KG"] + " " + reader["Price"]);









                        }
                        Console.ReadKey();
                    }
                }




            }
        }
    }
}
