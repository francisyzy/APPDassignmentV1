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
using System.Windows.Navigation;
using System.Windows.Shapes;
using APPDassignmentV1.Models;
using Microsoft.EntityFrameworkCore;

namespace APPDassignmentV1.Screens
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : UserControl
    {
        public Report()
        {
            InitializeComponent();
        }

        public string _connectionstring = @"Server=tcp:appd-assignment-v2.database.windows.net,1433;Initial Catalog = APPD_Assignment_V2; Persist Security Info=False;User ID = appdassignmenttwo; Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30; MultipleActiveResultSets=true;";

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var resourceList = ((PageSwitcher)this.Parent).data.Booking.Include(b => b.Region);
            foreach (Booking item in resourceList)
            {
                //TODO
            }

        }

        private void goto_shoppingCartScreenButton_Click(object sender, RoutedEventArgs e)//Button to goto shopping cart
        {
            Switcher.Switch(new ShoppingCartScreen());
        }

        private void goto_ChooseResourceScreenButton_Click(object sender, RoutedEventArgs e)//button to go back
        {
            Button button = (Button)sender;
            Switcher.Switch(new ChooseCategory());
        }
    }
}
