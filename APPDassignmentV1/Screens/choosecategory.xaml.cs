
using APPDassignmentV1;
using APPDassignmentV1.House;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for ChooseCategory.xaml
    /// </summary>
    public partial class ChooseCategory : UserControl, ISwitchable
    {
        public ChooseCategory()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ResourceData data;
            // read JSON directly from a file
            using (StreamReader file = File.OpenText(@"ResourceData.txt"))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {

                    data = JToken.ReadFrom(reader).ToObject<ResourceData>();
                }
            }
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Switcher.Switch(new ChooseResource("physical_resource"));
        }
    }
}
