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
            var bookingList = ((PageSwitcher)this.Parent).data.Booking.Include(b => b.Resource);
            var most = (from q in bookingList 
                        
                        group q by q.ResourceId into qgrp 
                        orderby qgrp.Count() descending
                        select new { Count = qgrp.Count(),qgrp}).Take(10);
            foreach (var booking in most)
            {
                StackPanel stackPanel = new StackPanel(); //Adds data from json file into the stackpanel using textbox


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
                    Width = 100,
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
                    Text = booking.Count.ToString(),
                    IsEnabled = false
                });

                bookingUniformGrid.Children.Add(stackPanel);
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
