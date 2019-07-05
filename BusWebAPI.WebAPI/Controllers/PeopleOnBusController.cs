﻿
using Aleph1.Logging;
using Aleph1.WebAPI.ExceptionHandler;
using BusWebAPI.BL.Contracts;
using BusWebAPI.Models;
using BusWebAPI.Models.PostModels;
using System.Linq;
using System.Web.Http;

namespace BusWebAPI.WebAPI.Controllers
{
    /// <summary>
    /// קונטרולר להסעות
    /// </summary>
    public class PeopleOnBusController : ApiController
    {
        private readonly IBL BL;

        /// <summary>
        /// בנאי
        /// </summary>
        /// <param name="BL">Business Logic</param>
        public PeopleOnBusController(IBL BL)
        {
            this.BL = BL;
        }

        /// <summary>
        /// הרשמה להסעה
        /// </summary>
        /// <param name="registerToBus">הרשמה להסעה</param>
        /// <returns>הנרשם החדש</returns>
        [Logged, HttpPost, Route("api/PeopleOnBus/RegisterToBus"), FriendlyMessage("לא ניתן להרשם כרגע להסעה")]
        public PeopleOnBus RegisterToBus(RegisterToBus registerToBus)
        {
            return BL.RegisterToBus(registerToBus);
        }

    }
}
