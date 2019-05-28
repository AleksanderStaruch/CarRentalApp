using APBDProject.DAL;
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
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow(string text)
        {
            InitializeComponent();
            Text.Content = text;
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (ConPass.Password == Pass.Password)
            {
                DB db = new DB();
                db.AddUser();


                Close();
            }
            else
            {
                MessageBox.Show("Password != ConfirmPassword", "Error", MessageBoxButton.OK);
            }
        }







    }
}
