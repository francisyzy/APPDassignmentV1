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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

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
