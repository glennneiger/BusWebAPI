
using Aleph1.Logging;
using Aleph1.WebAPI.ExceptionHandler;
using BusWebAPI.BL.Contracts;
using BusWebAPI.Models;
using BusWebAPI.Models.PostModels;
using BusWebAPI.Models.Security;
using BusWebAPI.Security.Contracts;
using BusWebAPI.WebAPI.Security;
using System.Linq;
using System.Web.Http;

namespace BusWebAPI.WebAPI.Controllers
{
    /// <summary>
    /// קונטרולר להסעות
    /// </summary>
    public class UserController : ApiController
    {
        private readonly ISecurity SecurityService;

        private readonly IBL BL;

        /// <summary>
        /// בנאי
        /// </summary>
        /// <param name="BL">Business Logic</param>
        public UserController(IBL BL, ISecurity SecurityService)
        {
            this.BL = BL;
            this.SecurityService = SecurityService;
        }

        /// <summary>
        /// קבלת רשימת בקשות להרשאות
        /// </summary>
        /// <returns>קבלת רשימת בקשות להרשאות</returns>
        [Authenticated(AllowAnonymous = false, RequireManagerAccess = true), Logged, HttpGet, Route("api/User/GetUserRequests"), FriendlyMessage("לא ניתן לקבל מידע על מבקשי הרשאות כרגע")]
        public IQueryable<User> GetUserRequests()
        {
            return BL.GetUserRequests();
        }

        /// <summary>
        /// אישור בקשת משתמש ומתן הרשאות
        /// </summary>
        /// <param name="verifyUser"></param>
        [Authenticated(AllowAnonymous = false, RequireManagerAccess = true), Logged, HttpPut, Route("api/User/VerifyUserRequest"), FriendlyMessage("לא ניתן לעדכן כרגע")]
        public void VerifyUserRequest(VerifyUser verifyUser)
        {
            BL.VerifyUserRequest(verifyUser);
        }

        /// <summary>
        /// דחיית בקשה של משתמש ומחיקתה מהרשימה
        /// </summary>
        /// <param name="userID">מס' משתמש ייחודי</param>
        [Authenticated(AllowAnonymous = false, RequireManagerAccess = true), Logged, HttpDelete, Route("api/User/DeclineUserRequest"), FriendlyMessage("לא ניתן לעדכן כרגע")]
        public void DeclineUserRequest(int userID)
        {
            BL.DeclineUserRequest(userID);
        }

        /// <summary>
        /// שינוי ססמא
        /// </summary>
        /// <param name="changePassword">מודל לשינוי ססמא</param>
        [Authenticated(AllowAnonymous = false, RequireManagerAccess = false), Logged, HttpPut, Route("api/User/ChangePassword"), FriendlyMessage("בעיה במהלך שינוי הססמא")]
        public void ChangePassword(ChangePassword changePassword)
        {
            // קבלת מזהה המשתמש דרך הטיקט המיוחד שלו - בכך משתמשים לא יכולים "לעבוד" על המערכת
            AuthenticationInfo authInfo = Request.Headers.GetAuthenticationInfo(SecurityService);

            BL.ChangePassword(changePassword, authInfo.UserUniqueID);
        }

        /// <summary>
        /// קבלת רשימת משתמשים
        /// </summary>
        /// <returns>רשימה של משתמשים</returns>
        [Authenticated(AllowAnonymous = false, RequireManagerAccess = true), Logged, HttpGet, Route("api/User/GetAllUsers"), FriendlyMessage("לא ניתן לקבל את רשימת המשתמשים כרגע")]
        public IQueryable<User> GetAllUsers()
        {
            return BL.GetAllUsers();
        }

        /// <summary>
        /// שינוי הרשאה למשתמשים
        /// </summary>
        /// <param name="changePerms">מודל שינוי הרשאות</param>
        [Authenticated(AllowAnonymous = false, RequireManagerAccess = true), Logged, HttpPut, Route("api/User/ChangePerms"), FriendlyMessage("לא ניתן לקבל את רשימת המשתמשים כרגע")]
        public void ChangePerms(ChangePerms changePerms)
        {
            BL.ChangePerms(changePerms);
        }

        /// <summary>
        /// מחיקת משתמש
        /// </summary>
        /// <param name="userID">משתמש אותו מעוניינים למחוק</param>
        [Authenticated(AllowAnonymous = false, RequireManagerAccess = true), Logged, HttpDelete, Route("api/User/DeleteUser"), FriendlyMessage("לא ניתן לקבל את רשימת המשתמשים כרגע")]
        public void DeleteUser(int userID)
        {
            BL.DeleteUser(userID);
        }
    }
}
