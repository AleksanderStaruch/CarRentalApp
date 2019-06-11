using APBDProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Type = APBDProject.Model.Type;

namespace APBDProject.DAL
{
    class DB
    {
        CarRentalDb carRental;
        public DB()
        {
            carRental = new CarRentalDb();
        }

        public bool CheckUserData(string login, string pass)
        {
            return carRental.User.Where(u => u.Login.Equals(login) && u.Pass.Equals(pass)).Any();
        }

        //add
        public void AddUser(User user)
        {
            carRental.User.Add(user);

            carRental.SaveChanges();
        }
        public void AddVehicle(Vehicle vehicle)
        {
            carRental.Vehicle.Add(vehicle);

            carRental.SaveChanges();
        }
        public void AddClient(Client client)
        {
            carRental.Client.Add(client);

            carRental.SaveChanges();
        }
        public void AddRent(Rent rent)
        {
            carRental.Rent.Add(rent);

            carRental.SaveChanges();
        }

        //edit
        public void EditUser(User user)
        {
            var s = (from x in carRental.User
                         where x.Uid == user.Uid
                         select x).First();

            s.Uid=user.Uid;
            s.Login=user.Login;
            s.Pass=user.Pass;
            s.UserStatus_Id=user.UserStatus_Id;

            carRental.SaveChanges();
        }
        public void EditVehicle(Vehicle vehicle)
        {
            var s = (from x in carRental.Vehicle
                      where x.Vid == vehicle.Vid
                      select x).First();
            
            s.VIN = vehicle.VIN;
            s.Type_Id = vehicle.Type_Id;
            s.Brand = vehicle.Brand;
            s.Model = vehicle.Model;
            s.Color = vehicle.Color;
            s.MakeYear = vehicle.MakeYear;
            s.FeulType_Id = vehicle.FeulType_Id;
            s.PriceByDay = vehicle.PriceByDay;
            s.Mileage = vehicle.Mileage;
            s.IfRent = vehicle.IfRent;
            
            carRental.SaveChanges();
        }
        public void EditClient(Client client)
        {
            var s = (from x in carRental.Client
                      where x.Cid == client.Cid
                      select x).First();

            s.Cid=client.Cid;
            s.FirstName = client.FirstName;
            s.LastName = client.LastName;
            s.PESEL = client.PESEL;
            s.PhoneNumber = client.PhoneNumber;
            s.Address = client.Address;

            carRental.SaveChanges();
        }
        public void EditRent(Rent rent)
        {
            var s = (from x in carRental.Rent
                      where x.Rid == rent.Rid
                      select x).First();

            s.Rid=rent.Rid;
            s.DateOfRental = rent.DateOfRental;
            s.DateOfReturn = rent.DateOfReturn;
            s.Client_Id = rent.Client_Id;
            s.User_Id = rent.User_Id;
            s.Vehicle_Id = rent.Vehicle_Id;

            carRental.SaveChanges();
        }

        //delete
        public void DeleteUser(User user)
        {
            carRental.User.Remove(carRental.User.Single(u => u.Uid == user.Uid));

            carRental.SaveChanges();
        }
        public void DeleteVehicle(Vehicle vehicle)
        {
            carRental.Vehicle.Remove(carRental.Vehicle.Single(v => v.Vid == vehicle.Vid));

            carRental.SaveChanges();
        }
        public void DeleteClient(Client client)
        {
            carRental.Client.Remove(carRental.Client.Single(c=> c.Cid == client.Cid));

            carRental.SaveChanges();
        }
        public void DeleteRent(Rent rent)
        {
            carRental.Rent.Remove(carRental.Rent.Single(r => r.Rid == rent.Rid));

            carRental.SaveChanges();
        }


        //get lists
        public List<UserStatus> GetUserStatuses()
        {
            var r = carRental.UserStatus.ToList();

            return r;
        }
        public List<User> GetUsers()
        {
            var r = carRental.User.ToList();
            return r;
        }
        public List<Type> GetTypes()
        {
            var r = carRental.Type.ToList();

            return r;
        }
        public List<FeulType> GetFeulTypes()
        {
            var r = carRental.FeulType.ToList();

            return r;
        }
        public List<Vehicle> GetVehicles()
        {
            var r = carRental.Vehicle.ToList();

            return r;
        }
        public List<Client> GetClients()
        {
            var r = carRental.Client.ToList();

            return r;
        }
        public List<Rent> GetRents()
        {
            var r = carRental.Rent.ToList();

            return r;
        }

    }
}
