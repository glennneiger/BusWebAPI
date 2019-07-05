
namespace BusWebAPI.Models
{
    /// <summary>
    /// מודל לססמאות מאובטחות
    /// </summary>
    public class Password
    {

        /// <summary>
        /// Unique ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// ססמא HASHED
        /// </summary>
        public string HashedPassword { get; set; }
    }
}
