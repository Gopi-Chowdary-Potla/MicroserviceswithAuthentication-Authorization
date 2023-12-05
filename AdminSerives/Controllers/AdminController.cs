using AdminSerives.Dao;
using AdminSerives.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminSerives.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly APpDB _db;
        public AdminController(APpDB db)
        {
            _db = db;
        }
        [HttpGet]
        public object GetAdminDetails()
        {
            List<Admin> objlist=_db.Admin.ToList();
            if(objlist.Count == 0 )
            {
                return BadRequest("Fail to Update Data");
            }
            return objlist;
        }
    }
}
