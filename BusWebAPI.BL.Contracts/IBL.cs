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

        /// <summary>
        /// רשימת מבקשי נסיעה
        /// </summary>
        /// <returns>רשימה של כל מי שמבקש לנסוע</returns>
        IQueryable<PeopleOnBus> GetRideRequests(int busID);

        /// <summary>
        /// אישור בקשה לנסיעה
        /// </summary>
        /// <param name="requestorID">מס' בקשה</param>
        void ApproveRideRequest(int requestorID);

        /// <summary>
        /// דחיית בקשה
        /// </summary>
        /// <param name="requestorID">מס' מבקש</param>
        void DeclineRideRequest(int requestorID);
        #endregion

        #region User & Auth
        /// <summary>
        /// הרשמה למערכת ניהול
        /// </summary>
        /// <param name="registerUser">פרטים להרשמה</param>
        /// <returns>משתמש חדש</returns>
        User RegisterUser(RegisterUser registerUser);

        /// <summary>
        /// התחברות
        /// </summary>
        /// <param name="loginModel">מודל התחברות</param>
        /// <returns></returns>
        bool Login(LoginModel loginModel);

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

        /// <summary>
        /// רשימת הסעות היסטוריות
        /// </summary>
        /// <returns>רשימה של הסעות שזמנם עבר</returns>
        IQueryable<Bus> GetBusHistory();

        /// <summary>
        /// רשימת בקשות
        /// </summary>
        /// <returns>רשימת מבקשי ההרשאות לפאנל הניהול</returns>
        IQueryable<User> GetUserRequests();
        
        /// <summary>
        /// אישור משתמש
        /// </summary>
        void VerifyUserRequest(VerifyUser verifyUser);

        /// <summary>
        /// דחיית משתמש
        /// </summary>
        void DeclineUserRequest(int userID);

        /// <summary>
        /// שינוי ססמא
        /// </summary>
        /// <param name="changePassword">מודל שינוי ססמא</param>
        /// <param name="userUniqueID">יוזר לו משנים ססמא</param>
        void ChangePassword(ChangePassword changePassword, int userUniqueID);

        #endregion
    }
}
