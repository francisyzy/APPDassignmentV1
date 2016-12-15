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
        private string _resourceType = "";
        private string _resourceID = "";

        public detailPageScreen(string tag, string resourcetype)
        {
            _resourceID = tag;
            _resourceType = resourcetype;
            InitializeComponent();
        }

        private void detailPageScreen_Loaded(object sender, RoutedEventArgs e)
        {
            if (_resourceType.Contains("UNIT RESOURCE"))
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
            else if (_resourceType.Contains("ROOM RESOURCE"))
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
    }
}
