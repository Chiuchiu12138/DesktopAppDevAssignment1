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
            //establish connection to database?
            try
            { //Exception handling
                string connectionString = "Data Source=DESKTOP-VMP9DN3;Initial Catalog=Assignment1;Integrated Security=True";
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
            /*
string name = nameTextbox.Text;
double weight = Convert.ToDouble(weightTextBox.Text);

//add button click pseudocode
sql name variable = select product name from product table //get name from product table
if name == sql name variable //check if name exists
	sql weight variable = select weight from product table where product name = name //get weight from product table for that specific name item
	if weight <= sql weight variable //check if inventory has enough of the item
		sql price variable = select price from product table where product name = name //get price for that specific item
		item price = weight * sql price variable //calculate total item price
		finalItemPrice = finalItemPrice + item price //add total item price to overall cart final price
	else
		exception error: not enough amount of (name) available //customer asked for too much of an item
else
		exception error: product does not exist in inventory //customer asked for an item that doesnt exist
	
finalPriceTextbox = finalItemPrice.ToString(); //display final price in the textbox on front end
             */


            //non-functional code
            /*
            //try catch to see if name and kg exists in present inventory
            double weight = Convert.ToDouble(weightTextBox.Text);
            string name = nameTextbox.Text;
            double itemPrice;
            double finalItemPrice;
            
            try
            {
                con.Open();
                string query = "select Product_Name = @productName, KG = @amountKG, Price = @price from productTable";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@productName", nameTextbox.Text);
                cmd.Parameters.AddWithValue("@amountKG", int.Parse(weightTextBox.Text));
                query = "select Price = @price from productTable where Product_Name = @productName";
                cmd.Parameters.AddWithValue("@price", itemPrice);

                //calculate price for each item
                if (name.Equals() && (weight = )
                {
                    itemPrice = weight * (price of item);
                    finalItemPrice = finalItemPrice + itemPrice;
                }
                con.Close();
            }
            catch (Exception ex) //name or kg invalid
            {
                MessageBox.Show("Name or weight invalid.");
            }
            //return final price value to send to final price textbox
            finalPriceTextbox = finalItemPrice.ToString();

            */
            
            //shows updated cart in dataview every time add button is pressed to refresh
            try
            {
                con.Open();// First step is to open the SQL connection in your application
                string query = "select * from cartTable";// Generate the database query 
                //**CREATE cartTABLE
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

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //cart table
        }
    }
}
