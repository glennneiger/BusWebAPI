using BusWebAPI.Models;
using BusWebAPI.Models.PostModels;
using System.Linq;

namespace BusWebAPI.BL.Contracts
{
    /// <summary>
    /// Handles buisness logic
    /// </summary>
    public interface IBL
    {

        #region Bus & People On Bus

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

        /// <summary>
        /// הוספת הסעה חדשה
        /// </summary>
        /// <param name="newBus">מודל של הסעה</param>
        Bus AddBus(AddBus newBus);

        /// <summary>
        /// הרשמה להסעה
        /// </summary>
        /// <param name="registerToBus">מודל בן אדם בהסעה</param>
        /// <returns>רשום חדש</returns>
        PeopleOnBus RegisterToBus(RegisterToBus registerToBus);

        #endregion

        /// <summary>
        /// הרשמה למערכת ניהול
        /// </summary>
        /// <param name="registerUser">פרטים להרשמה</param>
        /// <returns>משתמש חדש</returns>
        User RegisterUser(RegisterUser registerUser);

    }
}
