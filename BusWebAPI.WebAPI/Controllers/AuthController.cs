using Aleph1.Logging;
using BusWebAPI.Models.Security;
using BusWebAPI.Security.Contracts;
using BusWebAPI.WebAPI.Security;
using Aleph1.WebAPI.ExceptionHandler;
using System.Web.Http;
using BusWebAPI.Models;
using BusWebAPI.Models.PostModels;
using BusWebAPI.BL.Contracts;
using System;

namespace BusWebAPI.WebAPI.Controllers
{
    /// <summary>handle login</summary>
    public class AuthController : ApiController
    {
        private readonly ISecurity SecurityService;
        private readonly IBL BL;

        /// <summary>Initializes a new instance of the <see cref="AuthController"/> class.</summary>
        [Logged(LogParameters = false)]
        public AuthController(ISecurity securityService, IBL BL)
        {
            this.SecurityService = securityService;
            this.BL = BL;
        }

        /// <summary>
        /// הרשמה למערכת
        /// </summary>
        /// <param name="registerUser">נתונים הכרחיים להרשמה</param>
        /// <returns>משתמש חדש</returns>
        [Logged, HttpPost, Route("api/Auth/Register"), FriendlyMessage("לא ניתן להשלים את תהליך ההרשמה כרגע")]
        public User RegisterUser(RegisterUser registerUser)
        {
            return BL.RegisterUser(registerUser);
        }

        /// <summary>Logins to the app (specify if as manager).</summary>
        /// <param name="loginModel">Login model</param>
        [Authenticated(AllowAnonymous = true), Logged, HttpPost, Route("api/Auth/Login"), FriendlyMessage("התרחשה שגיאה בעת ההתחברות")]
        public string Login(LoginModel loginModel)
        {
            if(BL.Login(loginModel))
            {
                return Request.Headers.AddAuthenticationInfo(SecurityService, new AuthenticationInfo()
                {
                    UserUniqueID = BL.GetUserByPersonalID(loginModel.PersonalID).ID,
                    IsManager = BL.GetUserByPersonalID(loginModel.PersonalID).IsAdmin
                });
            } else
            {
                throw new Exception("שם משתמש או ססמא אינם נכונים");
            }

        }
    }
}
