using Labb3_API.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserInterestsDbContext _db;

        public UserController(UserInterestsDbContext db)
        {
            _db = db;
        }

        //Testdata:
        private static ICollection<User> _users = [
            new User { Id = 1, Name = "Anna Svensson", PhoneNumber = "070-1234567" },
                new User { Id = 2, Name = "Erik Johansson", PhoneNumber = "073-9876543" }
            ];

        [HttpGet("GetUsers", Name = "GetAllUsers")]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _db.Users.ToListAsync();
            return users;
        }

        [HttpPost("AddUser", Name = "AddNewUser")]
        public async Task<IActionResult> AddUser(User userToAdd)
        {
            if (userToAdd == null)
            {
                return BadRequest("User was not registered.");
            }
            _db.Users.Add(userToAdd);
            await _db.SaveChangesAsync();
            return Ok(userToAdd);
        }
    }
}
