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
        public string Email;
        public string Password;
        public UserApiConnector Connector;
        

        public LogiInWindow()
        {
            InitializeComponent();
            this.Connector = new UserApiConnector();
        }
         
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Email = TbxLogin.Text;
            Password = TbxPassword.Text;

            CUser user = new CUser(Email, Password);
            AbstractApiConnector.UserBearer = Connector.Login("/user/login", user);
            AbstractApiConnector.UserBearer = AbstractApiConnector.UserBearer.Substring(1, AbstractApiConnector.UserBearer.Length - 2);
            this.Close();
        }
    }
}
