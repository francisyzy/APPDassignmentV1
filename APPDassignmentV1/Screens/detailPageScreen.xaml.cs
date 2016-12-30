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
    /// Interaction logic for detailPageScreen.xaml
    /// </summary>
    public partial class detailPageScreen : UserControl
    {
        private int _resourceTypeID = 0;
        private string _resourceID = "";
        private Resource selectedResource = null;

        public detailPageScreen(string tag, int resourcetypeID)
        {
            _resourceID = tag;
            _resourceTypeID = resourcetypeID;
            InitializeComponent();
        }

        private void detailPageScreen_Loaded(object sender, RoutedEventArgs e)
        {
            if (_resourceTypeID == 1)
            {
                foreach (unitResource item in ((PageSwitcher)this.Parent).Data.unitResources)
                {
                    if (item.resourceId == _resourceID)
                    {
                        FullAdressTextBox.Text = item.address.fullAddress;
                        PostCodeTextBox.Text = item.address.postalCode.ToString();
                        PriceTextBox.Text = item.price.ToString();
                        SizeTextBox.Text = item.houseSize.ToString();
                    }

                }
            }
            else if (_resourceTypeID == 2)
            {
                foreach (roomResource item in ((PageSwitcher)this.Parent).Data.roomResources)
                {
                    if (item.resourceId == _resourceID)
                    {
                        FullAdressTextBox.Text = item.address.fullAddress;
                        PostCodeTextBox.Text = item.address.postalCode.ToString();
                        PriceTextBox.Text = item.price.ToString();
                        SizeTextBox.Text = item.roomSize.ToString();
                    }
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new ChooseCategory());
        }

        private void BookButton_Click(object sender, RoutedEventArgs e)
        {
            if (_resourceTypeID == 1)
            {
                selectedResource = ((PageSwitcher)this.Parent).Data.unitResources.Where(input => input.resourceId == _resourceID).Single<Resource>();//ask database for resource
            }
            else if (_resourceTypeID == 2)
            {
                selectedResource = ((PageSwitcher)this.Parent).Data.roomResources.Where(input => input.resourceId == _resourceID).Single<Resource>();//ask database for resource
            }
            CartItem cartItem = new CartItem(selectedResource);
            Switcher.Switch(new dateSelection(cartItem));
        }
    }
}
