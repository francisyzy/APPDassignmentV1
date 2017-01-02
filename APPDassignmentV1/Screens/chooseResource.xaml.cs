using APPDassignmentV1;
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
    /// Interaction logic for ChooseResource.xaml
    /// </summary>
    public partial class ChooseResource : UserControl, ISwitchable//ISwitchable means that the page allows for page switching
    {
        private string _resourceType = "";
        private string _regionSelected = "";
        private int _resourceTypeID = 0;

        public ChooseResource(string inResourceType,string _region)
        {

            _resourceType = inResourceType;
            _regionSelected = _region;
            InitializeComponent();
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _resourceTypeID = int.Parse(_resourceType);
            if (_resourceTypeID == 1) //Check what kind of resource user selected
            {
                foreach (unitResource item in ((PageSwitcher)this.Parent).Data.unitResources)
                {
                    if(item.address.region == _regionSelected){
                        StackPanel stackPanel = new StackPanel(); //Adds data from json file into the stackpanel using textbox
                        stackPanel.Children.Add(new TextBox
                        {
                            Width = 100,
                            Height = 20,
                            Margin = new Thickness(5),
                            Text = item.address.fullAddress.ToString(),
                            IsEnabled = false
                        });
                        Button button = new Button() //Adds button to check the details of the item that user selected
                        {
                            Width = 100,
                            Height = 20,
                            Margin = new Thickness(5),
                            Content = "Check Detail",
                            Tag = item.resourceId

                        };
                        button.Click += new RoutedEventHandler(goto_DetailPageScreenButton_Click);
                        stackPanel.Children.Add(button);
                        resourceUniformGrid.Children.Add(stackPanel);
                    }
                }
            }//end if block
            if (_resourceTypeID == 2)//Same code when generating rooom resource stack panel
            {
                foreach (roomResource item in ((PageSwitcher)this.Parent).Data.roomResources)
                {
                    if (item.address.region == _regionSelected)
                    {
                        StackPanel stackPanel = new StackPanel();
                        stackPanel.Children.Add(new TextBox
                        {
                            Width = 300,
                            Height = 20,
                            Margin = new Thickness(5),
                            Text = item.address.fullAddress.ToString(),
                            IsEnabled = false
                        });
                        Button button = new Button()
                        {
                            Width = 100,
                            Height = 20,
                            Margin = new Thickness(5),
                            Content = "Check Detail",
                            Tag = item.resourceId
                        };
                        button.Click += new RoutedEventHandler(goto_DetailPageScreenButton_Click);
                        stackPanel.Children.Add(button);
                        resourceUniformGrid.Children.Add(stackPanel);
                    }
                }
            }//end if block
        }

        private void goto_ChooseResourceScreenButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Switcher.Switch(new ChooseCategory());
        }

        private void goto_DetailPageScreenButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Switcher.Switch(new detailPageScreen((((Button)sender).Tag.ToString()), this._resourceTypeID));
        }

        private void goto_shoppingCartScreenButton_Click(object sender, RoutedEventArgs e)//Button to goto shopping cart
        {
            Switcher.Switch(new ShoppingCartScreen());
        }
    }
}
 