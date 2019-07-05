using Aleph1.Logging;
using BusWebAPI.DAL.Contracts;
using BusWebAPI.Models;
using System.Data.Entity;
using System.Linq;
using Z.EntityFramework.Plus;

namespace BusWebAPI.DAL.Implementation
{
    internal class DAL : IDAL
    {
        private readonly BusContext busContext;

        public DAL(BusContext busContext)
        {
            this.busContext = busContext;
        }

        public void SaveChanges()
        {
            busContext.SaveChanges();
        }

        #region Bus & People On Bus
        [Logged]
        public IQueryable<Bus> GetBusList()
        {
            return busContext.Bus.Include(u => u.PeopleOnBus).Where(b => b.IsActive == true).AsQueryable();
        }

        [Logged]
        public IQueryable<Bus> GetBusHistory()
        {
            return busContext.Bus.IncludeFilter(b => b.PeopleOnBus.Where(p => p.IsVerified == true)).Where(b => b.IsActive == false).AsQueryable();
        }

        [Logged]
        public Bus GetBusByID(int busID)
        {
            return busContext.Bus.Include(u => u.PeopleOnBus).Where(b => b.IsActive == true).FirstOrDefault(b => b.ID == busID);
        }

        [Logged]
        public Bus AddBus(Bus bus)
        {
            return busContext.Bus.Add(bus);
        }

        [Logged]
        public PeopleOnBus RegisterToBus(PeopleOnBus peopleOnBus)
        {
            return busContext.PeopleOnBus.Add(peopleOnBus);
        }

        [Logged]
        public IQueryable<PeopleOnBus> GetRideRequests(int busID)
        {
            return busContext.PeopleOnBus.Where(p => p.IsVerified == false && p.BusID == busID);
        }

        #endregion

        #region User & Auth
        [Logged]
        public User RegisterUser(User user)
        {
            return busContext.User.Add(user);
        }

        [Logged]
        public User GetUserByPersonalID(int personalID)
        {
            return busContext.User.Include(u => u.Password).FirstOrDefault(u => u.PersonalID == personalID);
        }

        [Logged]
        public User GetUserByID(int userID)
        {
            return busContext.User.Include(u => u.Password).FirstOrDefault(u => u.ID == userID);
        }

        public IQueryable<User> GetUserRequests()
        {
            return busContext.User.Where(u => u.IsActive == false).AsQueryable();
        }

        public void DeclineUserRequest(User user)
        {
            busContext.User.Remove(user);
        }
        #endregion

    }
}
