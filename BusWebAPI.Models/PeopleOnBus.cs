
namespace BusWebAPI.Models
{
    /// <summary>
    /// אנשים רשומים להסעה
    /// </summary>
    public class PeopleOnBus
    {
        /// <summary>
        /// Unique ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// גף
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// צוות
        /// </summary>
        public string Team { get; set; }

        /// <summary>
        /// שם מלא
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// מס' אישי
        /// </summary>
        public int PersonalNumber { get; set; }

        /// <summary>
        /// סיבת היציאה
        /// </summary>
        public string ExitReason { get; set; }

        /// <summary>
        /// שם מפקד חותם
        /// </summary>
        public string MefakedName { get; set; }

        /// <summary>
        /// הערות
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// הסעה אליו הוא נרשם
        /// </summary>
        public int BusID { get; set; }
    }
}
