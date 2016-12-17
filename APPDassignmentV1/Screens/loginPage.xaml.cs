using APPDassignmentV1;
using APPDassignmentV1.Models;
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
    /// Interaction logic for loginPage.xaml
    /// </summary>
    public partial class loginPage : UserControl, ISwitchable
    {
        public loginPage()
        {
            InitializeComponent();
        }
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            using (StreamReader file = File.OpenText(@"ResourceData.JSON"))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    //   rentingSpaceList =  JToken.ReadFrom(reader).ToObject<List<RentingSpace>>();
                    ((PageSwitcher)this.Parent).Data = JToken.ReadFrom(reader).ToObject<ResourceData>();

                    // PhysicalResource obj = JsonConvert.DeserializeObject< PhysicalResource> (reader.Value.ToString());
                }
            }//end of 1st using block, file
            Button button;

            foreach (string resourceType in ((PageSwitcher)this.Parent).Data.resourceType)
            {
                button = new Button()
                {
                    Content = string.Format("{0}", resourceType),
                    Tag = resourceType,
                    Height = 35,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                button.Click += new RoutedEventHandler(loginButton_Click);
                this.resourceTypeUniformGrid.Children.Add(button);
            }
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
            Button button = (Button)sender;
            Switcher.Switch(new ChooseCategory());
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
            Button button = (Button)sender;
            Switcher.Switch(new ChooseCategory());
        }

        private void createAccount_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
            Switcher.Switch(new ChooseCategory());
        }

        
    }
}
