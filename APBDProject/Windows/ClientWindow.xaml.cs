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
        string text;
        public ClientWindow( string text, Client client)
        {
            InitializeComponent();
            Text.Content = text;
            this.client = client;
            this.text = text;
            if (text == "Edit")
            {
                Text1.Text=client.FirstName;
                Text2.Text=client.LastName;
                Text3.Text=client.PESEL;
                Text4.Text=client.PhoneNumber;
                Text5.Text=client.Address;
            }
            
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

            if (Text3.Text.Length == 11 && Int64.TryParse(Text3.Text, out var a))
            {
                Text3.BorderBrush = new SolidColorBrush(Colors.Black);
            }
            else
            {
                i++;
                Text3.BorderBrush = new SolidColorBrush(Colors.Red);
            }

            if (Text4.Text.Length == 9 && Int64.TryParse(Text4.Text, out var b))
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
                client.FirstName = Text1.Text;
                client.LastName = Text2.Text;
                client.PESEL = Text3.Text;
                client.PhoneNumber = Text4.Text;
                client.Address = Text5.Text;

                DB db = new DB();
                if(text == "Edit")
                {
                    db.EditClient(client);
                }
                else
                {
                    db.AddClient(client);
                }
                

                Close();
            }
        }
    }
}
