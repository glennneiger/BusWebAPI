using BusWebAPI.Models;
using System.Linq;

namespace BusWebAPI.BL.Contracts
{
    /// <summary>
    /// Handles buisness logic
    /// </summary>
    public interface IBL
    {
        /// <summary>
        /// רשימת של הסעות
        /// </summary>
        /// <returns>רשימה של הסעות</returns>
        IQueryable<Bus> GetBusList();

        /// <summary>
        /// הסעה לפי מס' מזהה
        /// </summary>
        /// <param name="busID">מס' מזהה</param>
        /// <returns>הסעה</returns>
        Bus GetBusByID(int busID);

    }
}
