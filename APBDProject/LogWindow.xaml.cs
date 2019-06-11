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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace APBDProject
{
    public partial class LogWindow : Window
    {
        public LogWindow()
        {
            InitializeComponent();
        }

        private User GetUser(string login)
        {
            var list = new DB().GetUsers();

            var r = (from s in list
                     where s.Login == login
                     select s).First();

            return r;
        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            var l = Login.Text;
            var p = Pass.Password.ToString();
 
            DB db = new DB();
            if (db.CheckUserData(l,p))
            {
                MainWindow window = new MainWindow(GetUser(l));
                window.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Bad login or password", "Error", MessageBoxButton.OK);
            }
        }

        private void Log_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                var l = Login.Text;
                var p = Pass.Password.ToString();

                DB db = new DB();
                if (db.CheckUserData(l, p))
                {
                    MainWindow window = new MainWindow(GetUser(l));
                    window.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Bad login or password", "Error", MessageBoxButton.OK);
                }
            }

            if (e.Key == Key.Down)
            {
                MessageBox.Show("AAAAA");
                Pass.Focus();
            }

        }

    }
}
