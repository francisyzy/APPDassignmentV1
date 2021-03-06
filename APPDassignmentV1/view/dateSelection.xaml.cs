﻿using APPDassignmentV1.Models;
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
    /// Interaction logic for dateSelection.xaml
    /// </summary>
    public partial class dateSelection : UserControl
    {
        private CartItem _cartitem = null;
        private DateTime startDateTime;
        private DateTime endDateTime;
        public dateSelection(CartItem cartitem)
        {
            _cartitem = cartitem;
            InitializeComponent();
        }

        private void startTimeDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get DatePicker reference.
            var picker = sender as DatePicker;

            // ... Get nullable DateTime from SelectedDate.
            
            
            if (picker.SelectedDate == null)
            {
                // ... A null object.
                this.startDateTime = DateTime.Now;
            }
            else
            {
                // ... No need to display the time.
                DateTime date = (DateTime)picker.SelectedDate;
                this.startDateTime = date;
            }
        }

        private void endTimeDatePicker_SelectedDateChanged(object sender,
        SelectionChangedEventArgs e)
        {
            // ... Get DatePicker reference.
            var picker = sender as DatePicker;

            // ... Get nullable DateTime from SelectedDate.
            
            if (picker.SelectedDate == null)
            {
                // ... A null object.
                this.endDateTime = DateTime.Now;
            }
            else
            {
                // ... No need to display the time.
                DateTime date = (DateTime)picker.SelectedDate;
                this.endDateTime = date;
            }
        }

        private void addToCartButton_Click(object sender, RoutedEventArgs e)
        {
            if (checkvalidation(this.startDateTime, this.endDateTime))
            {
                _cartitem.BookingStartDateAndTime = this.startDateTime;
                _cartitem.BookingEndDateAndTime = this.endDateTime;
                shoppingCart.AddCartItem(_cartitem);//add datetime into cart
                Switcher.Switch(new ChooseCategory());//goes back into main page
            }
            else
            {
                MessageBox.Show("Invalid Date");
            }
        }




        public bool checkvalidation(DateTime start, DateTime end)
        {
            bool valid = true;

            foreach (Booking booking in (((PageSwitcher)this.Parent).data.Booking).Where(x=>x.ResourceId == _cartitem.ResourceId))
            {
                int bigthanzero = DateTime.Compare(start, booking.BookingEndDate);
                int smallthanzero = DateTime.Compare(end, booking.BookingStartDate);

                if (!((bigthanzero > 0) || (smallthanzero < 0)))
                {
                    valid = false;
                }
            }
            return valid;

        }
    }
}
