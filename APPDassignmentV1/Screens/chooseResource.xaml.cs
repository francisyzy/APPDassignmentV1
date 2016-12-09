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

namespace Assignment_Research.Screens
{
    /// <summary>
    /// Interaction logic for ChooseResource.xaml
    /// </summary>
    public partial class ChooseResource : UserControl, ISwitchable
    {
        private string _resourceType = "";

        public ChooseResource(string inResourceType)
        {

            _resourceType = inResourceType;
            InitializeComponent();
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            resultTextBlock.Text = _resourceType;
        }
    }
}
