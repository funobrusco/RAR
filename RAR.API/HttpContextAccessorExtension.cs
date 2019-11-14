﻿using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace RAR.API
{
    public static class HttpContextAccessorExtension
    {
        public static int CurrentUser(this IHttpContextAccessor httpContextAccessor)
        {
            var stringId = httpContextAccessor?.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
            int.TryParse(stringId ?? "0", out int userId);

            return userId;
        }
    }
}
