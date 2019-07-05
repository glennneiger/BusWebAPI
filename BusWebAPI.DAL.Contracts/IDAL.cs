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

        #region Bus & People On Bus
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

        /// <summary>
        /// הוספת הסעה חדשה
        /// </summary>
        /// <param name="bus">מודל של הסעה</param>
        Bus AddBus(Bus bus);

        /// <summary>
        /// הרשמה להסעה
        /// </summary>
        /// <param name="peopleOnBus">מודל בן אדם בהסעה</param>
        /// <returns>רשום חדש</returns>
        PeopleOnBus RegisterToBus(PeopleOnBus peopleOnBus);
        #endregion

        /// <summary>
        /// הרשמה למערכת ניהול
        /// </summary>
        /// <param name="user">מודל משתמש</param>
        /// <returns>משתמש חדש</returns>
        User RegisterUser(User user);

        /// <summary>
        /// קבלת משתמש לפי מס' אישי
        /// </summary>
        /// <param name="personalID">מס' אישי</param>
        /// <returns>משתמש אם קיים</returns>
        User GetUserByPersonalID(int personalID);

        /// <summary>
        /// קבלת משתמש לפי מזהה
        /// </summary>
        /// <param name="userID">מס' מזהה</param>
        /// <returns>משתמש</returns>
        User GetUserByID(int userID);
    }
}
