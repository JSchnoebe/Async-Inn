﻿using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AsyncInn.Models.Identity
{
    public class JwtService
    {
        public static TokenValidationParameters GetValidationParameters(IConfiguration configuration)
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                // This Is Our main goal: Make sure the security key, which comes from configuration is valid
                IssuerSigningKey = GetSecurityKey(configuration),

                // For simplifying testing
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        }

        private static SecurityKey GetSecurityKey(IConfiguration configuration)
        {
            var secret = configuration["JWT:Secret"];
            if (secret == null) { throw new InvalidOperationException("JWT:Secret is missing"); }
            var secretBytes = Encoding.UTF8.GetBytes(secret);
            return new SymmetricSecurityKey(secretBytes);
        }
    }
}
