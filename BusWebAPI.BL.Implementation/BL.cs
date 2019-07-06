using Aleph1.Logging;
using BusWebAPI.BL.Contracts;
using BusWebAPI.DAL.Contracts;
using BusWebAPI.Models;
using BusWebAPI.Models.PostModels;
using System;
using System.Linq;

namespace BusWebAPI.BL.Implementation
{
    internal class BL : IBL
    {
        private readonly IDAL DAL;
        private readonly HashHelpers hashHelpers;

        public BL(IDAL DAL, HashHelpers hashHelpers)
        {
            this.DAL = DAL;
            this.hashHelpers = hashHelpers;
        }

        #region Bus & People On Bus

        [Logged]
        public IQueryable<Bus> GetBusList()
        {
            foreach(var bus in DAL.GetBusList())
            {
                if(DateTime.Compare(DateTime.Now, bus.DateTime) > 0)
                {
                    bus.IsActive = false;
                } else
                {
                    bus.IsActive = true;
                }
            }

            DAL.SaveChanges();
            return DAL.GetBusList();
        }

        [Logged]
        public Bus GetBusByID(int busID)
        {
            return DAL.GetBusByID(busID);
        }

        [Logged]
        public Bus AddBus(AddBus newBus)
        {
            Bus bus = new Bus()
            {
                From = newBus.From,
                To = newBus.To,
                DateTime = newBus.DateTime,
                NumberOfSeats = newBus.NumberOfSeats,
                Comments = newBus.Comments,
                IsActive = true
            };

            DAL.AddBus(bus);
            DAL.SaveChanges();

            return bus;
        }

        [Logged]
        public PeopleOnBus RegisterToBus(RegisterToBus registerToBus)
        {
            PeopleOnBus peopleOnBus = new PeopleOnBus()
            {
                FullName = registerToBus.FullName,
                PersonalNumber = registerToBus.PersonalID,
                Team = registerToBus.Team,
                ExitReason = registerToBus.Reason,
                MefakedName = registerToBus.CommanderName,
                Comments = registerToBus.Notes,
                BusID = registerToBus.BusID,
                IsVerified = false,
                IsHidden = false
            };

            DAL.RegisterToBus(peopleOnBus);
            DAL.SaveChanges();
            return peopleOnBus;
        }

        [Logged]
        public IQueryable<Bus> GetBusHistory()
        {
            return DAL.GetBusHistory();
        }

        [Logged]
        public IQueryable<PeopleOnBus> GetRideRequests(int busID)
        {
            return DAL.GetRideRequests(busID);
        }

        [Logged]
        public void ApproveRideRequest(int requestorID)
        {
            PeopleOnBus peopleOnBus = DAL.GetRideRequestorByID(requestorID);
            peopleOnBus.IsVerified = true;
            DAL.SaveChanges();
        }

        [Logged]
        public void DeclineRideRequest(int requestorID)
        {
            PeopleOnBus peopleOnBus = DAL.GetRideRequestorByID(requestorID);
            peopleOnBus.IsHidden = true;
            DAL.SaveChanges();
        }



        #endregion

        #region User & Auth
        public User RegisterUser(RegisterUser registerUser)
        {
            if (DAL.GetUserByPersonalID(registerUser.PersonalID) == null)
            {

                Password password = new Password()
                {
                    HashedPassword = hashHelpers.HashPassword(registerUser.Password)
                };

                User user = new User()
                {
                    PersonalID = registerUser.PersonalID,
                    Password = password,
                    IsAdmin = false,
                    IsActive = false
                };

                DAL.RegisterUser(user);
                DAL.SaveChanges();

                return user;
            } else
            {
                throw new Exception("המשתמש קיים במערכת");
            }
        }

        public bool Login(LoginModel loginModel)
        {
            User user = DAL.GetUserByPersonalID(loginModel.PersonalID);
            if(user != null && user.IsActive == true)
            {
                return hashHelpers.ValidatePassword(loginModel.Password, user.Password.HashedPassword);
            } else
            {
                throw new Exception("המשתמש לא קיים במערכת או שלא אושר עדיין על ידי המנהלים");
            }
        }

        public User GetUserByPersonalID(int personalID)
        {
            return DAL.GetUserByPersonalID(personalID);
        }

        public User GetUserByID(int userID)
        {
            return DAL.GetUserByID(userID);
        }

        public IQueryable<User> GetUserRequests()
        {
            return DAL.GetUserRequests();
        }

        public void VerifyUserRequest(VerifyUser verifyUser)
        {
            User user = DAL.GetUserByID(verifyUser.UserID);
            if(user != null)
            {
                user.IsActive = true;
                user.IsAdmin = verifyUser.IsAdmin;
                DAL.SaveChanges();
            } else
            {
                throw new Exception("המשתמש אותו ניסית לעדכן לא קיים");
            }


        }

        public void DeclineUserRequest(int userID)
        {
            User user = DAL.GetUserByID(userID);
            DAL.DeclineUserRequest(user);
            DAL.SaveChanges();
        }

        public void ChangePassword(ChangePassword changePassword, int userUniqueID)
        {
            User user = DAL.GetUserByID(userUniqueID);
            if(hashHelpers.ValidatePassword(changePassword.OldPassword, user.Password.HashedPassword))
            {
                Password password = new Password()
                {
                    HashedPassword = hashHelpers.HashPassword(changePassword.NewPassword)
                };
                user.Password = password;
                DAL.SaveChanges();
            } else
            {
                throw new Exception("הססמא לא תואמת לססמא השמורה במערכת.");
            }
        }

        public IQueryable<User> GetAllUsers()
        {
            return DAL.GetAllUsers();
        }

        public void ChangePerms(ChangePerms changePerms)
        {
            User user = DAL.GetUserByID(changePerms.UserID);
            user.IsAdmin = changePerms.IsAdmin;
            DAL.SaveChanges();
        }

        public void DeleteUser(int userID)
        {
            User user = DAL.GetUserByID(userID);
            DAL.DeleteUser(user);
            DAL.SaveChanges();
        }

        #endregion


    }
}

