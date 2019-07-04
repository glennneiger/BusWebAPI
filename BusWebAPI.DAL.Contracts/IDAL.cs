using BusWebAPI.Models;
using System.Linq;

namespace BusWebAPI.DAL.Contracts
{
    /// <summary>
    /// Handles data access
    /// </summary>
    public interface IDAL
    {

        /// <summary>
        /// Save changes
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// רשימת הסעות
        /// </summary>
        /// <returns>רשימת הסעות</returns>
        IQueryable<Bus> GetBusList();

        /// <summary>
        /// הסעה לפי מס' מזהה
        /// </summary>
        /// <param name="busID">מס' מזהה של הסעה</param>
        /// <returns>הסעה</returns>
        Bus GetBusByID(int busID);
    }
}
