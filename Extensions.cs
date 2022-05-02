using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Security.Claims;

namespace OceanAPI.NET6
{
    public static class Extensions
    {
        public static bool IsCurrentUser(int id, ClaimsPrincipal User)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return false;
            if (!userId.Equals(id.ToString()))
                return false;
            return true;
        }

        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }
}
