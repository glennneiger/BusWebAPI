
using System;

namespace BusWebAPI.Models.PostModels
{

    /// <summary>
    /// מודל הוספת הסעה
    /// </summary>
    public class AddBus
    {
        /// <summary>
        /// מוצא
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// יעד
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// תאריך ושעה
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// מס' מקומות בהסעה
        /// </summary>
        public int NumberOfSeats { get; set; }

        /// <summary>
        /// הערות
        /// </summary>
        public string Comments { get; set; }
    }
}
