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
    }
}

