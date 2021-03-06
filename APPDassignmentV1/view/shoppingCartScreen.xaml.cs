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

namespace APPDassignmentV1.Screens
{
    /// <summary>
    /// Interaction logic for ShoppingCartScreen.xaml
    /// </summary>
    public partial class ShoppingCartScreen : UserControl
    {
        public ShoppingCartScreen()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)//runs when the screen is loaded
        {
            foreach (CartItem item in shoppingCart.GetCartItems())//generate following items for each shopping cart item
            {

                StackPanel stackPanel = new StackPanel();
                stackPanel.Children.Add(new Label//adds label for item info
                {
                    Content = "ResourceID",
                    Foreground = new SolidColorBrush(Colors.White),
                    FontWeight = FontWeights.Bold
                });
                stackPanel.Children.Add(new TextBox//adds item info
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
                Button button = new Button()
                {
                    Width = 100,
                    Height = 50,
                    Margin = new Thickness(5),
                    Content = "Remove",
                    Tag = item.ResourceId
                };
                button.Click += new RoutedEventHandler(removeItemButton_Click);//generate button to remove item from shopping cart
                stackPanel.Children.Add(button);
                ShoppingCartUniformGrid.Children.Add(stackPanel);
            }
            totalPrice.Content = "S$" + shoppingCart.totalprice();
        }

        private void removeItemButton_Click(object sender, RoutedEventArgs e)//Code when the remove item button is clicked
        {
            Button button = (Button)sender;
            shoppingCart.RemoveCartItem(((Button)sender).Tag.ToString());
            Switcher.Switch(new ShoppingCartScreen());//refresh shopping cart screen
        }
        private void goto_ChooseResourceScreenButton_Click(object sender, RoutedEventArgs e)//Goes to choose resource screen
        {
            Button button = (Button)sender;
            Switcher.Switch(new ChooseCategory());
        }

        private void goto_TransactionButton_Click(object sender, RoutedEventArgs e)//goes to transaction screen
        {
            Switcher.Switch(new Transaction());
        }
    }
}

