using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace profiwowdektop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        public string Url = "http://profi-wow-api.sebrogala.com/";

        public IList<CItem> ListCItems;
        public IList<CComponents> ListCComponentses;

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
            var itemsstring = connector.GetRespGet("/item/" + itemName, "Authorization: Bearer " + AbstractApiConnector.userBearer);

            try
            {
                CItem item = JsonConvert.DeserializeObject<CItem>(itemsstring);

                ListCItems = new List<CItem>();
                ListCComponentses = new List<CComponents>();

                ListCItems.Add(item);

                foreach (CItem itemItem in ListCItems)
                {
                    AddItemToPanel(true, itemItem.name, itemItem.icon_src,
                        "", "");
                }

                foreach (var component in item.components)
                {
                    ListCComponentses.Add(component);
                }

                ItemName.Content = item.name;
                ItemImage.Source = new BitmapImage(new Uri("http://" + item.icon_src));
                ItemPrice.Content = " ";

                foreach (CComponents itemComponent in ListCComponentses)
                {
                    AddItemToPanel(false, itemComponent.name, itemComponent.icon_src,
                        itemComponent.price_each.ah_price.ToString(), itemComponent.price_each.user_price.ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("nie mozna odnalezc przedmiotu");
            }
        }



        private void AddItemToPanel(bool Top, string name, string icon_src, string priceAH, string priceUSER)
        {
            var StackPanelBottomDyn = new StackPanel();
            StackPanelBottomDyn.Width = 160;
            StackPanelBottomDyn.Height = 171;
            StackPanelBottomDyn.Orientation = Orientation.Vertical;
            StackPanelBottomDyn.VerticalAlignment = VerticalAlignment.Top;
            StackPanelBottomDyn.HorizontalAlignment = HorizontalAlignment.Left;


            StackPanelBottomDyn.Background = Brushes.NavajoWhite;

            //tools in panel
            //label
            StackPanelBottomDyn.Children.Add(new Label { Content = name });

            //image
            StackPanelBottomDyn.Children.Add(new Image
            {
                Source = new BitmapImage(new Uri("http://" + icon_src)),
                Stretch = Stretch.Fill,
                Width = 56,
                Height = 56
            });

            //price - textbox
            StackPanelBottomDyn.Children.Add(new Label { Content = "AH price" });
            StackPanelBottomDyn.Children.Add(new TextBox
            {
                Text = priceAH
            });
            StackPanelBottomDyn.Children.Add(new Label { Content = "USER price" });
            StackPanelBottomDyn.Children.Add(new TextBox
            {
                Text = priceUSER
            });


            if (Top) //if true add item to top panel
            {
                StackPanelTop.Children.Add(StackPanelBottomDyn);
            }
            else //ifa false add item to bottom panel
            {
                StackPanelBottom.Children.Add(StackPanelBottomDyn);
            }
        }




    }
}
