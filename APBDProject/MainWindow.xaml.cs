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
        string what = "";
        User me;
        public MainWindow(User me)
        {
            InitializeComponent();
            this.me = me;
            Welcome.Content = "Welcome "+me.Login;
        }


        //add new 
        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            var user = new User();
            var add = new UserWindow("Register",user,me);
            add.ShowDialog();

            what = "users";
            SetDataGrid();
        }
        private void AddVehicle_Click(object sender, RoutedEventArgs e)
        {
            var vehicle = new Vehicle();
            var add = new VehicleWindow("Add new vehicle",vehicle);
            add.ShowDialog();

            what = "vehicles";
            SetDataGrid();
        }
        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            var client = new Client();
            var add = new ClientWindow("Add new client",client);
            add.ShowDialog();

            what = "clients";
            SetDataGrid();
        }
        private void AddRent_Click(object sender, RoutedEventArgs e)
        {
            var rent = new Rent();
            var add = new RentWindow("Create new rent",rent,me);
            add.ShowDialog();

            what = "rents";
            SetDataGrid();
        }


        //show list, "ilośc zaznaczonych wierszy"
        private void UserList_Click(object sender, RoutedEventArgs e)
        {
            what = "users";
            ListName.Content = "List of " + what;
            Count.Content = "You choose 0 users";
            SetDataGrid();
        }
        private void VehicleList_Click(object sender, RoutedEventArgs e)
        {
            what = "vehicles";
            ListName.Content = "List of " + what;
            Count.Content = "You choose 0 vehicles";

            SetDataGrid();
        }
        private void ClientList_Click(object sender, RoutedEventArgs e)
        {
            what = "clients";
            ListName.Content = "List of " + what;
            Count.Content = "You choose 0 clientss";
            SetDataGrid();
        }
        private void RentList_Click(object sender, RoutedEventArgs e)
        {
            what = "rents";
            ListName.Content = "List of " + what;
            Count.Content = "You choose 0 rents";
            SetDataGrid();
        }


        //user change password
        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            var window = new UserWindow("Edit", me,me);
            window.ShowDialog();
        }


        //log out from app, change usser
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            var w = new LogWindow();
            Close();
            w.Show();
        }


        //ukrycie wszystkich datagridow
        private void SetDataGrid()
        {
            Users_DataGrid.Visibility = Visibility.Hidden;
            Vehicles_DataGrid.Visibility = Visibility.Hidden;
            Clients_DataGrid.Visibility = Visibility.Hidden;
            Rents_DataGrid.Visibility = Visibility.Hidden;

            switch (what)
            {
                case "users":
                    var l1 = new DB().GetUsers();
                    var resoult1 = from s in l1 select s;

                    Users_DataGrid.ItemsSource = new ObservableCollection<User>(resoult1.ToList());
                    Users_DataGrid.Visibility = Visibility.Visible;
                    break;
                case "vehicles":
                    var l2 = new DB().GetVehicles();
                    var resoult2 = from s in l2 select s;

                    Vehicles_DataGrid.ItemsSource = new ObservableCollection<Vehicle>(resoult2.ToList());
                    Vehicles_DataGrid.Visibility = Visibility.Visible;
                    break;
                case "clients":
                    var l3 = new DB().GetClients();
                    var resoult3 = from s in l3 select s;

                    Clients_DataGrid.ItemsSource = new ObservableCollection<Client>(resoult3.ToList());
                    Clients_DataGrid.Visibility = Visibility.Visible;
                    break;
                case "rents":
                    var l4 = new DB().GetRents();
                    var resoult4 = from s in l4 select s;

                    Rents_DataGrid.ItemsSource = new ObservableCollection<Rent>(resoult4.ToList());
                    Rents_DataGrid.Visibility = Visibility.Visible;
                    break;
            }
        }
        

        //usuwanie
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            switch (what)
            {
                case "users":
                    for (int i = Users_DataGrid.SelectedItems.Count - 1; -1 < i; i = Users_DataGrid.SelectedItems.Count - 1)
                    {
                        var tmp = (User)Users_DataGrid.SelectedItems[i];
                        new DB().DeleteUser(tmp);
                    }
                    break;
                case "vehicles":
                    for (int i = Vehicles_DataGrid.SelectedItems.Count - 1; -1 < i; i = Vehicles_DataGrid.SelectedItems.Count - 1)
                    {
                        var tmp = (Vehicle)Vehicles_DataGrid.SelectedItems[i];
                        new DB().DeleteVehicle(tmp);
                    }
                    break;
                case "clients":
                    for (int i = Clients_DataGrid.SelectedItems.Count - 1; -1 < i; i = Clients_DataGrid.SelectedItems.Count - 1)
                    {
                        var tmp = (Client)Clients_DataGrid.SelectedItems[i];
                        new DB().DeleteClient(tmp);
                    }
                    break;
                case "rents":
                    for (int i = Rents_DataGrid.SelectedItems.Count - 1; -1 < i; i = Rents_DataGrid.SelectedItems.Count - 1)
                    {
                        var tmp = (Rent)Rents_DataGrid.SelectedItems[i];
                        new DB().DeleteRent(tmp);
                    }
                    break;
            }
        }


        //count ile zaznoczonych wierszy
        private void Users_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int n = Users_DataGrid.SelectedItems.Count;
            Count.Content = "You choose " + n + " users";
        }
        private void Vehicles_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int n = Vehicles_DataGrid.SelectedItems.Count;
            Count.Content = "You choose " + n + " vehicles";
        }
        private void Clients_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int n = Clients_DataGrid.SelectedItems.Count;
            Count.Content = "You choose " + n + " clients";
        }
        private void Rents_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int n = Rents_DataGrid.SelectedItems.Count;
            Count.Content = "You choose " + n + " rents";
        }
        

        //double click edycja
        private void Clients_DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var tmp = (Client)Clients_DataGrid.SelectedItem;
            var window = new ClientWindow("Edit", tmp);
            window.ShowDialog();
            SetDataGrid();
        }
        private void Vehicles_DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var tmp = (Vehicle)Vehicles_DataGrid.SelectedItem;
            var window = new VehicleWindow("Edit", tmp);
            window.ShowDialog();
            SetDataGrid();
        }
        private void Rents_DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var tmp = (Rent)Rents_DataGrid.SelectedItem;
            var window = new ReturnWindow(tmp);
            window.ShowDialog();
            SetDataGrid();
        }

        
    }
}
