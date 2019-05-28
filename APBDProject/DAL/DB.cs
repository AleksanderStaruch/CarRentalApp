using APBDProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace APBDProject.DAL
{
    class DB
    {
        CarRentalDb carRental;
        public DB()
        {
            carRental = new CarRentalDb();
        }

        public bool CheckUserData(string login, string Pass)
        {
            var r = carRental.User.Where(u => u.Login == login && u.Pass == Pass).Count();
            MessageBox.Show(r+"");
            if (r == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<string> GetUserStatuses()
        {
            var r = carRental.UserStatus.Select(s => s.Status).ToList();

            return r;
        }

        public void AddUser()
        {

        }




    }
}
