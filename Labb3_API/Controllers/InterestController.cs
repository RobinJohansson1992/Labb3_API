using Labb3_API.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Labb3_API.models.DTOs.InterestDTOs;

namespace Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private readonly UserInterestsDbContext _db;

        public InterestController(UserInterestsDbContext db)
        {
            _db = db;
        }

        [HttpPost("AddNewInterest")]
        public async Task<IActionResult> AddNewInterest(CreateAddInterestRequest addInterestRequest)
        {
            if (addInterestRequest == null)
            {
                return BadRequest("Interest was not registered.");
            }
            var interestToAdd = new Interest
            {
                Title = addInterestRequest.Title,
                Description = addInterestRequest.Description
            };

            _db.Interests.Add(interestToAdd);
            await _db.SaveChangesAsync();
            return Ok(interestToAdd);
        }


        [HttpGet("GetAllInterests")]
        public async Task<IActionResult> GetAllInterests()
        {
            var interests = await _db.Interests
                .Select(i => new
                {
                    i.Id,
                    i.Title,
                    i.Description
                })
                .ToListAsync();

            return Ok(interests);
        }


        [HttpGet("{userId}")]
        [EndpointSummary("Get interests by user id")]
        public async Task<IActionResult> GetInterestsByUserId(int userId)
        {
            var user = await _db.Users
                .Where(u => u.Id == userId)
                .Select(u => new
                {
                    u.Id,
                    Interests = u.Interests!.Select(i => new
                    {
                        i.Id,
                        i.Title,
                        i.Description
                    })
                })
                .FirstOrDefaultAsync();

            if (user == null) return NotFound("User not found.");

            return Ok(user.Interests);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterest(int id)
        {
            var interest = await _db.Interests.FindAsync(id);
            if (interest == null)
            {
                return NotFound("Interest was not found.");
            }

            _db.Interests.Remove(interest);
            await _db.SaveChangesAsync();
            return Ok("Interest deleted.");
        }

    }
}
