using Braintree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
    /// Interaction logic for ShoppingCartScreen.xaml
    /// </summary>
    public partial class ShoppingCartScreen : UserControl
    {

        var gateway = new BraintreeGateway
        {
            Environment = Braintree.Environment.SANDBOX,
            MerchantId = "pwkgm6dh9scwq8hp",
            PublicKey = "djzhmwmxm85zymyq",
            PrivateKey = "8b51991c9dfc9df934c35c5a27b54738"
        };
        public ShoppingCartScreen()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (CartItem item in shoppingCart.GetCartItems())
            {

                StackPanel stackPanel = new StackPanel();
                stackPanel.Children.Add(new TextBox
                {
                    Width = 100,
                    Height = 20,
                    Margin = new Thickness(5),
                    Text = item.resourceId.ToString(),
                    IsEnabled = false
                });
                stackPanel.Children.Add(new TextBox
                {
                    Width = 100,
                    Height = 20,
                    Margin = new Thickness(5),
                    Text = item.BookingStartDateAndTime.ToString(),
                    IsEnabled = false
                });
                stackPanel.Children.Add(new TextBox
                {
                    Width = 100,
                    Height = 20,
                    Margin = new Thickness(5),
                    Text = item.BookingEndDateAndTime.ToString(),
                    IsEnabled = false
                });
                stackPanel.Children.Add(new TextBox
                {
                    Width = 100,
                    Height = 20,
                    Margin = new Thickness(5),
                    Text = item.CalculatePrice(item.BookingStartDateAndTime, item.BookingEndDateAndTime).ToString(),
                    IsEnabled = false

                });
                Button button = new Button()
                {
                    Width = 100,
                    Height = 50,
                    Margin = new Thickness(5),
                    Content = "Remove",
                    Tag = item.resourceId

                };
                button.Click += new RoutedEventHandler(removeItemButton_Click);
                stackPanel.Children.Add(button);
                ShoppingCartUniformGrid.Children.Add(stackPanel);
            }
            totalPrice.Content = shoppingCart.totalprice();
        }

        private void removeItemButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            shoppingCart.RemoveCartItem(((Button)sender).Tag.ToString());
            Switcher.Switch(new ShoppingCartScreen());
        }
        private void goto_ChooseResourceScreenButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Switcher.Switch(new ChooseCategory());
        }
        public class ClientTokenHandler : IHttpHandler
        {
            public void ProcessRequest(HttpContext context)
            {
                var clientToken = gateway.ClientToken.generate();
                context.Response.Write(clientToken);
            }
        }

        private void goto_ReciptScreenButton_Click(object sender, RoutedEventArgs e)
        {

            var request = new TransactionRequest
            {
                Amount = 10.00M,
                PaymentMethodNonce = nonceFromTheClient,
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };

            Result<Transaction> result = gateway.Transaction.Sale(request);
            Switcher.Switch(new reciptScreen());
        }
    }
}

