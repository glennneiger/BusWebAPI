
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
        /// גף + צוות
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

        /// <summary>
        /// האם מאושר
        /// </summary>
        public bool IsVerified { get; set; }

        /// <summary>
        /// האם להחביא את הבקשה
        /// </summary>
        public bool IsHidden { get; set; }
    }
}
