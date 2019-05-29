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
    /// Interaction logic for RentWindow.xaml
    /// </summary>
    public partial class RentWindow : Window
    {
        Rent rent;
        public RentWindow(string text, Rent rent)
        {
            InitializeComponent();
            Text.Content = text;
            this.rent = rent;
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
