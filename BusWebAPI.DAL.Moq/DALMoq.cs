using BusWebAPI.DAL.Contracts;
using BusWebAPI.Models;
using System.Linq;

namespace BusWebAPI.DAL.Moq
{
    internal class DALMoq : IDAL
    {
        public Bus GetBusByID(int busID)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Bus> GetBusList()
        {
            return null;
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}
