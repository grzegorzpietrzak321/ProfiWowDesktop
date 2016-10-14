using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

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

        private void ButtonShowJWTBearer_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text = AbstractApiConnector.userBearer;

        }

        private void ButtonGetProfessions_Click(object sender, RoutedEventArgs e)
        {
            AbstractApiConnector connector = new UserApiConnector();

            var profeskistring = connector.GetRespGet("/professions",
                "Authorization: Bearer " + AbstractApiConnector.userBearer);

            IEnumerable<CProfession> professions =
                JsonConvert.DeserializeObject<IEnumerable<CProfession>>(profeskistring);

            foreach (CProfession item in (IList)professions)
            {
                ComboBoxProfessions.Items.Add(item.name);
            }


        }

        private void BtnSearchItem_Click(object sender, RoutedEventArgs e)
        {
            AbstractApiConnector connector = new UserApiConnector();

            string itemName = TxBoxSearchItem.Text;
            itemName = itemName.Replace(' ', '_');
            var items = connector.GetRespGet("/item/" + itemName, "Authorization: Bearer " + AbstractApiConnector.userBearer);



            try
            {
                CItem item = JsonConvert.DeserializeObject<CItem>(items);



                ItemImage.Source = new BitmapImage(new Uri("http://" + item.icon_src));



            }
            catch (Exception ex)
            {
                MessageBox.Show("nie mozna odnalezc przedmiotu");

            }





        }
    }
}
