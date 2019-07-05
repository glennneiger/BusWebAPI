
using Aleph1.Logging;
using Aleph1.WebAPI.ExceptionHandler;
using BusWebAPI.BL.Contracts;
using BusWebAPI.Models;
using BusWebAPI.Models.PostModels;
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
        private readonly IBL BL;

        /// <summary>
        /// בנאי
        /// </summary>
        /// <param name="BL">Business Logic</param>
        public UserController(IBL BL)
        {
            this.BL = BL;
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
    }
}
