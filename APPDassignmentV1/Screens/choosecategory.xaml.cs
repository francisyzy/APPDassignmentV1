﻿using APPDassignmentV1;
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
using Microsoft.EntityFrameworkCore;


namespace APPDassignmentV1.Screens
{
    /// <summary>
    /// Interaction logic for ChooseCategory.xaml
    /// </summary>
    public partial class ChooseCategory : UserControl, ISwitchable
    {
        public string regionSelected;
        public string _email = "";
        private APPD_Assignment_V2Context data = new APPD_Assignment_V2Context();
        public ChooseCategory()
        {
            InitializeComponent();
        }

        public ChooseCategory(string email)
        {
            this._email = email;
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // read JSON directly from a file
            //using (StreamReader file = File.OpenText(@"ResourceData.JSON"))
            //{
            //    using (JsonTextReader reader = new JsonTextReader(file))
            //    {
            //        ((PageSwitcher)this.Parent).Data = JToken.ReadFrom(reader).ToObject<ResourceData>();
            //    }
            //}//end of 1st using block, file
            //Json loader moved to login page since login page is the first page to be loaded that requires json data
            Button button;
            
            foreach (ResourceType resourceTypes in (data.ResourceType.ToList()))//generate buttons based on json file
            {
                button = new Button()
                {
                    Content = string.Format("{0}", resourceTypes.ResourceTypeName),//generate button content based on resourceTypeName data
                    Tag = resourceTypes.ResourceTypeId,
                    Height = 35,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                button.Click += new RoutedEventHandler(chooseResourceTypeButton_Click);
                this.resourceTypeUniformGrid.Children.Add(button);
            }

        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // ... Assign the ItemsSource to the List.
            foreach (Region region in (data.Region.ToList()))
            {

                regionList.Items.Add(region.RegionName);
            }
            // ... Make the first item selected.
            regionList.SelectedIndex = 0;

        }
        

        private void regionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBox = sender as ComboBox;

            // ... Set SelectedItem as Window Title.
            string value = comboBox.SelectedItem as string;
            this.regionSelected = value;
            
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void chooseResourceTypeButton_Click(object sender, RoutedEventArgs e)//goes into new page
        {
            Button button = (Button)sender;
            //Switcher.Switch(new ChooseResource((((Button)sender).Tag.ToString()),this.regionSelected));
        }

        private void goto_shoppingCartScreenButton_Click(object sender, RoutedEventArgs e)
        {
            //Switcher.Switch(new ShoppingCartScreen());
        }

        //private void themeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    // ... Get the ComboBox.
        //    var comboBox = sender as ComboBox;

        //    // ... Set SelectedItem as Window Title.
        //    string value = comboBox.SelectedItem as string;

        //    var app = (App)Application.Current;
        //    switch (value)
        //    {
        //        case "ExpressionDark":
        //            app.ChangeTheme(new Uri(@"Themes/ExpressionDark.xaml"));
        //            break;
        //        case "ExpressionLight":
        //            app.ChangeTheme(new Uri(@"Themes/ExpressionLight.xaml"));
        //            break;
        //        case "BureauBlack":
        //            app.ChangeTheme(new Uri(@"Themes/BureauBlack.xaml"));
        //            break;
        //        case "BureauBlue":
        //            app.ChangeTheme(new Uri(@"Themes/BureauBlue.xaml"));
        //            break;
        //        case "ShinyBlue":
        //            app.ChangeTheme(new Uri(@"Themes/ShinyBlue.xaml"));
        //            break;
        //        case "ShinyRed":
        //            app.ChangeTheme(new Uri(@"Themes/ShinyRed.xaml"));
        //            break;
        //        case "WhistlerBlue":
        //            app.ChangeTheme(new Uri(@"Themes/WhistlerBlue.xaml"));
        //            break;
        //        default:
        //            break;

        //    }
        //}

        //private void theme_Loaded(object sender, RoutedEventArgs e)
        //{
        //    // ... Get the ComboBox reference.
        //    var comboBox = sender as ComboBox;

        //    // ... Assign the ItemsSource to the List.
        //    themeList.Items.Add("ExpressionDark");
        //    themeList.Items.Add("ExpressionLight");
        //    themeList.Items.Add("BureauBlack");
        //    themeList.Items.Add("BureauBlue");
        //    themeList.Items.Add("ShinyBlue");
        //    themeList.Items.Add("ShinyRed");
        //    themeList.Items.Add("WhistlerBlue");

        //    // ... Make the first item selected.
        //    themeList.SelectedIndex = 0;

        //}

        //theme changing code moved to login page
    }
}
    