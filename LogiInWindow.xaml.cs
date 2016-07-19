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
        public ApiConnector connector;
        

        public LogiInWindow(ApiConnector connector)
        {
            InitializeComponent();
            this.connector = connector;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            email = tbxLogin.Text.ToString();
            password = tbxPassword.Text.ToString();

            CUser user = new CUser(email, password);
            connector.userBearer = connector.GetResp("/user/login", "POST", (connector.Login(user)));

            this.Close();
        }
    }
}
