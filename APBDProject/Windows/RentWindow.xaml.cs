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
        User user;
        public RentWindow(string text, Rent rent,User user)
        {
            InitializeComponent();
            Text.Content = text;
            this.rent = rent;
            this.user = user;
            
            SetComboBox1();
            SetComboBox2();
        }

        private void SetComboBox1()
        {
            var list = new DB().GetClients();
            ComboBox1.Items.Clear();
            foreach (Client s in list)
            {
                ComboBox1.Items.Add(s);
            }
        }

        private int GetClientId()
        {
            var list = new DB().GetClients();

            var id = (from s in list
                      where s.ToString() == ComboBox1.Text
                      select s.Cid).Max();


            return Convert.ToInt32(id);
        }

        //private string GetClient(int n)
        //{
        //    var list = new DB().GetClients();

        //    var r = (from s in list
        //             where s.Tid == n
        //             select s).First();

        //    return r;
        //}

        private void SetComboBox2()
        {
            var list = new DB().GetVehicles();
            ComboBox2.Items.Clear();
            foreach (Vehicle s in list)
            {
                if(s.IfRent == "nie")
                {
                    ComboBox2.Items.Add(s);
                }
                
            }
        }

        private int GetVehicleId()
        {
            var list = new DB().GetVehicles();

            var id = (from s in list
                      where s.ToString() == ComboBox2.Text
                      select s.Vid).Max();

            return Convert.ToInt32(id);
        }

        //private string GetVehicle(int n)
        //{
        //    var list = new DB().GetVehicles();

        //    var r = (from s in list
        //             where s.Fid == n
        //             select s).First();

        //    return r;
        //}


        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            rent.User_Id=user.Uid;
            rent.Vehicle_Id=GetVehicleId();
            rent.Client_Id=GetClientId();
            rent.DateOfRental = DateTime.Now;

            DB db = new DB();
            db.AddRent(rent);

            var v=db.GetVehicles().Where(s => s.Vid == GetVehicleId()).Single();
            v.IfRent = "tak";
            db.EditVehicle(v);
            


            Close();
        }
    }
}
