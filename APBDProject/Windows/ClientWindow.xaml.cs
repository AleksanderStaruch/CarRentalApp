using APBDProject.DAL;
using APBDProject.Model;
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

namespace APBDProject.Windows
{
    /// <summary>
    /// Interaction logic for ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        Client client;
        public ClientWindow( string text, Client client)
        {
            InitializeComponent();
            Text.Content = text;
            this.client = client;
        }

        private bool Check()
        {
            int i = 0;
            if (String.IsNullOrWhiteSpace(Text1.Text))
            {
                i++;
                Text1.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                Text1.BorderBrush = new SolidColorBrush(Colors.Black);
            }

            if (String.IsNullOrWhiteSpace(Text2.Text))
            {
                i++;
                Text2.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                Text2.BorderBrush = new SolidColorBrush(Colors.Black);
            }

            if (Text3.Text.Length == 11 && Int32.TryParse(Text3.Text, out int a))
            {
                Text3.BorderBrush = new SolidColorBrush(Colors.Black);
            }
            else
            {
                i++;
                Text3.BorderBrush = new SolidColorBrush(Colors.Red);
            }

            if (Text4.Text.Length == 9 && Int32.TryParse(Text4.Text, out int b))
            {
                Text4.BorderBrush = new SolidColorBrush(Colors.Black);
            }
            else
            {
                i++;
                Text4.BorderBrush = new SolidColorBrush(Colors.Red);
            }

            if (String.IsNullOrWhiteSpace(Text5.Text))
            {
                i++;
                Text5.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                Text5.BorderBrush = new SolidColorBrush(Colors.Black);
            }


            if (i == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (Check())
            {
                Int32.TryParse(Text3.Text, out int n1);
                Int32.TryParse(Text4.Text, out int n2);
                client.FirstName = Text1.Text;
                client.LastName = Text2.Text;
                client.PESEL = n1;
                client.PhoneNumber = n2;
                client.Address = Text5.Text;

                DB db = new DB();
                db.AddClient(client);

                Close();
            }
        }
    }
}
