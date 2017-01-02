﻿using System;
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
                    Text = item.resourceId.ToString(),
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
            }
            totalPrice.Content = "S$" + shoppingCart.totalprice();//get total S$

            firstNameLabel.Content = currentUser.cu.firstName;//Gets userinformation & Display them
            lastNameLabel.Content = currentUser.cu.lastName;
            emailLabel.Content = currentUser.cu.email;
            phoneNumberLabel.Content = currentUser.cu.phoneNum;
            creditNumberLabel.Content = currentUser.cu.creditCardNum;
            shoppingCart.RemoveAllCartItem();//remove all shopping cart items after transection is over
        }

        private void goto_ChooseResourceScreenButton_Click(object sender, RoutedEventArgs e)//Button to go back
        {
            Button button = (Button)sender;
            Switcher.Switch(new ChooseCategory());
        }
    }
}

