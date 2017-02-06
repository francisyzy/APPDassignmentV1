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
using Microsoft.EntityFrameworkCore;

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
            var resourceList = ((PageSwitcher)this.Parent).data.Resource.Include(b=>b.Region);
                foreach (Resource item in resourceList)
                {
                    if((item.Region.RegionName == _regionSelected)&&(item.ResourceTypeId == _resourceTypeID)){
                        StackPanel stackPanel = new StackPanel(); //Adds data from json file into the stackpanel using textbox


                    stackPanel.Children.Add(new Image
                    {
                        Width = 150,
                        Height = 150,
                        //http://stackoverflow.com/questions/14337071/convert-array-of-bytes-to-bitmapimage
                        Source = (BitmapSource)new ImageSourceConverter().ConvertFrom(item.Picture),
                            //((PageSwitcher)this.Parent).data.Picture.Where
                            //(x => x.PictureId == (int)item.PictureId).Single<Picture>().Picturee),//(BitmapSource)new ImageSourceConverter().ConvertFrom(item.Picture.Picturee),
                        Stretch = Stretch.UniformToFill
                    });
                    stackPanel.Children.Add(new TextBox
                        {
                            Width = 100,
                            Height = 20,
                            Margin = new Thickness(5),
                            Text = item.Fulladdress.ToString(),
                            IsEnabled = false
                        });
                        Button button = new Button() //Adds button to check the details of the item that user selected
                        {
                            Width = 100,
                            Height = 20,
                            Margin = new Thickness(5),
                            Content = "Check Detail",
                            Tag = item.ResourceId

                        };
                        button.Click += new RoutedEventHandler(goto_DetailPageScreenButton_Click);
                        stackPanel.Children.Add(button);
                        resourceUniformGrid.Children.Add(stackPanel);
                    }
                }
            
        }

        private void goto_ChooseResourceScreenButton_Click(object sender, RoutedEventArgs e)//button to go back
        {
            Button button = (Button)sender;
            Switcher.Switch(new ChooseCategory());
        }

        private void goto_DetailPageScreenButton_Click(object sender, RoutedEventArgs e)//page switching
        {
            Button button = (Button)sender;
            Switcher.Switch(new detailPageScreen((((Button)sender).Tag.ToString()), this._resourceTypeID));//bring info from previous page to new page
        }

        private void goto_shoppingCartScreenButton_Click(object sender, RoutedEventArgs e)//Button to goto shopping cart
        {
            Switcher.Switch(new ShoppingCartScreen());
        }

        private void goto_reportScreenButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Report());
        }
    }
}