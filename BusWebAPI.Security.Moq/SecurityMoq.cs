using BusWebAPI.Models.Security;
using BusWebAPI.Security.Contracts;

namespace BusWebAPI.Security.Moq
{
    internal class SecurityMoq : ISecurity
    {
        public string GenerateTicket(AuthenticationInfo authenticationInfo, string userUniqueID)
        {
            return null;
        }

        public string ReGenerateTicket(AuthenticationInfo authenticationInfo, string userUniqueID)
        {
            return null;
        }

        public AuthenticationInfo ReadTicket(string ticketValue, string userUniqueID)
        {
            return null;
        }

        public bool IsAllowedForRegularContent(AuthenticationInfo authenticationInfo)
        {
            return true;
        }

        public bool IsAllowedForManagementContent(AuthenticationInfo authenticationInfo)
        {
            return true;
        }
    }
}
