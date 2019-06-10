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
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        User user;
        string text;
        public UserWindow(string text, User user)
        {
            InitializeComponent();
            Text.Content = text;
            this.user = user;
            this.text = text;
            SetComboBox();

            if (text == "Edit")
            {
                Login.Text=user.Login;
                ComboBox.Text = GetUserStstusName(user.UserStatus_Id);

                Login.IsEnabled = false;
                ComboBox.IsEnabled = false;
            }

        }

        private void SetComboBox()
        {
            var list = new DB().GetUserStatuses();
            ComboBox.Items.Clear();
            foreach (UserStatus s in list)
            {
                ComboBox.Items.Add(s.Status);
            }
            ComboBox.SelectedItem = list[0].Status;
        }

        private int GetUserStatusId()
        {
            var list = new DB().GetUserStatuses();

            var id = (from s in list
                      where s.Status == ComboBox.Text
                      select s.USid).Max();


            return Convert.ToInt32(id);
        }

        private string GetUserStstusName(int n)
        {
            var list = new DB().GetUserStatuses();

            var r = (from s in list
                     where s.USid == n
                     select s.Status).First();

            return r;
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (ConPass.Password.ToString() == Pass.Password.ToString())
            {
                user.Login = Login.Text;
                user.Pass = Pass.Password.ToString();
                user.UserStatus_Id = GetUserStatusId();
                DB db = new DB();
                if(text == "Edit")
                {
                    db.EditUser(user);
                }
                else
                {
                    db.AddUser(user);
                }
                
                
                Close();
            }
            else
            {
                MessageBox.Show("Password != ConfirmPassword", "Error", MessageBoxButton.OK);
            }
        }

    }
}
