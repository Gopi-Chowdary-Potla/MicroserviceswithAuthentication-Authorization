using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationandAuthorization.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    public class ValidateUser
    {
        public string Token { get; set; }
        public int Expiretime { get; set; }
    }
    public class Login
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
    
}
