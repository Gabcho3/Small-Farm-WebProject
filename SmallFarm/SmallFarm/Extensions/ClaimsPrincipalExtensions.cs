using System.Security.Claims;
using static SmallFarm.Common.DataConstants.AdministratorConstants;

namespace SmallFarm.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool IsAdmin(this ClaimsPrincipal user)
            => user.IsInRole(AdminRoleName);
    }
}
