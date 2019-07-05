namespace BusWebAPI.Models.Security
{
    /// <summary>The information that the server needs for determining if a user is allowed for a resource</summary>
    public class AuthenticationInfo
    {

        /// <summary>
        /// Unique ID of a user
        /// </summary>
        public int UserUniqueID { get; set; }

        /// <summary>indicating whether this user has manager access.</summary>
        public bool IsManager { get; set; }
    }
}
