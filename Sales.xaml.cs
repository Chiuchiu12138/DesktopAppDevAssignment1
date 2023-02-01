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
    }
}
