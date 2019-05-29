using APBDProject.DAL;
using APBDProject.Model;
using APBDProject.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace APBDProject
{
    public partial class MainWindow : Window
    {
        //ObservableCollection<?> list;
        string what = "";
        Dictionary<string, int> hash = new Dictionary<string, int>();
        public MainWindow(string login)
        {
            InitializeComponent();
            Welcome.Content = "Welcome "+login;
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            var user = new User();
            var adduser = new UserWindow("Register",user);
            adduser.ShowDialog();
        }

        private void AddVehicle_Click(object sender, RoutedEventArgs e)
        {
            var vehicle = new Vehicle();
            var adduser = new VehicleWindow("Add new vehicle",vehicle);
            adduser.ShowDialog();
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            var client = new Client();
            var adduser = new ClientWindow("Add new client",client);
            adduser.ShowDialog();
        }

        private void AddRent_Click(object sender, RoutedEventArgs e)
        {
            var rent = new Rent();
            var adduser = new RentWindow("Create new rent",rent);
            adduser.ShowDialog();
        }

        private void UserList_Click(object sender, RoutedEventArgs e)
        {
            what = "users";
            ListName.Content = "List of " + what;
            SetDataGrid();
        }

        private void VehicleList_Click(object sender, RoutedEventArgs e)
        {
            what = "vehicles";
            ListName.Content = "List of " + what;
            SetDataGrid();
        }

        private void ClientList_Click(object sender, RoutedEventArgs e)
        {
            what = "clients";
            ListName.Content = "List of " + what;
            SetDataGrid();
        }

        private void RentList_Click(object sender, RoutedEventArgs e)
        {
            what = "rents";
            ListName.Content = "List of " + what;
            SetDataGrid();

        }

        private void SetDataGrid()
        {
            switch (what)
            {
                case "users":
                    var l1 = new DB().GetUsers();
                    var resoult1 = from s in l1 select s;

                    DataGrid.ItemsSource = new ObservableCollection<User>(resoult1.ToList());
                    break;
                case "vehicles":
                    var l2 = new DB().GetVehicles();
                    var resoult2 = from s in l2 select s;

                    DataGrid.ItemsSource = new ObservableCollection<Vehicle>(resoult2.ToList());
                    break;
                case "clients":
                    var l3 = new DB().GetClients();
                    var resoult3 = from s in l3 select s;

                    DataGrid.ItemsSource = new ObservableCollection<Client>(resoult3.ToList());
                    break;
                case "rents":
                    var l4 = new DB().GetRents();
                    var resoult4 = from s in l4 select s;

                    DataGrid.ItemsSource = new ObservableCollection<Rent>(resoult4.ToList());
                    break;
                default:

                    break;
            }
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            switch (what)
            {
                case "users":
                    var tmp1 = (User)DataGrid.SelectedItem;
                    var window1 = new UserWindow("Edit",tmp1);
                    window1.ShowDialog();
                    break;
                case "vehicles":
                    var tmp2 = (Vehicle)DataGrid.SelectedItem;
                    var window2 = new VehicleWindow("Edit", tmp2);
                    window2.ShowDialog();
                    break;
                case "clients":
                    var tmp3 = (Client)DataGrid.SelectedItem;
                    var window3 = new ClientWindow("Edit", tmp3);
                    window3.ShowDialog();
                    break;
                case "rents":
                    var tmp4 = (Rent)DataGrid.SelectedItem;
                    var window4 = new RentWindow("Edit", tmp4);
                    window4.ShowDialog();
                    break;
            }
            SetDataGrid();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int n = DataGrid.SelectedItems.Count;
            Count.Content = "You choose " + n + " what";
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
