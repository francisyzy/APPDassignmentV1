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
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;
using APPDassignmentV1.House;
using System.IO;

namespace APPDassignmentV1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<Resource> resourceList;

            using(StreamReader file = File.OpenText(@"ResourceData.txt"))
            {
                using(JsonTextReader reader = new JsonTextReader(file))
                {
                    var data = JToken.ReadFrom(reader).ToObject<List<object>>();

                    MessageBox.Show("123");//debug

                    Recomended.Text = data.ToString();//debug
                }
            }
        }


    }
}
