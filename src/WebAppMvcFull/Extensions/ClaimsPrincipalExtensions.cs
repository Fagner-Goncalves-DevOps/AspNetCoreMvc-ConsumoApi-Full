using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAppMvcFull.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal) 
        {
            if (principal == null) { throw new ArgumentException(nameof(principal));}

            var claim = principal.FindFirst("sub");
            return claim?.Value;
        }

        public static string GetUserEmail (this ClaimsPrincipal principal) 
        {
            if (principal == null) { throw new ArgumentException(nameof(principal)); }

            var claim = principal.FindFirst("email");
            return claim?.Value;
        }

        
        public static string GetUserToken(this ClaimsPrincipal principal) 
        {
            if (principal == null) { throw new ArgumentException(nameof(principal)); }

            var claim = principal.FindFirst("JWT");
            return claim?.Value;

        }


    }
}
