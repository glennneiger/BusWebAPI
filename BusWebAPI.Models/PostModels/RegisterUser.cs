
namespace BusWebAPI.Models.PostModels
{
    /// <summary>
    /// מודל להרשמה
    /// </summary>
    public class RegisterUser
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
