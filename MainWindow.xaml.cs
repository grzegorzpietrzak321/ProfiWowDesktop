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

namespace profiwowdektop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string url = "http://profi-wow-api.sebrogala.com/";
        
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            LogiInWindow loginWindow = new LogiInWindow();
            loginWindow.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //textBox.Text = connector.userBearer;
            textBox.Text = AbstractApiConnector.userBearer;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //connector.GetRespGET("/professions", "Authorization: Bearer " + connector.userBearer);
        }
    }
}
