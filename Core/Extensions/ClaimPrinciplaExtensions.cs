﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Core.Extensions
{
    public static class ClaimPrinciplaExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal,string claimType)
        {
            return claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
        }
        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
