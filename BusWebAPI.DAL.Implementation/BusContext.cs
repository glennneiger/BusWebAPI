
using BusWebAPI.Models;
using System.Data.Entity;

namespace BusWebAPI.DAL.Implementation
{
    public class BusContext : DbContext
    {
        public BusContext() : base("name=BusEntities")
        {
        }

        public DbSet<Bus> Bus { get; set; }
        public DbSet<PeopleOnBus> PeopleOnBus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bus>()
               .HasMany(b => b.PeopleOnBus)
               .WithRequired()
               .HasForeignKey(f => f.BusID)
               .WillCascadeOnDelete();

        }
    }
}
