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

        public Bus GetBusByID(int busID)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Bus> GetBusList()
        {
            return null;
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
