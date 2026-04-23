using Labb3_API.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Labb3_API.models.DTOs.UserDTOs;

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
        //private static ICollection<User> _users = [
        //      new User { Id = 1, Name = "Anna Svensson", PhoneNumber = "070-1234567" },
        //      new User { Id = 2, Name = "Erik Johansson", PhoneNumber = "073-9876543" }
        //    ];

        [HttpPost("AddNewUser")]
        public async Task<IActionResult> AddUser(CreateAddUserRequest addUserRequest)
        {
            if (addUserRequest == null)
            {
                return BadRequest("User was not registered.");
            }
            var userToAdd = new User
            {
                Name = addUserRequest.Name,
                PhoneNumber = addUserRequest.PhoneNumber
            };
            await _db.Users.AddAsync(userToAdd);
            await _db.SaveChangesAsync();
            return Ok(userToAdd);
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _db.Users
                .Select(u => new
                {
                    u.Id,
                    u.Name,
                    u.PhoneNumber
                })
                .ToListAsync();

            return Ok(users);
        }

        [HttpGet("{userId}", Name = "GetInterestsByUserId")]
        public async Task<IActionResult> GetInterestsByUserId(int userId)
        {
            var user = await _db.Users
                .Where(u => u.Id == userId)
                .Select(u => new
                {
                    u.Id,
                    u.Name,
                    Interests = u.Interests.Select(i => new
                    {
                        i.Id,
                        i.Title,
                        i.Description
                    })
                })
                .FirstOrDefaultAsync();

            if (user == null) return BadRequest("User not found.");

            return Ok(user.Interests);
        }

        [HttpPost("{userId}/interests/{interestId}", Name = "AddInterestToUser")]
        public async Task<IActionResult> AddInterestToUser(int userId, int interestId)
        {
            var user = await _db.Users
                .Include(u => u.Interests)
                .FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var interest = await _db.Interests
                .FindAsync(interestId);
            if (interest == null)
            {
                return NotFound("Interest not found.");
            }
            if (user.Interests.Any(i => i.Id == interestId))
            {
                return Conflict("User already has this interest.");
            }

            user.Interests.Add(interest);
            await _db.SaveChangesAsync();
            return Ok($"Intrest '{interest.Title}' added to user: {user.Name}");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("User was not found.");
            }

            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            return Ok("User deleted.");
        }
    }
}
