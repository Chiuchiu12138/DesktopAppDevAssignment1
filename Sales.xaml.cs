using DesptopAppDevAssignment1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Xml.Linq;
using System.ComponentModel.Design;

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

        private void goBackToAdmin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow admin = new MainWindow();
            this.Visibility = Visibility.Hidden;
            admin.Show();
        }

        private void viewCart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Display the cart content and expanded prices
                con.Open();// First step is to open the SQL connection in your application
                string query = "select *, KG*Price as calculatedPrice from dbo.cartTable";// Generate the database query
                SqlCommand cmd = new SqlCommand(query, con);// Generate the SQL command query for the application


                SqlDataAdapter da = new SqlDataAdapter(cmd);//Create a data adapter which will work as a bridge in between the front-end, datagrid and the back-end database.
                DataTable dt = new DataTable();//We need a table view for our dataGrid. so we are creating the dataTable schema over here
                da.Fill(dt);// We need to pass the datatable to the adapter
                cartGrid.ItemsSource = dt.AsDataView();
                DataContext = da;


                string sql = "SELECT SUM(KG*PRICE) as value from dbo.cartTable";

                SqlCommand command = new SqlCommand(sql, con);

                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        totalSales.Text = Convert.ToString(Math.Round(Convert.ToDecimal(reader[0]), 2));
                    }
                }
                catch { }
                {

                }

                //Display the cart total in Textbox
                /*query = "SELECT sum(Expanded_Price) from cartTable";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Total_Sales", float.Parse(totalSales.Text));
                SqlDataReader sqlReader = cmd.ExecuteReader();
                while (sqlReader.Read())
                {
                    totalSales.Text = (string)sqlReader.GetValue(0);
                
                }*/
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void connectCart_Click(object sender, RoutedEventArgs e)
        {
            try
            { //Exception handling
                string connectionString = "Data Source=DESKTOP-V50PKCU\\SQLEXPRESS;Initial Catalog=A1;Integrated Security=True;MultipleActiveResultSets=True";
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

        private void cartGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void okToPay_Click(object sender, RoutedEventArgs e)
        {
            con.Open();

            

            string sql = "select * from dbo.cartTable";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                string productName = Convert.ToString(reader["Product_Name"]);
                int kg = (int)Convert.ToInt64(reader["KG"]);

                string sqlq = "UPDATE dbo.productTable SET KG = KG - " + kg + " where Product_Name = '" + productName.TrimEnd() + "'";

    
                SqlCommand command2 = new SqlCommand(sqlq, con);
                command2.ExecuteNonQuery();
                

            }
            MessageBox.Show("PURCHASED!");
            string deleteSQL = "delete from cartTable";
            SqlCommand command3 = new SqlCommand(deleteSQL, con);
            command3.ExecuteNonQuery();
            con.Close();
            viewCart_Click(sender, e);





        }
    }
}
