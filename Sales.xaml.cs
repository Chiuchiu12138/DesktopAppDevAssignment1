using DesptopAppDevAssignment1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesktopAppDevAssignment_1
{
    /// <summary>
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Sales : Window
    {
        SqlConnection con;
        public string[] operations { get; set; }
        public Sales()
        {
            InitializeComponent();
            operations = new string[] { };
            DataContext = this;
        }
     
        private void adminButton_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            this.Visibility = Visibility.Hidden;
            admin.Show();
        }

        private void payButton_Click(object sender, RoutedEventArgs e)
        {
            //update inventory
            //display message
            //clear cart table for next customer
        }

        private void connectionButtonSales_Click(object sender, RoutedEventArgs e)
        {
            //establish connection to database
            try
            { //Exception handling
                string connectionString = "Data Source=DESKTOP-VMP9DN3;Initial Catalog=Assignment1;Integrated Security=True;MultipleActiveResultSets=True";
                con = new SqlConnection(connectionString);
                con.Open();
                MessageBox.Show("Connection Established Properly");
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            //remove everything from cart
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string tempName = nameTextbox.Text;
            decimal tempWeight = Convert.ToDecimal(weightTextBox.Text);
            decimal finalItemPrice = 0;

            using (con)
            {
                con.Open();
                
                string sql = "select product_name from productTable where product_name = '" + tempName + "'"; //check name
                using (SqlCommand command = new SqlCommand(sql, con)) 
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sql = "select kg from productTable where product_name = '" + tempName + "'"; //check kg
                            
                            using (SqlCommand cmd = new SqlCommand(sql, con))
                            {
                                using (SqlDataReader Reader = cmd.ExecuteReader())
                                {
                                    while (Reader.Read())
                                    {
                                        sql = "select price from productTable where product_name =  '" + tempName + "'"; //get price
                                        
                                        using (SqlCommand comd = new SqlCommand(sql, con))
                                        {
                                            using (SqlDataReader rdr = comd.ExecuteReader())
                                            {
                                                while (rdr.Read())
                                                {
                                                    double temp = rdr.GetDouble(0);
                                                    decimal price = Convert.ToDecimal(temp);
                                                    finalItemPrice = tempWeight * price;
                                                    finalPriceTextbox.Text = finalItemPrice.ToString();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                con.Close();
            }
        
                

            /*
                
                {
                    q.CommandText = String.Format(
                        @"select KG from productTable where Product_Name = @product_Name", "KG");
                    q.Parameters.AddWithValue("@product_Name", nameTextbox.Text);

                    using (var reader = q.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            MessageBox.Show("YES");
                        }
                        else
                        {
                            MessageBox.Show("NO");
                        }
                    }
                }
            */

            //shows updated cart in dataview every time add button is pressed to refresh

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //cart table
        }
    }
}
