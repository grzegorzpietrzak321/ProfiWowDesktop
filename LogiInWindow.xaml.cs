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
using System.Windows.Shapes;

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

            this.Close();
        }
    }
}
