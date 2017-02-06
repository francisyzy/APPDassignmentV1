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
    public partial class Transaction : UserControl
    {
        public Transaction()
        {
            InitializeComponent();
        }

        public string _connectionstring = @"Server=tcp:appd-assignment-v2.database.windows.net,1433;Initial Catalog = APPD_Assignment_V2; Persist Security Info=False;User ID = appdassignmenttwo; Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30; MultipleActiveResultSets=true;";

        private void UserControl_Loaded(object sender, RoutedEventArgs e)//When user control is loaded, run:
        {
            foreach (CartItem item in shoppingCart.GetCartItems())//Generate display information for every item in the cart
            {

                StackPanel stackPanel = new StackPanel();
                stackPanel.Children.Add(new Label//generate label for resourceId
                {
                    Content = "ResourceID",
                    Foreground = new SolidColorBrush(Colors.White),
                    FontWeight = FontWeights.Bold
                });
                stackPanel.Children.Add(new TextBox//generate textbox (used as label) for resourceId
                {
                    Width = 100,
                    Height = 20,
                    Margin = new Thickness(5),
                    Text = item.ResourceId.ToString(),
                    IsEnabled = false

                });
                stackPanel.Children.Add(new Label
                {
                    Content = "Booking Start Date",
                    Foreground = new SolidColorBrush(Colors.White),
                    FontWeight = FontWeights.Bold
                });
                stackPanel.Children.Add(new TextBox
                {
                    Width = 100,
                    Height = 20,
                    Margin = new Thickness(5),
                    Text = item.BookingStartDateAndTime.ToString(),
                    IsEnabled = false
                });
                stackPanel.Children.Add(new Label
                {
                    Content = "Booking End Date",
                    Foreground = new SolidColorBrush(Colors.White),
                    FontWeight = FontWeights.Bold
                });
                stackPanel.Children.Add(new TextBox
                {
                    Width = 100,
                    Height = 20,
                    Margin = new Thickness(5),
                    Text = item.BookingEndDateAndTime.ToString(),
                    IsEnabled = false
                });
                stackPanel.Children.Add(new Label
                {
                    Content = "Booking Price",
                    Foreground = new SolidColorBrush(Colors.White),
                    FontWeight = FontWeights.Bold
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

                Booking _booking = new Booking()
                {
                    
                    BookingDate = DateTime.Now,
                    BookingStartDate = item.BookingStartDateAndTime,
                    BookingEndDate = item.BookingEndDateAndTime,
                    ResourceId = item.ResourceId,
                    Email = Models.User.getuser()
                    

                };
                //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                //{
                //    using (var conn = new System.Data.SqlClient.SqlConnection(_connectionstring))
                //    {
                //        conn.Open();
                        
                //            ((PageSwitcher)this.Parent).data.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[Booking] ON");
                            ((PageSwitcher)this.Parent).data.Booking.Add(_booking);
                            ((PageSwitcher)this.Parent).data.SaveChanges();
                //            ((PageSwitcher)this.Parent).data.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[Booking] OFF");


                //        scope.Complete();
                //    }
                //}



            }
            totalPrice.Content = "S$" + shoppingCart.totalprice();//get total S$

            //firstNameLabel.Content = currentUser.cu.firstName;//Gets userinformation & Display them
            //lastNameLabel.Content = currentUser.cu.lastName;
            //emailLabel.Content = currentUser.cu.email;
            //phoneNumberLabel.Content = currentUser.cu.phoneNum;
            shoppingCart.RemoveAllCartItem();//remove all shopping cart items after transection is over
        }

        private void goto_ChooseResourceScreenButton_Click(object sender, RoutedEventArgs e)//Button to go back
        {
            Button button = (Button)sender;
            Switcher.Switch(new ChooseCategory());
        }
    }
}

