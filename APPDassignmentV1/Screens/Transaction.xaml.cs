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


namespace APPDassignmentV1.Screens
{
    /// <summary>
    /// Interaction logic for ShoppingCartScreen.xaml
    /// </summary>
    public partial class Transaction : UserControl
    {
        public Transaction()
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
                
                reciptScreenUniformGrid.Children.Add(stackPanel);
            }
            totalPrice.Content = "S$" + shoppingCart.totalprice();

            firstNameLabel.Content = currentUser.cu.firstName;
            lastNameLabel.Content = currentUser.cu.lastName;
            emailLabel.Content = currentUser.cu.email;
            phoneNumberLabel.Content = currentUser.cu.phoneNum;
            creditNumberLabel.Content = currentUser.cu.creditCardNum;
            shoppingCart.RemoveAllCartItem();
        }

        private void goto_ChooseResourceScreenButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Switcher.Switch(new ChooseCategory());
        }
    }
}

