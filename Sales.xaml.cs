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
using System.Runtime.Remoting.Messaging;

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
                string query = "select * ,KG_Cart*Price AS Expanded_Price from cartTable";// Generate the database query
                SqlCommand cmd = new SqlCommand(query, con);// Generate the SQL command query for the application
                SqlDataAdapter da = new SqlDataAdapter(cmd);//Create a data adapter which will work as a bridge in between the front-end, datagrid and the back-end database.
                DataTable dt = new DataTable();//We need a table view for our dataGrid. so we are creating the dataTable schema over here
                da.Fill(dt);// We need to pass the datatable to the adapter
                cartGrid.ItemsSource = dt.AsDataView();
                DataContext = da;

                //Display the cart total in Textbox
                query = "SELECT sum(KG_Cart*Price) from cartTable";
                cmd = new SqlCommand(query, con);
                SqlDataReader sqlReader = cmd.ExecuteReader();
                try
                {
                    while (sqlReader.Read())
                    {
                        totalSales.Text = Convert.ToString(Math.Round(Convert.ToDecimal(sqlReader[0]), 2));
                    }
                }
                catch { }      
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
                string connectionString = "Data Source=DESKTOP-5DGA5O7\\SQLEXPRESS;Initial Catalog=DesptopAppDevAssignment1;Integrated Security=True;MultipleActiveResultSets=True";
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

        private void OkToPay_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            string sql = "select * from cartTable";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string productID = Convert.ToString(reader["Product_ID"]);
                int kg = (int)Convert.ToInt64(reader["KG_Cart"]);
                string sqlquery1 = "UPDATE productTable SET KG_Inventory = KG_Inventory -" + kg + "where Product_ID =" + productID;
                SqlCommand command1 = new SqlCommand(sqlquery1, con);
                command1.ExecuteNonQuery();
            }
            string sqlquery2 = "DELETE cartTable";
            SqlCommand command2 = new SqlCommand(sqlquery2, con);
            command2.ExecuteNonQuery();

            MessageBox.Show("Successfully paid");

            con.Close();

            viewCart_Click(sender, e);

        }
    }
}
