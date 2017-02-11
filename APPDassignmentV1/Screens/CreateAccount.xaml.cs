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
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : UserControl
    {
        private const string BASE_PATH = "https://appd-assignmentv2.firebaseio.com";
        private const string API_KEY = " AIzaSyDkxUrEOTFiAorYh810vKSeO-FC_u_zd8I";
        
        public CreateAccount()
        {
            InitializeComponent();
        }

        private async void createBtn_Click(object sender, RoutedEventArgs e)
        {
            var provider = new FirebaseAuthProvider(new FirebaseConfig(API_KEY));
            //FirebaseClient database;
            if (passwordInput.Password == confirmPasswordInput.Password)
            {
                try
                {
                    var su = await provider.CreateUserWithEmailAndPasswordAsync(emailInput.Text, passwordInput.Password);
                    MessageBox.Show("Successful Created");
                    Switcher.Switch(new loginPage());
                }
                catch(Exception a)
                {
                    
                    MessageBox.Show("Create account failed");
                }


                   
                
               
            }
            else
                MessageBox.Show("Passwords do not match! \n Please check passwords");

            //Switcher.Switch(new ChooseCategory());
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new loginPage());
        }
    }
}
