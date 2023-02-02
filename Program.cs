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




            string connectionString = "Data Source=DESKTOP-V50PKCU\\SQLEXPRESS;Initial Catalog=A1;Integrated Security=True;MultipleActiveResultSets=True";
            string sql = "select KG from dbo.productTable where Product_Name = '"+fruit+"'";
            //string sql = "select * from dbo.cartTable";
            
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


                            // USED TO GRAB SPECIFIC VALUES

                            /*
                            Console.WriteLine(reader["Product_ID"] + " " + reader["Product_Name"] + " " + reader["KG"] + " " + reader["Price"]);

                            
                            double temp = Convert.ToDouble(reader["Price"]);
                            decimal price = Convert.ToDecimal(temp);
                            decimal finalPrice = weight * price;
                            Console.WriteLine("your final price : " + finalPrice);

                            string sql = "select * from dbo.cartTable";
                            SqlCommand command = new SqlCommand(sql, con);
                            SqlDataReader reader = command.ExecuteReader();

                            */






                            // USED TO CREATE SPECIFIC QUERIES

                            /*
                                string productName = Convert.ToString(reader["Product_Name"]);
                                int kg = (int)Convert.ToInt64(reader["KG"]);

                                Console.WriteLine(productName + "   "+ kg );
                                string sqlq = "UPDATE dbo.productTable SET KG = KG + " + kg + " where Product_Name = '"+productName.TrimEnd()+"'";
                              

                               

                                Console.WriteLine(sqlq);
                                SqlCommand command2 = new SqlCommand(sqlq, connection);
                                command2.ExecuteNonQuery();
                              */

                            
                            int inputKG = 31;
                            int checkKG = (int)Convert.ToInt64(reader["KG"]);
                            if (inputKG > checkKG )
                            {
                                
                                Console.WriteLine("Cannot be done because inventory too low...REQUEST = "+inputKG  +", actually INVENTORY = "+checkKG);
                            } else
                            {
                                /*
                                string query = "Insert into cartTable values(@productID, @productName,  @price, @amountKG) "; //We need to call the textBox and then grab the text
                                SqlCommand cmd = new SqlCommand(query, connection);
                                cmd.Parameters.AddWithValue("@productID", int.Parse(productID.Text));
                                cmd.Parameters.AddWithValue("@productName", productName.Text);
                                cmd.Parameters.AddWithValue("@price", float.Parse(price.Text));
                                cmd.Parameters.AddWithValue("@amountKG", int.Parse(amountKG.Text));


                                //We now need to execute our query
                                cmd.ExecuteNonQuery();
                                */
                                Console.WriteLine("DONE because REQUEST = "+inputKG  +", actually INVENTORY = "+checkKG);
                            }

                           








                        }
                        connection.Close();
                        Console.ReadKey();
                    }
                }




            }
        }
    }
}
