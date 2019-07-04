using Aleph1.Logging;
using BusWebAPI.BL.Contracts;
using BusWebAPI.DAL.Contracts;
using BusWebAPI.Models;
using System;
using System.Linq;

namespace BusWebAPI.BL.Implementation
{
    internal class BL : IBL
    {
        private readonly IDAL DAL;

        public BL(IDAL DAL)
        {
            this.DAL = DAL;
        }


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

    }
}

