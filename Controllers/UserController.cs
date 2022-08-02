using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private static List<User> GetUsers()
        {
            return new List<User>() {
                new User{ Id = 1, Name = "Dylan", BirthDate = new DateTime(1995, 8, 12)}
            };
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(GetUsers());
        }
    }
}