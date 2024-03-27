using System.Security.Claims;
using static SmallFarm.Common.DataConstants.RoleConstants;

namespace SmallFarm.Extensions
{
    public static class IdentityExtenstion
    {
        public static bool IsAdmin(this ClaimsPrincipal user)
            => user.IsInRole(Admin.RoleName);

        public static bool IsManufacturer(this ClaimsPrincipal user)
            => user.IsInRole(Manufacturer.RoleName);
    }
}
