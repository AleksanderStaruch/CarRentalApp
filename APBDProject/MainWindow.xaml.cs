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
            var add = new UserWindow("Register",user);
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
            var add = new RentWindow("Create new rent",rent);
            add.ShowDialog();
        }


        //show list, "ilośc zaznaczonych wierszy"
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

        //user change password
        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            var window = new UserWindow("Edit", me);
            window.ShowDialog();
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
            //for (int i = DataGrid.SelectedItems.Count - 1; -1 < i; i = DataGrid.SelectedItems.Count - 1)
            //{

            //    Student tmp = (Student)DataGrid.SelectedItems[i];

            //    new DB().DeleteStudent_Subject(tmp.IdStudent);
            //    new DB().DeleteStudent(tmp);
            //}

            switch (what)
            {
                case "users":

                    break;
                case "vehicles":
                    
                    break;
                case "clients":
                    
                    break;
                case "rents":
                    
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
        }
        private void Vehicles_DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var tmp = (Vehicle)Vehicles_DataGrid.SelectedItem;
            var window = new VehicleWindow("Edit", tmp);
            window.ShowDialog();
        }
        private void Rents_DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var tmp = (Rent)Rents_DataGrid.SelectedItems;
            var window = new RentWindow("edit", tmp);
            window.ShowDialog();
        }
        
        
    }
}
