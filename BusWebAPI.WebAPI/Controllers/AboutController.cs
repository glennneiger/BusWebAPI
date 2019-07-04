﻿using Aleph1.Logging;
using BusWebAPI.WebAPI.Classes;
using BusWebAPI.WebAPI.Models;
using Aleph1.WebAPI.ExceptionHandler;
using System;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace BusWebAPI.WebAPI.Controllers
{
    /// <summary>some data about the current service</summary>
    public class AboutController : ApiController
    {
        /// <summary>Get data about the current api and user</summary>
        [Logged, HttpGet, Route("api/About"), FriendlyMessage("התרחשה שגיאה בעת שליפת נתוני מערכת")]
        public AboutModel About()
        {

            //Client logon Name (when using Windows Authentication)
            //string userUniqueID = HttpContext.Current.User.Identity.Name;
            return new AboutModel()
            {
                ClientIP = HttpContext.Current?.Request?.UserHostAddress,
                ClientUserName = HttpContext.Current?.User?.Identity?.Name,
                Environment = SettingsManager.Environment,
                APIVersion = Assembly.GetExecutingAssembly()?.GetName()?.Version?.ToString(),
                Server = Environment.MachineName
            };
        }
    }
}
