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
using APPDassignmentV1.House;

namespace APPDassignmentV1.Screens
{
    /// <summary>
    /// Interaction logic for ChooseResource.xaml
    /// </summary>
    public partial class ChooseResource : UserControl, ISwitchable
    {
        private string _resourceType = "";
        private string _regionSelected = "";

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
            if (_resourceType.Contains("UNIT RESOURCE"))
            {
                foreach (unitResource item in ((PageSwitcher)this.Parent).Data.unitResources)
                {
                    StackPanel stackPanel = new StackPanel();

                    stackPanel.Children.Add(new TextBlock
                    {
                        Width = 100,
                        Height = 20,
                        Margin = new Thickness(5),
                        Text = item.unitId.ToString()
                    });
                    stackPanel.Children.Add(new Button
                    {
                        Width = 100,
                        Height = 20,
                        Margin = new Thickness(5),
                        Content = "Add to Cart"
                    });
                    resourceUniformGrid.Children.Add(stackPanel);

                }
            }//end if block
            if (_resourceType.Contains("ROOM RESOURCE"))
            {
                foreach (roomResource item in ((PageSwitcher)this.Parent).Data.roomResources)
                {
                    StackPanel stackPanel = new StackPanel();
                    resourcesStackPanel.Children.Add(new TextBox
                    {
                        Width = 100,
                        Height = 20,
                        Margin = new Thickness(5),
                        Text = item.roomId.ToString()
                    });
                    resourcesStackPanel.Children.Add(new Button
                    {
                        Width = 100,
                        Height = 20,
                        Margin = new Thickness(5),
                        Content = "Add to cart"
                    });
                    resourcesStackPanel.Children.Add(stackPanel);
                }
            }//end if block
        }

        private void goto_ChooseResourceScreenButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Switcher.Switch(new ChooseCategory());
        }
    }
}
