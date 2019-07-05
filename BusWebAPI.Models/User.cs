
namespace BusWebAPI.Models
{
    /// <summary>
    /// מודל לתיאור משתמש
    /// </summary>
    public class User
    {
        /// <summary>
        /// Unique ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// מס' אישי
        /// </summary>
        public int PersonalID { get; set; }

        /// <summary>
        /// ססמא מאובטחת
        /// </summary>
        public Password Password { get; set; }

        /// <summary>
        /// האם מנהל או רק מפקד
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// האם אושר כמנהל
        /// </summary>
        public bool IsActive { get; set; }
    }
}
