using Aleph1.Logging;
using BusWebAPI.DAL.Contracts;
using BusWebAPI.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

        [Logged]
        public IQueryable<Bus> GetBusList()
        {
            return busContext.Bus.Include(p => p.PeopleOnBus).AsQueryable();
        }

        [Logged]
        public Bus GetBusByID(int busID)
        {
            return busContext.Bus.Include(p => p.PeopleOnBus).FirstOrDefault(b => b.ID == busID);
        }
    }
}
