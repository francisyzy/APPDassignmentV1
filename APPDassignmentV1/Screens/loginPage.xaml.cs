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
using Firebase.Auth;
using Firebase.Database;

namespace APPDassignmentV1.Screens
{
    /// <summary>
    /// Interaction logic for loginPage.xaml
    /// </summary>
    public partial class loginPage : UserControl, ISwitchable
    {
        private const string BASE_PATH = "https://appd-assignmentv2.firebaseio.com";
        private const string API_KEY = " AIzaSyDkxUrEOTFiAorYh810vKSeO-FC_u_zd8I";

        
        public loginPage()
        {
            InitializeComponent();
        }
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }


        private async void login_Click(object sender, RoutedEventArgs e)//check login credentials
        {

            var provider = new FirebaseAuthProvider(new FirebaseConfig(API_KEY));
            FirebaseClient database;
            FirebaseAuthLink auth;
            try
            {

                auth = await provider.SignInWithEmailAndPasswordAsync(emailInput.Text,
                   passwordInput.Password);
                database = new FirebaseClient(BASE_PATH, new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(auth.FirebaseToken)
                });
                //Store the user id and token inside a Static class.
                //So that other supporting C# code in other classes can retrive them
                //for Firebase data operations.
                ApplicationConfiguration.UserId = emailInput.Text;
                ApplicationConfiguration.UserFirebaseToken = auth.FirebaseToken;
                /* For testing only */
                /*
                for (int count = 3; count <= 6; count++)
                {
                        var venues = await database
                                        .Child("venues")
                                            .PostAsync(new Venue { VenueId = count, VenueTitle = "VENUE " + count });
                }
                */
                Switcher.Switch(new ChooseCategory());
                //MessageBox.Show("abc");
            }
            catch (FirebaseAuthException ex)
            {
                MessageBox.Show("User Id or Password is incorrect. Please try again.");
            }
        }

        private void createAccount_Click(object sender, RoutedEventArgs e)//Brings to create account page
        {

            Switcher.Switch(new CreateAccount());
        }

        private void themeList_SelectionChanged(object sender, SelectionChangedEventArgs e)//themes for user to select
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
