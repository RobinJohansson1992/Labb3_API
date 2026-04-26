using Labb3_API.models;
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


        [HttpPost("{userId}/interests/{interestId}")]
        [EndpointSummary("Connect user to interest")]
        public async Task<IActionResult> AddInterestToUser(int userId, int interestId)
        {
            var user = await _db.Users
                .Where(u => u.Id == userId)
                .Select(u => new
                {
                    User = u,
                    HasInterest = u.Interests!.Any(i => i.Id == interestId)
                })
                .FirstOrDefaultAsync();
            
            if (user == null)
            {
                return NotFound("User not found.");
            }
            if (user.HasInterest)
            {
                return Conflict("User already has this interest.");
            }

            var interest = await _db.Interests.FindAsync(interestId);
            if (interest == null)
            {
                return NotFound("Interest not found.");
            }

            user.User.Interests!.Add(interest);
            await _db.SaveChangesAsync();
            return Ok($"Intrest '{interest.Title}' added to user: {user.User.Name}");
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
