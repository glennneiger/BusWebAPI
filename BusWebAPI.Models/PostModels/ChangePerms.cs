
namespace BusWebAPI.Models.PostModels
{
    /// <summary>
    /// מודל שינוי הרשאות
    /// </summary>
    public class ChangePerms
    {
        /// <summary>
        /// משתמש לו משנים הרשאות
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// האם מנהל
        /// </summary>
        public bool IsAdmin { get; set; }
    }
}
