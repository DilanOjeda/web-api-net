using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        private static List<User> GetUsers()
        {
            return new List<User>() {
                new User{ Id = 1, Name = "Dylan", BirthDate = new DateTime(1995, 8, 12)}
            };
        }

        [HttpGet]
        public async Task <IActionResult> Get()
        {
            var users = await _userRepository.SearchUsers();
            return users.Any()
                    ? Ok(users)
                    : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userRepository.SearchUser(id);
            return user != null 
                    ? Ok(user)
                    : NoContent();
        }

        [HttpPost]
        public async Task <IActionResult> Post(User user)
        {
            _userRepository.AddUser(user);
            return await _userRepository.SaveChangesAsync()
                    ? Ok("User cre1ated successfully")
                    : BadRequest("Error creating User");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, User user)
        {
            var userDb = await _userRepository.SearchUser(id);
            if (userDb == null) return NotFound("User was not found");
            userDb.Name = user.Name ?? userDb.Name;
            user.BirthDate = user.BirthDate != new DateTime()
                    ? userDb.BirthDate : userDb.BirthDate;
            _userRepository.UpdateUser(userDb);
            return await _userRepository.SaveChangesAsync()
                    ? Ok("User updated successfully")
                    : BadRequest("Error updating User");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userDb = await _userRepository.SearchUser(id);
            if (userDb == null) return NotFound("Not exist user");
            _userRepository.DeleteUser(userDb);
            return await _userRepository.SaveChangesAsync()
                    ? Ok("User deleted successfully")
                    : BadRequest("Error deleting User");
        }
    }
}