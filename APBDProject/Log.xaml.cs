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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace APBDProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            var l = Login.Text;
            var p = Pass.Password;

            DB db = new DB();
            if (db.CheckUserData(l, p))
            {
                MainWindow window = new MainWindow(l,p);
                window.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Bad login or password", "Error", MessageBoxButton.OK);
            }









        }
    }
}
