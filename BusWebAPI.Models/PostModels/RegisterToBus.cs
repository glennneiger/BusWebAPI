

namespace BusWebAPI.Models.PostModels
{
    /// <summary>
    /// מודל הרשמה להסעה
    /// </summary>
    public class RegisterToBus
    {
        /// <summary>
        /// שם מלא
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// מספר אישי
        /// </summary>
        public int PersonalID { get; set; }

        /// <summary>
        /// גף + צוות
        /// </summary>
        public string Team { get; set; }

        /// <summary>
        /// סיבה
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// שם מפקד
        /// </summary>
        public string CommanderName { get; set; }

        /// <summary>
        /// הערות
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// הסעה אליה מעוניינים להרשם
        /// </summary>
        public int BusID { get; set; }
    }
}
