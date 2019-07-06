
namespace BusWebAPI.Models.PostModels
{
    /// <summary>
    /// מודל שינוי ססמא
    /// </summary>
    public class ChangePassword
    {
        /// <summary>
        /// ססמא ישנה
        /// </summary>
        public string OldPassword { get; set; }

        /// <summary>
        /// ססמא חדשה
        /// </summary>
        public string NewPassword { get; set; }
    }
}
