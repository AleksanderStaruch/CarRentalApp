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
    /// Interaction logic for ReturnWindow.xaml
    /// </summary>
    public partial class ReturnWindow : Window
    {
        Rent rent;
        int payment=0;
        public ReturnWindow(Rent rent)
        {
            InitializeComponent();
            this.rent = rent;

            client.Content=rent.Client;
            vehicle.Content =rent.Vehicle;
            int r;
            if (rent.DateOfReturn!=null)
            {
                r = (rent.DateOfReturn - rent.DateOfRental).Value.Days;
                Pay.IsEnabled = false;
            }
            else
            {
                r = (DateTime.Today - rent.DateOfRental).Days;
            }
            
            payment = (r + 1) * rent.Vehicle.PriceByDay;
            cost.Content = payment;
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Client must pay " + payment, "Pay", MessageBoxButton.OKCancel)==MessageBoxResult.OK)
            {
                DB db = new DB();
                rent.DateOfReturn=DateTime.Today;
                db.EditRent(rent);
                
                var v = db.GetVehicles().Where(s => s.Vid == rent.Vehicle.Vid).Single();
                v.IfRent = "nie";
                db.EditVehicle(v);

                Close();
            }
        }

    }
}
