using AuthenticationandAuthorization.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AuthenticationandAuthorization.Controllers
{
  
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly List<User> _userInfo;
        private readonly Authenticationserivces _services;

        public AuthController(Authenticationserivces services)
        {
            _services = services;

            // Initialize some dummy user data for demonstration
            _userInfo = new List<User>
            {
                new User { UserName = "Admin", Password = "Admin123", Role = "Administration" },
                
            };
        }

        [HttpPost]
        public IActionResult LoginUser(Login login)
        {
            var userDetails = _userInfo.Find(u => u.UserName == login.Name && u.Password == login.Password);

            if (userDetails == null)
            {
                // User not found or invalid credentials
                return Unauthorized();
            }

            // Assuming successful authentication, generate a token
            var token = _services.GenerateToken(userDetails);

            return Ok(new { Token = token.Token, ExpiresInMinutes = token.Expiretime });
        }
    }
}
