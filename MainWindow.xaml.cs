using System;
using System.Collections.Generic;
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
                string connectionString = "Data Source=DESKTOP-5DGA5O7\\SQLEXPRESS;Initial Catalog=DesptopAppDevAssignment1;Integrated Security=True";
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

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Open the Database Connect
                con.Open();
                string query = "Insert into productTable values(@productID, @productName, @amountKG, @price) "; //We need to call the textBox and then grab the text
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@productID", int.Parse(productID.Text));
                cmd.Parameters.AddWithValue("@productName", productName.Text);
                cmd.Parameters.AddWithValue("@amountKG", int.Parse(amountKG.Text));
                cmd.Parameters.AddWithValue("@price", float.Parse(price.Text));

                //We now need to execute our query
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted perfectly into the database");
                con.Close();
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
                string query = "Update productTable set productName=@productName, amountKG=@amountKG, price=@price where productID = @productID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@productID", int.Parse(@productID.Text));
                cmd.Parameters.AddWithValue("@productName", productName.Text);
                cmd.Parameters.AddWithValue("@amountKG", int.Parse(amountKG.Text));
                cmd.Parameters.AddWithValue("@price", float.Parse(price.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated perfectly into the database");
                con.Close();
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
                string query = "Delete studentTable where productID = @productID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@productID", int.Parse(productID.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted peoperly");
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
