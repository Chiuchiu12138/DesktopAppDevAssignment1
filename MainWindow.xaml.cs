using DesktopAppDevAssignment_1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace DesptopAppDevAssignment1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection con;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            try
            { //Exception handling
                string connectionString = "Data Source=DESKTOP-5DGA5O7\\SQLEXPRESS;Initial Catalog=DesptopAppDevAssignment1;Integrated Security=True;MultipleActiveResultSets=True";
                con = new SqlConnection(connectionString);
                con.Open();
                MessageBox.Show("Connection Established Properly");
                con.Close();

                ViewData_Click(sender, e);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Open the Database Connect
                con.Open();
                string query = "Insert into productTable values(@productID, @productName,  @price, @amountKG) "; //We need to call the textBox and then grab the text
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@productID", int.Parse(productID.Text));
                cmd.Parameters.AddWithValue("@productName", productName.Text);
                cmd.Parameters.AddWithValue("@price", float.Parse(price.Text));
                cmd.Parameters.AddWithValue("@amountKG", int.Parse(amountKG.Text));

                //We now need to execute our query
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted perfectly into the database");
                con.Close();

                ViewData_Click(sender, e);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                string query = "Update productTable set Product_Name = @productName,  Price = @price, KG_Inventory = @amountKG where Product_ID = @productID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@productID", int.Parse(@productID.Text));
                cmd.Parameters.AddWithValue("@productName", productName.Text);
                cmd.Parameters.AddWithValue("@price", float.Parse(price.Text));
                cmd.Parameters.AddWithValue("@amountKG", int.Parse(amountKG.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated perfectly into the database");
                con.Close();

                ViewData_Click(sender, e);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Delect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                string query = "Delete productTable where Product_ID = @productID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@productID", int.Parse(productID.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted peoperly");
                con.Close();

                ViewData_Click(sender, e);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ViewData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();// First step is to open the SQL connection in your application
                string query = "select * from productTable";// Generate the database query
                SqlCommand cmd = new SqlCommand(query, con);// Generate the SQL command query for the application
                SqlDataAdapter da = new SqlDataAdapter(cmd);//Create a data adapter which will work as a bridge in between the front-end, datagrid and the back-end database.
                DataTable dt = new DataTable();//We need a table view for our dataGrid. so we are creating the dataTable schema over here
                da.Fill(dt);// We need to pass the datatable to the adapter
                dataGrid.ItemsSource = dt.AsDataView();
                DataContext = da;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void goToSale_Click(object sender, RoutedEventArgs e)
        {
            //if cart is empty, create new sales
            //else, dont create new sales?
            Sales sales = new Sales();
            this.Visibility = Visibility.Hidden;
            sales.Show();
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                string query = "Insert into cartTable values(@productID, @productName,  @price, @amountKG) "; //We need to call the textBox and then grab the text
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@productID", int.Parse(productID.Text));
                cmd.Parameters.AddWithValue("@productName", productName.Text);
                cmd.Parameters.AddWithValue("@price", float.Parse(price.Text));
                cmd.Parameters.AddWithValue("@amountKG", int.Parse(amountKG.Text));

                string sql1 = "select KG_Inventory from productTable where product_ID =" + int.Parse(productID.Text);
                SqlCommand command1 = new SqlCommand(sql1, con);
                SqlDataReader reader1 = command1.ExecuteReader();
                reader1.Read();
                int kgInventory = (int)Convert.ToInt64(reader1["KG_Inventory"]);
                int kgCart = int.Parse(amountKG.Text);

                if (kgInventory >= kgCart)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added successfully to the cart");
                }
                else { 
                    MessageBox.Show("Insufficient Inventory"); 
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
