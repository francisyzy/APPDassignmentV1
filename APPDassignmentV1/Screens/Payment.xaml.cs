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
using System.Transactions;
using System.Runtime.Remoting.Contexts;
using Braintree;

namespace APPDassignmentV1.Screens
{
    /// <summary>
    /// Interaction logic for ShoppingCartScreen.xaml
    /// </summary>
    public partial class Payment : UserControl
    {
        private double _price = 0;
        public Payment(double price)
        {
            this._price = price;
            InitializeComponent();
        }

        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)//When user control is loaded, run:
        {
            var gateway = new BraintreeGateway
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = "pwkgm6dh9scwq8hp",
                PublicKey = "djzhmwmxm85zymyq",
                PrivateKey = "8b51991c9dfc9df934c35c5a27b54738"
            };


        }

        private void goto_ChooseResourceScreenButton_Click(object sender, RoutedEventArgs e)//Button to go back
        {
            Button button = (Button)sender;
            Switcher.Switch(new ChooseCategory());
        }
    }
}

