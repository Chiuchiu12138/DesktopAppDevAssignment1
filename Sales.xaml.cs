using DesptopAppDevAssignment1;
using System;
using System.Collections.Generic;
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
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            //remove everything from cart
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            //try catch to see if name and kg exists in present inventory
            //calculate price for each item
            //return final price value to send to final price textbox
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //cart table
        }
    }
}
