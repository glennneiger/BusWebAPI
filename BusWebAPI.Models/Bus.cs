
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusWebAPI.Models
{
    /// <summary>
    /// מודל הסעות
    /// </summary>
    public class Bus
    {
        /// <summary>
        /// Unique ID
        /// </summary>
        public int ID { get; set; }

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

        /// <summary>
        /// רשומים להסעה
        /// </summary>
        public List<PeopleOnBus> PeopleOnBus { get; set; }

        /// <summary>
        /// האם ההסעה פעילה
        /// </summary>
        public bool IsActive { get; set; }

    }
}
