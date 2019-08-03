﻿using IgpFramework.Dto.Common.Users;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Igp.Core.Security.Token
{
    public static class TokenHelper
    {
        public static string GetToken(UserDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = SignHandler.GetSecurityKey("vwaXxKAsTQ5msMfiYNYdzd4KBpjR5Y4MIGP");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("userName",user.UserName),
                    new Claim("userId",user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                Audience = "mysite.com",
                Issuer = "mysite.com",
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}