﻿using Aleph1.Logging;
using BusWebAPI.DAL.Contracts;
using BusWebAPI.Models;
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

        [Logged]
        public IQueryable<Bus> GetBusList()
        {
            return busContext.Bus.IncludeFilter(b => b.PeopleOnBus.Where(p => p.IsVerified == true)).Where(b => b.IsActive == true).AsQueryable();
        }

        [Logged]
        public Bus GetBusByID(int busID)
        {
            return busContext.Bus.IncludeFilter(b => b.PeopleOnBus.Where(p => p.IsVerified == true)).FirstOrDefault(b => b.ID == busID);
        }

        public Bus AddBus(Bus bus)
        {
            return busContext.Bus.Add(bus);
        }

        public PeopleOnBus RegisterToBus(PeopleOnBus peopleOnBus)
        {
            return busContext.PeopleOnBus.Add(peopleOnBus);
        }
    }
}
