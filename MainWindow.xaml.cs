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
        }

        private void ButtonLogIn_Click(object sender, RoutedEventArgs e)
        {
            LogiInWindow loginWindow = new LogiInWindow();
            loginWindow.Show();

            //if(loginWindow.Closed)
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
