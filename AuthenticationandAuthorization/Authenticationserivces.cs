using AuthenticationandAuthorization.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AuthenticationandAuthorization
{
    public class Authenticationserivces
    {
        private readonly IConfiguration _configuration;
        public readonly string Jwkey = "";
        public readonly string Issuer = "";

        public Authenticationserivces(IConfiguration configuration)
        {
            _configuration = configuration;
            Jwkey = _configuration.GetSection("JWT:Key").Value;
            Issuer = _configuration.GetSection("JWT:Issuer").Value;
        }

        public ValidateUser GenerateToken(User user)
        {
            ValidateUser obj=new ValidateUser();
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Jwkey));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var expireTimestamp = DateTime.Now.AddMinutes(3);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("role", user.Role)
            };
            var secToken = new JwtSecurityToken(
                issuer: Issuer,
                claims: claims,
                expires: expireTimestamp,
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(secToken);
            obj.Token=tokenString;
            obj.Expiretime = (int)expireTimestamp.Subtract(DateTime.Now).TotalMinutes;
            return obj;
            
        }

        
    }
}
