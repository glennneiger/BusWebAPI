
namespace BusWebAPI.Models.PostModels
{
    public class VerifyUser
    {

        /// <summary>
        /// המשתמש אותו מנסים לעדכן
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// אמת אם מנהל, שקר אם מפקד
        /// </summary>
        public bool IsAdmin { get; set; }
    }
}
