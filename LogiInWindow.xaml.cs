using System.Windows;

namespace profiwowdektop
{
    /// <summary>
    /// Interaction logic for LogiInWindow.xaml
    /// </summary>
    public partial class LogiInWindow : Window
    {
        public string email;
        public string password;
        public UserApiConnector connector;


        public LogiInWindow()
        {
            InitializeComponent();
            this.connector = new UserApiConnector();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            email = tbxLogin.Text;
            password = tbxPassword.Text;

            CUser user = new CUser(email, password);
            AbstractApiConnector.userBearer = connector.Login("/user/login", user);
            AbstractApiConnector.userBearer = AbstractApiConnector.userBearer.Substring(1, AbstractApiConnector.userBearer.Length - 2);
            this.Close();
        }
    }
}
