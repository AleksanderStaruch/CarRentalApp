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
using Type = APBDProject.Model.Type;

namespace APBDProject.Windows
{
    /// <summary>
    /// Interaction logic for VehicleWindow.xaml
    /// </summary>
    public partial class VehicleWindow : Window
    {

        Vehicle vehicle;
        string text;
        public VehicleWindow(string text, Vehicle vehicle)
        {
            InitializeComponent();

            Text.Content = text;
            this.vehicle = vehicle;
            this.text = text;

            SetComboBox1();
            SetComboBox2();

            if (text == "Edit")
            {
                Text1.Text=vehicle.VIN;
                ComboBox1.Text=GetTypeName(vehicle.Type_Id);
                Text2.Text=vehicle.Brand;
                Text3.Text=vehicle.Model;
                Text4.Text=vehicle.Color;
                Text5.Text = vehicle.MakeYear+"";
                ComboBox2.Text= GetFeulTypeName(vehicle.FeulType_Id);
                Text6.Text = vehicle.PriceByDay + "";
                Text7.Text = vehicle.Mileage + "";
            }
        }

        private bool Check()
        {
            int i = 0;
            if (Text1.Text.Length != 17)
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

            if (String.IsNullOrWhiteSpace(Text3.Text))
            {
                i++;
                Text3.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                Text3.BorderBrush = new SolidColorBrush(Colors.Black);
            }

            if (String.IsNullOrWhiteSpace(Text4.Text))
            {
                i++;
                Text4.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                Text4.BorderBrush = new SolidColorBrush(Colors.Black);
            }


            if (Text5.Text.Length != 4 && Int32.TryParse(Text5.Text, out int n))
            {
                i++;
                Text5.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                Text5.BorderBrush = new SolidColorBrush(Colors.Black);
            }

            if (!Int32.TryParse(Text6.Text, out int a))
            {
                i++;
                Text6.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                Text6.BorderBrush = new SolidColorBrush(Colors.Black);
            }

            if (!Int32.TryParse(Text7.Text, out int b))
            {
                i++;
                Text7.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                Text7.BorderBrush = new SolidColorBrush(Colors.Black);
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

        private void SetComboBox1()
        {
            var list = new DB().GetTypes();
            ComboBox1.Items.Clear();
            foreach (Type s in list)
            {
                ComboBox1.Items.Add(s.Name);
            }
            ComboBox1.SelectedItem = list[0].Name;
        }

        private int GetTypeId()
        {
            var list = new DB().GetTypes();

            var id = (from s in list
                      where s.Name == ComboBox1.Text
                      select s.Tid).Max();


            return Convert.ToInt32(id);
        }

        private string GetTypeName(int n)
        {
            var list = new DB().GetTypes();

            var r = (from s in list
                     where s.Tid == n
                     select s.Name).First();

            return r;
        }

        private void SetComboBox2()
        {
            var list = new DB().GetFeulTypes();
            ComboBox2.Items.Clear();
            foreach (FeulType s in list)
            {
                ComboBox2.Items.Add(s.Feul);
            }
            ComboBox2.SelectedItem = list[0].Feul;
        }

        private int GetFeulTypesId()
        {
            var list = new DB().GetFeulTypes();

            var id = (from s in list
                      where s.Feul == ComboBox2.Text
                      select s.Fid).Max();

            return Convert.ToInt32(id);
        }

        private string GetFeulTypeName(int n)
        {
            var list = new DB().GetFeulTypes();

            var r = (from s in list
                     where s.Fid == n
                     select s.Feul).First();

            return r;
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (Check())
            {
                Int64.TryParse(Text5.Text, out var n1);
                Int64.TryParse(Text6.Text, out var n2);
                Int64.TryParse(Text7.Text, out var n3);

                vehicle.VIN=Text1.Text;
                vehicle.Type_Id = GetTypeId();
                vehicle.Brand = Text2.Text;
                vehicle.Model = Text3.Text;
                vehicle.Color = Text4.Text;
                vehicle.MakeYear = (int)n1;
                vehicle.FeulType_Id = GetFeulTypesId();
                vehicle.PriceByDay = (int)n2;
                vehicle.Mileage = (int)n3;
                

                DB db = new DB();
                if (text == "Edit")
                {
                    db.EditVehicle(vehicle);
                }
                else
                {
                    vehicle.IfRent="nie";
                    db.AddVehicle(vehicle);
                }
                
                Close();
            }
        }

    }
}
