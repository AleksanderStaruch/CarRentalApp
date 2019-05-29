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
        public UserWindow(string text, User user)
        {
            InitializeComponent();
            Text.Content = text;
            this.user = user;
            SetComboBox();
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


        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (ConPass.Password.ToString() == Pass.Password.ToString())
            {
                user.Login = Login.Text;
                user.Pass = Pass.Password.ToString();
                user.UserStatus_Id = GetUserStatusId();
                DB db = new DB();
                db.AddUser(user);
                
                Close();
            }
            else
            {
                MessageBox.Show("Password != ConfirmPassword", "Error", MessageBoxButton.OK);
            }
        }







    }
}
