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
        private Boolean pass = false;
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
            }//end of 1st using block, 
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            
            foreach (user user in ((PageSwitcher)this.Parent).Data.users)
            {
                if ((emailInput.Text == user.email) && (passwordInput.Password == user.password))
                {
                    currentUser c = new currentUser();
                    c.setcurrentUser(user);
                    pass = true;
                    break;
                }
            }

            if (pass)
            {
                Switcher.Switch(new ChooseCategory());
            }
            else
                MessageBox.Show("wrong email or password");
        }

        private void createAccount_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
            Switcher.Switch(new ChooseCategory());
        }

        private void themeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBox = sender as ComboBox;

            // ... Set SelectedItem as Window Title.
            string value = comboBox.SelectedItem as string;

            var app = (App)Application.Current;
            switch (value)
            {

                case "ExpressionLight":
                    app.ChangeTheme(new Uri(@"/Themes/ExpressionLight.xaml",UriKind.Relative));
                    break;
                case "BureauBlack":
                    app.ChangeTheme(new Uri(@"/Themes/BureauBlack.xaml", UriKind.Relative));
                    break;
                case "BureauBlue":
                    app.ChangeTheme(new Uri(@"/Themes/BureauBlue.xaml", UriKind.Relative));
                    break;

                case "WhistlerBlue":
                    app.ChangeTheme(new Uri(@"/Themes/WhistlerBlue.xaml", UriKind.Relative));
                    break;
                default:
                    break;

            }
        }

        private void theme_Loaded(object sender, RoutedEventArgs e)
        {
            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // ... Assign the ItemsSource to the List.
            
            themeList.Items.Add("ExpressionLight");
            themeList.Items.Add("BureauBlack");
            themeList.Items.Add("BureauBlue");
            
            themeList.Items.Add("WhistlerBlue");

            // ... Make the first item selected.
            themeList.SelectedIndex = 0;

        }
    }
}
