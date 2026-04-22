using Labb3_API.models;
using Microsoft.AspNetCore.Http;
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
            if(addInterestRequest == null)
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
        public async Task<IEnumerable<Interest>> GetAllInterests()
        {
            var interests = await _db.Interests.ToListAsync();
            return interests;
        }

    }
}
