
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
    public class BusController : ApiController
    {
        private readonly IBL BL;

        /// <summary>
        /// בנאי
        /// </summary>
        /// <param name="BL">Business Logic</param>
        public BusController(IBL BL)
        {
            this.BL = BL;
        }

        /// <summary>
        /// קבלת כל ההסעות
        /// </summary>
        /// <returns>רשימה של הסעות כולל רשומים</returns>
        [Logged, HttpGet, Route("api/Bus/GetBusList"), FriendlyMessage("לא ניתן להציג את ההסעות כרגע")]
        public IQueryable<Bus> GetBusList()
        {
            return BL.GetBusList();
        }

        /// <summary>
        /// קבלת הסעה לפי מס' מזהה
        /// </summary>
        /// <param name="busID">מס' מזהה</param>
        /// <returns>קבלת הסעה כולל רשומים אליה</returns>
        [Logged, HttpGet, Route("api/Bus/GetBusByID"), FriendlyMessage("הסעה לא נמצאה")]
        public Bus GetBusByID(int busID)
        {
            return BL.GetBusByID(busID);
        }

        /// <summary>
        /// הרשמה להסעה
        /// </summary>
        /// <param name="newBus">הסעה חדשה</param>
        /// <returns>ההסעה שנוספה</returns>
        [Logged, HttpPost, Route("api/Bus/AddBus"), FriendlyMessage("הוספת הסעה לא הצליחה")]
        public Bus AddBus(AddBus newBus)
        {
            return BL.AddBus(newBus);
        }

    }
}
