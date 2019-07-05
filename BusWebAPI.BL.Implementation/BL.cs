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
                IsVerified = false
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

        #endregion


    }
}

