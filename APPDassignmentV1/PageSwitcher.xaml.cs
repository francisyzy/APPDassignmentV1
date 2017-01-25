using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using APPDassignmentV1;
using APPDassignmentV1.Screens;
using APPDassignmentV1.Models;


namespace APPDassignmentV1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PageSwitcher : Window
    {
        public APPD_Assignment_V2Context data = new APPD_Assignment_V2Context();
        //public ResourceData Data { get; set; }
        public PageSwitcher()
        {
            InitializeComponent();

            shoppingCart.initializeShoppingCart();//loads shopping cart
            Switcher.pageSwitcher = this;
            Switcher.Switch(new loginPage());//goes to login page (first page) 
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        public void Navigate(UserControl nextPage, object state)
        {
            this.Content = nextPage;
            ISwitchable s = nextPage as ISwitchable;

            if (s != null)
                s.UtilizeState(state);
            else
                throw new ArgumentException("NextPage is not ISwitchable! "
                  + nextPage.Name.ToString());
        }

        
    }
}
