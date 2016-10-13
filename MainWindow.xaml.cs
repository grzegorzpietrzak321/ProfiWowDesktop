using System.Windows;

namespace profiwowdektop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        public string Url = "http://profi-wow-api.sebrogala.com/";

        public MainWindow()
        {
            InitializeComponent();
            //test
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            LogiInWindow loginWindow = new LogiInWindow();
            loginWindow.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text = AbstractApiConnector.userBearer;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            AbstractApiConnector connector = new UserApiConnector();
            connector.GetRespGet("/professions", "Authorization: Bearer " + AbstractApiConnector.userBearer);
        }
    }
}
