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
            




        }

        private void goto_ChooseResourceScreenButton_Click(object sender, RoutedEventArgs e)//Button to go back
        {
            Button button = (Button)sender;
            Switcher.Switch(new ChooseCategory());
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var gateway = new BraintreeGateway
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = "pwkgm6dh9scwq8hp",
                PublicKey = "djzhmwmxm85zymyq",
                PrivateKey = "8b51991c9dfc9df934c35c5a27b54738"
            };

            TransactionRequest request = new TransactionRequest
            {
                Amount = 10.00M,
                OrderId = "order id",
                MerchantAccountId = "a_merchant_account_id",
                PaymentMethodNonce = "fake-valid-nonce",
                Customer = new CustomerRequest
                {
                    FirstName = "Tripp",
                    LastName = "Jacobson",
                    
                    Phone = "312-555-1234",
                    Fax = "312-555-1235",
                    Website = "http://www.example.com",
                    Email = "drew@example.com"
                },
                BillingAddress = new AddressRequest
                {
                    FirstName = "Paul",
                    LastName = "Smith",
                    Company = "Braintree",
                    StreetAddress = "1 E Main St",
                    ExtendedAddress = "Suite 403",
                    Locality = "Chicago",
                    Region = "IL",
                    PostalCode = "60622",
                    CountryCodeAlpha2 = "US"
                },
                ShippingAddress = new AddressRequest
                {
                    FirstName = "Jen",
                    LastName = "Smith",
                    Company = "Braintree",
                    StreetAddress = "1 E 1st St",
                    ExtendedAddress = "Suite 403",
                    Locality = "Bartlett",
                    Region = "IL",
                    PostalCode = "60103",
                    CountryCodeAlpha2 = "US"
                },
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                },
            };

            Result<Transaction> result = gateway.Transaction.Sale(request);
        }

        
    
    
    }
}

