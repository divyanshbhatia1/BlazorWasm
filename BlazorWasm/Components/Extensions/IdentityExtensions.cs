using System.Security.Claims;

namespace BlazorWasm.Components.Extensions
{
    public static class IdentityExtensions
    {
        public static int GetIntClaim(this ClaimsPrincipal claims, string type)
        {
            var claim = claims.FindFirst(type);

            if (claim == null) return 0;

            return Convert.ToInt32(claim);
        }
    }
}
