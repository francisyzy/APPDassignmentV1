using APPDassignmentV1.Models;
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
        private bool valid = false;
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
                nonull(picker.SelectedDate);
            }
            else
            {
                // ... No need to display the time.
                DateTime date = (DateTime)picker.SelectedDate;
                this.startDateTime = date;
                nonull(picker.SelectedDate);
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
                nonull(picker.SelectedDate);
            }
            else
            {
                // ... No need to display the time.
                DateTime date = (DateTime)picker.SelectedDate;
                this.endDateTime = date;
                nonull(picker.SelectedDate);
            }
        }

        private void addToCartButton_Click(object sender, RoutedEventArgs e)
        {
            if (!checkvalidation(this.startDateTime, this.endDateTime))
            {
                MessageBox.Show("Date not available for booking");
            }
            else if(!checkDate(this.startDateTime, this.endDateTime))
            {
                MessageBox.Show("End date earlier than start date");
            }
            else if(!valid)
            {
                MessageBox.Show("Please select a date");
            }
            else if (!notbftoday(this.startDateTime))
            {
                MessageBox.Show("Please check start date selection. Booking can only be made on days after today");
            }
            else
            {
                _cartitem.BookingStartDateAndTime = this.startDateTime;
                _cartitem.BookingEndDateAndTime = this.endDateTime;
                shoppingCart.AddCartItem(_cartitem);//add datetime into cart
                Switcher.Switch(new ChooseCategory());//goes back into main page
                
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
            foreach (CartItem booking in (shoppingCart.GetCartItems()).Where(x => x.ResourceId == _cartitem.ResourceId))
            {
                int bigthanzero = DateTime.Compare(start, booking.BookingEndDateAndTime);
                int smallthanzero = DateTime.Compare(end, booking.BookingStartDateAndTime);

                if (!((bigthanzero > 0) || (smallthanzero < 0)))
                {
                    valid = false;
                }
            }


            return valid;
        }

        public bool checkDate(DateTime start, DateTime end)
        {
            bool vaild = true;
            if (start > end)
            {
                vaild = false;
            }
            return vaild;
        }

        public void nonull(DateTime? a){
            if(a == null)
            {
                this.valid = false;
            }
            else
            {
                this.valid = true;
            }

        }

        public bool notbftoday(DateTime start)
        {
            if (start <= DateTime.Now)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new ChooseCategory());
        }
    }
}
