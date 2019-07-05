using BusWebAPI.DAL.Contracts;
using BusWebAPI.Models;
using System.Linq;

namespace BusWebAPI.DAL.Moq
{
    internal class DALMoq : IDAL
    {
        public Bus AddBus(Bus bus)
        {
            throw new System.NotImplementedException();
        }

        public void DeclineUserRequest(User user)
        {
            throw new System.NotImplementedException();
        }

        public Bus GetBusByID(int busID)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Bus> GetBusHistory()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Bus> GetBusList()
        {
            return null;
        }

        public User GetUserByID(int userID)
        {
            throw new System.NotImplementedException();
        }

        public User GetUserByPersonalID(int personalID)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<User> GetUserRequests()
        {
            throw new System.NotImplementedException();
        }

        public PeopleOnBus RegisterToBus(PeopleOnBus peopleOnBus)
        {
            throw new System.NotImplementedException();
        }

        public User RegisterUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}
