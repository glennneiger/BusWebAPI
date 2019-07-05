
namespace BusWebAPI.Models
{
    /// <summary>
    /// מודל התחברות
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// מס' אישי
        /// </summary>
        public int PersonalID { get; set; }

        /// <summary>
        /// ססמא
        /// </summary>
        public string Password { get; set; }
    }
}
