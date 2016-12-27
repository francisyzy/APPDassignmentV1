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

            
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {

            foreach (user user in ((PageSwitcher)this.Parent).Data.users)
            {
                if((emailInput.Text == user.email)&&(passwordInput.Password == user.password))
                {
                    Switcher.Switch(new ChooseCategory(user.email));
                }
                else
                {
                    MessageBox.Show("test");
                    break;
                }
            }
            
        }

        private void createAccount_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
            Switcher.Switch(new ChooseCategory());
        }

        
    }
}
