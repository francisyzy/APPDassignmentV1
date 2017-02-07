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

        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            int count = 1;
            var bookingList = ((PageSwitcher)this.Parent).data.Booking.Include(b => b.Resource);
            var most = (from q in bookingList 
                        
                        group q by q.ResourceId into qgrp 
                        orderby qgrp.Count() descending
                        select new { Count = qgrp.Count(),qgrp}).Take(10);
            //Before stack panel legend thingy
            StackPanel legend = new StackPanel(); //Adds data from json file into the stackpanel using textbox
            legend.Orientation = Orientation.Horizontal;

            legend.Children.Add(new TextBox
            {
                Width = 25,
                Height = 20,
                Margin = new Thickness(5),
                Text = "No.",
                IsEnabled = false
            });
            legend.Children.Add(new TextBox
            {
                Width = 100,
                Height = 20,
                Margin = new Thickness(5),
                Text = "No. Of Booking",
                IsEnabled = false
            });
            legend.Children.Add(new TextBox
            {
                Width = 150,
                Height = 20,
                Margin = new Thickness(5),
                Text = "Picture",
                IsEnabled = false
            });
            legend.Children.Add(new TextBox
            {
                Width = 30,
                Height = 20,
                Margin = new Thickness(5),
                Text = "ID",
                IsEnabled = false
            });
            legend.Children.Add(new TextBox
            {
                Width = 100,
                Height = 20,
                Margin = new Thickness(5),
                Text = "Address",
                IsEnabled = false
            });

            legend.Children.Add(new TextBox
            {
                Width = 100,
                Height = 20,
                Margin = new Thickness(5),
                Text = "Button to check details",
                IsEnabled = false

            });

            bookingUniformGrid.Children.Add(legend);

            foreach (var booking in most)
            {
                StackPanel stackPanel = new StackPanel(); //Adds data from json file into the stackpanel using textbox
                stackPanel.Orientation = Orientation.Horizontal;

                stackPanel.Children.Add(new TextBox
                {
                    Width = 25,
                    Height = 20,
                    Margin = new Thickness(5),
                    Text = count.ToString(),
                    IsEnabled = false
                });
                stackPanel.Children.Add(new TextBox
                {
                    Width = 100,
                    Height = 20,
                    Margin = new Thickness(5),
                    Text = booking.Count.ToString(),
                    IsEnabled = false
                });
                stackPanel.Children.Add(new Image
                {
                    Width = 150,
                    Height = 150,
                    //http://stackoverflow.com/questions/14337071/convert-array-of-bytes-to-bitmapimage
                    Source = (BitmapSource)new ImageSourceConverter().ConvertFrom((((PageSwitcher)this.Parent).data.Resource.Where(i=>i.ResourceId==booking.qgrp.Key.ToString())).Single<Resource>().Picture),
                    //((PageSwitcher)this.Parent).data.Picture.Where
                    //(x => x.PictureId == (int)item.PictureId).Single<Picture>().Picturee),//(BitmapSource)new ImageSourceConverter().ConvertFrom(item.Picture.Picturee),
                    Stretch = Stretch.UniformToFill
                });
                stackPanel.Children.Add(new TextBox
                {
                    Width = 30,
                    Height = 20,
                    Margin = new Thickness(5),
                    Text = booking.qgrp.Key.ToString(),
                    IsEnabled = false
                });
                stackPanel.Children.Add(new TextBox
                {
                    Width = 100,
                    Height = 20,
                    Margin = new Thickness(5),
                    Text = (((PageSwitcher)this.Parent).data.Resource.Where(i => i.ResourceId == booking.qgrp.Key.ToString())).Single<Resource>().Fulladdress,//This is supoosed to be full address
                    IsEnabled = false
                });

                Button button = new Button() //Adds button to check the details of the item that user selected
                {
                    Width = 100,
                    Height = 20,
                    Margin = new Thickness(5),
                    Content = "Check Detail",
                    Tag = booking.qgrp.Key.ToString()

                };
                button.Click += new RoutedEventHandler(goto_DetailPageScreenButton_Click);
                stackPanel.Children.Add(button);

                bookingUniformGrid.Children.Add(stackPanel);

                count++;
            }

        }

        private void goto_DetailPageScreenButton_Click(object sender, RoutedEventArgs e)//page switching
        {
            Button button = (Button)sender;
            Switcher.Switch(new detailPageScreen((((Button)sender).Tag.ToString())));//bring info from previous page to new page
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

        private void topBooking_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void topPeriodBooking_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lastWeekBooking_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lastMonthBooking_Click(object sender, RoutedEventArgs e)
        {
            //idk what to add here
        }
    }
}
